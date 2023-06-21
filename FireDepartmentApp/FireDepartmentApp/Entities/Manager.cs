using FireDepartmentApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FireDepartmentApp.Entities
{
    public class Manager
    {
        public static Frame MainFrame { get; set; }
        public static AddDeparturePage AddDeparturePage { get; set; }
        // флаг, открыт ли справочник
        public static bool IsDirectory { get; set; } = false; 
        // флаг, открыта ли страница добавления, редактирования
        public static bool IsOpenAddPage { get; set; } = true; 
    }
}
