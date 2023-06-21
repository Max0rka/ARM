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
    /// Логика взаимодействия для AlignmentFoceWindow.xaml
    /// </summary>
    public partial class AlignmentFoceWindow : Window
    {
        public AlignmentFoceWindow()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditAlignmentWinow addOrEditAlignmentWinow = new AddOrEditAlignmentWinow(null);
            addOrEditAlignmentWinow.ShowDialog();
            Window_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridAlignmentFoces.SelectedItem is AlignmentFoce alignmentFoce)
            {
                AddOrEditAlignmentWinow addOrEditAlignmentWinow = new AddOrEditAlignmentWinow(alignmentFoce);
                addOrEditAlignmentWinow.ShowDialog();
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
            DataGridAlignmentFoces.ItemsSource = FireDepartEntities.GetContext().AlignmentFoces.ToList();
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridAlignmentFoces.SelectedItem is AlignmentFoce alignmentFoce)
            {
                try
                {
                    //if (positionType.Specialties.Count > 0)
                    //    throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    FireDepartEntities.GetContext().AlignmentFoces.Remove(alignmentFoce);
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

    }
}
