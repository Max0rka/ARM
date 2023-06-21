using FireDepartmentApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddOrEditTechnicWindow.xaml
    /// </summary>
    public partial class AddOrEditTechnicWindow : Window
    {
        private Technic _currentTechnic = new Technic();
        public AddOrEditTechnicWindow(Technic technic)
        {
            InitializeComponent();
            if (technic != null)
                _currentTechnic = technic;
            DataContext = _currentTechnic;
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog() { Title = "Выберите фотографию", Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;" };
                if (op.ShowDialog() == true)
                {
                    TechnicImage.Source = new BitmapImage(new Uri(op.FileName));
                    Stream stream = File.OpenRead(op.FileName);
                    byte[] binaryImage = new byte[stream.Length];
                    stream.Read(binaryImage, 0, (int)stream.Length);
                    _currentTechnic.TechnicImage = binaryImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (_currentTechnic.TechnicId == 0)
                    FireDepartEntities.GetContext().Technics.Add(_currentTechnic);
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
            if (string.IsNullOrWhiteSpace(_currentTechnic.TechnicName))
                error.AppendLine("Введите название техники");
            return error;
        }
    }
}
