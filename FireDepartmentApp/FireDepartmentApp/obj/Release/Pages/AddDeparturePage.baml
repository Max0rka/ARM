   M S B A M L   `   `   `  ���� L  HFireDepartmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FireDepartmentApp.PagesFireDepartmentApp.Pages  .    (FireDepartmentApp.Pages.AddDeparturePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  1local%clr-namespace:FireDepartmentApp.Pages  X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xceed)http://schemas.xceed.com/wpf/xaml/toolkit  -     N� Title$   �� N� 
Background
 ����� � 	Resources ��%    .���� .���  � RowDefinitions �� $��* ��� $
��auto �.+��� .+�(  "MaterialDesignThemes.Wpf.ColorZone  
����p��$��1q�.���� $5��/Раздел 1. Общая информация��$��Center=�
�������$��15(�  
�������$��1q�.���� $-��'Первичная информация��$
��Bold"�$��Center=�
���   �$��15(�� $��Center=�.+�  -     Name$ ColorZoneDateTime��   	ColorZone#��[  {�.  .���� .+��� $X��RДата и время получения извещения(информации)��(  "System.Windows.Controls.DatePicker  -     Name$ 
DateDepart��$	��140��$��14(�$��5q�/  )MaterialDesignThemes.Wpf.DatePickerAssist$   OutlinedBorderActiveThickness$ 2q�$��5q�&   OutlinedBorderInactiveThickness$ 2q� $  MaterialDesignOutlinedDatePicker#��[ $��36��   SelectedDate �� *DateTimeDepart+	 �� Mode$	 TwoWay=�)  #MaterialDesignThemes.Wpf.TimePicker  -   
  Name$
 
TimeDepart��$	��140��$��14(�/  )MaterialDesignThemes.Wpf.TimePickerAssist$   OutlinedBorderActiveThickness$ 2q�&   OutlinedBorderInactiveThickness$ 2q�   	Is24Hours . $��5q�$��36�� $  MaterialDesignOutlinedTimePicker#��[    SelectedTime �� *DateTimeDepart+$	 TwoWay=�  #��[  .���� $��Center=�.+��� $%��Населенный пункт���� -    ��Name$ ComboBoxSettlement��$��5q�$��5q� " MaterialDesignOutlinedComboBox#��[ $��36�� �� DisplayMemberPath$ SettlementName�� �� SelectedItem �� *
Settlement+�� -   $ ComboBoxDepArea��$��5q�$��5q�#��[ $ DepartureAreaName��{�.  $��36�� �� *DepartureArea+  #��[  .���� $��Center=�.+��� $��
Улица���� -   $ ComboBoxStreet��$��5q�$��5q�#��[ $ 
StreetName��$��36�� �� *Street+  #��[  .���� $��Center=�.+��� $��Дом���� $��14(�$��5q�$��5q� ! MaterialDesignOutlinedTextBox#��[ ���� *
NumHouse+  #��[  .���� $��Center=�.+��� $��Корпус���� $��14(�$��5q�$��5q�#��[ ���� *	NumCorp+  #��[  .���� $��Center=�.+��� $��Квартира���� $��14(�$��5q�$��5q�#��[ ���� *	NumAppart+  #��[  .���� $��Center=�.+��� $��Ориентиры���� $��14(�$��5q�$��5q�$	��100��#��[  �� TextWrapping$
 Wrap=�$��Disabled=����� *
Landmark+  #��[  .���� $��Center=�.+��� $4��.Номер телефона заявителя���� $��14(�$��5q�$��5q�#��[ ���� *ApplicantPhone+  #��[  .���� $��Center=�.+��� $��Что горит��%  Xceed.Wpf.Toolkit.CheckComboBox  -     Name$ ComboBoxBurns��$��1��$��5q�$��2q�+  %Xceed.Wpf.Toolkit.Primitives.Selector   	Delimiter$ ,��$ BurnTypeName��$	��300��$	��180��$��36��$��36��$��14(�$��5q�   SelectedMemberPath$ BurnSelected�� � ToolTip ��  �� ElementName$ ComboBoxBurns�� �� Path$
 Text�  #��[  .���� $��Center=�.+��� $"��Доп. информация���� $��14(�$��5q�$��5q�$	��100��#��[ $
 Wrap=�$��Disabled=����� *AdditionalInfo+  
�������$��1q�.��9� $��0q� 9� 
IsExpanded . ���� $/��)Уточненная информация��$��0q�$
��Bold"�$��Center=�
���   �$��15(�.���� .+�� $��Center=�  �� 
TargetType �� Property �� Value��%�   '��       �� " ��.���  � ��$ Comic Sans MS)���  � ��$ 12(���  � ��$ 3q���  � ��
 �   ���  � ��$
 Wrap=���  � ��$ Center=�.+�    ColorZoneAdditional#��[ .���  �� $��* ��� $
��auto �.+��� .+��� $F��@Что вы видите по внешним признакам?��$��10q�	� -	    	�Name$ RButtonSign1��$
��10,1q� 	� 	GroupName$ Signs��  MaterialDesignRadioButton#��[ .���� $.��(Слабое выделение дыма��	� -
   $ RButtonSign2��$
��10,1q�$ Signs��#��[ .���� $0��*Сильное выделение дыма��	� -   $ RButtonSign3��$
��10,1q�$ Signs��#��[ .���� $8��2Вырывающиеся языки пламени���� $��1��.+��� $"��Доп. информация���� -    ��Name$ TbAdditionalInfoSign��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *ExternalSignAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $A��;Угроза людям, просят ли о помощи?��$��10q��� -     ��Name$  ThreatPeople��  MaterialDesignCheckBox#��[ $
��10,1q�.���� $,��&Имеется угроза людям���� $��14(�$��5q�$��5q����� *ThreatPeopleCount+.������ " ��! �� BasedOn#! [ .���  � {� .  " �� Triggers" �� # �� Binding# �� $ ThreatPeople��$ 	IsChecked�$ �� Value$ True.a���  � {� . .���� $��1��.+��� $"��Доп. информация���� -   $" TbAdditionalInfoThreatPeople��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *ThreatPeopleAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $3��-Имеются ли пострадавшие?��$��10q�	� -   $ YesAffected��$
��10,1q�$ 
IsAffected��#��[ .���� $#��Да, в количестве���� $��14(�$��5q�$��5q����� *AffectedCount+.������ " ��#! [ .���  � {� .  " �� # �� $ YesAffected��$ 	IsChecked�$ True.a���  � {� . .��	� -   $ 
NoAffected��$
��10,1q�$ 
IsAffected��#��[ .���� $%��Пострадавших нет��	� -   $ UnknownAffected��$
��10,1q�$ 
IsAffected��#��[ .���� $��Не знаю���� $��1��.+��� $"��Доп. информация���� -   $ TbAdditionalInfoAffect��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *AffectedAddInfo+  .���  �� $��* ��� $
��auto �.+��� .+��� $��Что с ними?��$��10q��� -   $  StatePeople1��#��[ $
��10,1q�.���� $��Без сознания���� -   $  StatePeople2��#��[ $
��10,1q�.���� $!��Получили ожоги���� -   $  StatePeople3��#��[ $
��10,1q�.���� $��Не знаю���� $��1��.+��� $"��Доп. информация���� -   $ AdditionalInfoStatePeople��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *StatePeopleAddInfo+ ��%�   '        7  �� "  8!   .���  � y�$ 	Collapsed=�" �� # �� $ YesAffected��$ 	IsChecked�$ True.a���  � y�$ Visible=�  .���  �� $��* ��� $
��auto �.+��� .+��� $ ��Где находятся?��$��10q��� -   $  CheckBoxLocation1��#��[ $
��10,1q�.���� $;��5Самостоятельно эвакуируются���� -   $  CheckBoxLocation2��#��[ $
��10,1q�.���� $(��"В зоне воздействия���� $��1��.+��� $"��Доп. информация���� -   $ TbAdditionalInfoLocation��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *PeopleLocationAddInfo+ ��%�   '        7  �� "  8!   .���  � y�$ 	Collapsed=�" �� # �� $ YesAffected��$ 	IsChecked�$ True.a���  � y�$ Visible=�  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $F��@Имеется ли угроза распространения?��$��10q�	� -   $��ThreatFire1��$
��10,1q�$ Threat��#��[ .���� $��Имеется��	� -   $��ThreatFire2��$
��10,1q�$ Threat��#��[ .���� $$��Имеется на этажи��	� -   $��ThreatFire3��$
��10,1q�$ Threat��#��[ .���� $9��3Имеется на соседние объекты��	� -   $��ThreatFire4��$
��10,1q�$ Threat��#��[ .���� $��Не знаю���� $��1��.+��� $"��Доп. информация���� -   $ TbAdditionalInfoThreat��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *ThreatFireAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $K��EКакие значимые объекты имеются рядом?��$��10q��� -   $  CheckBoxObject1��#��[ $
��10,1q�.���� $+��%Социально - значимые���� -    $  CheckBoxObject2��#��[ $
��10,1q�.���� $0��*С массовым пребыванием���� -!   $  CheckBoxObject3��#��[ $
��10,1q�.���� $&�� Производственные���� -"   $  CheckBoxObject4��#��[ $
��10,1q�.���� $N��HСоциально - значимых объектов рядом нет���� -#   $  CheckBoxObject5��#��[ $
��10,1q�.���� $(��"Рядом объектов нет���� $��1��.+��� $"��Доп. информация���� -$   $ TbAdditionalInfoObject��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *NearbyObjectAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $8��2Местонахождение заявителя?��$��10q�	� -%   $ RButtonPlace1��$
��10,1q�$ Place��#��[ .���� $��На объекте��	� -&   $ RButtonPlace2��$
��10,1q�$ Place��#��[ .���� $$��Рядом с объектом��	� -'   $ RButtonPlace3��$
��10,1q�$ Place��#��[ .���� $��Внутри здания���� $��1��.+��� $"��Доп. информация���� -(   $ TbAdditionalInfoPlace��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *PlaceAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $8��2Есть ли перекрытые проезды?��$��10q�	� -)   $ RButtonBarrier1��$
��10,1q�$ Barrier��#��[ .���� $��Есть��	� -*   $ RButtonBarrier2��$
��10,1q�$ Barrier��#��[ .���� $'��!Припаркованные ТС��	� -+   $ RButtonBarrier3��$
��10,1q�$ Barrier��#��[ .���� $��Котлованы��	� -,   $ RButtonBarrier4��$
��10,1q�$ Barrier��#��[ .���� $��Шлагбаум��	� --   $ RButtonBarrier5��$
��10,1q�$ Barrier��#��[ .���� $7��1Искусственные заграждения���� $��1��.+��� $"��Доп. информация���� -.   $ TbAdditionalInfoBarrier��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *BarrierAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $X��RВозможность встречи пожарных подразделений?��$��10q�	� -/   $ RButtonMCS1��$
��10,1q�$
 Meet��#��[ .���� $��Имеется��	� -0   $ RButtonMCS2��$
��10,1q�$
 Meet��#��[ .���� $��Нет���� $��1��.+��� $"��Доп. информация���� -1   $ TbAdditionalInfoMeet��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *MeetMCSAddInfo+  #��[ .���  �� $��* ��� $
��auto �.+��� .+��� $A��;Ваше отношение к объекту пожара?��$��10q�	� -2   $ RButtonWhy1��$
��10,1q�$	 Why��#��[ .���� $��Собственник��	� -3   $ RButtonWhy2��$
��10,1q�$	 Why��#��[ .���� $��
Сосед��	� -4   $ RButtonWhy3��$
��10,1q�$	 Why��#��[ .���� $��Арендатор��	� -5   $ RButtonWhy4��$
��10,1q�$	 Why��#��[ .���� $��Очевидец���� $��1��.+��� $"��Доп. информация���� -6   $ TbAdditionalInfoWhy��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *WhyApplicantAddInfo+  #��[ .���  �� $
��auto �.+��� $��1��.+��� $8��2Ваша фамилия, имя, отчество?��$��10q��� -7   $ TbAdditionalInfoFIO��$��14(�$��5q�$��5q�$��70��#��[ $
 Wrap=�$��Disabled=����� *FIOApplicant+  
�������$��1q�.���� $����Спасибо за переданную информацию, ваша информация будет использована в ходе организации и проведения аварийно - спасательных работ��$
��Bold"�$��Center=�
���   �$��14(�  
����p��$��1q�.���� $H��BРаздел 2. Учет прибытия сил и средств��$��Center=�
�������$��15(�  
����p��$��1q�$��0,3,0,0q�.���� $r��lПодраздел 2.1. Учет прибытия сил и средств дежурных караулов��$��Center=�
�������$��15(�� $��Center=�$��5q�.+�  -8   $ ColorZoneRank��$y�	Collapsed=�
���   �$��1q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №1��$��Center=��� -9   % ��Name$% ListViewRank��$��1��$��Disabled=�  MaterialDesignListView#��[  	 ListViewItem#��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-:   $��
Выезд��#��[ & d� 	IsChecked& �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-;   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-<   $��40��$��5q�$��5q�' �� 	MaxLength$' 1��$
��Left=�.  (MaterialDesignThemes.Wpf.TextFieldAssist!(   CharacterCounterVisibility$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  -=   $ ColorZoneRank1��$y�	Collapsed=�
���   �$��1q�$��5,0,0,0q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №1 - БИС��$��Center=��� ->   $% ListViewRank1��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-?   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-@   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-A   $��40��$��5q�$��5q�$' 1��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  -B   $ ColorZoneRank2��$y�	Collapsed=�
���   �$��1q�$��5,0,0,0q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №2��$��Center=��� -C   $% ListViewRank2��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-D   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-E   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-F   $��40��$��5q�$��5q�$' 1��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  -G   $ ColorZoneRank3��$y�	Collapsed=�
���   �$��1q�$��5,0,0,0q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №3��$��Center=��� -H   $% ListViewRank3��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-I   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-J   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-K   $��40��$��5q�$��5q�$' 1��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  -L   $ ColorZoneRank4��$y�	Collapsed=�
���   �$��1q�$��5,0,0,0q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №4��$��Center=��� -M   $% ListViewRank4��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-N   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-O   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-P   $��40��$��5q�$��5q�$' 1��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  -Q   $ ColorZoneRank5��$y�	Collapsed=�
���   �$��1q�$��5,0,0,0q�.���  �� $
��auto ��� $��* �.+��� $��Ранг №5��$��Center=��� -R   $% ListViewRank5��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *SubdivisionName+�� $  CheckBoxDepart��-S   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrival��-T   $��Прибыл��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepart��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . �� $ TbPeopleCount��-U   $��40��$��5q�$��5q�$' 1��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrival��$ 	IsChecked�$ True.a���  � {� . .��  
����p��$��1q�$��0,3,0,0q�.���� $����Подраздел 2.2. Учет прибытия сил и средств местного звена ТП РСЧС, иные службы��$��Center=�
�������$��15(�� $��Center=�$��5q�.+�  -V   $ ColorZoneServiceType��$y�	Collapsed=�
���   �$��1q�.���  �� $
��auto ��� $��* �.+��� $��Иные службы��$
��Bold"�$��Center=��� -W   $% ListViewServiceTypes��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *ServiceTypeName+�� $  CheckBoxDepartService��-X   $��
Выезд��#��[ & �� *DepartureChecked+   .  �� *TimeDeparture+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxDepartService��$ 	IsChecked�$ True.a���  � {� . �� $  CheckBoxArrivalService��-Y   $��Прибытие��& �� *ArrivalChecked+ ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxDepartService��$ 	IsChecked�$ True.a���  � {� .    .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrivalService��$ 	IsChecked�$ True.a���  � {� . �� $��Личный состав��$
��Left=��� $ TbPeopleCount��-Z   $��40��$��5q�$��5q�$' 2��$
��Left=�$( 	Collapsed=����� *PeopleCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrivalService��$ 	IsChecked�$ True.a���  � {� . .���� $��Техника��$
��Left=��� $ TbTechnicCount��-[   $��40��$��5q�$��5q�$' 2��$
��Left=�$( 	Collapsed=����� *TechnicCount+.�� ��%�   '��       7  �� " ��8!   .���  � {� .  " �� # �� $ CheckBoxArrivalService��$ 	IsChecked�$ True.a���  � {� . .��  
����p��$��1q�$��0,3,0,0q�.���� $U��OПодраздел 2.3. Учет прибытия должностных лиц��$��Center=�
�������$��15(�� $��Center=�$��5q�.+�  -\   $ ColorZonePositionType��$y�	Collapsed=�
���   �$��1q�.���  �� $
��auto ��� $��* �.+��� -]   $% ListViewPositionTypes��$��1��$��Disabled=�#��[ #��[	 $��10q����� .R�� $��Center=����� .R�� .+��� .+��� $��Center=����� *PositionTypeName+�� $  CheckBoxArrivalPosition��-^   $��Прибыл��& �� *ArrivalChecked+   .  �� *TimeArrival+$	 TwoWay=� ��%�   '        �� "  .���  � {� .  " �� # �� $ CheckBoxArrivalPosition��$ 	IsChecked�$ True.a���  � {� .   
����p��$��1q�$��0,3,0,0q�.���� ${��uПодраздел 2.4. Количество задействованных сил и общая информация��$��Center=�
�������$��15(�  -_   $ ColorZoneGeneralInfo��
���   �$y�	Collapsed=�$��2q�$��5q�$��3q�.��� ) � ColumnDefinitions) �� $
��1.6* ��� $��* �.+��� .+��� $<��6Итого привлечено техники (ед.)��$
��Left=�$
��Bold"��� -`   $% ListViewDepTechnics��$��Disabled=�#��[  
 ListViewItemTechnic#��[
 $��10q����� .R�� $
��Left=����� .R�� .+��� * �� Orientation$* 
Horizontal=�.+��� $��Center=�$��Center=����� *TechnicName+�� $ TbTechnicCount��-a   $��40��$��5q�$	��5,0q�$' 3��$
��Left=�+ �� 
IsReadOnly+ . $( 	Collapsed=�#��[ ���� *TechnicCountGeneral+$	 TwoWay=�.���� $* 
Horizontal=�.+��� $)��#Подано стволов (ед.)��$
��Bold"��� -b   $ TbCountSteam��$��60��$��5q�$	��5,0q�$' 6��$
��Left=�+ . $( 	Collapsed=�#��[ ���� *BarrelCount+$	 TwoWay=�.���� $'��!Площадь пожара (м2)��$
��Bold"��� -c   $ TbSquareFire��$	��100��$��5q�$	��5,0q�$' 10��$
��Left=�+ . $( 	Collapsed=�#��[ ���� *FireAreaCount+$	 TwoWay=�.���� $��1��.+��� $* 
Horizontal=�$
��Left=�.+��� -d   $��CheckBoxFireEnd��$)��#Локализация пожара��$	��260��& �� *IsFireContainment+  -e   $��DatePickerFireEnd��$	��100�� �� *DateTimeFireContainment+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$	 5,0q���  � ��$ 5q�" �� # �� $ CheckBoxFireEnd��$ 	IsChecked�$ True.a���  � {� .   -f   $
 TimePickerFireEnd��$��80�� .  �� *DateTimeFireContainment+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$ 5q�" �� # �� $ CheckBoxFireEnd��$ 	IsChecked�$ True.a���  � {� . �� $* 
Horizontal=�$
��Left=�$	��0,5q�.+��� -g   $��CheckBoxOpenFire��$>��8Локализация открытого горения��$	��260��& �� *IsOpenBurning+  -h   $ DatePickerOpenFire��$	��100�� �� *DateTimeOpenBurn+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$	 5,0q���  � ��$ 5q�" �� # �� $ CheckBoxOpenFire��$ 	IsChecked�$ True.a���  � {� .   -i   $
 TimePickerOpenFire��$��80�� .  �� *DateTimeOpenBurn+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$ 5q�" �� # �� $ CheckBoxOpenFire��$ 	IsChecked�$ True.a���  � {� . �� $* 
Horizontal=�$
��Left=�.+��� -j   $��CheckBoxAftermathFire��$>��8Ликвидация последствия пожара��$	��260��& �� *IsAftermathFire+  -k   $ DatePickerAftermathFire��$	��100�� �� *DateTimeAftermath+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$	 5,0q���  � ��$ 5q�" �� # �� $ CheckBoxAftermathFire��$ 	IsChecked�$ True.a���  � {� .   -l   $
 TimePickerAftermathFire��$��80�� .  �� *DateTimeAftermath+$	 TwoWay=� ��%�   '        7  �� "  8!   .���  � {� .  ��  � ��$ 5q�" �� # �� $ CheckBoxAftermathFire��$ 	IsChecked�$ True.a���  � {� . �� $* 
Horizontal=�$	��0,5q�.+��� $)��#Всего привлекалось���� -m   $ TbGeneralCountPeople��$��60��$�� ��$��5q�$	��5,0q�$' 6��$
��Left=�+ . $( 	Collapsed=�#��[ .���� $��человек���� -n   $ TbGeneralCountTechnic��$��60��$�� ��$��5q�$	��5,0q�$' 10��$
��Left=�+ . $( 	Collapsed=�#��[ .���� $��ед. техники���� $* 
Horizontal=�$	��0,5q�.+��� $'��!В том числе от МЧС ���� -o   $ TbMCSCountPeople��$��60��$�� ��$��5q�$	��5,0q�$' 6��$
��Left=�+ . $( 	Collapsed=�#��[ .���� $��человек���� -p   $ TbMCSCountTechnic��$��60��$�� ��$��5q�$	��5,0q�$' 10��$
��Left=�+ . $( 	Collapsed=�#��[ .���� $��ед. техники��  
����p��$��1q�$��0,3,0,0q�.���� $O��IИнформация с места пожара, аварии или ЧС��$��Center=�
�������$��15(��� -q   , ��Name$, BtnAddFireInfo��$y�	Collapsed=�$��Right=�$��10q�$ Добавить����0	  *MaterialDesignThemes.Wpf.PackIconExtension	  - 	  Kind$	- Add=�&
   System.Windows.Controls.DataGrid
  -r   . 
 Name$. DataGridFireInfo��/ 
  AutoGenerateColumns/ .  0 
  
IsReadOnly0 . 1 
  Columns1 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn2   Header$<2 6Время поступления информации��3   Width5  /System.Windows.Controls.DataGridLengthConverter$
3 0.5*   textWrap1  +System.Windows.Controls.DataGridBoundColumn4   ElementStyle#4 [ 5   Binding5 �� *DateTimeEntry+6 �� StringFormat$6 	{0:HH.mm}��  $2 Кто передал��$
3 0.8*   	textWrap2#4 [ 5 �� *Broadcast.BroadcastName+  $(2 "Информация с места��$3 2* #4 [ 5 �� *	InfoPlace+  $+2 %Разновидность работ��$3 * #4 [ 5 �� *WorkVariety+  $!2 Приданные силы��$3 * #4 [ 5 �� *ListSubdivisions+  $2 Задача��$3 * #4 [ 5 �� *MissionType.MissionTypeName+  $!2 Участок работы��$
3 0.7* #4 [ 5 �� *WorkArea.WorkAreaName+  $2 Тип стволов��$
3 0.6* #4 [ 5 �� *BarrelType.BarrelTypeName+  $ 2 Кол-во стволов��$
3 0.4* #4 [ 5 �� *BarrelCount+  $!2 Боевой участок��$
3 0.5* #4 [ 5 �� *CombatArea.CombatAreaName+  $2 Доп. инф-ция��$3 * #4 [ 5 �� *	AddInfo+4  .System.Windows.Controls.DataGridTemplateColumn  $
3 auto 7   CellTemplate7 �� .R��� $, BtnEdit��-s   $  Редактировать����	  $
- Edit=�  $
3 auto 7 �� .R��� $, BtnDell��-t   $ Удалить����	  $- Delete=�8 
  ColumnHeaderStyle8 �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �� .R��� $��11(�$
��Wrap=����� ��  � ��$ Center=�