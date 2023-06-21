using FireDepartmentApp.Entities;
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
using Xceed.Wpf.AvalonDock.Controls;

namespace FireDepartmentApp.Windows.AddOrEditWindow
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditStreetWindow.xaml
    /// </summary>
    public partial class AddOrEditStreetWindow : Window
    {
        private Street _currentStreet = new Street();
        public AddOrEditStreetWindow(Street street)
        {
            InitializeComponent();
            if (street != null)
                _currentStreet = street;
            DataContext = _currentStreet;
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = CheckField();
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_currentStreet.StreetId == 0)
                    FireDepartEntities.GetContext().Streets.Add(_currentStreet);
                FireDepartEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена/добавлена");

                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private StringBuilder CheckField()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentStreet.StreetName))
                error.AppendLine("Введите название улицы");
            return error;
        }
    }
}
