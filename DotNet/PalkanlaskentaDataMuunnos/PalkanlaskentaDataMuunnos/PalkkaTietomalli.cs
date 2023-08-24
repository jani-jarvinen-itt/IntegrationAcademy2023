using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalkanlaskentaDataMuunnos
{
    public class PalkkaTietomalli
    {
        public string personName { get; set; }
        public Salary salary { get; set; }
        public string hireDate { get; set; }
    }

    public class Salary
    {
        public float monthly { get; set; }
    }
}
