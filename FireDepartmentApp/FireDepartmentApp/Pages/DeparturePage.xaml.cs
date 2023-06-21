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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FireDepartmentApp.Entities;
using FireDepartmentApp.Pages;

namespace FireDepartmentApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeparturePage.xaml
    /// </summary>
    public partial class DeparturePage : Page
    {
        public DeparturePage()
        {
            InitializeComponent();
            DatePickerStart.SelectedDate = new DateTime(DateTime.Now.Year, 01, 01);
            DatePickerEnd.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void ListViewDepartures_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListViewDepartures.SelectedItem is Departure departure)
            {
                Manager.MainFrame.Content = new AddDeparturePage(departure);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Manager.IsOpenAddPage = false;
                FireDepartEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Settlement> settlements = FireDepartEntities.GetContext().Settlements.ToList();
                settlements.Insert(0, new Settlement { SettlementName = "Все пункты" });
                ComboSettlements.ItemsSource = settlements;
                UpdateData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void ComboSettlements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            if (DatePickerStart.SelectedDate != null && DatePickerEnd.SelectedDate != null)
            {
                DateTime dateTimestart = (DateTime)DatePickerStart.SelectedDate;
                DateTime dateTimeEnd = (DateTime)DatePickerEnd.SelectedDate;
                List<Departure> departures = FireDepartEntities.GetContext().Departures.Where(p => p.DateTimeDepart >= dateTimestart && p.DateTimeDepart <= dateTimeEnd).OrderByDescending(p => p.DateTimeDepart).ToList();
                // фильтрация
                if (ComboSettlements.SelectedIndex > 0 && ComboSettlements.SelectedItem is Settlement settlement)
                    departures = departures.Where(p => p.DepartureArea.SettlementId == settlement.SettlementId).ToList();
                // сортировка
                switch (ComboSort.SelectedIndex)
                {
                    case 0:
                        departures = departures.OrderBy(p => p.DateTimeDepart).ToList();
                        break;
                    case 1:
                        departures = departures.OrderByDescending(p => p.DateTimeDepart).ToList();
                        break;
                }

                ListViewDepartures.ItemsSource = departures;
            }
            
        }

        private void DatePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void DatePickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && ListViewDepartures.SelectedItem is Departure dep)
            {
                try
                {
                    //if (positionType.Specialties.Count > 0)
                    //    throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().Departures.Remove(dep);
                    FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    UpdateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
