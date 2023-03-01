using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.AddonName.BO
{
    public class Detalle
    {
        public string U_VIS_Cate { get; set; }
        public string U_VIS_Serie { get; set; }
        public string U_VIS_Estado { get; set; }
        public string U_VIS_FechaEntrega { get; set; }
        public string U_VIS_FotoAsignacion { get; set; }
        public string U_VIS_Observacion { get; set; }
        public object U_VIS_Archivo { get; set; }
        public string U_VIS_Modelo { get; set; }
        public object U_VIS_ID_Modelo { get; set; }
        public string U_VIS_FechaFinalizacion { get; set; }
        public string U_VIS_Est_Alm { get; set; }
    }
    public class VISASIGIS1Collection
    {
        public string LineId { get; set; }
        public string U_VIS_Estado { get; set; }
    }
}
