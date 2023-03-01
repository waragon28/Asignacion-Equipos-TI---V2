using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.AddonName.BO;
using Vistony.AddonName.DAL;

namespace Vistony.AddonName.BLL
{
    public class AsignacionHEM11_BO
    {

        AsignacionHEM11 AsignacionHEM11 = new AsignacionHEM11();

        /**/
        public SAPbouiCOM.DataTable GetSerieAcivos(string Query, SAPbouiCOM.DataTable oDT)
        {
            try
            {
               return AsignacionHEM11.GetSerieAcivos(Query, oDT);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool StockModeloEquipo(string MODELO, Recordset recordset, StaticText Stock)
        {
            try
            {
                return AsignacionHEM11.StockModeloEquipo(MODELO, recordset, Stock);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void GetLineAsignacion(Recordset recordset, string Query, ComboBox ComboBox0,
                                                ComboBox ComboBox2, EditText EditText0, 
                                                ComboBox ComboBox1, EditText EditText3,
                                                EditText EditText4, Button Button5,
                                                StaticText StaticText12, EditText EditText8, EditText EditText9)
        {
            try
            {
                 AsignacionHEM11.GetLineAsignacion(recordset, Query,ComboBox0, ComboBox2, 
                     EditText0, ComboBox1, EditText3, EditText4, Button5, StaticText12, EditText8,EditText9);
            }
            catch (Exception)
            {
                
            }
        }
        public Cabecera AgregarCabeceraAsignacionTI(int EmpleadoID, string NombreEmpleado, string Categoria, string Cod_Modelo,
                                            string Modelo, string Serie, string EstadoAsignacion, string FotoAsignacion,
                                            string Observaciones,string FechaAsignacion,string FechaFinalizacion)
        {
            try
            {
               return  AsignacionHEM11.AgregarCabeceraAsignacionTI(EmpleadoID, NombreEmpleado, Categoria, Cod_Modelo,
                                             Modelo, Serie, EstadoAsignacion, FotoAsignacion, Observaciones, FechaAsignacion, FechaFinalizacion);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Cabecera ActualizarCabeceraAsignacionTI(string Code, int EmpleadoID, string NombreEmpleado, string Categoria, string Cod_Modelo,
                                                 string Modelo, string Serie, string EstadoAsignacion, string FotoAsignacion, string Observaciones, 
                                                 string FechaAsignacion,string FechaFinalizacion)
        {
            try
            {
                return AsignacionHEM11.ActualizarCabeceraAsignacionTI(Code,EmpleadoID, NombreEmpleado, Categoria, Cod_Modelo,
                                            Modelo, Serie, EstadoAsignacion, FotoAsignacion, Observaciones,FechaAsignacion, FechaFinalizacion);
            }
            catch (Exception)
            {

                return null;
            }
        }
        /*===========================================================*/

        public void EnviarCorreoOffice365(SAPbouiCOM.Form oForm, string Notificacion, string DT, 
            string Asunto_Correo, string Cuerpo_Correo)
        {
            //AsignacionHEM11.EnviarCorreoOffice365(oForm, Notificacion, DT, Asunto_Correo, Cuerpo_Correo);
        }
        public void EnviarCorreoOffice365_Static(SAPbouiCOM.Form oForm, Recordset recordset,string DocNum, string Notificacion, string DT,
            string Asunto_Correo, string Cuerpo_Correo)
        {
            
        }
        public void EnviarCorreoOffice365_StaticUpdate(SAPbouiCOM.Form oForm, Recordset recordset,
                      string DocNum, string Notificacion, string DT, string DT2)
        {
            AsignacionHEM11.EnviarCorreoOffice365_StaticUpdate(oForm, recordset, DocNum, Notificacion, DT, DT2);

        }
        public void EnviarCorreoOffice365_Static_Aprobador(SAPbouiCOM.Form oForm, Recordset recordset, string DocNum, 
            string Notificacion, string DT, string DT2,
           string Asunto_Correo,string Solicitante,string Empelado,string MotivoAsignacion)
        {
            AsignacionHEM11.EnviarCorreoOffice365_Static_Aprobador(oForm, recordset, DocNum, Notificacion, DT, 
                DT2, Asunto_Correo, Solicitante, Empelado, MotivoAsignacion);
        }

        public List<Usuario_Notificacion_Entrega> ListaUsuariosEntrega_TI(SAPbouiCOM.Form oForm, SAPbouiCOM.DataTable oDatatable, string DT)
        {
            return AsignacionHEM11.ListaUsuariosEntrega_TI(oForm, oDatatable, DT);
        }
        public bool ValidarObtenerUltimoDocNum(Recordset recordset, EditText EditText4)
        {
            return AsignacionHEM11.ValidarObtenerUltimoDocNum(recordset, EditText4);
        }
        public void ValidarObtenerJefeDepart(Recordset recordset, string Usuario, EditText EditText7)
        {
             AsignacionHEM11.ValidarObtenerJefeDepart(recordset, Usuario, EditText7);
        }
        public void ObtenerSolicitudesGeneradas(SAPbouiCOM.DataTable oDatatable, SAPbouiCOM.Grid Grid1, SAPbouiCOM.Form oForm,
                                               string U_VIS_Cod_OHEM, string DocNum, string DT)
        {
            AsignacionHEM11.ObtenerSolicitudesGeneradas(oDatatable, Grid1, oForm, U_VIS_Cod_OHEM, DocNum, DT);
        }
        public bool ObtenerSolicitudAsignacion(Recordset recordset, string U_VIS_Cod_OHEM)
        {
            return AsignacionHEM11.ObtenerSolicitudAsignacion(recordset, U_VIS_Cod_OHEM);
        }
        public Alert.Messagedataline Messagedataline(string Object, string ObjectKey, string Value)
        {
            return AsignacionHEM11.Messagedataline(Object, ObjectKey, Value);
        }
        public Alert.Recipientcollection Recipientcollection(string SendInternal, string UserCode)
        {
            return AsignacionHEM11.Recipientcollection(SendInternal, UserCode);
        }
        public Cabecera ObtenerCabecera(SAPbouiCOM.Matrix Mtx, string Name, int U_VIS_Code_OHEM, string Accion, string Code_Cabecera, Recordset recordset)
        {
            return AsignacionHEM11.ObtenerCabecera(Mtx, Name, U_VIS_Code_OHEM, Accion, Code_Cabecera, recordset);
        }
        public CabeceraURL ObtenerCabeceraURL(SAPbouiCOM.Matrix Mtx, string U_VIS_Code_OHEM)
        {
            return AsignacionHEM11.ObtenerCabeceraURL(Mtx, U_VIS_Code_OHEM);
        }
        public CabeceraUpdate ActualizarEstadoObjetAsignaconCabecera(string Code, string LineId, string U_VIS_Estado)
        {
            return AsignacionHEM11.ActualizarEstadoObjetAsignaconCabecera(Code, LineId, U_VIS_Estado);
        }
        public void ValidarAsignaciones(Recordset recordset, string Code, EditText ValidacionAsignaicon, EditText Code_Cabecera)
        {
            AsignacionHEM11.ValidarAsignaciones(recordset, Code, ValidacionAsignaicon, Code_Cabecera);
        }
        public void ChooseFromList_Num_Soli(SAPbouiCOM.Form oForm, string CFL_, string Alias1, string condicion1)
        {
            AsignacionHEM11.ChooseFromList_Num_Soli(oForm,  CFL_, Alias1, condicion1);
        }
        public void ObtenerInfoUsuLog(Recordset recordset,string usu, EditText EditText3)
        {
            AsignacionHEM11.ObtenerInfoUsuLog(recordset,usu,EditText3);
        }
        public bool ObtenerInfoUsuLogPerfil(Recordset recordset, string Usu)
        {
            return AsignacionHEM11.ObtenerInfoUsuLogPerfil(recordset, Usu);
        }
        public bool ValidarSeriesEquipos(Recordset recordset, string Modelo, string Serie)
        {
            return AsignacionHEM11.ValidarSeriesEquipos(recordset, Modelo, Serie);
        }
        public bool ValidarAsignacionesSeriesEquipos(Recordset recordset, string Serie, string Code)
        {
            return AsignacionHEM11.ValidarAsignacionesSeriesEquipos(recordset, Serie, Code);
        }
        public void ChooseFromList_Activos(SAPbouiCOM.Form oForm, string CFL_, string Alias, string condicion)
        {
            AsignacionHEM11.ChooseFromList_Activos(oForm, CFL_, Alias, condicion);
        }
        public void ChooseFromList_Emp_Diferente(SAPbouiCOM.Form oForm, string CFL_, string Alias, string condicion)
        {
            AsignacionHEM11.ChooseFromList_Emp_Diferente(oForm, CFL_, Alias, condicion);
        }
        public void ValidarObtenerUsuarioUD(Recordset recordset, string Usuario, EditText EditText5)
        {
            AsignacionHEM11.ValidarObtenerUsuarioUD(recordset, Usuario, EditText5);
        }
        public void ValidarObtenerUsuarioSolicitante(Recordset recordset, string Usuario, EditText EditText5)
        {
            AsignacionHEM11.ValidarObtenerUsuarioSolicitante(recordset, Usuario, EditText5);
        }
        public void ValidarObtenerCodUser(Recordset recordset, string Usuario, EditText EditText5)
        {
            AsignacionHEM11.ValidarObtenerCodUser(recordset, Usuario, EditText5);
        }
        public void CargarAsignaciones(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix,string CodeOHEM)
        {
            AsignacionHEM11.CargarAsignaciones(oForm, oMatrix, CodeOHEM);
        }
        public void CargarAsignacionesAlmacen(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string CodeOHEM)
        {
            AsignacionHEM11.CargarAsignacionesAlmacen(oForm, oMatrix, CodeOHEM);
        }
        public bool Layout_Preview(string ReportName, string IDEmp, Recordset oRS)
        {
            return AsignacionHEM11.Layout_Preview(ReportName, IDEmp, oRS);
        }
        public bool ValidarSolicitudRequerimiento(Recordset recordset, string idEmpleado,EditText EditText2)
        {
            return AsignacionHEM11.ValidarSolicitudRequerimiento(recordset, idEmpleado, EditText2);
        }
        public bool ValidarSolicitudAsignacion(Recordset recordset, string DocNum, string U_VIS_Categoria, EditText EditText1)
        {
            return AsignacionHEM11.ValidarSolicitudAsignacion(recordset, DocNum, U_VIS_Categoria,EditText1);
        }
    }

}
