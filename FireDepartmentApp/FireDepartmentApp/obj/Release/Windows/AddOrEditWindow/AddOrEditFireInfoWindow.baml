   M S B A M L   `   `   `  ���� L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:FireDepartmentApp.Windows.AddOrEditWindow)FireDepartmentApp.Windows.AddOrEditWindow  G    AFireDepartmentApp.Windows.AddOrEditWindow.AddOrEditFireInfoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Ilocal7clr-namespace:FireDepartmentApp.Windows.AddOrEditWindow     X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$5  /Информация с места пожара��$	��760��$	��750��$	��760��$	��750�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� $
��auto ��� .+��� $<��6Время поступления информации��$
��Left=�$��5,20,5,5q�$��Center=��� $��Кто передал��$
��Left=�$��5,20,5,5q�$��Center=�$��1���� $(��"Информация с места��$
��Left=�$��5q�$��Center=�$��2���� $+��%Разновидность работ��$
��Left=�$��5q�$��Center=�$��3���� $!��Приданные силы��$
��Left=�$��5q�$��Center=�$��4���� $��Задача��$
��Left=�$��5q�$��Center=�$��5���� $!��Участок работы��$
��Left=�$��5q�$��Center=�$��6���� $��Тип стволов��$
��Left=�$��5q�$��Center=�$��7���� $ ��Кол-во стволов��$
��Left=�$��5q�$��Center=�$��8���� $!��Боевой участок��$
��Left=�$��5q�$��Center=�$��9���� $��Доп. инф-ция��$
��Left=�$��5q�$��Center=�$��10����  �� Orientation$ 
Horizontal=�$��2��$��1��.+��� -    ��Name$ TbInfoPlace��$��1��$��1��$	��450��$
��Left=� !  MaterialDesignOutlinedTextBox#��[  $��5q�$��5q�$	��120��$��Disabled=� �� TextWrapping$
 Wrap=� �� 
IsReadOnly . ���� *	InfoPlace+�� -   	 ��Name$	 
BtnAddInfo��$��1��$��1��$��Right=�$	��Top=�$��5q�$��5q� # MaterialDesignFlatLightBgButton#��[ ��0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 DotsVertical=��� -   $ TbWorkVariety��$��3��$��1��$	��300��$
��Left=�#��[  $��5q�$��5q�$��70��$��Disabled=�$
 Wrap=� . ���� *WorkVariety+�� -    ��Name$ ComboBoxBroadcasts��$��5q�$��5q�$	��250�� " MaterialDesignOutlinedComboBox#��[  �� DisplayMemberPath$ BroadcastName��$��36��$��1��$��1��$
��Left=� �� SelectedItem �� *	Broadcast+%  Xceed.Wpf.Toolkit.CheckComboBox  -     Name$ ComboSubdivisions��$��1��$��4��$��5q�$��2q�+  %Xceed.Wpf.Toolkit.Primitives.Selector   	Delimiter$ ,��$ SubdivisionName��$	��300��$	��300��$��36��$��36��$��14(�$��5q�   SelectedMemberPath$ SubdivisionSelected��$
��Left=� � ToolTip ��  �� ElementName$ ComboSubdivisions�� �� Path$
 Text��� -   $ ComboBoxMissionTypes��$��5q�$��5q�$	��300��#��[ $ MissionTypeName��$��36��$��5��$��1��$
��Left=� �� *MissionType+�� -   $ ComboBoxWorkAreas��$��5q�$��5q�$	��300��#��[ $ WorkAreaName��$��36��$��6��$��1��$
��Left=� �� *
WorkArea+�� -   $ ComboBoxBarrelTypes��$��5q�$��5q�$	��300��#��[ $ BarrelTypeName��$��36��$��7��$��1��$
��Left=� �� *
BarrelType+�� -	   $ TbBarrelCount��$��8��$��1��$��50��$
��Left=�#��[  $��5q�$��5q����� *BarrelCount+�� -
   $ ComboBoxCombatAreas��$��5q�$��5q�$	��300��#��[ $ CombatAreaName��$��36��$��9��$��1��$
��Left=� �� *
CombatArea+�� -   $ 	TbAddInfo��$��10��$��1��$	��300��$
��Left=�#��[  $��5q�$��5q�$��70��$��Disabled=�$
 Wrap=����� *	AddInfo+)  #MaterialDesignThemes.Wpf.TimePicker  $��1��$	��120��$
��Left=� $  MaterialDesignOutlinedTimePicker#��[ $��Center=�$��5q�$��5,20,5,5q�   	Is24Hours .    SelectedTime �� *DateTimeEntry+�� $��11��$��2��$ 
Horizontal=�$��Right=�$��10q�.+��� -   $	 BtnOk��$��Ok��#��[ �� -   $	 	BtnCancel��$��Cancel��#��[ $��10,0,0,0q�