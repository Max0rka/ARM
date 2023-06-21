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
    /// Логика взаимодействия для BarrelTypeWindow.xaml
    /// </summary>
    public partial class BarrelTypeWindow : Window
    {
        public BarrelTypeWindow()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditBarrelTypeWindow addOrEditBarrel = new AddOrEditBarrelTypeWindow(null);
            addOrEditBarrel.ShowDialog();
            Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBarrelTypes.SelectedItem is BarrelType barrelType)
            {
                AddOrEditBarrelTypeWindow addOrEditBarrel = new AddOrEditBarrelTypeWindow(barrelType);
                addOrEditBarrel.ShowDialog();
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
            DataGridBarrelTypes.ItemsSource = FireDepartEntities.GetContext().BarrelTypes.ToList();
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridBarrelTypes.SelectedItem is BarrelType barrelType)
            {
                try
                {
                    if (barrelType.FireInfoes.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().BarrelTypes.Remove(barrelType);
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
