using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zolotoy_telenok_0._1
{
    using System;
    using System.Collections.Generic;

    public partial class Работник
    {
        public string Worker
        {
            get 
            { 
                return Фамилия + " " + Имя;
            }
        }
    }
}