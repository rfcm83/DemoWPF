   M S B A M L   `   `   `  ����  Kabel.DemoWPF.Storyboards*    $Kabel.DemoWPF.Storyboards.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5       	  SbFun g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value��%i  &	        �� 5   
   $ Forever��6#   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $
 Rect��6�   .\�5        $ 0��6'   $ 0Q�63     5	      $ 0:0:0.25��6'   $ 45Q�6:     5
      $ 0:0:0.5��6'   $ 90Q�69     5      $ 0:0:0.75��6'   $	 135Q�6:     5      $ 0:0:1��6'   $	 180Q�67     5      $ 0:0:1.25��6'   $	 225Q�6:     5      $ 0:0:1.5��6'   $	 270Q�69     5      $ 0:0:1.75��6'   $	 315Q�6:     5      $ 0:0:2��6'   $	 360Q�67   5      �� 5      $* $(Shape.Fill).(SolidColorBrush.Color)�6+   $
 Rect��6l   .g�5        $ 0:0:0.25��6&   $ 	#FF6E2B9C��69     5      $ 0:0:0.5��6&   $ 	#FF002EFF��68     5      $ 0:0:0.75��6&   $ 	#FF2BB6A9��69     5      $ 0:0:1��6&   $ 	#FF23AA05��66     5      $ 0:0:1.25��6&   $ 	#FFDE7E1E��69     5      $ 0:0:1.5��6&   $ 	#FFD30E0E��68     5      $ 0:0:1.75��6&   $ 	#FFC72BC7��69     5      $ 0:0:2��6&   $ White��66   5      5      5      	 � Triggers	 5      :� 5    
   
 :� RoutedEvent$
 FrameworkElement.Loaded��6   .[�5!      �� #��[  6   5"      .��5$      � .+�5%   
   A� 
�������$	��200��6"   $	��200��6.   �� 5&   
   -   5         ��Name$
 Rect��5&      
�������$��141.4214��6/   $��141.4214��6@    J� RenderTransformOrigin$ 0.5,0.5&�6R   z�5'      V� 5(      .~�5)      �� �� 5*      �� 5+      T� 5,      5-      5/      50      51      