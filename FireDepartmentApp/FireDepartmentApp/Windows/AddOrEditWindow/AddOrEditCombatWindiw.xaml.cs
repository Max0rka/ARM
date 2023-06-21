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
    /// Логика взаимодействия для AddOrEditCombatWindiw.xaml
    /// </summary>
    public partial class AddOrEditCombatWindiw : Window
    {
        private CombatArea _currentCombatArea = new CombatArea();
        public AddOrEditCombatWindiw(CombatArea combatArea)
        {
            InitializeComponent();
            if (combatArea != null)
                _currentCombatArea = combatArea;
            DataContext = _currentCombatArea;
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
                if (_currentCombatArea.CombatAreaId == 0)
                    FireDepartEntities.GetContext().CombatAreas.Add(_currentCombatArea);
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
            if (string.IsNullOrWhiteSpace(_currentCombatArea.CombatAreaName))
                error.AppendLine("Введите боевой участок");
            return error;
        }
    }
}
