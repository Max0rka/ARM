   M S B A M L   `   `   `  ����L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FireDepartmentAppFireDepartmentApp  5   	   "    FireDepartmentApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:FireDepartmentApp  5   	   -   5          � Title$�  �Автоматизированное рабочее место диспетчера пожаро-спасательного гарнизона Республики Татарстан��5	   	   $	��800��6q   $	��800��6~    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�5
   	   $	��800��6!   $
��1300��61   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   `�  `� 
Background
 �����.�5      c� 
�������}�.     MaterialDesignToolBar#��[  5      .@�5      �� -   5         ��Name$ 	BtnNewDoc��5       � ToolTip$0 *Создать новый документ��5      ��5      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ FileDocument=�5      �� 5      -   5        $ 
BtnOpenDoc��5      $% Открыть документ��5      ��5        $ FolderOpenOutline=�5   #   �� 5      -   5        $ 
BtnSaveDoc��5      $) #Сохранить документ��6{   ��6F     $ ContentSave=�6{   �� 5      �� 5      -   5        $ 
BtnWaybill��5      $ Путевой лист��6{   ��6F     $ FileAccount=�6{   �� 5      -   5        $ 	BtnAction��5      $ В дело��6�   ��6D     $ FileDocumentArrowRight=�6�   �� 5      �� 5       -   5        $ BtnDirectoryEdit��5       $7 1Редактировать справочники��6�   ��6R     $ FileEdit=�6�   �� 5!      -   5        $ 
BtnOptions��5!      $- 'Настройки приложения��6s   ��6F     $	 Cog=�6s   �� 5"      �� 5#      -	   5        $ BtnExit��5#      $ 
Выход��6s   ��6@     $ 	ExitToApp=�6s   5%      5&      �� 5'   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5(      �� -
   5        $ BtnListDepart��5(      $! Список выездов��6y   $��10q�6�   ��6H     $ ListBox=�6�   �� 5)      -   5        $ BtnBack��5)      $ 
Назад��6p   $��10q�5*      $y�Visible=�6   ��5)   <     $ 	ArrowBack=�5*      5+       � 5,   
   -   5        	  �Name$	 	MainFrame��5,      $��1��6   
  � NavigationUIVisibility$
 Hidden=�60   6P   5-      5.      