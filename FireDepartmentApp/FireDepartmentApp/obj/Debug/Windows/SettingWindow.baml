   M S B A M L   `   `   `  ����L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FireDepartmentApp.WindowsFireDepartmentApp.Windows  5   	   -    'FireDepartmentApp.Windows.SettingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FireDepartmentApp.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��400��5	   	   $	��700��6   $	��400��6"   $	��700��62   
�������  � 
ResizeMode$  NoResize=�6T    � WindowStartupLocation$ CenterScreen=�6j    � Title$- 'Настройки приложения��5
      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  .��5      �� -   5         ��Name$ TabControlSetting��5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�64    "  MaterialDesignFilledTabControl#��[  6h    �� TabStripPlacement$
 Left=�6�   .@�5      �� -   5         ��Name$ TabDocExport��5      $)��#Экспорт документов��60   .��5      �� .+�5      �� $��Путевой лист��6$   $��5q�68   $
��Left=�6C   �� 5      
���   �$��2q�68   �� 5      $%��Наименование ПСЧ��6$   $��5q�6<   $
��Left=�6G   �� 5      -   5        $��	TbDepName��5   "   $	��400��63   $��5q�6?   $��5q�6J   $
��Left=�6V   $��Center=�6q    ! MaterialDesignOutlinedTextBox#��[ 6�   5      5      5      5       �� 5!   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��10q�6J   .+�5"      �� -   5        	 ��Name$	 BtnSave��5"      $��Bottom=�6&   $��Сохранить��6A    # MaterialDesignFlatLightBgButton#��[ 6k   �� 5#      -   5        $	 	BtnCancel��5#      $��Bottom=�6(   $��Отменить��6C   $
��10,0q�6V   #��[ 6|   5$      52      53      