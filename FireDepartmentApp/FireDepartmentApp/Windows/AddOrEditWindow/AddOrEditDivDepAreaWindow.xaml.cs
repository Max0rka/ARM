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
    /// Логика взаимодействия для AddOrEditDivDepAreaWindow.xaml
    /// </summary>
    public partial class AddOrEditDivDepAreaWindow : Window
    {
        private Subdivision _currentSubdivision = new Subdivision();
        public AddOrEditDivDepAreaWindow(Subdivision subdivision)
        {
            InitializeComponent();
            if (subdivision != null)
                _currentSubdivision = subdivision;
            DataContext = _currentSubdivision;
            ComboBoxDivision.ItemsSource = FireDepartEntities.GetContext().Divisions.ToList();
            
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
                if (_currentSubdivision.SubdivisionId == 0)
                    FireDepartEntities.GetContext().Subdivisions.Add(_currentSubdivision);
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
            if (ComboBoxDivision.SelectedItem == null)
                error.AppendLine("Выберите подразделение");
            if (ComboBoxTechnics.SelectedItem == null)
                error.AppendLine("Выберите технику");
            return error;
        }

        private void ComboBoxDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDivision.SelectedItem is Division division)
            {
                List<TechnicDivision> technicDivisions = FireDepartEntities.GetContext().TechnicDivisions.Where(p => p.DivisionId == division.DivisionId).ToList();
                List<Technic> technics = FireDepartEntities.GetContext().Technics.ToList();
                ComboBoxTechnics.ItemsSource = technics.Where(p => p.TechnicId == technicDivisions.FirstOrDefault(k => k.TechnicId == p.TechnicId)?.TechnicId).ToList();
            }
            
        }
    }
}
