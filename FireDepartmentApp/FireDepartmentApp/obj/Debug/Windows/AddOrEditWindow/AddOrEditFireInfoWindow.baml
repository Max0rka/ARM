   M S B A M L   `   `   `  ����L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:FireDepartmentApp.Windows.AddOrEditWindow)FireDepartmentApp.Windows.AddOrEditWindow  5   	   G    AFireDepartmentApp.Windows.AddOrEditWindow.AddOrEditFireInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:FireDepartmentApp.Windows.AddOrEditWindow     5   	   X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  6O   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$5  /Информация с места пожара��5
   	   $	��760��6+   $	��750��68   $	��760��6D   $	��750��6T    � 
ResizeMode$ NoResize=�6c    � WindowStartupLocation$ CenterScreen=�6y   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $<��6Время поступления информации��6   $
��Left=�68   $��5,20,5,5q�6S   $��Center=�6e   �� 5   
   $��Кто передал��6   $
��Left=�6'   $��5,20,5,5q�6B   $��Center=�6T   $��1��6o   �� 5    
   $(��"Информация с места��6   $
��Left=�6.   $��5q�6I   $��Center=�6T   $��2��6o   �� 5!   
   $+��%Разновидность работ��6   $
��Left=�6/   $��5q�6J   $��Center=�6U   $��3��6p   �� 5"   
   $!��Приданные силы��6   $
��Left=�6*   $��5q�6E   $��Center=�6P   $��4��6k   �� 5#   
   $��Задача��6   $
��Left=�6"   $��5q�6=   $��Center=�6H   $��5��6c   �� 5$   
   $!��Участок работы��6   $
��Left=�6*   $��5q�6E   $��Center=�6P   $��6��6k   �� 5%   
   $��Тип стволов��6   $
��Left=�6'   $��5q�6B   $��Center=�6M   $��7��6h   �� 5&   
   $ ��Кол-во стволов��6   $
��Left=�6*   $��5q�6E   $��Center=�6P   $��8��6k   �� 5'   
   $!��Боевой участок��6   $
��Left=�6*   $��5q�6E   $��Center=�6P   $��9��6k   �� 5(   
   $��Доп. инф-ция��6   $
��Left=�6(   $��5q�6C   $��Center=�6N   $��10��6i   �� 5*   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��1��6;   .+�5+      �� -   5         ��Name$ TbInfoPlace��5+      $��1��6+   $��1��68   $	��450��6c   $
��Left=�6o    !  MaterialDesignOutlinedTextBox#��[  6�   $��5q�6�   $��5q�6�   $	��120��6�   $��Disabled=�5,       �� TextWrapping$
 Wrap=�6H    �� 
IsReadOnly . ��5+   H   �� *	InfoPlace+5,   \   �� 5-      -   5        	 ��Name$	 
BtnAddInfo��5-      $��1��6B   $��1��6R   $��Right=�6_   $	��Top=�6{   $��5q�6�   $��5q�6�    # MaterialDesignFlatLightBgButton#��[ 5.      ��5-   �   0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 DotsVertical=�5.      5/      �� 50   
   -   5        $ TbWorkVariety��50      $��3��6)   $��1��66   $	��300��6c   $
��Left=�6o   #��[  6�   $��5q�6�   $��5q�6�   $��70��6�   $��Disabled=�51      $
 Wrap=�6H    . ��50   F   �� *WorkVariety+51   \   �� 53   
   -   5         ��Name$ ComboBoxBroadcasts��53      $��5q�6/   $��5q�6:   $	��250��6F    " MaterialDesignOutlinedComboBox#��[ 6R    �� DisplayMemberPath$ BroadcastName��54   +   $��36��6p   $��1��6   $��1��6�   $
��Left=�6�    �� SelectedItem 6M   �� *	Broadcast+6�   %  Xceed.Wpf.Toolkit.CheckComboBox  55   
   -   5          Name$ ComboSubdivisions��55   ;   $��1��6   $��4��6.   $��5q�6V   $��2q�6a   +  %Xceed.Wpf.Toolkit.Primitives.Selector   	Delimiter$ ,��6u   $ SubdivisionName��6�   $	��300��56   "   $	��300��61   $��36��6=   $��36��6L   $��14(�6X   $��5q�6f      SelectedMemberPath$ SubdivisionSelected��57   "   $
��Left=�6K    � ToolTip 56   r   ��  �� ElementName$ ComboSubdivisions�� �� Path$
 Text�57   K   �� 58   
   -   5        $ ComboBoxMissionTypes��58      $��5q�61   $��5q�6<   $	��300��6H   #��[ 6T   $ MissionTypeName��59   +   $��36��6t   $��5��6�   $��1��6�   $
��Left=�6�    6O   �� *MissionType+6�   �� 5:   
   -   5        $ ComboBoxWorkAreas��5:      $��5q�6.   $��5q�69   $	��300��6E   #��[ 6Q   $ WorkAreaName��5;   +   $��36��6n   $��6��6}   $��1��6�   $
��Left=�6�    6L   �� *
WorkArea+6�   �� 5<   
   -   5        $ ComboBoxBarrelTypes��5<      $��5q�60   $��5q�6;   $	��300��6G   #��[ 6S   $ BarrelTypeName��5=   +   $��36��6r   $��7��6�   $��1��6�   $
��Left=�6�    6N   �� *
BarrelType+6�   �� 5>   
   -	   5        $ TbBarrelCount��5>      $��8��6)   $��1��66   $��50��6c   $
��Left=�6n   #��[  6�   $��5q�6�   $��5q�6�   ��6F   �� *BarrelCount+6�   �� 5?   
   -
   5        $ ComboBoxCombatAreas��5?      $��5q�60   $��5q�6;   $	��300��6G   #��[ 6S   $ CombatAreaName��5@   +   $��36��6r   $��9��6�   $��1��6�   $
��Left=�6�    6N   �� *
CombatArea+6�   �� 5A   
   -   5        $ 	TbAddInfo��5A      $��10��6%   $��1��63   $	��300��6\   $
��Left=�6h   #��[  6�   $��5q�6�   $��5q�6�   $��70��6�   $��Disabled=�5B      $
 Wrap=�6H   ��5A   C   �� *	AddInfo+5B   H   )  #MaterialDesignThemes.Wpf.TimePicker  5C   
   $��1��6$   $	��120��64   $
��Left=�6@    $  MaterialDesignOutlinedTimePicker#��[ 6[   $��Center=�6�   $��5q�6�   $��5,20,5,5q�6�      	Is24Hours .    SelectedTime 5D   $   �� *DateTimeEntry+6K   �� 5F   
   $��11��6   $��2��6#   $ 
Horizontal=�67   $��Right=�6P   $��10q�6l   .+�5G      �� -   5        $	 BtnOk��5G      $��Ok��6$   #��[ 6E   �� 5H      -   5        $	 	BtnCancel��5H      $��Cancel��6(   #��[ 6Q   $��10,0,0,0q�6�   5I      5J      5K      