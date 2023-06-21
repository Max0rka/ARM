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
    /// Логика взаимодействия для AddOrEditBarrelTypeWindow.xaml
    /// </summary>
    public partial class AddOrEditBarrelTypeWindow : Window
    {
        private BarrelType _currentBarrelType = new BarrelType();
        public AddOrEditBarrelTypeWindow(BarrelType barrelType)
        {
            InitializeComponent();
            if (barrelType != null)
                _currentBarrelType = barrelType;
            DataContext = _currentBarrelType;
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
                if (_currentBarrelType.BarrelTypeId == 0)
                    FireDepartEntities.GetContext().BarrelTypes.Add(_currentBarrelType);
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
            if (string.IsNullOrWhiteSpace(_currentBarrelType.BarrelTypeName))
                error.AppendLine("Введите тип ствола");
            return error;
        }
    }
}
