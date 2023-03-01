using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.AddonName.BO
{
    public class Cabecera
    {
        public string Code { get; set; }
        public string U_VIS_Name { get; set; }
        public int U_VIS_Code_OHEM { get; set; }
        public List<Detalle> VIS_ASIG_IS1Collection { get; set; }
    }

    public class CabeceraUpdate
    {
        public string Code { get; set; }
        public List<VISASIGIS1Collection> VIS_ASIG_IS1Collection { get; set; }
    }


}
