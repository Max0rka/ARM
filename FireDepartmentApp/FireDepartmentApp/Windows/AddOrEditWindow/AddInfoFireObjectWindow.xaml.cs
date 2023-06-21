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
    /// Логика взаимодействия для AddInfoFireObjectWindow.xaml
    /// </summary>
    public partial class AddInfoFireObjectWindow : Window
    {
        public string FireInfo { get; set; }
        public AddInfoFireObjectWindow()
        {
            InitializeComponent();
            List<string> openObjects = new List<string>();
            foreach (var  i in ComboOpenObjects.Items)
                openObjects.Add(((ComboBoxItem)i).Content.ToString());
            openObjects = openObjects.OrderBy(p => p).ToList();
            ComboOpenObjects.Items.Clear();
            ComboOpenObjects.ItemsSource = openObjects;
        }

        private void TreeViewObjectInfo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
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
            FireInfo = "";
            foreach (string s in strings)
            {
                FireInfo += $"{s} - ";
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
            if (TreeViewObjectInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                FireInfo += treeViewItem.Header.ToString();
                Close();
            }

        }

        private void TVItemOpenObjects_Selected(object sender, RoutedEventArgs e)
        {
            SPanelOpenObject.Visibility = Visibility.Visible;
            BtnSave.Click += BtnSaveOpenObject;
        }

        private void TVItemOpenObjects_Unselected(object sender, RoutedEventArgs e)
        {
            SPanelOpenObject.Visibility = Visibility.Collapsed;
            BtnSave.Click -= BtnSaveOpenObject;
        }
        // ветка для мест открытого хранения вещест, материалов
        private void BtnSaveOpenObject(object sender, RoutedEventArgs e)
        {
            if (TreeViewObjectInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames(treeViewItem);
                FireInfo += $"{treeViewItem.Header.ToString()} - {ComboOpenObjects.SelectedItem}";
                Close();
            }

        }
        private void TVItemAllItem2_Selected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click += BtnSaveAllElements2;
        }

        private void TVItemAllItem2_Unselected(object sender, RoutedEventArgs e)
        {
            BtnSave.Click -= BtnSaveAllElements2;
        }
        private void TVItemHeaderNames2(TreeViewItem treeViewItem)
        {
            List<string> strings = new List<string>();
            var objectParent = treeViewItem.Parent;
            while (objectParent is TreeViewItem parent)
            {
                strings.Add(parent.Header.ToString());
                objectParent = parent.Parent;
            }
            if (strings.Count > 0)
                strings.RemoveAt(0);
            strings.Reverse();
            FireInfo = "";
            foreach (string s in strings)
            {
                FireInfo += $"{s} - ";
            }
        }
        // ветка для вложенных элементов
        private void BtnSaveAllElements2(object sender, RoutedEventArgs e)
        {
            if (TreeViewObjectInfo.SelectedItem is TreeViewItem treeViewItem)
            {
                TVItemHeaderNames2(treeViewItem);
                //string treeViewItemParentHeader = (treeViewItem.Parent as TreeViewItem)?.Header.ToString() ?? "";
                //FireInfo = FireInfo.Replace(treeViewItemParentHeader, "");
                FireInfo += treeViewItem.Header.ToString();
                Close();
            }

        }
    }
}
