   M S B A M L   `   `   `  ����L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FireDepartmentApp.WindowsFireDepartmentApp.Windows  5   	   0    *FireDepartmentApp.Windows.SettlemetsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:FireDepartmentApp.Windows  5   	   X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  6?     � Title$  Справочник��5	   	   $	��800��6   $
��1100��6)   $	��800��66   $
��1100��6F    � WindowStartupLocation$ CenterScreen=�6V   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��1.3* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $'��!Населенные пункты��6   `� 5   
    `� 
Background
 �����$��1��6.   .�5      c� 
�������}�.     MaterialDesignToolBar#��[  5      .@�5      �� -   5         ��Name$ BtnAdd��5       � ToolTip$ Добавить��5       ��5      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	PencilAdd=�5       �� 5!      -   5        $ BtnEdit��5!      $  Редактировать��5#      ��5"        $ Pencil=�5#       �� 5$      -   5        $ BtnDell��5$      $ Удалить��6u   ��6@     $ PencilMinus=�6u   �� 5%      5'      5(      �� 5)   
   -   5         ��Name$ TbSettlementSearch��5)      $��2��6.    ! MaterialDesignOutlinedTextBox#��[ 6h   $��5q�5*      $��5q�6   $	��200��6)   $
��Left=�65   $��16(�6P   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Поиск��6^   $��2q�6�   
���   �5+      &   System.Windows.Controls.DataGrid  5,   
   -   5        
  Name$
 DataGridSettlement��5,      $��3��6/      
IsReadOnly .    AutoGenerateColumns .  $��5q�6j   $��2q�6u   
���   �   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Название��6/     textWrap1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6d      Binding 6A   �� *SettlementName+6d   51      �� 52   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   $��3��6c   .+�54      �� -   5        $ 	BtnCancel��54      $��Закрыть��6(    # MaterialDesignFlatLightBgButton#��[ 6R   $��10,0,0,0q�6�   55      �� 59   
   $��Районы выезда��6   $��2��6)   `� 5:   
   
 �����$��1��6.   $��2��6;   .�5;      c� 
�������}�.  #��[  5=      .@�5>      �� -   5        $ 
BtnAddArea��5>      $ Добавить��5@      ��5?        $ 	PencilAdd=�5@      �� 5A      -   5        $ BtnEditArea��5A      $  Редактировать��5C      ��5B        $ Pencil=�5C       �� 5D      -	   5        $ BtnDellArea��5D      $ Удалить��6}   ��6H     $ PencilMinus=�6}   �� 5E      5G      5H      �� 5I   
   -
   5        $ TbDepAreaSearch��5I      $��2��6+   $��2��6;   #��[ 6r   $��5q�5J      $��5q�6   $	��200��6)   $
��Left=�65   $��16(�6P   $	 
Поиск��6^   $��2q�6�   
���   �5K        5L   
   -   5        $
 DataGridDepArea��5L   0   $��3��6   $��2��6     .  .  $��5q�6w   $��2q�5M      
���   � 5N        5O      $ * 6%   $ Название��6/   # [ 6g    6A   �� *DepartureAreaName+6g   5R      �� 5S   
   $��4��6   $��5q�6!   $9��3Привлекаемые подразделения��6,   $��5��6N   $
��Left=�6b   (  "MaterialDesignThemes.Wpf.ColorZone  5T   
   $��5��6#   $��3��60      CornerRadius$ 5��6D   $
��auto��6U   $
��auto��6c   $��10q�6p     ColorZoneAdditional#��[ 6}   .��5U      �  5V      �� 5W      $
��auto �6$   �� 5X      $
��auto �6$   �� 5Y      $��* �6$   �� 5Z      $
��auto �6$    5\      �� 5]      $��* �6'   �� 5^      $��* �6'   �� 5_      $��* �6'   �� 5`      $��* �6'   �� 5a      $��* �6'   �� 5b      $��* �6'   .+�5d      �� $��5q�6   $��Ранг №1��6'   $
��Left=�67     5e      $��1��6+   $ 0��68   $
��auto��6I   $
��auto��6W   $��10q�6d   #��[ 6q   .��5f      �  5g      �� 5h      $
��auto �6,   �� 5i      $��* �6,   .+�5k      `� 
 �����$��0��6>   .�5l      c� 
�������}�.  #��[  5n      .@�5o   "   �� -   5        $ 	BtnAddDiv��5o   )   $��0q�6<   $��1q�6H   $ Добавить��5q      ��5p        $ 	PencilAdd=�   Size$ 25X�5q      �� 5r   "   -   5        $ 
BtnEditDiv��5r   )   $��0q�6=   $��1q�6I   $  Редактировать��5t      ��5s        $ Pencil=�$ 25X�5t       �� 5u   "   -   5        $ 
BtnDellDiv��5u   )   $��0q�6=   $��1q�6I   $ Удалить��6�   ��6m     $ PencilMinus=�$ 25X�6�   5v      5w      �� 5x      -   5        $��ListViewDiv��5x   #   $��1��66   $	��100��6C   ��5y      �� 5z   "   .R�5{   &   ��  �� Padding$ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5|   #   5~      5      5�      �� 5�      $��5q�6   $��Ранг №1 - БИС��6'   $��1��6<   $
��Left=�6L     5�      $��1��6+   $��1��68   $ 0��6H   $
��auto��6Y   $
��auto��6g   $��10q�6t   #��[ 6�   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      $��* �6,   .+�5�      `� 
 �����$��0��6>   .�5�      c� 
�������}�.  #��[  5�      .@�5�   "   �� -   5        $ 
BtnAddDiv1��5�   )   $��0q�6=   $��1q�6I   $ Добавить��5�      ��5�        $ 	PencilAdd=�$ 25X�5�      �� 5�   "   -   5        $ BtnEditDiv1��5�   )   $��0q�6>   $��1q�6J   $  Редактировать��5�      ��5�        $ Pencil=�$ 25X�5�       �� 5�   "   -   5        $ BtnDellDiv1��5�   )   $��0q�6>   $��1q�6J   $ Удалить��6�   ��6o     $ PencilMinus=�$ 25X�6�   5�      5�      �� 5�      -   5        $��ListViewDiv1��5�   #   $��1��67   $��1��6D   $	��100��6T   ��5�      �� 5�   "   .R�5�   &   �� $ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5�   #   5�      5�      5�      �� 5�      $��5q�6   $��Ранг №2��6'   $��2��66   $
��Left=�6F     5�      $��1��6+   $��2��68   $ 0��6H   $
��auto��6Y   $
��auto��6g   $��10q�6t   #��[ 6�   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      $��* �6,   .+�5�      `� 
 �����$��0��6>   .�5�      c� 
�������}�.  #��[  5�      .@�5�   "   �� -   5        $ 
BtnAddDiv2��5�   )   $��0q�6=   $��1q�6I   $ Добавить��5�      ��5�        $ 	PencilAdd=�$ 25X�5�      �� 5�   "   -   5        $ BtnEditDiv2��5�   )   $��0q�6>   $��1q�6J   $  Редактировать��5�      ��5�        $ Pencil=�$ 25X�5�       �� 5�   "   -   5        $ BtnDellDiv2��5�   )   $��0q�6>   $��1q�6J   $ Удалить��6�   ��6o     $ PencilMinus=�$ 25X�6�   5�      5�      �� 5�      -   5        $��ListViewDiv2��5�   #   $��1��67   $��1��6D   $	��100��6T   ��5�      �� 5�   "   .R�5�   &   �� $ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5�   #   5�      5�      5�      �� 5�      $��5q�6   $��Ранг №3��6'   $��3��66   $
��Left=�6F     5�      $��1��6+   $��3��68   $ 0��6H   $
��auto��6Y   $
��auto��6g   $��10q�6t   #��[ 6�   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      $��* �6,   .+�5�      `� 
 �����$��0��6>   .�5�      c� 
�������}�.  #��[  5�      .@�5�   "   �� -   5        $ 
BtnAddDiv3��5�   )   $��0q�6=   $��1q�6I   $ Добавить��5�      ��5�        $ 	PencilAdd=�$ 25X�5�      �� 5�   "   -   5        $ BtnEditDiv3��5�   )   $��0q�6>   $��1q�6J   $  Редактировать��5�      ��5�        $ Pencil=�$ 25X�5�       �� 5�   "   -   5        $ BtnDellDiv3��5�   )   $��0q�6>   $��1q�6J   $ Удалить��6�   ��6o     $ PencilMinus=�$ 25X�6�   5�      5�      �� 5�      -   5        $��ListViewDiv3��5�   #   $��1��67   $��1��6D   $	��100��6T   ��5�      �� 5�   "   .R�5�   &   �� $ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5�   #   5�      5�      5�      �� 5�      $��5q�6   $��Ранг №4��6'   $��4��66   $
��Left=�6F     5�      $��1��6+   $��4��68   $ 0��6H   $
��auto��6Y   $
��auto��6g   $��10q�6t   #��[ 6�   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      $��* �6,   .+�5�      `� 
 �����$��0��6>   .�5�      c� 
�������}�.  #��[  5�      .@�5�   "   �� -   5        $ 
BtnAddDiv4��5�   )   $��0q�6=   $��1q�6I   $ Добавить��5�      ��5�        $ 	PencilAdd=�$ 25X�5�      �� 5�   "   -   5        $ BtnEditDiv4��5�   )   $��0q�6>   $��1q�6J   $  Редактировать��5�      ��5�        $ Pencil=�$ 25X�5�       �� 5�   "   -   5        $ BtnDellDiv4��5�   )   $��0q�6>   $��1q�6J   $ Удалить��6�   ��6o     $ PencilMinus=�$ 25X�6�   5�      5�      �� 5�      -   5        $��ListViewDiv4��5�   #   $��1��67   $��1��6D   $	��100��6T   ��5�      �� 5�   "   .R�5�   &   �� $ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5�   #   5�      5�      5�      �� 5�      $��5q�6   $��Ранг №5��6'   $��5��66   $
��Left=�6F     5�      $��1��6+   $��5��68   $ 0��6H   $
��auto��6Y   $
��auto��6g   $��10q�6t   #��[ 6�   .��5�      �  5�      �� 5�      $
��auto �6,   �� 5�      $��* �6,   .+�5     `� 
 �����$��0��6>   .�5     c� 
�������}�.  #��[  5     .@�5  "   �� -    5        $ 
BtnAddDiv5��5  )   $��0q�6=   $��1q�6I   $ Добавить��5     ��5       $ 	PencilAdd=�$ 25X�5     �� 5  "   -!   5        $ BtnEditDiv5��5  )   $��0q�6>   $��1q�6J   $  Редактировать��5
     ��5	       $ Pencil=�$ 25X�5
      �� 5  "   -"   5        $ BtnDellDiv5��5  )   $��0q�6>   $��1q�6J   $ Удалить��6�   ��6o     $ PencilMinus=�$ 25X�6�   5     5     �� 5     -#   5        $��ListViewDiv5��5  #   $��1��67   $��1��6D   $	��100��6T   ��5     �� 5  "   .R�5  &   �� $ 0q�6Q   $��0q�6]   ��60   �� *SubdivisionName+6]   5  #   5     5     5     5     5     5     5     