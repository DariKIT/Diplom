using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zolotoy_telenok_0._1
{
    public partial class ZTDBEntities : DbContext
    {
        private static ZTDBEntities _Context;

        public static ZTDBEntities GetContext()
        {
            if (_Context == null)
                _Context = new ZTDBEntities();
            return _Context;
        }
    }
}
