using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using LicenseManager.Core.Services;


using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace LicenseManager.WinDesktop.Services
{
    public enum MessageBoxServiceResult
    {
        None,
        OK,
        Cancel,
        Abort,
        Retry,
        Ignore,
        Yes,
        No
    }

    public class MessageBoxNotificationService : INotificationService
    {
        //Source: http://www.cyberforum.ru/wpf-silverlight/thread1316497.html
        private class CenterWinDialog : IDisposable
        {
            private struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            private int _mTries;
            private readonly Window _mOwner;

            // P/Invoke declarations
            private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

            private void FindDialog()
            {
                // Enumerate windows to find the message box
                if (_mTries < 0) return;
                var callback = new EnumThreadWndProc(CheckWindow);
                if (EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero))
                {
                    if (++_mTries < 10)
                        Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(FindDialog));
                }
            }
            private bool CheckWindow(IntPtr hWnd, IntPtr lp)
            {
                // Checks if <hWnd> is a dialog
                var sb = new StringBuilder(260);
                GetClassName(hWnd, sb, sb.Capacity);
                if (sb.ToString() != "#32770") return true;
                // Got it
                var frmRect = new Rectangle(new System.Drawing.Point((int)_mOwner.Left, (int)_mOwner.Top),
                    new System.Drawing.Size((int)_mOwner.ActualWidth, (int)_mOwner.ActualHeight));
                Rect dlgRect;
                GetWindowRect(hWnd, out dlgRect);
                MoveWindow(hWnd,
                    frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) / 2,
                    frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) / 2,
                    dlgRect.Right - dlgRect.Left,
                    dlgRect.Bottom - dlgRect.Top, true);
                return false;
            }

            public CenterWinDialog(Window owner)
            {
                _mOwner = owner;
                Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(FindDialog));
            }
            public void Dispose()
            {
                _mTries = -1;
            }

            [DllImport("user32.dll")]
            private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
            [DllImport("kernel32.dll")]
            private static extern int GetCurrentThreadId();
            [DllImport("user32.dll")]
            private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
            [DllImport("user32.dll")]
            private static extern bool GetWindowRect(IntPtr hWnd, out Rect rc);
            [DllImport("user32.dll")]
            private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);
        }

        private static MessageBoxServiceResult MessageBoxToDialogResult(MessageBoxResult messageBoxResult)
        {
            return (MessageBoxServiceResult)messageBoxResult;
        }

        public MessageBoxServiceResult Show(string messageText)
        {
            using (new CenterWinDialog(Owner))
            {
                MessageBox.Show(Owner, messageText);
                return MessageBoxServiceResult.OK;
            }
        }
        public MessageBoxServiceResult Show(string messageText, string caption)
        {
            using (new CenterWinDialog(Owner))
                return MessageBoxToDialogResult(MessageBox.Show(Owner, messageText, caption));
        }

        public Window Owner { get; set; }


        public void DisplayAlert(string message)
        {
            using (new CenterWinDialog(Owner))
            {
                MessageBox.Show(Owner, message, "Alert", MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation, MessageBoxResult.OK);
            }
        }
    }
}
