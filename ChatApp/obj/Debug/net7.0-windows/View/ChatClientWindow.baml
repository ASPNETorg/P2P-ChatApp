   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ChatApp.ViewChatApp.View  5   	   E'clr-namespace:ChatApp.View.UserControlsChatApp.View.UserControls  5   	   #    ChatApp.View.ChatClientWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ChatApp.View     5   	   @userControls'clr-namespace:ChatApp.View.UserControls     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   $	��600��5
   ^   $	��800��6k     � Icon$,  &pack://application:,,,/Images/icon.ico��5   	    � Title 5
   	   ��  �� Path$ WindowTitle� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Closing��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *	OnClose+5      	 � 	Resources	 5         ShakeAnimation
 �� TargetProperty	 W� By g� Duration g� AutoReverse g� RepeatBehavior��%�   &	        �� 5   
   .��5      W� $
 (Window.Left)�6    75      $ 0:0:0.05D�6   $
 True��5      $ 5x��6)   W� 5      $
 (Window.Top)�6    75      $ 0:0:0.05D�6   $
 True��5      $ 5x��6)   5      5      ��5      �� 5   
    �� 
TargetType" �6    �� Triggers 5       �� 5!       �� Binding 6   �� *ShouldShake+ �� Value True6>    N� EnterActions 5"      �� 5#      #��[  6*   5%      5'      .��5*      �   BackgroundBrush#��[ 6    � ColumnDefinitions 5+   
   �� 5,      $	��200 �6   �� 5-      $��* �6    � RowDefinitions 5/   
   �� 50      $��50 �6   �� 51      $��90 �6   �� 52      $��20 �6   �� 53      $	��150 �6   �� 54      $��* �6   �� 55      $��30 �6   .+�58   
   3   -ChatApp.View.UserControls.ActiveConversations  $��0��6+   $��3��6;   $��1��6H   5   /ChatApp.View.UserControls.InactiveConversations  59   
   $��0��6-   $��4��6=   $��1��6J   2   ,ChatApp.View.UserControls.SidebarRequestView  5:   
   $��0��6*   $��0��6:   $��2��6G   ,   &ChatApp.View.UserControls.Conversation  5;   
   $��1��6$   $��5��64   $��0��6E   1	   +ChatApp.View.UserControls.PendingRequestBar	  5<   
   $��1��6)   $��0��69   /
   )ChatApp.View.UserControls.NotificationBar
  5=   
   $��6��6'   $��0��64   $��2��6D   �� 5>   
   $��Center=�6   $��2��61   $
��Wrap=�6>   $��Active conversations:��6R   $
��Bold"�6o   $��Center=�6�   5@      5A      