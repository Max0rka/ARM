using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartmentApp.Entities
{
    public partial class FireDepartEntities
    {
        private static FireDepartEntities _context;
        public static FireDepartEntities GetContext()
        {
            if (_context == null )
                _context = new FireDepartEntities();
            return _context;
        }
    }
}
