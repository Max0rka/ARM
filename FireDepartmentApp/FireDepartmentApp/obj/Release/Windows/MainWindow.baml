   M S B A M L   `   `   `  ���� L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FireDepartmentAppFireDepartmentApp  "    FireDepartmentApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  +localclr-namespace:FireDepartmentApp  -     � Title$�  �Автоматизированное рабочее место диспетчера пожаро-спасательного гарнизона Республики Татарстан��$	��800��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�$	��800��$
��1300��.���  � RowDefinitions �� $
��auto ��� .+�`�  `� 
Background
 �����.�c� 
�������}�.     MaterialDesignToolBar#��[  .@��� -    ��Name$ 	BtnNewDoc�� � ToolTip$0 *Создать новый документ����0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ FileDocument=��� -   $ 
BtnOpenDoc��$% Открыть документ����  $ FolderOpenOutline=��� -   $ 
BtnSaveDoc��$) #Сохранить документ����  $ ContentSave=��� �� -   $ 
BtnWaybill��$ Путевой лист����  $ FileAccount=��� -   $ 	BtnAction��$ В дело����  $ FileDocumentArrowRight=��� �� -   $ BtnDirectoryEdit��$7 1Редактировать справочники����  $ FileEdit=��� -   $ 
BtnOptions��$- 'Настройки приложения����  $	 Cog=��� �� -	   $ BtnExit��$ 
Выход����  $ 	ExitToApp=���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -
   $ BtnListDepart��$! Список выездов��$��10q���  $ ListBox=��� -   $ BtnBack��$ 
Назад��$��10q�$y�Visible=���  $ 	ArrowBack=� � -   	  �Name$	 	MainFrame��$��1��
  � NavigationUIVisibility$
 Hidden=�