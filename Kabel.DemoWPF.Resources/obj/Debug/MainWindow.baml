   M S B A M L   `   `   `  ����  Kabel.DemoWPF.Resources(    "Kabel.DemoWPF.Resources.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��550��6)    � 	Resources 5         
ColorBlack  
ColorWhite  ColorRed  
ColorGreen  	ColorBlue  
BrushBlack �� Color �� Opacity  
BrushWhite  BrushRed  
BrushGreen 	 	BrushBlue 
 BrushGradient �� EndPoint �� 
StartPoint � Color � Offset  
BrushImage �� ImageSource	 j� TileMode
 j� 
AlignmentX j� 
AlignmentY j� Viewport j� ViewportUnits j� Stretch��%j  &	        &	 !     &	 B     &	 c     &	 �     &	 �     7   &	 �     7  &	 �     7  &	 �     7  &		     7  &	
 /    &	 7    ��5   
   	#FF000000��6.   ��5   
   	#FFFFFFFF��6.   ��5   
   	#FFFF0000��6,   ��5	   
   	#FF00FF00��6.   ��5
   
   	#FF0000FF��6-   �� 5   
   8   $ 1Q�6Q   �� 5   
   8   $	 0.5Q�6Q   �� 5   
   8   6+   �� 5   
   8   6-   �� 5   
   8   6,   �� 5   
   $ 0.5,1&�64   $ 0.5,0&�6E   .��5      � # �   6   $ 0Q�6@   � 5      # �  6   $
 0.25Q�6>   � 5      # �  6   $
 0.50Q�6@   � 5      # �  6   $
 0.75Q�6?   � 5      # �  6   $ 1Q�6@   5      �� 5   
   $ Assets/Images/Brick.png��6(   $
	 Tile=�5      $

 Left=�6%   $	 Top=�67   $ 0,0,128,128�5      $ Absolute=�6,   $
 None=�5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5!   
   �� -   5         ��Name$ 
ListStyles��5!      $��0��6&    �� DisplayMemberPath$	 Key��66    �� SelectedValuePath$ Value��6N   ��5"      �� *	Brushes+�� 5#   
   $��1��6   ��6$   �� *SelectedItem.Value+ �� ElementName$ 
ListStyles��5$      5%      