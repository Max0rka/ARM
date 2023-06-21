using FireDepartmentApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FireDepartmentApp.Windows.AddOrEditWindow
{
    /// <summary>
    /// Логика взаимодействия для AddInfoPlaceWindow.xaml
    /// </summary>
    public partial class AddInfoPlaceWindow : Window
    {
        private FireInfo _currentFireInfo = new FireInfo();
        private List<CombatDepForce> combatDepForces = new List<CombatDepForce>();
        private List<AlignmentFoce> alignmentFoces = new List<AlignmentFoce>();
        public AddInfoPlaceWindow(FireInfo fireInfo)
        {
            InitializeComponent();
            if (fireInfo != null )
            {
                _currentFireInfo = fireInfo;
            }
            List<string> buildingObjects = new List<string>();
            foreach (var i in ComboInBuildings.Items)
                buildingObjects.Add(((ComboBoxItem)i).Content.ToString());
            buildingObjects = buildingObjects.OrderBy(p => p).ToList();
            ComboInBuildings.Items.Clear();
            ComboInBuildings.ItemsSource = buildingObjects;

            FireDepartEntities.GetContext().CombatDepForces.ForEachAsync(p => p.IsCombatDepForceChecked = false).Wait();
            FireDepartEntities.GetContext().AlignmentFoces.ForEachAsync(p => p.IsAlignmentFoceChecked = false).Wait();
            ListViewCombatDepForces.ItemsSource = combatDepForces = FireDepartEntities.GetContext().CombatDepForces.ToList();
            ListViewAlignmentForces.ItemsSource = alignmentFoces = FireDepartEntities.GetContext().AlignmentFoces.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TreeViewPlaceInfo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem treeViewItem && treeViewItem.Items.Count == 0)
            {
                BtnSave.IsEnabled = true;
            }
            else
                BtnSave.IsEnabled = false;
            
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
        //private void RemoveClickEvent(Button b)
        //{
        //    FieldInfo f1 = typeof(Control).GetField("EventClick",
        //        BindingFlags.Static | BindingFlags.NonPublic);

        //    object obj = f1.GetValue(b);
        //    PropertyInfo pi = b.GetType().GetProperty("Events",
        //        BindingFlags.NonPublic | BindingFlags.Instance);

        //    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
        //    list.RemoveHandler(obj, list[obj]);
        //}
        private void TVItem1_Selected(object sender, RoutedEventArgs e)
        {

            BtnSave.Click += BtnSave1_Click;
        }
        private void TVItem1_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSave1_Click;
        }

        private void BtnSave1_Click(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                _currentFireInfo.InfoPlace = treeViewItem.Header.ToString();
                _currentFireInfo.WorkVariety = "";
                Close();
            }
                
        }

        private void TVItem2_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSave2_Click;
        }
        private void TVItem2_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSave2_Click;
        }
        private void BtnSave2_Click(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                
                _currentFireInfo.InfoPlace = (treeViewItem.Parent as TreeViewItem)?.Header.ToString();
                _currentFireInfo.WorkVariety = treeViewItem.Header.ToString();
                Close();
            }
            
        }

        private void TVItem2span_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSave2span;
        }

        private void TVItem2span_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSave2span;
        }
        private void BtnSave2span(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {

                _currentFireInfo.InfoPlace = (treeViewItem.Parent as TreeViewItem)?.Header.ToString();
                _currentFireInfo.InfoPlace += $" - {treeViewItem.Header}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }
        // ветка к месту вызова направлены дополнительно
        private void TVItemServices_Selected(object sender, RoutedEventArgs e)
        {
            SPanelServices.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveServices;
        }

        private void TVItemServices_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelServices.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveServices;
        }
        private void BtnSaveServices(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {

                _currentFireInfo.InfoPlace = treeViewItem.Header.ToString() + ": ";
                if (CBoxGIBDD.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxGIBDD.Content.ToString()}, ";
                if (CBoxElect.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxElect.Content.ToString()}, ";
                if (CBoxGas.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxGas.Content.ToString()}, ";
                if (CBoxLadder.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxLadder.Content.ToString()}, ";
                if (_currentFireInfo.InfoPlace.Length > treeViewItem.Header.ToString().Length + 2)
                    _currentFireInfo.InfoPlace = _currentFireInfo.InfoPlace.Remove(_currentFireInfo.InfoPlace.Length - 2);
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }
        private void TVItemOther_Selected(object sender, RoutedEventArgs e)
        {
            SPanelOther.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveOther;
        }

        private void TVItemOther_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelOther.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveOther;
        }
        // ветка иное
        private void BtnSaveOther(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {

                _currentFireInfo.InfoPlace = (treeViewItem.Parent as TreeViewItem)?.Header.ToString();
                _currentFireInfo.InfoPlace += $" - {TbOther.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemSmoke_Selected(object sender, RoutedEventArgs e)
        {
            SPanelSmoke.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveSmoke;
        }

        private void TVItemSmoke_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelSmoke.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveSmoke;
        }
        // ветка в пути следования наблюдаю дым
        private void BtnSaveSmoke(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {

                _currentFireInfo.InfoPlace = treeViewItem.Header.ToString();
                if (ComboSmoke.SelectedItem != null)
                _currentFireInfo.InfoPlace += $" - Номер (ранг) вызова: {(ComboSmoke.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }
        private void TVItemHeaderNames(TreeViewItem treeViewItem)
        {
            List<string> strings = new List<string>();
            var objectParent = treeViewItem.Parent;
            while (objectParent is TreeViewItem parent)
            {
                strings.Add(parent.Header.ToString());
                objectParent = parent.Parent;
            }
            strings.Reverse();
            _currentFireInfo.InfoPlace = "";
            foreach (string s in strings)
            {
                _currentFireInfo.InfoPlace += $"{s} - ";
            }
        }

        private void TVItemAllItem_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSaveAllElements;
        }

        private void TVItemAllItem_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSaveAllElements;
        }
        // ветка для вложенных элементов
        private void BtnSaveAllElements(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += treeViewItem.Header.ToString();               
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemOtherObject_Selected(object sender, RoutedEventArgs e)
        {
            SPanelOther.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveOtherFire;
        }

        private void TVItemOtherObject_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelOther.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveOtherFire;
        }
        // ветка объект пожара - иное
        private void BtnSaveOtherFire(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += TbOther.Text;
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemRoomBuild_Selected(object sender, RoutedEventArgs e)
        {
            SPanelInBuilding.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveRoomBuild;
        }

        private void TVItemRoomBuild_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelInBuilding.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveRoomBuild;
        }
        // ветка место пожара - помещение в здании
        private void BtnSaveRoomBuild(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - ";
                string text = "";
                if (ComboInBuildings.SelectedItem != null)
                    text = $"{ComboInBuildings.SelectedItem}";
                if (TbOtherRoom.Text != null && TbOtherRoom.Text.Length > 0)
                    text = TbOtherRoom.Text;
                _currentFireInfo.InfoPlace += text;
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemSeeFirePlace_Selected(object sender, RoutedEventArgs e)
        {
            SPanelSeeFirePlace.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveSeeFirePlace;
        }

        private void TVItemSeeFirePlace_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelSeeFirePlace.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveSeeFirePlace;
        }

        private void TbFloor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsNumber(e.Text, 0);
        }
        // ветка наблюдаю на месте пожара
        private void BtnSaveSeeFirePlace(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - Горение наблюдается на {TbFloor.Text} этаже ";
                string text = "";
                if (ComboSeeFirePlace.SelectedItem != null)
                    text = $"{(ComboSeeFirePlace.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (TbOtherFirePlace.Text != null && TbOtherFirePlace.Text.Length > 0)
                    text = TbOtherFirePlace.Text;
                _currentFireInfo.InfoPlace += text;
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemPeopleFireBuild_Selected(object sender, RoutedEventArgs e)
        {
            SPanelPeopleFireBuild.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSavePeopleFireBuild;
        }

        private void TVItemPeopleFireBuild_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelPeopleFireBuild.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSavePeopleFireBuild;
        }
        // ветка Наличие людей в горящем здании - имеется
        private void BtnSavePeopleFireBuild(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                string text = "";
                if (TbPeopleCount.Text != null && TbPeopleCount.Text.Length > 0)
                    text += $" - {TbPeopleCount.Text} чел.";
                if (TbPeoplePlace.Text != null && TbPeoplePlace.Text.Length > 0)
                    text += $" - Возможное местонахождение - {TbPeoplePlace.Text}";
                if (CBoxUnknown.IsChecked == true)
                    text = $" - {CBoxUnknown.Content.ToString()}";
                if (ComboPeopleStatus.SelectedItem != null)
                    text += $" - Состояние людей внутри здания - {(ComboPeopleStatus.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                
                _currentFireInfo.InfoPlace += text;
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemFloor_Selected(object sender, RoutedEventArgs e)
        {
            SPanelFloor.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveFloor;
        }

        private void TVItemFloor_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelFloor.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveFloor;
        }
        // ветка этажность здания
        private void BtnSaveFloor(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - {TbFloorBuild.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemSystemTypes_Selected(object sender, RoutedEventArgs e)
        {
            SPanelSystemTypes.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveSystemType;
        }

        private void TVItemSystemTypes_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelSystemTypes.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveSystemType;
        }
        // ветка в результате пожара произошла сработка
        private void BtnSaveSystemType(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                string textFire = "";
                string textSmoke = "";
                string textNotify = "";
                if (RBFireSystemYes.IsChecked == true)
                    textFire = "Да";
                if (RBFireSystemNo.IsChecked == true)
                    textFire = "Нет";
                if (RBSmokeSystemYes.IsChecked == true)
                    textSmoke = "Да";
                if (RBSmokeSystemNo.IsChecked == true)
                    textSmoke = "Нет";
                if (RBNotifySystemYes.IsChecked == true)
                    textNotify = "Да";
                if (RBNotifySystemNo.IsChecked == true)
                    textNotify = "Нет";
                _currentFireInfo.InfoPlace += $" - Системы пожаротушения: {textFire} - Системы дымоудаления: {textSmoke} - Системы сигнализации: {textNotify}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemStayedBuild_Selected(object sender, RoutedEventArgs e)
        {
            SPanelStayedBuild.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveStayedBuild;
        }

        private void TVItemStayedBuild_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelStayedBuild.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveStayedBuild;
        }
        // ветка Информация об оставшихся людях в здании 
        private void BtnSaveStayedBuild(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                string text = "";
                string textPlace = "";
                if (TbStayedPeopleCount.Text != null && TbStayedPeopleCount.Text.Length > 0)
                    text += $": {TbStayedPeopleCount.Text} чел.";
                if (ComboStayedPeopleStatus.SelectedItem != null)
                    text += $" - Состояние людей по информации очевидцев: {(ComboStayedPeopleStatus.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboStayedPeoplePlace.SelectedItem != null)
                    textPlace = $" - Возможное местонахождение: {(ComboStayedPeoplePlace.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (TbOtherPeoplePlace.Text != null && TbOtherPeoplePlace.Text.Length > 0)
                    textPlace = $" - Возможное местонахождение: {TbOtherPeoplePlace.Text}";
                text += textPlace;
                _currentFireInfo.InfoPlace += text;
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemServices2_Selected(object sender, RoutedEventArgs e)
        {
            SPanelServices2.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveServices2;
        }

        private void TVItemServices2_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelServices2.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveServices2;
        }
        // ветка Вызов служб к месту вызова
        private void BtnSaveServices2(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += treeViewItem.Header.ToString() + ": ";
                if (CBoxAmbulance.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxAmbulance.Content.ToString()}, ";
                if (CBoxEnergy.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxEnergy.Content.ToString()}, ";
                if (CBoxGas2.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxGas2.Content.ToString()}, ";
                if (CBoxGIBDD2.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxGIBDD2.Content.ToString()}, ";
                if (CBoxVodokanal.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxVodokanal.Content.ToString()}, ";
                if (CBoxPPS.IsChecked == true)
                    _currentFireInfo.InfoPlace += $"{CBoxPPS.Content.ToString()}, ";
                if (_currentFireInfo.InfoPlace.Length > treeViewItem.Header.ToString().Length + 2)
                    _currentFireInfo.InfoPlace = _currentFireInfo.InfoPlace.Remove(_currentFireInfo.InfoPlace.Length - 2);
                _currentFireInfo.WorkVariety = "";
                Close();
            }

        }

        private void TVItemFireArea_Selected(object sender, RoutedEventArgs e)
        {
            SPanelFireArea.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveFireArea;
        }

        private void TVItemFireArea_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelFireArea.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveFireArea;
        }
        // ветка площадь пожара
        private void BtnSaveFireArea(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}: {TbFireArea.Text} м2";
                if (TbFireArea.Text.Length > 0)
                    _currentFireInfo.FireAreaCount = Convert.ToInt32(TbFireArea.Text);
                //_currentFireInfo.FireAreaCount = Convert.ToInt16(TbFireArea.Text);
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemChiefStaffRear_Selected(object sender, RoutedEventArgs e)
        {
            SPanelChiefStaffRear.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveChiefStaffRear;
        }

        private void TVItemChiefStaffRear_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelChiefStaffRear.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveChiefStaffRear;
        }
        // ветка создание оперативного штаба... - начальник штаба...
        private void BtnSaveChiefStaffRear(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"Начальник штаба: {TbChiefStaff.Text} - Начальник тыла: {TbChiefRear.Text} - Ответственный за охрану труда: {TbChiefWork.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemChiefKPP_Selected(object sender, RoutedEventArgs e)
        {
            SPanelChiefKPP.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveChiefKPP;
        }

        private void TVItemChiefKPP_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelChiefKPP.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveChiefKPP;
        }
        // ветка создание оперативного штаба... - начальник КПП ГДЗС...
        private void BtnSaveChiefKPP(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"Начальник КПП ГДЗС: {TbChiefKPP.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemChiefBY_Selected(object sender, RoutedEventArgs e)
        {
            SPanelChiefBY.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveChiefBY;
        }

        private void TVItemChiefBY_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelChiefBY.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveChiefBY;
        }
        // ветка создание оперативного штаба... - начальник БУ (СПР)...
        private void BtnSaveChiefBY(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - Участок по тушению пожара: {TbAreaFire.Text} - Участок по защите: {TbSecurity.Text}" +
                    $" - Участок по организации спасения людей: {TbRescuePeople.Text} - Участок по организации спасения имущества: {TbAreaSecurity.Text}" +
                    $" - Участок по проведению АСР: {TbACP.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }
        private void TVItemForces_Selected(object sender, RoutedEventArgs e)
        {
            SViewerAlignmentForce.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveAlignmentForce;
        }

        private void TVItemForces_Unselected(object sender, RoutedEventArgs e)
        {
            SViewerAlignmentForce.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveAlignmentForce;
        }
        // ветка расстановка сил и средств
        private void BtnSaveAlignmentForce(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                string workVariety = "";
                foreach (var i in combatDepForces)
                    if (i.IsCombatDepForceChecked)
                        workVariety += $"{i.CombatDepForceName}, ";
                foreach (var i in alignmentFoces)
                    if (i.IsAlignmentFoceChecked)
                        workVariety += $"{i.AlignmentFoceName}, ";
                if (workVariety.Length > 2)
                    workVariety = workVariety.Remove(workVariety.Length - 2);
                _currentFireInfo.WorkVariety = workVariety;
                Close();
            }
        }
        private void TVItemConfirm_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSaveConfirm;
        }

        private void TVItemConfirm_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSaveConfirm;
        }
        // ветка подтверждения установления сигнала на отход 
        private void BtnSaveConfirm(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                if (MessageBox.Show("Подтвердить установку сигнала на отход?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                    _currentFireInfo.WorkVariety = "";
                    Close();
                }
                    
            }
        }

        private void TVItemCreateReserve_Selected(object sender, RoutedEventArgs e)
        {
            SPanelCreateReserve.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveCreateReserve;
        }

        private void TVItemCreateReserve_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelCreateReserve.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveCreateReserve;
        }
        // ветка создание резерва сил и средств - создаю резерв
        private void BtnSaveCreateReserve(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"Создан резерв сил и средств на месте пожара в составе {TbPeopleReserve.Text} человек  личного состава, из них {TbPeopleGas.Text} " +
                    $"газодымозащитников и {TbTechnicCount.Text} единиц техники";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemPeopleCount_Selected(object sender, RoutedEventArgs e)
        {
            SPanelPeopleCount.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSavePeopleCount;
        }

        private void TVItemPeopleCount_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelPeopleCount.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSavePeopleCount;
        }
        // ветка Обнаружены на месте пожара (инф-ция о кол-ве переданных людей)
        private void BtnSavePeopleCount(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} {TbPeopleCountTrans.Text} чел.";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemDataPeople_Selected(object sender, RoutedEventArgs e)
        {
            SPanelDataPeople.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveDataPeople;
        }

        private void TVItemDataPeople_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelDataPeople.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveDataPeople;
        }
        // ветка обнаружены на месте пожара - пострадавший
        private void BtnSaveDataPeople(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}: {TbLastName.Text} {TbFirstName.Text} {TbMiddleName.Text}, год рождения: {TbYearOfBirth.Text}" +
                    $", пол: {(ComboGender.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (CBoxBurn.IsChecked == true)
                    _currentFireInfo.InfoPlace += $", тело имеет признаки воздействия открытого огня, площадь ожогов: {TbAreaBurn.Text}";
                if (TbAddInfo.Text != null && TbAddInfo.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", {TbAddInfo.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemDataDeadPeople_Selected(object sender, RoutedEventArgs e)
        {
            SPanelDataPeopleDead.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveDataPeopleDead;
        }

        private void TVItemDataDeadPeople_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelDataPeopleDead.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveDataPeopleDead;
        }
        // ветка обнаружены на месте пожара - погибший
        private void BtnSaveDataPeopleDead(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}: {TbLastNameDead.Text} {TbFirstNameDead.Text} {TbMiddleNameDead.Text}, год рождения: {TbYearOfBirthDead.Text}" +
                    $", пол: {(ComboGenderDead.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (CBoxBurnDead.IsChecked == true)
                    _currentFireInfo.InfoPlace += $", тело имеет признаки воздействия открытого огня";
                _currentFireInfo.InfoPlace += $", обнаружен: {TbDiscorver.Text}, место обнаружения: {TbDiscorverPlace.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemRescuedPeople_Selected(object sender, RoutedEventArgs e)
        {
            SPanelRescuedPeople.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveAddInfoRescuedPeople;
        }

        private void TVItemRescuedPeople_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelRescuedPeople.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveAddInfoRescuedPeople;
        }
        // ветка Дополнительная информация по спасенным гражданам
        private void BtnSaveAddInfoRescuedPeople(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}: {TbAddInfoRescuedPeople.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemCharactBuild_Selected(object sender, RoutedEventArgs e)
        {
            SPanelCharactBuild.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveCharactBuild;
        }

        private void TVItemCharactBuild_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelCharactBuild.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveCharactBuild;
        }

        private void BtnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            AddInfoFireObjectWindow addInfoFireObjectWindow = new AddInfoFireObjectWindow();
            addInfoFireObjectWindow.ShowDialog();
            TbFireObject.Text = addInfoFireObjectWindow.FireInfo;
        }
        // ветка характеристика объекта
        private void BtnSaveCharactBuild(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - Объект пожара: {TbFireObject.Text}";
                if (TbFloorObject.Text != null && TbFloorObject.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", этажность здания: {TbFloorObject.Text}";
                if (ComboRefactorines.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", степень огнестойкости: {(ComboRefactorines.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboOuterWalls.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", наружные стены: {(ComboOuterWalls.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboBuildSheathings.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", обшивка здания: {(ComboBuildSheathings.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboOverlaps.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", перекрытие: {(ComboOverlaps.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboRoofs.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", кровля: {(ComboRoofs.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboBaseRoofs.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", обрешетка кровли (основание): {(ComboBaseRoofs.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboIsCellar.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", наличие подвала: {(ComboIsCellar.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboIsAttic.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", наличие чердачного помещения: {(ComboIsAttic.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (TbSize1.Text != null && TbSize1.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", геометрические размеры в плане: {TbSize1.Text} х ";
                if (TbSize2.Text != null && TbSize2.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $"{TbSize2.Text}";
                if (ComboBuildGas.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", здание газифицировно: {(ComboBuildGas.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboBuildElect.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", здание электрифицировано: {(ComboBuildElect.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (ComboBuidHeating.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", отопление: {(ComboBuidHeating.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (TbAddInfoBuild.Text != null && TbAddInfoBuild.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", доп. инф-ция: {TbAddInfoBuild.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemCharactHome_Selected(object sender, RoutedEventArgs e)
        {
            SPanelCharactHome.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveCharactHome;
        }

        private void TVItemCharactHome_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelCharactHome.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveCharactHome;
        }
        // ветка характеристика многоквартирного дома
        private void BtnSaveCharactHome(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                if (TbEntranceCount.Text != null && TbEntranceCount.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $"- количество подъездов в доме: {TbEntranceCount.Text}";
                if (TbFlatEntranceCount.Text != null && TbFlatEntranceCount.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", количество квартир в подъезде: {TbFlatEntranceCount.Text}";
                if (TbFlatHouseCount.Text != null && TbFlatHouseCount.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", количество квартир в доме: {TbFlatHouseCount.Text}";
                if (TbFlatNumber.Text != null && TbFlatNumber.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", номер квартиры: {TbFlatNumber.Text}";
                if (TbFloorFlat.Text != null && TbFloorFlat.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", этаж расположения квартиры: {TbFloorFlat.Text}";
                if (ComboFlatCount.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", количество комнат: {(ComboFlatCount.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                if (TbFlatArea.Text != null && TbFlatArea.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $", площадь квартиры: {TbFlatArea.Text}";
                if (TbRoomFireArea.Text != null && TbRoomFireArea.Text.Length > 0)
                {
                    _currentFireInfo.FireAreaCount = Convert.ToInt32(TbRoomFireArea.Text);
                    _currentFireInfo.InfoPlace += $", площадь комнаты, где произошел пожар: {TbRoomFireArea.Text}";
                }
                    
                if (ComboFirePlace.SelectedItem != null)
                    _currentFireInfo.InfoPlace += $", место пожара: {(ComboFirePlace.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemAftermathFire_Selected(object sender, RoutedEventArgs e)
        {
            SPanelAftermathFire.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveAftermathFire;
        }

        private void TVItemAftermathFire_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelAftermathFire.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveAftermathFire;
        }

        private void ComboInsurance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboInsurance.SelectedIndex == 0)
                TbSummInsurance.IsEnabled = true;
            else
                TbSummInsurance.IsEnabled = false;
        }

        private void BtnAddInfoCause_Click(object sender, RoutedEventArgs e)
        {
            AddInfoCauseWindow addInfoCauseWindow = new AddInfoCauseWindow();
            addInfoCauseWindow.ShowDialog();
            TbCauseFire.Text = addInfoCauseWindow.CauseInfo;
        }
        // ветка последствия пожара
        private void BtnSaveAftermathFire(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                if (TbLastNameOwner.Text.Length > 0 || TbFirstNameOwner.Text.Length > 0 || TbMiddleNameOwner.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Сведения о собственнике: {TbLastNameOwner.Text} {TbFirstNameOwner.Text} {TbMiddleNameOwner.Text}";
                if (TbLastNameTenant.Text.Length > 0 || TbFirstNameTenant.Text.Length > 0 || TbMiddleNameTenant.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Сведения об арендаторе: {TbLastNameTenant.Text} {TbFirstNameTenant.Text} {TbMiddleNameTenant.Text}";
                if (TbOrgName.Text.Length > 0 || TbActivityType.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Организация: {TbOrgName.Text}, вид деятельности: {TbActivityType.Text}";
                if (ComboInsurance.SelectedItem != null)
                {
                    _currentFireInfo.InfoPlace += $" - Наличие страховки: {(ComboInsurance.SelectedItem as ComboBoxItem)?.Content.ToString()}";
                    if (ComboInsurance.SelectedIndex == 0)
                        _currentFireInfo.InfoPlace += $", сумма: {TbSummInsurance.Text}";
                }
                if (TbSummDamage.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Предварительный ущерб: {TbSummDamage.Text}";
                if (TbSummSalvage.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Сумма спасенного имущества: {TbSummSalvage.Text}";
                if (TbCauseFire.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Предварительная причина пожара: {TbCauseFire.Text}";
                if (TbDamageObject.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Что пострадало: {TbDamageObject.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemGeneralEvac_Selected(object sender, RoutedEventArgs e)
        {
            SPanelEvac.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveEvac;
        }

        private void TVItemGeneralEvac_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelEvac.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveEvac;
        }
        // ветка спасенные и эвакуированные при пожаре
        private void BtnSaveEvac(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                if (TbGeneralEvac.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Всего: {TbGeneralEvac.Text} чел.";
                if (TbGeneralEvacChild.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - В том числе детей: {TbGeneralEvacChild.Text}";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemRescued_Selected(object sender, RoutedEventArgs e)
        {
            SPanelRescued.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveRescued;
        }

        private void TVItemRescued_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelRescued.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveRescued;
        }
        // ветка спасенные и эвакуированные при пожаре - спасено населением
        private void BtnSaveRescued(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                if (TbRescuedDoor.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Через входную дверь: {TbRescuedDoor.Text} чел.";
                if (TbRescuedWindow.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - Через окно: {TbRescuedWindow.Text} чел.";
                if (TbRescuedLadder.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - По лестничной клетке: {TbRescuedLadder.Text} чел.";
                if (TbRescuedTool.Text.Length > 0)
                    _currentFireInfo.InfoPlace += $" - С применением приспособленной лестницы (инструменты): {TbRescuedTool.Text} чел.";
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        private void TVItemRescuedWorker_Selected(object sender, RoutedEventArgs e)
        {
            SPanelRescuedWorker.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveRescuedWorker;
        }

        private void TVItemRescuedWorker_Unselected(object sender, RoutedEventArgs e)
        {

            SPanelRescuedWorker.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveRescuedWorker;
        }
        // ветка спасенные и эвакуированные при пожаре - спасено сотрудниками
        private void BtnSaveRescuedWorker(object sender, RoutedEventArgs e)
        {
            if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()}";
                if (TbGeneralRescLadder.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - По лестничной клетке с применением <<капюшона>> - всего: {TbGeneralRescLadder.Text} чел.";
                    if (TbResLadderChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResLadderChild.Text}";
                }
                if (TbGeneralRescAL.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - По АЛ (АКП) - всего: {TbGeneralRescAL.Text} чел.";
                    if (TbResALChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResALChild.Text}";
                }
                if (TbGeneralRescPPSY.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - С применением ППСУ-20 - всего: {TbGeneralRescPPSY.Text} чел.";
                    if (TbResPPSYChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResPPSYChild.Text}";
                }
                if (TbGeneralRescCanvas.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - С применением натяжного полотна - всего: {TbGeneralRescCanvas.Text} чел.";
                    if (TbResCanvasChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResCanvasChild.Text}";
                }
                if (TbGeneralRescWindow.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - Через окно - всего: {TbGeneralRescWindow.Text} чел.";
                    if (TbResWindowChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResWindowChild.Text}";
                }
                if (TbGeneralRescOther.Text.Length > 0)
                {
                    _currentFireInfo.InfoPlace += $" - Иное - всего: {TbGeneralRescOther.Text} чел.";
                    if (TbResOtherChild.Text.Length > 0)
                        _currentFireInfo.InfoPlace += $", в том числе детей: {TbResOtherChild.Text}";
                }
                _currentFireInfo.WorkVariety = "";
                Close();
            }
        }

        //private void TVItemInjBuild_Selected(object sender, RoutedEventArgs e)
        //{
        //    SPanelInjRoom.Visibility = Visibility.Visible;
        //    BtnSave.Click += BtnSaveInjRoom;
        //}

        //private void TVItemInjBuild_Unselected(object sender, RoutedEventArgs e)
        //{
        //    SPanelInjRoom.Visibility = Visibility.Collapsed;
        //    BtnSave.Click -= BtnSaveInjRoom;
        //}
        //// ветка место пожара - инженерные коммуникации
        //private void BtnSaveInjRoom(object sender, RoutedEventArgs e)
        //{
        //    if (TreeViewPlaceInfo.SelectedItem is TreeViewItem treeViewItem)
        //    {
        //        TVItemHeaderNames(treeViewItem);
        //        _currentFireInfo.InfoPlace += $"{treeViewItem.Header.ToString()} - ";
        //        string text = "";
        //        if (ComboInjRooms.SelectedItem != null)
        //            text = $"{(ComboInjRooms.SelectedItem as ComboBoxItem)?.Content.ToString()}";
        //        if (TbOtherInjRoom.Text != null && TbOtherInjRoom.Text.Length > 0)
        //            text = TbOtherInjRoom.Text;
        //        _currentFireInfo.InfoPlace += text;
        //        _currentFireInfo.WorkVariety = "";
        //        Close();
        //    }

        //}
    }
}
