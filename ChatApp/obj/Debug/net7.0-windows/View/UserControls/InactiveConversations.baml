   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ChatApp.View.UserControlsChatApp.View.UserControls  5      5    /ChatApp.View.UserControls.InactiveConversations   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ChatApp.View.UserControls     5        � 	Resources  5	         RoundedTextBox �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name  AccentBrush2��%  &	        7  �� 5
   
   " ��6'   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      �� #��z��6   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $ PART_ContentHost��6'   $��Center=�6A   $��Center=�6^   5      5      5      �� 5   
    � ��8   6(   �� 5   
    � ��$ 1q�6,   �� 5   
    � ��$ 12(�6%   �� 5   
    � ��$ Segoe UI)�6'   �� 5   
    � ��$ 20��6#   �� 5   
    � ��$	 180��6"   5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��30 �6   �� 5#      $��* �6   .+�5&   
   �� -   5         ��Name$ SearchTermTextBox��5&   �   $��0��6   #��[  6s   $��Center=�6�   	 �� TextWrapping$
	 Wrap=�6�   $��Center=�6�   ��6   �� 
 �� Path$
 SearchQuery� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5'   
    J� IsHitTestVisible$ False��6   $��Search conversations...��6-   $��Center=�6L   $
��Left=�6g   $��20,0,0,0q�6�   
���������5(      �� 5)      " ��6   .�5*      ��  � y�$ 	Collapsed=�63    �� Triggers 5+      ^� 5,       ^� 
Conditions 5-      �� 5.   "    �� Binding 6,   �� *Text+ �� ElementName$ SearchTermTextBox�� �� Value  6d   �� 5/   "    6,   �� *IsKeyboardFocusWithin+$ SearchTermTextBox��	 False6u   .0�51      ��  � y�$ Visible=�6;   52      54      56      �� 59   
   $��1��6   ��6    �� $
 FilteredConversations� �� SelectedItem 6S   �� $
 SelectedConversation�$ TwoWay=�$ PropertyChanged=���5:      �� 5;      " ��6   .�5<      ��  � ��$ 5q�60   �� 5=       � ��$ 2q�6/   �� 5>       � ��
 �����64   �� 5?       � ��$ 1q�68   �� 5@       � ��
 �����63   �� 5A       � �� 5B      �� 5C      " ��6.   .R�5D   "   �� #��z��6)   #��z��5E   )   #��z��5F   )   ._�5G   &   �� 5H   #   5I      5K       5L      P� 5M       P� Property �@��
IsSelected P� Value$
 True��68   . �5N      ��  � ��  AccentBrush4# [ 6;   �� 5O       � ��
 �   �6;   5P      5R      ��5T      �� 5U      .R�5V      �  � ColumnDefinitions 5W      �� 5X   "   $��24 �63   �� 5Y   "   $��* �63   �� 5Z   "   $��60 �63   .+�5]      A� $��10��6&   $��10��61   
�������$��4,0,10,0q�6I   $��0��6[   �� 5^      $
��Bold"�6G   $��1��6Y   ��6(   �� $
 UserName�6Y   �� 5_      $��10(�6S   $��2��6b   $
��Left=�6r   ��6(   �� $
 LastActivityToString�6r   5`      5a      5d      5e      5f      