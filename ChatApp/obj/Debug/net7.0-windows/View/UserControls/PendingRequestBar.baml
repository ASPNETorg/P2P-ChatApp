   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatApp.View.UserControlsChatApp.View.UserControls  5      1    +ChatApp.View.UserControls.PendingRequestBar   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ChatApp.View.UserControls     5        � 	Resources  5	         HoverButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName��%8  &	        �� 5
   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 14(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � �� �#E1E5E56S   5      5      5       5!      5"      .��5$      �   AccentBrush3#��[ 6[   y�6   ��  �� Path$ HasNewRequest�  	BoolToVis �� 	Converter# [  � ColumnDefinitions 5%   
   �� 5&      $��40 �6   �� 5'      $��* �6   �� 5(      $	��100 �6   �� 5)      $	��100 �6   .+�5,   
   �� $��
5, 1, 1, 1q�6   $��0��6$   $��Center=�64   $��Center=�6Q   $��25��6l   $��25��6w   $2��,pack://application:,,,/Images/add-friend.png��6�   �� 5.   
   $��2��6     AcceptBrush#��[ 6!   $ 10��6K   $��40��6]   $��90��6i   ._�5/      �� #��[  6   $��Accept��6h   $��Center=�50      $��Center=�62   $��90��51      $��40��6    ��5/   :   �� $ AcceptRequestCommand�52      53      �� 55   
   $��3��6     DeclineBrush#��[ 6!   $ 10��6L   $��40��6^   $��90��6j   ._�56      �� #��[  6   $��Decline��6i   $��Center=�57      $��Center=�62   $��90��58      $��40��6    ��56   :   �� $ DeclineRequestCommand�59      5:      �� 5<   
   $��1��6   $
��Left=�6$   $
��Wrap=�6?   $��Center=�5>      $��
2, 1, 1, 1q�6/   $��Segoe UI)�6C   $��SemiBold"�6Y   $��14(�6o   ���#333333��5=      �� $ RequestMessage� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5?      5@      5A      