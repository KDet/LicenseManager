   M S B A M L   `   `   `  ����N  JLicenseManager.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:LicenseManager.Core;assembly=LicenseManager.CoreLicenseManager.Core  5      T PLicenseManager.WinDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:LicenseManager.WinDesktop.PagesLicenseManager.WinDesktop.Pages 5      6   0LicenseManager.WinDesktop.Pages.CustomerEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Ocore>clr-namespace:LicenseManager.Core;assembly=LicenseManager.Core     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:LicenseManager.WinDesktop.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  CustomerEditPage��5       � DataContext 5	      �� *   $LicenseManager.Core.ViewModelLocator   Locator �� Source# Z  �� Path$ CustomerEdit�.��5      �  � 	Resources 5   
      placeHolder �� BasedOn �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name K� ZIndex �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding%  System.Windows.Markup.Reference �� Value��%y  &	        7���� 5      8   " ��5      .�5      ��  � ��	 5      �� 5      "
 ��6*   .R�5      � .+�5   "   �� $ 
textSource��6*   $ 2��5   *   
������ ��5   *   �� $
 Text� �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=��� 5   "   $ 1��6*   #��z��5   *   #��z 5    *   .��6G   ��5!   &   �� 5"   *   " ��60   .�5#   .   ��  � ��
	 ���� 6K    5$   .   �� 5%   2    6>   �� $
 Text�   *
textSource+  6}   .a�5&   6   ��  � ��
	 �����6S   5'   3   5)   +   .��5*   5   5+   #   5,      5-      5/      50      52       � RowDefinitions 53   
   �� 54      �� 55      $
��Auto �6   .+�57   
   �� $
��Auto=�6   $
��Auto=�6<   .��58      � $��5q�6    59      �� 5:      $
��Auto �6$   �� 5;      $
��Auto �6$   �� 5<      $
��Auto �6$   �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   �� 5?      $
��Auto �6$   �� 5@      $
��Auto �6$   �� 5A      $
��Auto �6$   �� 5B      $
��Auto �6$   �� 5C      $
��Auto �6$   �� 5D      $
��Auto �6$   �� 5E      $
��Auto �6$   �� 5F       � ColumnDefinitions 5H      �� 5I      $
��Auto �6'   �� 5J      �� 5K      $
��Auto �6'   .+�5M      ��  �� Orientation$ Vertical=�6   .+�5N      �� $	��120��6   $	��120��5O      $��3q�5P      $��UniformToFill=�5R      ��5Q      �� *
PhotoUri+ J� Clip 5S      @� 5T       @� Center$ 60,60&�6.    @� RadiusX$ 60Q�5U   .    @� RadiusY$ 60Q�5V   .   5X      �� 5Y      $
��Edit��6   5Z      �� 5[      $��1��6   $��2��5\      $ Vertical=�5]      .+�5^      �� #��[  6   $
 Name��5_      ��5`      �� *Name+�� 5a      #��[  6   $ LastName��5b      ��5c      �� *
LastName+�� 5d      #��[  6   $ Company��5e      ��5f      �� *	Company+�� 5g      #��[  6   $ Position��5h      ��5i      �� *
Position+5j      �� 5k      $��1��6   $��0��5l      $��Right=�5m      $��Phone��5n      �� 5o      $��1��6   $��1��5p      $��2��5q      #��[  5r      $ Phone��5s      ��5t      �� *PhoneNumber+�� 5v      $��2��6   $��0��5w      $��Right=�5x      $��E-Mail��5y      �� 5z      $��2��6   $��1��5{      $��2��5|      #��[  5}      $ example@mail.com��5~      ��5      �� *EMail+�� 5�      $��3��6   $��0��5�      $��Right=�5�      $��Skype��5�      �� 5�      $��3��6   $��1��5�      $��2��5�      #��[  5�      $ 
your.skype��5�      ��5�      �� *Skype+ � 5�      $��4��6   $��3��5�      $��1��5�      $��0q�5�      ���	#7F0000005�      �� 5�      $��5��6   $��Right=�5�      $��	Is Client��5�      �� 5�      $��5��6   $��1��5�      $	��0,6q�5�      $
��Left=�5�      $��Center=�5�       d� 	IsChecked 5�      �� *
IsClient+$ TwoWay=��� 5�      $��6��6   $��Right=�5�      $	��Key��5�      �� 5�      $��6��6   $��1��5�      $��2��5�      $	 key��5�      ��5�      �� *Key+5�      � 5�      $��7��6   $��1��5�      $��2��5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��New Key��6-   �� 5�      $��1��6   $��
Delete Key��6-   5�       � 5�      $��8��6   $��3��5�      $��1��5�      $��0q�5�      ���	#7F0000005�      �� 5�      $��9��6   $��0��5�      $��Right=�5�      $��Address��5�      �� 5�      $��9��6   $��1��5�      $��3q�5�      .+�5�      �� $��0q�6   $	��3,0q�5�      #��[  5�      $ Street��5�      ��5�      �� *StreetAddress+�� 5�      $ 
Horizontal=�6!   .+�5�      �� $��0q�6"   $	��3,0q�5�   "   #��[  5�   "   $
 City��5�   "   ��5�   "   �� *City+�� 5�      $��0q�6"   $	��3,0q�5�   "   #��[  5�   "   $ State��5�   "   ��5�   "   �� *State+5�      �� 5�      $��0q�6   $	��3,0q�5�      #��[  5�      $ Zip Code��5�      ��5�      �� *	ZipCode+�� 5�      $��0q�6   $	��3,0q�5�      #��[  5�      $ Country��5�      ��5�      �� *	Country+5�      �� 5�      $��9��6   $��2��5�      $��0q�5�      $	��Top=�5�      $��On map��5�       � 5�      $��10��6   $��1��5�      $��2��5�      $	��100��5�      $��0q�5�      $��Center=�5�      $��Center=�5�      
��� ���$��BING MAP��5�       � 5�      $��11��6   $��3��5�      $��1��5�      $��0q�5�      ���	#7F0000005�      �� 5�      $��12��6   $��0��5�      $��Right=�5�      $
��Note��5�      �� 5�      $��12��6   $��1��5�      $��2��5�      $��40��5�      $��0,0,0,20q�5�       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5�      ��5�      �� *	AboutUs+5�      5�      5�      �� 5�   
   $��1��6   $
��Done��5�      ��5�      �� *UpdateCustomerCommand+5�      5�      5�      