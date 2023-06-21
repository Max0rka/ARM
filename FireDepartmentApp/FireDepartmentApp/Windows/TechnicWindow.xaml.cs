using FireDepartmentApp.Entities;
using FireDepartmentApp.Windows.AddOrEditWindow;
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

namespace FireDepartmentApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechnicWindow.xaml
    /// </summary>
    public partial class TechnicWindow : Window
    {
        public TechnicWindow()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditTechnicWindow addOrEditTechnic = new AddOrEditTechnicWindow(null);
            addOrEditTechnic.ShowDialog();
            Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridTechnic.SelectedItem is Technic technic)
            {
                AddOrEditTechnicWindow addOrEditTechnic = new AddOrEditTechnicWindow(technic);
                addOrEditTechnic.ShowDialog();
                Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FireDepartEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridTechnic.ItemsSource = FireDepartEntities.GetContext().Technics.ToList();
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridTechnic.SelectedItem is Technic technic)
            {
                try
                {
                    if (technic.TechnicDivisions.Count > 0 || technic.Subdivisions.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().Technics.Remove(technic);    
                    FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDellAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить все записи?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // сделать проверку всех записей
            //if (result == MessageBoxResult.Yes && )
            //{
            //    try
            //    {
            //        //if (positionType.Specialties.Count > 0)
            //        //    throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
            //        FireDepartEntities.GetContext().PositionTypes.Remove(positionType);
            //        FireDepartEntities.GetContext().SaveChanges();
            //        MessageBox.Show("Запись удалена!");
            //        Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
        }
    }
}
