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
    /// Логика взаимодействия для AddOrEditCombatDepWindow.xaml
    /// </summary>
    public partial class AddOrEditCombatDepWindow : Window
    {
        private CombatDepForce _currentCombatDepForce = new CombatDepForce();
        public AddOrEditCombatDepWindow(CombatDepForce combatDepForce)
        {
            InitializeComponent();
            if (combatDepForce != null)
                _currentCombatDepForce = combatDepForce;
            DataContext = _currentCombatDepForce;
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
                if (_currentCombatDepForce.CombatDepForceId == 0)
                    FireDepartEntities.GetContext().CombatDepForces.Add(_currentCombatDepForce);
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
            if (string.IsNullOrWhiteSpace(_currentCombatDepForce.CombatDepForceName))
                error.AppendLine("Введите название боевого развертывания сил и средств");
            return error;
        }
    }
}
