   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatAppChatApp  5   	       ChatApp.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ChatApp     5   	     � Title$  Log in��5   	   $	��550��6   $	��300��6%    � Icon$, &pack://application:,,,/Images/icon.ico��5	   	   .��5      �    BackgroundBrush#��[  6    � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $��8* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   �� $��
FirstName:��6   $
��Left=�6%   $	��Top=�6@   $��20(�6X   $��	98,32,0,0q�6f   $��2��6y   �� 5   
     RoundedTextBox#��[ 6`   $
��Left=�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��150��6�   $��20(�6�   $��	75,74,0,0q�6�   $��2��6�   ��6   ��  �� Path$ FName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��	LastName:��6   $
��Left=�6$   $	��Top=�6?   $��20(�6W   $��
98,130,0,0q�6e   $��2��6y   $��2��6�   �� 5   
   #��[ 6`   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   $��20(�6�   $��	75,40,0,0q�6�   $��1��6�   $��2��6
  $��2��6  ��6   �� $ LName�$ TwoWay=�$ PropertyChanged=�6  �� 5   
   $��	Username:��6   $
��Left=�6$   $��Center=�6?   $��20(�6Z   $��98,0,0,0q�6h   $��2��6z   $��3��6�   �� 5    
   #��[ 6c   $��4��6�   $
��Left=�6�   $
 Wrap=�6�   $��Center=�6�   $	��150��6�   $��20(�6�   $��2��6�   $��75,0,0,0q�6  ��6   �� $ UserName�$ TwoWay=�$ PropertyChanged=�6  �� 5!   
   $��5��6   $��Port:��6   $
��Left=�6-   $��Center=�6H   $��20(�6c   $��2��6q   $��	124,0,0,0q�6�   �� 5"   
   #��[ 6_   $��6��6�   $
��Left=�6�   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   $��20(�6�   $��2��6�   $��	75,10,0,0q�6	  ��6   �� $
 Port�$ TwoWay=�$ PropertyChanged=�.��6   J� InputBindings 5#      �� 5$      
	 �� Key$	 Enter��6B   
 �� Command
 6   �� $ StartClient�6B   .��5%   %   5&      �� 5'   
   $��6��6m   $��30��6z   $	��150��6�   $��20(�6�   $
��Left=�6�   $	��Top=�6�   $��2��6�   $��	75,60,0,0q�6�   $��2��6�   ��6   �� *IpAddresses+ �� SelectedItem 67   �� $ 
SelectedIp�$ TwoWay=�6�   �� 5(   
   $��7��6     AccentBrush3#��[ 6    �� CornerRadius$ 10��6I   $��40��6[   $	��150��6g   $
��Left=�6s   $��2��6�   $��
75,10,0,10q�6�   ._�5)      �� $��7��6   $	��150��6"   $��40��6.   $��Start client��6:   $��Center=�6Q     HoverButton#��[ 6n   $��Center=�6�   $��20(�6�   ��6�   �� $ StartClient�6�   5*      �� 5+   
   $
��Left=�6    �� TextAlignment$ Center=�6/   $��7��6F     DeclineBrush#��[ 6S   $
��Wrap=�6~   $
��Bold"�6�   $��10,0,0,0q�6�   $��Center=�6  $��1��6&  ��6�   �� $ ErrorMessage�$ OneWay=�$ PropertyChanged=�6&  5,      5-      