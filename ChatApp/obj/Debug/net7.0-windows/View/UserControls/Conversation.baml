   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatApp.View.UserControlsChatApp.View.UserControls  5      ?$clr-namespace:ChatApp.View.UtilitiesChatApp.View.Utilities  5      ,    &ChatApp.View.UserControls.Conversation   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ChatApp.View.UserControls     5      :	utilities$clr-namespace:ChatApp.View.Utilities     5        � 	Resources  5
         HoverButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName  RoundedTextBox ��Name  UserMessageTemplate  AccentBrush1 �� Padding �� Path  OtherUserMessageTemplate  AccentBrush54   .ChatApp.View.Utilities.MessageTemplateSelector  MessageSelector   UserMessageTemplate   OtherUserMessageTemplate��%�  &	        &	 .    &	     7  &	 �    7  &	 ,    7  7  �� 5   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       � ��$ 14(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��5      #��z��5      $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5   +   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   �� $
 border��6)    � �� �#E5E5E56S   5      5      5!      5"      �� 5#   
   " ��6'   .�5$      ��  � �� 5%      �� 5&      " ��6&   .R�5'      �� #��z��6!   #��z��5(      #��z��5)      $ 10��5*      ._�5+      �� $ PART_ContentHost��6+   $
��Left=�6E   $��Center=�6`   5,      5-      5/      �� 50       � �� �#e3b0e06,   �� 51       � ��$ 1q�60   �� 52       � ��$ 20(�6)   �� 53       � ��$ Segoe UI)�6+   �� 54       � ��$ 30��6'   55      �� 57   
   .R�58      �� 8��  $ 10��6@   $��5q�6R   $ 10q�6]   $��Right=�59      $	��400��61   $	��420��6@   ._�5:      �� .+�5;      �� $
��Bold"�6?   $��16(�6Q   ��6    �� $ UserName�6Q   �� 5<      $
��Thin"�6;   $��10(�6M   ��6    �� $
 Date�6M   �� 5=      $
��Wrap=�6>   $��12(�6R   ��6    �� $ Message�6R   5>      5?      5@      �� 5B   
   .R�5C      �� 8��  $ 10��6@   $��5q�6R   $ 10q�6]   $
��Left=�5D      $	��400��60   $	��420��6?   ._�5E      �� .+�5F      �� $
��Bold"�6?   $��16(�6Q   ��6    �� $ UserName�6Q   �� 5G      $
��Thin"�6;   $��10(�6M   ��6    �� $
 Date�6M   �� 5H      $
��Wrap=�6>   $��12(�6R   ��6    �� $ Message�6R   5I      5J      5K        5M   
   8   8  5O   (   5Q      .��5R      �  � RowDefinitions 5S   
   �� 5T      $��* �6   �� 5U      $��50 �6   .+�5X   
   �� $��0��6   $��3��6$   $
��Auto=�68   )   #ChatApp.View.Utilities.ScrollHelper   AutoScrollToEnd 6[   �� *ShouldScrollToEnd+.��5Y      �� #��[ 6A   ��6   �� $ Messages�5Z      5[      � 5]   
   $��2��6   y�6   �� $ CanSendMessage�  	BoolToVis �� 	Converter# [  � ColumnDefinitions 5^      �� 5_      $��* �6#   �� 5`      $	��100 �6#   �� 5a      $	��100 �6#   .+�5d      �� #��[ 6f   $��5q�6�   $��1,1,1,1q�6�   $��40��6�   $��Stretch=�6�   $��1��6�   $��0��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6  ��6   �� $ Message� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6!   J� InputBindings 5e      �� 5f      
 �� Key$ Enter��6M    �� Command 6!   �� $ SendMessageCommand�6M   .��5g   )   5h      �� 5k      $��1��6   $��1��6%     AccentBrush2#��[ 62   $ 10��6]   $��40��6o   $��90��6{   $��Center=�6�   $��5q�6�   ._�5l      �� #��[  6   $
��Send��6j   $��Center=�5m      $��Center=�62   $��90��6M   $��40��6X   $��16(�6d   ��5l   >   �� $ SendMessageCommand�5m   d   5n      �� 5p      $��2��6   $��1��6%   #��[ 62   $ 10��6]   $��40��6o   $��90��6{   $��Center=�6�   $��5q�6�   ._�5q      �� #��[  6   $
��Buzz��6g   $��Center=�5r      $��Center=�62   $��90��6M   $��40��6X   $��16(�6d   ��5q   >   �� $ SendBuzzCommand�5r   d   5s      5t      �� 5u   
   $��0��6`   $��1��6p   #��[ 6}   $ 10��6�   $��40��6�   $��Stretch=�6�   $��5q�6�   y�6   �� $ CanReconnect�# [ ._�5v      �� #��[  6   $��	Reconnect��6d   $��Stretch=�5w      $��Center=�6/   $��40��6J   $��16(�6V   ��5v   :   �� $ ReconnectCommand�5w   V   5x      5z      5}      