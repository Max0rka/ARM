   M S B A M L   `   `   `  ����L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FireDepartmentApp.PagesFireDepartmentApp.Pages  5      +    %FireDepartmentApp.Pages.DeparturePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6E   1local%clr-namespace:FireDepartmentApp.Pages  5      -   5          N� Title$!  Список выездов��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $!��Список выездов��6   $��Center=�6*   $
��Bold"�6G   $��20(�6Y   � 5   
   $��1��6   .+�5      �� -   5        $��ComboSettlements��5   #   $	��250��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Населенный пункт��6;    �� DisplayMemberPath$ SettlementName��6m    "  MaterialDesignOutlinedComboBox#��[  5      $��5q�6O   $��5q�6Z   �� 5      -   5         ��Name$ 	ComboSort��5      $	��250��6*   $ Сортировка��67   #��[  6c   $��5q�6�   $��5q�6�   .@�5      �� .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Дата выезда��6$   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ ArrowUp=�62   $	��5,0q�6A   $��Center=�6N   5      5      �� 5      .��5      �� $ 
Horizontal=�6!   .+�5      �� $��Дата выезда��6$     5       $ 	ArrowDown=�62   $	��5,0q�6C   $��Center=�6P   5!      5"      5#      �� 5$      $��с��6   $��Center=�6!   (  "System.Windows.Controls.DatePicker  5%      -   5          Name$ DatePickerStart��5%      $	��150��62    $  MaterialDesignOutlinedDatePicker#��[ 6>   $��5q�6x   $��5q�6�   6�   �� 5&      $
��по��6   $��Center=�6"     5'      -   5        $ DatePickerEnd��5'      $	��150��60   #��[ 6<   $��5q�6v   $��5q�6�   6�   5(      �� 5)   
   -   5        	 ��Name$	 ListViewDepartures��5)       $��2��6     ListViewItemDepart#��[ 6s   $��Stretch=�6�   ��5*      �� 5+      .R�5,      � .+�5-      �� $��5q�6%   .+�5.      �� $
��Left=�6�   ��6(   �� *DateTimeDepart+
 �� StringFormat$Z
 TДата и время получения информации: {0:dd.MM.yyyy HH.mm}��6�   �� 5/      $
��Left=�6`   ��6(   �� *AddressName+$
 Адрес: {0}��6`   �� 50      $
��Left=�6l   ��6(   �� *ListBurnTypes+$(
 "Объекты горения: {0}��6l   51      �� 52       ��Name$ BtnDell��6!   -   5        $��Right=�52   b   $��Center=�6~   $
��20,0q�6�    � ToolTip$ Удалить��6�   ��62   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�6�   53      54      56      57      58      