using FireDepartmentApp.Entities;
using Microsoft.Xaml.Behaviors.Layout;
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
    /// Логика взаимодействия для AddOrEditDivisionWindow.xaml
    /// </summary>
    public partial class AddOrEditDivisionWindow : Window
    {
        private Division _currentDivision = new Division();
        // текст, отображаемый в ComboBox
        private string _comboText = "";
        List<Technic> technics = FireDepartEntities.GetContext().Technics.ToList();
        public AddOrEditDivisionWindow(Division division)
        {
            InitializeComponent();
            if (division != null)
                _currentDivision = division;
            DataContext = _currentDivision;
            LoadComboBoxTechincss();
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
                if (_currentDivision.DivisionId == 0)
                    FireDepartEntities.GetContext().Divisions.Add(_currentDivision);
                FireDepartEntities.GetContext().SaveChanges();
                // сохранение информации о технике подразделения
                SaveDivisionTechnics();
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
            if (string.IsNullOrWhiteSpace(_currentDivision.DivisionName))
                error.AppendLine("Введите название пожарной части");
            return error;
        }

        private void ComboBoxTechnics_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            Technic technic = e.Item as Technic;
            if (e.IsSelected)
            {
                //technic.TechnicSelected = true;
                ComboBoxTechnics.Text = _comboText += $"{technic.TechnicName} - {technic.TechnicCount} ед, ";
            }               
            else
            {
                ComboBoxTechnics.Text = _comboText = _comboText.Replace($"{technic.TechnicName} - {technic.TechnicCount} ед, ", "");
            }   
        }
        
        private void LoadComboBoxTechincss()
        {
            ComboBoxTechnics.Items.Clear();
            
            foreach (var i in technics)
            {
                i.TechnicSelected = false;
                i.TechnicCount = 1;
                if (_currentDivision.DivisionId != 0)
                {
                    TechnicDivision technicDiv = _currentDivision.TechnicDivisions.FirstOrDefault(p => p.TechnicId == i.TechnicId);
                    if (technicDiv != null)
                    {
                        i.TechnicSelected = true;
                        i.TechnicCount = technicDiv.CountTechnic;
                        _comboText += $"{i.TechnicName} - {i.TechnicCount} ед, ";
                    }
                }

            }            
            ComboBoxTechnics.ItemsSource = technics;
            ComboBoxTechnics.Text = _comboText;
        }
        private void SaveDivisionTechnics()
        {
            
            try
            {
                FireDepartEntities.GetContext().TechnicDivisions.RemoveRange(_currentDivision.TechnicDivisions);
                List<TechnicDivision> technicDivisions = new List<TechnicDivision>();
                foreach (var i in technics)
                {
                    if (i.TechnicSelected)
                        technicDivisions.Add(new TechnicDivision
                        {
                            TechnicId = i.TechnicId,
                            DivisionId = _currentDivision.DivisionId,
                            CountTechnic = (short)i.TechnicCount
                        });
                }
                FireDepartEntities.GetContext().TechnicDivisions.AddRange(technicDivisions);
                FireDepartEntities.GetContext().SaveChanges();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void TbTechnicCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsNumber(e.Text, 0);
        }
        //private void LoadComboBoxTechincs()
        //{
        //    ComboBoxTechnics.Items.Clear();
        //    ComboBoxTechnics.ItemsSource = FireDepartEntities.GetContext().Technics.ToList();
        //    List<Technic> selectedTechincs = new List<Technic>();
        //    if (_currentDivision.DivisionId != 0)
        //    {
        //        List<Technic> technics = ComboBoxTechnics.Items.Cast<Technic>().ToList();
        //        //foreach (var i in ComboBoxTechnics.SelectedItem)
        //        //{

        //        //}

        //        foreach (var i in technics)
        //        {
        //            i.TechnicSelected = false;
        //            if (_currentDivision.TechnicDivisions.FirstOrDefault(p => p.TechnicId == i.TechnicId) != null)
        //            {
        //                i.TechnicSelected = true;
        //                selectedTechincs.Add(i);
        //            }

        //        }
        //        //ComboBoxTechnics.SelectedItemsOverride = selectedTechincs;
        //        ComboBoxTechnics.ItemsSource = selectedTechincs;
        //    }
        //    ComboBoxTechnics.Text = _comboText;
        //}
    }
}
