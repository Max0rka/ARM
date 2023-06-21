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
    /// Логика взаимодействия для AddInfoCauseWindow.xaml
    /// </summary>
    public partial class AddInfoCauseWindow : Window
    {
        public string CauseInfo { get; set; }
        public AddInfoCauseWindow()
        {
            InitializeComponent();
        }

        private void TreeViewCauseInfo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem treeViewItem && treeViewItem.Items.Count == 0)
            {
                BtnSave.IsEnabled = true;
            }
            else
                BtnSave.IsEnabled = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void TVItemHeaderNames(TreeViewItem treeViewItem)
        {
            List<string> strings = new List<string>();
            var objectParent = treeViewItem.Parent;
            while (objectParent is TreeViewItem parent)
            {
                strings.Add(parent.Header.ToString());
                objectParent = parent.Parent;
            }
            strings.Reverse();
            CauseInfo = "";
            foreach (string s in strings)
            {
                CauseInfo += $"{s} - ";
            }
        }
        private void TVItemAllItem_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSaveAllElements;
        }

        private void TVItemAllItem_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSaveAllElements;
        }
        // ветка для вложенных элементов
        private void BtnSaveAllElements(object sender, RoutedEventArgs e)
        {
            if (TreeViewCauseInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                CauseInfo += treeViewItem.Header.ToString();
                Close();
            }

        }

    }
}
