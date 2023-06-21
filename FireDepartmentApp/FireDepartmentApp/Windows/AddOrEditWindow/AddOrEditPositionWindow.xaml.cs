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

namespace FireDepartmentApp.Windows.AddOrEditWindow
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditPositionWindow.xaml
    /// </summary>
    public partial class AddOrEditPositionWindow : Window
    {
        private PositionType _currentPositionType = new PositionType();
        private DataGrid dataGrid;
        public AddOrEditPositionWindow(PositionType currentPositionType, DataGrid dataGrid)
        {
            InitializeComponent();
            if (currentPositionType != null)
                _currentPositionType = currentPositionType;
            DataContext = _currentPositionType;
            this.dataGrid = dataGrid;
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
                if (_currentPositionType.PositionTypeId == 0)
                    FireDepartEntities.GetContext().PositionTypes.Add(_currentPositionType);
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
            if (string.IsNullOrWhiteSpace(_currentPositionType.PositionTypeName))
                error.AppendLine("Введите название позывного");
            return error;
        }
    }
}
