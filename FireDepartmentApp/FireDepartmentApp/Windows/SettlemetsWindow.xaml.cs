using System;
using System.Collections.Generic;
using System.Linq;
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
using FireDepartmentApp.Entities;
using FireDepartmentApp.Windows.AddOrEditWindow;

namespace FireDepartmentApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для SettlemetsWindow.xaml
    /// </summary>
    public partial class SettlemetsWindow : Window
    {
        // выделенный населенный пункт
        private Settlement selectedSettlement;
        // выделенный район выезда
        private DepartureArea selectedDepArea;
        public SettlemetsWindow()
        {
            InitializeComponent();
            DataGridSettlement.ItemsSource = FireDepartEntities.GetContext().Settlements.ToList();
        }

        private void BtnAddArea_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSettlement != null)
            {
                AddOrEditDepAreaWindow depAreaWindow = new AddOrEditDepAreaWindow(null, selectedSettlement.SettlementId);
                depAreaWindow.ShowDialog();
                UpdateDataGridDepArea();
            }
            
        }

        private void BtnEditArea_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridDepArea.SelectedItem is DepartureArea depArea)
            {
                AddOrEditDepAreaWindow depAreaWindow = new AddOrEditDepAreaWindow(depArea, selectedSettlement.SettlementId);
                depAreaWindow.ShowDialog();
                UpdateDataGridDepArea();
            }
        }

        private void BtnDellArea_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridDepArea.SelectedItem is DepartureArea depArea)
            {
                try
                {
                    if (depArea.Departures.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().Subdivisions.RemoveRange(depArea.Subdivisions);
                    FireDepartEntities.GetContext().DepartureAreas.Remove(depArea);
                    FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    UpdateDataGridDepArea();
                    DataGridDepArea_SelectionChanged(null, default);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDellAllArea_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditSettlementWindow addOrEditSettlementWindow = new AddOrEditSettlementWindow(null);
            addOrEditSettlementWindow.ShowDialog();
            UpdateDataGridSettlement();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSettlement.SelectedItem is Settlement settlement)
            {
                AddOrEditSettlementWindow addOrEditSettlementWindow = new AddOrEditSettlementWindow(settlement);
                addOrEditSettlementWindow.ShowDialog();
                UpdateDataGridSettlement();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridSettlement.SelectedItem is Settlement settlement)
            {
                try
                {
                    if (settlement.DepartureAreas.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().Settlements.Remove(settlement);
                    FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    UpdateDataGridSettlement();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDellAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridSettlement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridSettlement.SelectedItem is Settlement settlement)
            {
                selectedSettlement = settlement;
                DataGridDepArea.ItemsSource = FireDepartEntities.GetContext().DepartureAreas.Where(p => p.SettlementId == settlement.SettlementId).ToList();
            }
        }
        private void DataGridDepArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FireDepartEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            if (DataGridDepArea.SelectedItem is DepartureArea depArea)
            {
                selectedDepArea = depArea;
                // загрузка в 1 ранг пожаров
                ListViewDiv.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId
                && p.FireRank == 1).ToList();
                // загрузка в 1-БИС ранг пожаров
                ListViewDiv1.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId
                && p.FireRank == 2).ToList();
                // загрузка во 2 ранг пожаров
                ListViewDiv2.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId
                && p.FireRank == 3).ToList();
                // загрузка в 3 ранг пожаров
                ListViewDiv3.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId && p.FireRank == 4).ToList();
                // загрузка в 4 ранг пожаров
                ListViewDiv4.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId && p.FireRank == 5).ToList();
                // загрузка в 5 ранг пожаров
                ListViewDiv5.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == depArea.DepartureAreaId && p.FireRank == 6).ToList();
            }
            else
            {
                ListViewDiv.ItemsSource = null;
                ListViewDiv1.ItemsSource = null;
                ListViewDiv2.ItemsSource = null;
                ListViewDiv3.ItemsSource = null;
                ListViewDiv4.ItemsSource = null;
                ListViewDiv5.ItemsSource = null;
            }
        }

        private void TbSettlementSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Settlement> settlements = FireDepartEntities.GetContext().Settlements.ToList();
            string settlement = TbSettlementSearch.Text.ToLower();
            if (settlement != "")
            {
                settlements = settlements.Where(p => p.SettlementName.ToLower().Contains(settlement)).ToList(); 
            }
            DataGridSettlement.ItemsSource = settlements;
        }

        private void TbDepAreaSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<DepartureArea> departureAreas = FireDepartEntities.GetContext().DepartureAreas.Where(p => p.SettlementId == selectedSettlement.SettlementId).ToList();
            string depArea = TbDepAreaSearch.Text.ToLower();
            if (depArea != "")
            {
                departureAreas = departureAreas.Where(p => p.DepartureAreaName.ToLower().Contains(depArea)).ToList();
            }
            DataGridDepArea.ItemsSource = departureAreas;

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
        private void UpdateDataGridSettlement()
        {
            FireDepartEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridSettlement.ItemsSource = FireDepartEntities.GetContext().Settlements.ToList();
        }
        private void UpdateDataGridDepArea()
        {
            FireDepartEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridDepArea.ItemsSource = FireDepartEntities.GetContext().DepartureAreas.Where(p => p.SettlementId == selectedSettlement.SettlementId).ToList();
        }
        /// <summary>
        /// добавление привлекаемых подразделений
        /// </summary>
        /// <param name="fireRankCode"></param>
        private void DivDepAreaAdd(byte fireRankCode)
        {
            if (DataGridDepArea.SelectedItem == null)
            {
                MessageBox.Show("Выберите район вызова", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            AddOrEditDivDepAreaWindow divDepAreaWindow = new AddOrEditDivDepAreaWindow(new Subdivision
            {
                DepartureArea = selectedDepArea,
                FireRank = fireRankCode
            });
            divDepAreaWindow.ShowDialog();
            DataGridDepArea_SelectionChanged(null, default);
        }
        /// <summary>
        /// редактирование привлекаемых подразделений
        /// </summary>
        /// <param name="divDepAreaListView"></param>
        private void DivDepAreEdit(ListView SubdivisionListView)
        {
            if (SubdivisionListView.SelectedItem is Subdivision subdivision)
            {
                AddOrEditDivDepAreaWindow divDepAreaWindow = new AddOrEditDivDepAreaWindow(subdivision);
                divDepAreaWindow.ShowDialog();
                DataGridDepArea_SelectionChanged(null, default);
            }
        }
        /// <summary>
        /// удаление привлекаемых подразделений
        /// </summary>
        /// <param name="divDepAreaListView"></param>
        private void DivDepAreaDell(ListView SubdivisionListView)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && SubdivisionListView.SelectedItem is Subdivision subdivision)
            {
                try
                {
                    if (subdivision.FireInfoSubdivisions.Count > 0 || subdivision.DepartureSubdivisions.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().Subdivisions.Remove(subdivision);
                    FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    DataGridDepArea_SelectionChanged(null, default);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // действия с 1 рангом пожаров
        private void BtnAddDiv_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(1);
        }

        private void BtnEditDiv_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv);
        }

        private void BtnDellDiv_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv);
        }
        
        // действия с 1 БИС рангом пожаров

        private void BtnAddDiv1_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(2);
        }

        private void BtnEditDiv1_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv1);
        }

        private void BtnDellDiv1_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv1);
        }
        // действия со 2 рангом пожаров
        private void BtnAddDiv2_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(3);
        }

        private void BtnEditDiv2_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv2);
        }

        private void BtnDellDiv2_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv2);
        }
        // действия с 3 рангом пожаров
        private void BtnAddDiv3_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(4);
        }

        private void BtnEditDiv3_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv3);
        }

        private void BtnDellDiv3_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv3);
        }
        // действия с 4 рангом пожаров
        private void BtnAddDiv4_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(5);
        }

        private void BtnEditDiv4_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv4);
        }

        private void BtnDellDiv4_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv4);
        }
        // действия с 5 рангом пожаров
        private void BtnAddDiv5_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaAdd(6);
        }

        private void BtnEditDiv5_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreEdit(ListViewDiv5);
        }

        private void BtnDellDiv5_Click(object sender, RoutedEventArgs e)
        {
            DivDepAreaDell(ListViewDiv5);
        }
    }
}
