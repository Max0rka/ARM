   M S B A M L   `   `   `  ���� L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FireDepartmentApp.WindowsFireDepartmentApp.Windows  ,    &FireDepartmentApp.Windows.StreetWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:FireDepartmentApp.Windows     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  
Улицы��$	��600��$	��500��$	��600��$	��500�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+�`�  `� 
Background
 �����.�c� 
�������}�.     MaterialDesignToolBar#��[  .@��� -    ��Name$ BtnAdd�� � ToolTip$ Добавить����0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 	PencilAdd=��� -   $ BtnEdit��$  Редактировать����  $ Pencil=��� -   $ BtnDell��$ Удалить����  $ PencilMinus=��� �� -    ��Name$ TbStreetSearch��$��1�� ! MaterialDesignOutlinedTextBox#��[ $��5q�$��5q�$	��200��$
��Left=�$��16(�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��$��2q�
���   �&   System.Windows.Controls.DataGrid  -   	  Name$	 DataGridStreets��$��2��
   
IsReadOnly
 .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ Название��  textWrap1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    Binding �� *
StreetName+�� $��3�� �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -   $ 	BtnCancel��$��Закрыть�� # MaterialDesignFlatLightBgButton#��[ $��10,0,0,0q�