   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatApp.View.UserControlsChatApp.View.UserControls  5      2    ,ChatApp.View.UserControls.SidebarRequestView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ChatApp.View.UserControls     5        � 	Resources  5	         HoverButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName  AccentBrush2  RoundedTextBox ��Name��%4  &	        7  &	 $    7  �� 5
   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 12(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)   8    � ��6S   5      5      5       5!      �� 5"   
   " ��6'   .�5#      ��  � �� 5$      �� 5%      " ��6&   .R�5&      �� #��z��6!   #��z��5'   !   #��z��5(   !   $ 10��5)   !   ._�5*      �� $ PART_ContentHost��6+   $��Center=�6E   $��Center=�6b   5+      5,      5.      �� 5/       � ��8   6,   �� 50       � ��$ 1q�60   �� 51       � ��$ 12(�6)   �� 52       � ��$ Segoe UI)�6+   �� 53       � ��$ 20��6'   �� 54       � ��$	 180��6&   55      56      .��58      �  � RowDefinitions 59   
   �� 5:      $��30 �6   �� 5;      $��20 �6   �� 5<      $��30 �6   �� 5=      $��20 �6   �� 5>      $��40 �6   .+�5A   
   �� $��IP Address:��6   $��Center=�6&   $��Center=�6C   $��0��6^   $��Segoe UI)�6k   $��SemiBold"�6�   $��12(�6�   �� 5B   
   #��[ 6]   $��Center=�6�   $��1��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   ��6   ��  �� Path$ Ip� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5D   
   $��Port:��6   $��Center=�6    $��Center=�6=   $��2��6X   $��Segoe UI)�6e   $��SemiBold"�6{   $��12(�6�   �� 5E   
   #��[ 6_   $��Center=�6�   $��3��6�   $
 Wrap=�6�   $��Center=�6�   ��6   �� $
 Port�$ TwoWay=�$ PropertyChanged=�.��6�    J� InputBindings 5F      �� 5G      
 �� Key$ Enter��6B    �� Command 6   �� $ SendRequest�6B   .��5H   %   5I      �� 5K   
   $��4��6   #��[ 6   $ 10��6I   $��20��6[   $	��180��6g   $��Center=�6s   ._�5L      �� #��[  6   $��Send request��6_   $��Center=�5M      $��Center=�62   $	��180��5N      $��20��6!   ��5L   :   �� $ SendRequest� J� Effect 5O      3  -System.Windows.Media.Effects.DropShadowEffect  5P         Color$ White��6'      Opacity$	 0.8Q�65      
BlurRadius$ 10Q�6C      ShadowDepth$ 2Q�6S   5R      5S      5U      5V      