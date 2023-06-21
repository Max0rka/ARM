using FireDepartmentApp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddOrEditFireInfoWindow.xaml
    /// </summary>
    public partial class AddOrEditFireInfoWindow : Window
    {
        private FireInfo _currentFireInfo = new FireInfo();
        private Departure _currentDepart = new Departure();
        List<Subdivision> subdivisions;
        public AddOrEditFireInfoWindow(FireInfo fireInfo, Departure departure)
        {
            InitializeComponent();
            if (fireInfo != null)
            {
                _currentFireInfo = fireInfo;
            }
            else
            {
                _currentFireInfo.DateTimeEntry = DateTime.Now;
                
            }
            _currentFireInfo.DepartureId = departure.DepartureId;    
            _currentDepart = departure;

            DataContext = _currentFireInfo;
            ComboBoxBroadcasts.ItemsSource = FireDepartEntities.GetContext().Broadcasts.ToList();
            ComboBoxMissionTypes.ItemsSource = FireDepartEntities.GetContext().MissionTypes.ToList();
            ComboBoxWorkAreas.ItemsSource = FireDepartEntities.GetContext().WorkAreas.ToList();
            ComboBoxBarrelTypes.ItemsSource = FireDepartEntities.GetContext().BarrelTypes.ToList();
            ComboBoxCombatAreas.ItemsSource = FireDepartEntities.GetContext().CombatAreas.ToList();
            subdivisions = FireDepartEntities.GetContext().Subdivisions.Where(p => p.DepartureAreaId == _currentDepart.DepartureArea.DepartureAreaId).ToList();
            //subdivisions = _currentDepart.DepartureSubdivisions..ToList();
            LoadComboBoxSubdivisions();
        }
        private void LoadComboBoxSubdivisions()
        {
            ComboSubdivisions.Items.Clear();

            foreach (var i in subdivisions)
            {
                i.SubdivisionSelected = false;
                //if (_currentFireInfo.FireInfoId != 0)
                //{
                //    FireInfoSubdivision fireInfoSubd = _currentFireInfo.FireInfoSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                //    if (fireInfoSubd != null)
                //    {
                //        i.SubdivisionSelected = true;
                //    }
                //}
                FireInfoSubdivision fireInfoSubd = _currentFireInfo.FireInfoSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                if (fireInfoSubd != null)
                {
                    i.SubdivisionSelected = true;
                }
            }
            ComboSubdivisions.ItemsSource = subdivisions;
        }
        private void SaveFireInfoSubdivisions()
        {

            try
            {
                if (_currentFireInfo.FireInfoId != 0)
                    FireDepartEntities.GetContext().FireInfoSubdivisions.RemoveRange(_currentFireInfo.FireInfoSubdivisions);
                _currentFireInfo.FireInfoSubdivisions.Clear();
                List<FireInfoSubdivision> fireInfoSubdivisions = new List<FireInfoSubdivision>();
                foreach (var i in subdivisions)
                {
                    if (i.SubdivisionSelected)
                        _currentFireInfo.FireInfoSubdivisions.Add(new FireInfoSubdivision
                        {
                            FireInfoId = _currentFireInfo.FireInfoId,
                            FireInfo = _currentFireInfo,
                            SubdivisionId = i.SubdivisionId,
                            Subdivision = i
                        });
                }
                //FireDepartEntities.GetContext().FireInfoSubdivisions.AddRange(fireInfoSubdivisions);
                FireDepartEntities.GetContext().SaveChanges();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //StringBuilder error = CheckField();
                //if (error.Length > 0)
                //{
                //    MessageBox.Show(error.ToString());
                //    return;
                //}
                if (_currentFireInfo.FireInfoId == 0)
                {
                    
                    _currentDepart.FireInfoes.Add(_currentFireInfo);
                }
                SaveFireInfoSubdivisions();
                DialogResult = true;
                Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = true;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
           
        }

        private void BtnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            AddInfoPlaceWindow addInfoPlaceWindow = new AddInfoPlaceWindow(_currentFireInfo);
            addInfoPlaceWindow.ShowDialog();
            TbInfoPlace.Text = _currentFireInfo.InfoPlace;
            TbWorkVariety.Text = _currentFireInfo.WorkVariety;
        }

        private void TbBarrelCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsNumber(e.Text, 0);
        }
    }
}
