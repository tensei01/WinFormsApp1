using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Context
    {
        public static List<MorderRow> _data { get; set; }


        public void clear() { 
            _data.Clear();
        }

    }
}
