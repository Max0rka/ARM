   M S B A M L   `   `   `  ���� L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FireDepartmentApp.WindowsFireDepartmentApp.Windows  0    *FireDepartmentApp.Windows.SettlemetsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  3local'clr-namespace:FireDepartmentApp.Windows  X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Справочник��$	��800��$
��1100��$	��800��$
��1100�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $��* ��� $��20 ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��1.3* ��� $
��auto ��� $��* ��� $
��auto �.+��� $'��!Населенные пункты��`�  `� 
Background
 �����$��1��.�c� 
�������}�.     MaterialDesignToolBar#��[  .@��� -    ��Name$ BtnAdd�� � ToolTip$ Добавить����0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	PencilAdd=��� -   $ BtnEdit��$  Редактировать����  $ Pencil=��� -   $ BtnDell��$ Удалить����  $ PencilMinus=��� �� -    ��Name$ TbSettlementSearch��$��2�� ! MaterialDesignOutlinedTextBox#��[ $��5q�$��5q�$	��200��$
��Left=�$��16(�)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Поиск��$��2q�
���   �&   System.Windows.Controls.DataGrid  -   
  Name$
 DataGridSettlement��$��3��   
IsReadOnly .    AutoGenerateColumns .  $��5q�$��2q�
���   �   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ Название��  textWrap1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    Binding �� *SettlementName+�� $��6�� �� Orientation$ 
Horizontal=�$��Right=�$��10q�$��3��.+��� -   $ 	BtnCancel��$��Закрыть�� # MaterialDesignFlatLightBgButton#��[ $��10,0,0,0q��� $��Районы выезда��$��2��`� 
 �����$��1��$��2��.�c� 
�������}�.  #��[  .@��� -   $ 
BtnAddArea��$ Добавить����  $ 	PencilAdd=��� -   $ BtnEditArea��$  Редактировать����  $ Pencil=��� -	   $ BtnDellArea��$ Удалить����  $ PencilMinus=��� �� -
   $ TbDepAreaSearch��$��2��$��2��#��[ $��5q�$��5q�$	��200��$
��Left=�$��16(�$	 
Поиск��$��2q�
���   �  -   $
 DataGridDepArea��$��3��$��2�� .  .  $��5q�$��2q�
���   �   $ * $ Название��# [  �� *DepartureAreaName+�� $��4��$��5q�$9��3Привлекаемые подразделения��$��5��$
��Left=�(  "MaterialDesignThemes.Wpf.ColorZone  $��5��$��3��   CornerRadius$ 5��$
��auto��$
��auto��$��10q�  ColorZoneAdditional#��[ .���  �� $
��auto ��� $
��auto ��� $��* ��� $
��auto � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��5q�$��Ранг №1��$
��Left=�  $��1��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -   $ 	BtnAddDiv��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�   Size$ 25X��� -   $ 
BtnEditDiv��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -   $ 
BtnDellDiv��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -   $��ListViewDiv��$��1��$	��100������ .R���  �� Padding$ 0q�$��0q����� *SubdivisionName+�� $��5q�$��Ранг №1 - БИС��$��1��$
��Left=�  $��1��$��1��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -   $ 
BtnAddDiv1��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�$ 25X��� -   $ BtnEditDiv1��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -   $ BtnDellDiv1��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -   $��ListViewDiv1��$��1��$��1��$	��100������ .R��� $ 0q�$��0q����� *SubdivisionName+�� $��5q�$��Ранг №2��$��2��$
��Left=�  $��1��$��2��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -   $ 
BtnAddDiv2��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�$ 25X��� -   $ BtnEditDiv2��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -   $ BtnDellDiv2��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -   $��ListViewDiv2��$��1��$��1��$	��100������ .R��� $ 0q�$��0q����� *SubdivisionName+�� $��5q�$��Ранг №3��$��3��$
��Left=�  $��1��$��3��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -   $ 
BtnAddDiv3��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�$ 25X��� -   $ BtnEditDiv3��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -   $ BtnDellDiv3��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -   $��ListViewDiv3��$��1��$��1��$	��100������ .R��� $ 0q�$��0q����� *SubdivisionName+�� $��5q�$��Ранг №4��$��4��$
��Left=�  $��1��$��4��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -   $ 
BtnAddDiv4��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�$ 25X��� -   $ BtnEditDiv4��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -   $ BtnDellDiv4��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -   $��ListViewDiv4��$��1��$��1��$	��100������ .R��� $ 0q�$��0q����� *SubdivisionName+�� $��5q�$��Ранг №5��$��5��$
��Left=�  $��1��$��5��$ 0��$
��auto��$
��auto��$��10q�#��[ .���  �� $
��auto ��� $��* �.+�`� 
 �����$��0��.�c� 
�������}�.  #��[  .@��� -    $ 
BtnAddDiv5��$��0q�$��1q�$ Добавить����  $ 	PencilAdd=�$ 25X��� -!   $ BtnEditDiv5��$��0q�$��1q�$  Редактировать����  $ Pencil=�$ 25X��� -"   $ BtnDellDiv5��$��0q�$��1q�$ Удалить����  $ PencilMinus=�$ 25X��� -#   $��ListViewDiv5��$��1��$��1��$	��100������ .R��� $ 0q�$��0q����� *SubdivisionName+