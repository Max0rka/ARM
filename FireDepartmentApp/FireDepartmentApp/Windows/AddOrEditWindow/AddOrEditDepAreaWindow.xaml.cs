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
    /// Логика взаимодействия для AddOrEditDepAreaWindow.xaml
    /// </summary>
    public partial class AddOrEditDepAreaWindow : Window
    {
        private DepartureArea _currentDepArea = new DepartureArea();
        // текст, отображаемый в ComboBox
        //private string _comboText = "";
        //List<Division> divisions = FireDepartEntities.GetContext().Divisions.ToList();
        public AddOrEditDepAreaWindow(DepartureArea depArea, int settlementId)
        {
            InitializeComponent();
            if (depArea != null)
                _currentDepArea = depArea;
            _currentDepArea.SettlementId = settlementId;
            DataContext = _currentDepArea;
            //LoadComboBoxDivisions();
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
                if (_currentDepArea.DepartureAreaId == 0)
                    FireDepartEntities.GetContext().DepartureAreas.Add(_currentDepArea);
                FireDepartEntities.GetContext().SaveChanges();
                //SaveDivisionDepAreas();
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
            if (string.IsNullOrWhiteSpace(_currentDepArea.DepartureAreaName))
                error.AppendLine("Введите название района выезда");
            return error;
        }
        //private void LoadComboBoxDivisions()
        //{
        //    ComboBoxDivisions.ItemsSource = null;

        //    foreach (var i in divisions)
        //    {
        //        i.DivisionSelected = false;
        //        DivisionDepArea divDepArea = _currentDepArea.DivisionDepAreas.FirstOrDefault(p => p.DivisionId == i.DivisionId);
        //        if (divDepArea != null)
        //        {
        //            i.DivisionSelected = true;

        //        }

        //    }
        //    ComboBoxDivisions.ItemsSource = divisions;

        //}
        //private void SaveDivisionDepAreas()
        //{

        //    try
        //    {
        //        FireDepartEntities.GetContext().DivisionDepAreas.RemoveRange(_currentDepArea.DivisionDepAreas);
        //        List<DivisionDepArea> divisionDepArea = new List<DivisionDepArea>();
        //        foreach (var i in divisions)
        //        {
        //            if (i.DivisionSelected)
        //                divisionDepArea.Add(new DivisionDepArea
        //                {
        //                    DivisionId = i.DivisionId,
        //                    DepartureAreaId = _currentDepArea.DepartureAreaId
        //                }); ;
        //        }
        //        FireDepartEntities.GetContext().DivisionDepAreas.AddRange(divisionDepArea);
        //        FireDepartEntities.GetContext().SaveChanges();

        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        //}
    }
}
