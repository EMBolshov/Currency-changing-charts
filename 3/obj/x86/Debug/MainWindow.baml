   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    3   _3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��700��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� -   5         ��Name$ vallist��5      $	��150��6#   $��0��6/   � 5   
   $��1��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      	� -   5        $	��pie��5      $	��Pie��6)   $��10q�67   6C   	� 5      -   5        $
��area��5      $
��Area��6*   $��10q�69   6E   	� 5      -   5        $	��bar��5      $	��Bar��6)   $��10q�67   6C   	� 5      -   5        $
��line��5      $
��Line��6*   $��10q�69   6E   	� 5      -   5        $��column��5      $��Column��6,   $��10q�6=   6I   5      �� 5      $��1��6   $ 
Horizontal=�6&   .+�5      &   System.Windows.Controls.Calendar  -   5        $��dates��5         SelectionMode$ MultipleRange=�6(   �� 5      -   5        $��getdata��5   ?   $#��Показать данные��6   $��50��63   $	��175��6N   $��50,0,0,0q�6Z   6l   5      >   8System.Windows.Controls.DataVisualization.Charting.Chart  5      -	   5        $��Charts��5   +   $��2��6   6+   5      5      5       