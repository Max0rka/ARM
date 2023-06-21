using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FireDepartmentApp.Entities
{
    public partial class Technic
    {
        public BitmapImage TechnicPhoto
        {
            get
            {
                BitmapImage bitmapImage = new BitmapImage();
                if (TechnicImage != null)
                {
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new System.IO.MemoryStream(TechnicImage);
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
                return null;
            }
        }
        public int TechnicCount { get; set; } = 1;
        public int TechnicCountGeneral { get; set; }
        public static int AllTechnicCount { get; set; }
        public bool TechnicSelected { get; set; } = false;

        
    }
}
