using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.AddonName.UI.Constans
{
    public class AddonMessageInfo
    {

        public const string AddonName = "Interfaz Solicitud de Requerimientos ";

        public const string SAPNotRunning = AddonName + "SAP Business One, no se encuentra corriendo ";
        
        public const string StartLoading = AddonName + "Iniciando Carga ..." ;
        public const string FinishLoading = AddonName + "Carga Finalizada ...";
        public const string Message006 = AddonName+" : Se genero la Asignacion ";


        public const string Message007 = AddonName+" : Error al Obtener la informacion del Empleado. ";
        public const string Message008= AddonName+" : Verifique  que la serie {0} no este asignado a otro empleado";
        public const string Message009 = AddonName+" : Datos insuficientes";
        public const string Message010 = AddonName+" : La serie {0} ya esta asignada a otro empleado";
        public const string Message011 = AddonName+" : La serie {0} Incorrecta";
        public const string Message012 = AddonName+" : Error al Actualizar Datos";
        public const string Message013 = AddonName+ " : Se Asigno correctamente";

        public const string QueryListValoresValidos = "CALL P_VIS_LIST_VALORES_VALIDOS('{0}','{1}')";
        public const string QueryListCategoriaActivos = "CALL P_VIS_LIST_CATEGORIA_ACTIVOS()";
        public const string QueryListModeloActivos = "CALL P_VIS_LIST_MODELO_ACTIVOS('{0}')";
        public const string QueryListModelo_Serie_Activos = "CALL P_VIS_LIST_MODELO_SERIE_ACTIVOS('{0}')";
        public const string QueryListStock_Modelo_Serie_Activos = "CALL P_VIS_LIST_STOCK_MODELO_SERIE_ACTIVOS('{0}')";
        public const string QueryListAsignacionesOHEM= "CALL P_VIST_ASIGNACIONES_OHEM('{0}')";
        public const string QueryGetAsignacionLine= "CALL P_VIST_GET_ASIGNACION_LINE('{0}')";
        
    }// fin de la clase


}// fin del namespace
