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

namespace FireDepartmentApp.Windows.AddOrEditWindow
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditServiceTypeWindow.xaml
    /// </summary>
    public partial class AddOrEditServiceTypeWindow : Window
    {
        private ServiceType _currentServiceType = new ServiceType();
        public AddOrEditServiceTypeWindow(ServiceType serviceType)
        {
            InitializeComponent();
            if (serviceType != null)
                _currentServiceType = serviceType;
            DataContext = _currentServiceType;
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
                if (_currentServiceType.ServiceTypeId == 0)
                    FireDepartEntities.GetContext().ServiceTypes.Add(_currentServiceType);
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
            if (string.IsNullOrWhiteSpace(_currentServiceType.ServiceTypeName))
                error.AppendLine("Введите название службы");
            return error;
        }
    }
}
