﻿using System;
using System.Collections.Generic;
using System.Linq;
using ImageCircle.Forms.Plugin.iOS;
using Foundation;
using LicenseManager.XamForms.UI;
using UIKit;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using LicenseManager.Core.Services;

namespace LicenseManager.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
//			#if ENABLE_TEST_CLOUD
//			Xamarin.Calabash.Start();
//			#endif
			ImageCircleRenderer.Init();

			LoadApplication (new LicenseManager.XamForms.UI.App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

