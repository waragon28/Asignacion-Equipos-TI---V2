using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Newtonsoft.Json;
using RestSharp;
using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vistony.AddonName.BO;

namespace Vistony.AddonName.DAL
{
    public class AsignacionHEM11
    {

        /**/
        public SAPbouiCOM.DataTable GetSerieAcivos(string Query,SAPbouiCOM.DataTable oDT)
        {
            try
            {
                string StrHANA = Query;
                oDT.ExecuteQuery(StrHANA);
                return oDT;
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                return null;
            }
        }
        public bool StockModeloEquipo(string MODELO, Recordset recordset, StaticText Stock)
        {
            bool Rspt = false;
            string StrHANA = string.Format("CALL P_VIS_LIST_STOCK_MODELO_SERIE_ACTIVOS('{0}')", MODELO);
            recordset.DoQuery(StrHANA);
            Stock.Caption = "Stock : "+recordset.Fields.Item("Stock").Value.ToString();
            return Rspt;

        }

        public void GetLineAsignacion(Recordset recordset,string Query, ComboBox ComboBox0,
                                                ComboBox ComboBox2, EditText EditText0, 
                                                ComboBox ComboBox1, EditText EditText3,
                                                EditText EditText4, Button Button5,
                                                StaticText StaticText12, EditText EditText08, EditText EditText9)
        {
            string strSQL = Query;
            recordset.DoQuery(strSQL);
            ComboBox0.Select(recordset.Fields.Item("Categoria").Value.ToString(), BoSearchKey.psk_ByValue);
            ComboBox2.Select(recordset.Fields.Item("Modelo").Value.ToString(), BoSearchKey.psk_ByDescription);
            EditText0.Value = recordset.Fields.Item("Serie").Value.ToString();
            ComboBox1.Select(recordset.Fields.Item("Estado").Value.ToString(), BoSearchKey.psk_ByDescription);
            EditText3.Value = recordset.Fields.Item("Foto de Asignacion").Value.ToString();
            EditText4.Value = recordset.Fields.Item("Observacion").Value.ToString();
            StaticText12.Caption = recordset.Fields.Item("LineId").Value.ToString();
            EditText08.Value = recordset.Fields.Item("Fecha Entrega").Value.ToString();
            EditText9.Value = recordset.Fields.Item("U_VIS_FechaFinalizacion").Value.ToString();
            Button5.Caption= "Actualizar";
            if (EditText0.Value != "")
            {
                Button5.Item.Enabled = true;
            }
        }
        public Cabecera AgregarCabeceraAsignacionTI(int EmpleadoID,string NombreEmpleado,string Categoria,string Cod_Modelo,
                                                    string Modelo,string Serie,string EstadoAsignacion,string FotoAsignacion,
                                                    string Observaciones,string FechaAsignacion,string FechaFinalizacion)
        {
            List<Cabecera> Cabecera = new List<Cabecera>();
            Cabecera TransferDocument = new Cabecera();
            Guid code = Guid.NewGuid();
            TransferDocument.Code = code.ToString();
            TransferDocument.U_VIS_Name = NombreEmpleado;
            TransferDocument.U_VIS_Code_OHEM = EmpleadoID;
            TransferDocument.VIS_ASIG_IS1Collection = AgregarDetalle(Categoria,  Cod_Modelo,Modelo,  Serie,  
                EstadoAsignacion, FotoAsignacion, Observaciones, FechaAsignacion, FechaFinalizacion);
            return TransferDocument;
        }
        public List<Detalle> AgregarDetalle(string Categoria, string Cod_Modelo,
                                                    string Modelo, string Serie, string EstadoAsignacion, string FotoAsignacion, 
                                                    string Observaciones,string FechaAsignacion,string FechaFinalizacion)
        {
            List<Detalle> DetalleDocumentDetalls = new List<Detalle>();

            Detalle Detalle_ClassDocumentDetalls = new Detalle();
            Detalle_ClassDocumentDetalls.U_VIS_Cate = Categoria; /**/
            Detalle_ClassDocumentDetalls.U_VIS_ID_Modelo = Cod_Modelo; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Modelo = Modelo; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Serie= Serie; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Estado= EstadoAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_FotoAsignacion= FotoAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_FechaEntrega= FechaAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Observacion = Observaciones; /**/
            Detalle_ClassDocumentDetalls.U_VIS_FechaFinalizacion = FechaFinalizacion; /**/

            DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);

            return DetalleDocumentDetalls;
        }


        public Cabecera ActualizarCabeceraAsignacionTI(string Code ,int EmpleadoID, string NombreEmpleado, string Categoria, string Cod_Modelo,
                                                   string Modelo, string Serie, string EstadoAsignacion, string FotoAsignacion, string Observaciones,
                                                   string FechaAsignacion,string FechaFinalizacion)
        {
            List<Cabecera> Cabecera = new List<Cabecera>();
            Cabecera TransferDocument = new Cabecera();
            TransferDocument.Code = Code;
            TransferDocument.U_VIS_Name = NombreEmpleado;
            TransferDocument.U_VIS_Code_OHEM = EmpleadoID;
            TransferDocument.VIS_ASIG_IS1Collection = ActualizarDetalle(Categoria, Cod_Modelo, Modelo, Serie, EstadoAsignacion, 
                FotoAsignacion, Observaciones, FechaAsignacion, FechaFinalizacion);
            return TransferDocument;
        }

        public List<Detalle> ActualizarDetalle(string Categoria, string Cod_Modelo,
                                                   string Modelo, string Serie, string EstadoAsignacion, 
                                                   string FotoAsignacion, string Observaciones, 
                                                   string FechaAsignacion,string FechaFinalizacion)
        {
            List<Detalle> DetalleDocumentDetalls = new List<Detalle>();

            Detalle Detalle_ClassDocumentDetalls = new Detalle();
            Detalle_ClassDocumentDetalls.U_VIS_Cate = Categoria; /**/
            Detalle_ClassDocumentDetalls.U_VIS_ID_Modelo = Cod_Modelo; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Modelo = Modelo; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Serie = Serie; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Estado = EstadoAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_FotoAsignacion = FotoAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_Observacion = Observaciones; /**/

            Detalle_ClassDocumentDetalls.U_VIS_FechaEntrega = FechaAsignacion; /**/
            Detalle_ClassDocumentDetalls.U_VIS_FechaFinalizacion = FechaFinalizacion; /**/
            
            DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);

            return DetalleDocumentDetalls;
        }

        /*=========================================================*/

        int U_VIS_Code_HEM;
        public List<Usuario_Notificacion_Entrega> ListaUsuariosEntrega_TI(SAPbouiCOM.Form oForm, SAPbouiCOM.DataTable oDatatable,string DT)
        {
            List<Usuario_Notificacion_Entrega> DetalleDocumentDetalls = new List<Usuario_Notificacion_Entrega>();

            string StrHANA = string.Format("CALL P_VIS_OBTENER_LIST_USU_ASIGNACION()");
            oDatatable = oForm.DataSources.DataTables.Item(DT);
            oDatatable.ExecuteQuery(StrHANA);
            for (int i = 0; i < oDatatable.Rows.Count; i++)
            {
                Detalle Detalle_ClassDocumentDetalls = new Detalle();
              //  Detalle_ClassDocumentDetalls.U_VIS_Cate = Mtx.GetValueFromEditText("Col_7", oRows + 1); /**/

              //  DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);
            }


            return DetalleDocumentDetalls;
        }
        public void ObtenerSolicitudes(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string CodeOHEM)
        {
            SAPbouiCOM.DataTable udt;

            string strHANA = string.Format("CALL P_VIST_ASIGNACIONES_OHEM('{0}')", CodeOHEM);
            udt = oForm.DataSources.DataTables.Item("DT_0");
            udt.ExecuteQuery(strHANA);
            oMatrix = oForm.GetMatrix("Item_0");

            SAPbouiCOM.Columns oColumns;
            oColumns = oMatrix.Columns;
            var colItems = udt.Columns;
            // SAPbouiCOM.Column oColumn;
            oColumns = oMatrix.Columns;

            for (int oRows = 0; oRows < udt.Rows.Count; oRows++)
            {
                SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource("@VIS_ASIG_IS1");
                int rowCount = 0;

                rowCount = oDatasource.Offset;

                rowCount = rowCount + 1;

                oDatasource.InsertRecord(oDatasource.Size);
                oDatasource.Offset = oDatasource.Size - 1;

                oDatasource.SetValue("Code", oRows, udt.GetString("Code", oRows));

                oDatasource.SetValue("U_VIS_Cate", oRows, udt.GetString("U_VIS_Cate", oRows));
                oDatasource.SetValue("U_VIS_Serie", oRows, udt.GetString("U_VIS_Serie", oRows));
                oDatasource.SetValue("U_VIS_Estado", oRows, udt.GetString("U_VIS_Estado", oRows));

                oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));
                oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));

                // object AA = udt.GetString("U_VIS_Num_Req", oRows);
                // if (AA != null ||Convert.ToString(AA)!="") { 
                oDatasource.SetValue("U_VIS_Num_Req", oRows, udt.GetString("U_VIS_Num_Req", oRows));
                // }

                string U_VIS_FechaEntrega = udt.GetString("U_VIS_FechaEntrega", oRows);
                if (U_VIS_FechaEntrega == "")
                {

                }
                oDatasource.SetValue("U_VIS_FechaEntrega", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaEntrega", oRows)).ToString("yyyyMMdd"));

                //oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));
                if (udt.GetString("U_VIS_Estado", oRows) == "D")
                {
                    oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));

                }

                string URL = ConfigurationManager.AppSettings["URL"].ToString();

                if (udt.GetString("U_VIS_Archivo", oRows) != "" || udt.GetString("U_VIS_Archivo", oRows) != null)
                {
                    //U_VIS_Code_OHEM + Mtx.GetValueFromEditText("Col_1", oRows + 1) /*Serie*/ + Mtx.GetValueFromEditText("Col_3", oRows + 1);/*ID UNICO*/
                    oDatasource.SetValue("U_VIS_FotoAsignacion", oRows, URL + CodeOHEM + udt.GetString("U_VIS_Serie", oRows) + Convert.ToDateTime(udt.GetString("U_VIS_FechaEntrega", oRows)).ToString("yyyyMMdd"));
                }



                oDatasource.SetValue("LineId", oRows, udt.GetString("LineId", oRows));

                // string U_VIS_FechaFinalizacion = udt.GetString("U_VIS_FechaFinalizacion", oRows).ToString();

                oDatasource.SetValue("U_VIS_Observacion", oRows, udt.GetString("U_VIS_Observacion", oRows));
                oDatasource.SetValue("U_VIS_Archivo", oRows, udt.GetString("U_VIS_Archivo", oRows));
                oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));
                oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));

                oDatasource.SetValue("U_VIS_Est_Alm", oRows, udt.GetString("U_VIS_Est_Alm", oRows));

                oMatrix.Columns.Item("Col_2").Editable = false;
                oMatrix.Columns.Item("Col_11").Visible = false;
                // oMatrix.Columns.Item("Col_2").Editable = false;

                oMatrix.LoadFromDataSource();
            }
            oMatrix.LoadFromDataSource();
            oMatrix.AutoResizeColumns();
            oMatrix.AssignLineNro();


        }
        public void ObtenerSolicitudesGeneradas(SAPbouiCOM.DataTable oDatatable, SAPbouiCOM.Grid Grid1, SAPbouiCOM.Form oForm,
                                                string U_VIS_Cod_OHEM,string DocNum, string DT)
        {
            try
            {
                string strHANA = "";
                strHANA = string.Format(" CALL P_VIST_OBTENER_SOLICITUD_ASIGNACIONES('{0}','{1}')", U_VIS_Cod_OHEM,DocNum);
                oDatatable = oForm.DataSources.DataTables.Item(DT);
                oDatatable.ExecuteQuery(strHANA);
                Grid1.AutoResizeColumns();
                Grid1.AssignLineNro();
            }
            catch (Exception EX)
            {
                Sb1Messages.ShowError(string.Format(EX.ToString()));
            }

        }
        public Alert.Messagedataline Messagedataline(string Object, string ObjectKey, string Value)
        {
            Alert.Messagedataline MessagedatalineOBj = new Alert.Messagedataline();
            MessagedatalineOBj.Object = Object;
            MessagedatalineOBj.ObjectKey = ObjectKey;
            MessagedatalineOBj.Value = Value;

            return MessagedatalineOBj;
        }
        public Alert.Recipientcollection Recipientcollection(string SendInternal, string UserCode)
        {
            Alert.Recipientcollection RecipientcollectionOBj = new Alert.Recipientcollection();
            RecipientcollectionOBj.SendInternal = SendInternal;
            RecipientcollectionOBj.UserCode = UserCode;
            return RecipientcollectionOBj;
        }
        public Cabecera ObtenerCabecera(SAPbouiCOM.Matrix Mtx, string Name, int U_VIS_Code_OHEM, string Accion, string Code_Cabecera, Recordset recordset)
        {
            List<Cabecera> Cabecera = new List<Cabecera>();
            Cabecera TransferDocument = new Cabecera();
            Guid code = Guid.NewGuid();
            if (Code_Cabecera != "")
            {
                TransferDocument.Code = Code_Cabecera;
                TransferDocument.U_VIS_Name = Name;
                TransferDocument.U_VIS_Code_OHEM = U_VIS_Code_OHEM;
            }
            else
            {
                TransferDocument.Code = code.ToString();
                TransferDocument.U_VIS_Name = Name;
                TransferDocument.U_VIS_Code_OHEM = U_VIS_Code_OHEM;
            }
            U_VIS_Code_HEM = U_VIS_Code_OHEM;
            TransferDocument.VIS_ASIG_IS1Collection = ObtenerDetalle(Mtx, Accion, recordset);
            return TransferDocument;
        }
        public List<Detalle> ObtenerDetalle(SAPbouiCOM.Matrix Mtx, string Accion, Recordset recordset)
        {
            List<Detalle> DetalleDocumentDetalls = new List<Detalle>();
            if (Accion == "Agregar")
            {
                for (int oRows = 0; oRows < Mtx.RowCount; oRows++)
                {
                    Detalle Detalle_ClassDocumentDetalls = new Detalle();

                    if (Mtx.GetValueFromEditText("Col_3", oRows + 1) != "" && Mtx.GetValueFromEditText("Col_0", oRows + 1) != "" &&
                        Mtx.GetValueFromEditText("Col_1", oRows + 1) != "" && Mtx.GetValueFromEditText("Col_11", oRows + 1) == "")
                    {
                        Detalle_ClassDocumentDetalls.U_VIS_Cate = Mtx.GetValueFromEditText("Col_0", oRows + 1); /*Categoria*/
                        Detalle_ClassDocumentDetalls.U_VIS_ID_Modelo = Mtx.GetValueFromEditText("Col_1", oRows + 1); /*Codigo Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Modelo = Mtx.GetValueFromEditText("Col_2", oRows + 1); /*Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Serie = Mtx.GetValueFromEditText("Col_3", oRows + 1); /*Serie*/
                        Detalle_ClassDocumentDetalls.U_VIS_Estado = Mtx.GetValueFromComboBox("Col_4", oRows + 1); /*Estado*/
                        Detalle_ClassDocumentDetalls.U_VIS_FechaEntrega = Mtx.GetValueFromEditText("Col_5", oRows + 1); /*Fecha ENtrega*/
                        Detalle_ClassDocumentDetalls.U_VIS_FechaFinalizacion = Mtx.GetValueFromEditText("Col_6", oRows + 1); /*Fecha Finalizacion*/
                        Detalle_ClassDocumentDetalls.U_VIS_Observacion = Mtx.GetValueFromEditText("Col_8", oRows + 1); /*Observaciones*/
                        Detalle_ClassDocumentDetalls.U_VIS_Est_Alm = Mtx.GetValueFromComboBox("Col_12", oRows + 1); /*Estado Almacen*/
                      //  Detalle_ClassDocumentDetalls.U_VIS_Num_Req = Mtx.GetValueFromEditText("Col_13", oRows + 1); /*U_VIS_Num_Req*/
                        Detalle_ClassDocumentDetalls.U_VIS_FotoAsignacion = "[Ver Archivo]";/*U_VIS_FotoAsignacion*/

                        string fileName = Mtx.GetValueFromEditText("Col_9", oRows + 1); /*Archivo*/

                        if (File.Exists(fileName))
                        {
                            /*Envio de IMAGEN*/
                            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("LINK") + "upload");
                            client.AddDefaultHeader("system", "f78533fe5f610e2c45d0b855d66b8e09");
                            RestRequest request = new RestRequest(Method.POST);
                            request.AlwaysMultipartFormData = true;
                            request.AddHeader("Content-Type", "multipart/form-data");
                            request.AddFile("files", fileName);
                            IRestResponse result = client.Execute(request);
                            dynamic m = JsonConvert.DeserializeObject(result.Content.ToString());
                            var Message = m[0]["message"].ToString();
                            Detalle_ClassDocumentDetalls.U_VIS_Archivo = Message; /**/
                        }
                        else
                        {
                            Detalle_ClassDocumentDetalls.U_VIS_Archivo = Mtx.GetValueFromEditText("Col_9", oRows + 1); /**/
                        }

                            DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);
                    }
                }
            }
            else
            {
                for (int oRows = 0; oRows < Mtx.RowCount; oRows++)
                {

                    Detalle Detalle_ClassDocumentDetalls = new Detalle();
                    string a = Mtx.GetValueFromEditText("Col_10", oRows + 1);
                    string aa = Mtx.GetValueFromEditText("Col_0", oRows + 1);

                    if (Mtx.GetValueFromEditText("Col_10", oRows + 1) == "" && Mtx.GetValueFromEditText("Col_0", oRows + 1) != "")
                    //  if (""== "")
                    {
                        string U_VIS_Estado = Mtx.GetValueFromComboBox("Col_4", oRows + 1);
                        if (U_VIS_Estado=="D")
                        {
                            U_VIS_Estado = "L";
                        }
                        Detalle_ClassDocumentDetalls.U_VIS_Cate = Mtx.GetValueFromEditText("Col_0", oRows + 1); /*Categoria*/
                        Detalle_ClassDocumentDetalls.U_VIS_ID_Modelo = Mtx.GetValueFromEditText("Col_1", oRows + 1); /*Codigo Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Modelo = Mtx.GetValueFromEditText("Col_2", oRows + 1); /*Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Serie = Mtx.GetValueFromEditText("Col_3", oRows + 1); /*Serie*/
                        Detalle_ClassDocumentDetalls.U_VIS_Estado = Mtx.GetValueFromComboBox("Col_4", oRows + 1); /*Estado*/

                        Detalle_ClassDocumentDetalls.U_VIS_FechaEntrega = Mtx.GetValueFromEditText("Col_5", oRows + 1); /**/
                        Detalle_ClassDocumentDetalls.U_VIS_FechaFinalizacion = Mtx.GetValueFromEditText("Col_6", oRows + 1); /**/
                        Detalle_ClassDocumentDetalls.U_VIS_FotoAsignacion ="[Ver Archivo]"; /*U_VIS_FotoAsignacion */
                        Detalle_ClassDocumentDetalls.U_VIS_Observacion = Mtx.GetValueFromEditText("Col_8", oRows + 1); /**/
                        Detalle_ClassDocumentDetalls.U_VIS_Est_Alm = Mtx.GetValueFromComboBox("Col_12", oRows + 1); /*Estado Almacen*/
                       // Detalle_ClassDocumentDetalls.U_VIS_Num_Req = Mtx.GetValueFromEditText("Col_13", oRows + 1); /*U_VIS_Num_Req*/

                        string fileName = Mtx.GetValueFromEditText("Col_9", oRows + 1); /*Archivo*/

                        if (File.Exists(fileName))
                        {
                            /*Envio de IMAGEN*/
                            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                            RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("LINK") + "upload");
                            client.AddDefaultHeader("system", "f78533fe5f610e2c45d0b855d66b8e09");
                            RestRequest request = new RestRequest(Method.POST);
                            request.AlwaysMultipartFormData = true;
                            request.AddHeader("Content-Type", "multipart/form-data");
                            request.AddFile("files", fileName);
                            IRestResponse result = client.Execute(request);
                            dynamic m = JsonConvert.DeserializeObject(result.Content.ToString());
                            var Message = m[0]["message"].ToString();
                            Detalle_ClassDocumentDetalls.U_VIS_Archivo = Message; /**/
                        }
                        else
                        {
                            Detalle_ClassDocumentDetalls.U_VIS_Archivo = Mtx.GetValueFromEditText("Col_9", oRows + 1); /**/
                        }


                        DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);

                        string SQL2 = string.Format("CALL P_VIST_VERIFICACION_ASIGNACIONES_ALMACEN_FILA('{0}','{1}')", Mtx.GetValueFromEditText("Col_3", oRows + 1), U_VIS_Estado);
                        recordset.DoQuery(SQL2);

                    }
                }
            }


            return DetalleDocumentDetalls;
        }
        public List<Detalle> ObtenerDetalleUpdate(SAPbouiCOM.Matrix Mtx, string Code)
        {
            List<Detalle> DetalleDocumentDetalls = new List<Detalle>();
            if (Code != "Agregar")
            {
                for (int oRows = 0; oRows < Mtx.RowCount; oRows++)
                {
                    Detalle Detalle_ClassDocumentDetalls = new Detalle();

                    if (Mtx.GetValueFromEditText("Col_10", oRows + 1) == "" && Mtx.GetValueFromEditText("Col_0", oRows + 1) != "")
                    {
                        Detalle_ClassDocumentDetalls.U_VIS_Cate = Mtx.GetValueFromEditText("Col_0", oRows + 1); /*Categoria*/
                        Detalle_ClassDocumentDetalls.U_VIS_ID_Modelo = Mtx.GetValueFromEditText("Col_9", oRows + 1); /*Codigo Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Modelo = Mtx.GetValueFromEditText("Col_8", oRows + 1); /*Modelo*/
                        Detalle_ClassDocumentDetalls.U_VIS_Serie = Mtx.GetValueFromEditText("Col_1", oRows + 1); /*Serie*/
                        Detalle_ClassDocumentDetalls.U_VIS_Estado = Mtx.GetValueFromComboBox("Col_2", oRows + 1); /*Estado*/

                        Detalle_ClassDocumentDetalls.U_VIS_FechaEntrega = Mtx.GetValueFromEditText("Col_3", oRows + 1); /**/
                        Detalle_ClassDocumentDetalls.U_VIS_FechaFinalizacion = Mtx.GetValueFromEditText("Col_4", oRows + 1); /**/

                        Detalle_ClassDocumentDetalls.U_VIS_Observacion = Mtx.GetValueFromEditText("Col_6", oRows + 1); /**/
                        Detalle_ClassDocumentDetalls.U_VIS_Archivo = Mtx.GetValueFromEditText("Col_7", oRows + 1); /**/

                        DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);
                    }
                }
            }
            else
            {

            }

            return DetalleDocumentDetalls;
        }
        public CabeceraURL ObtenerCabeceraURL(SAPbouiCOM.Matrix Mtx, string U_VIS_Code_OHEM)
        {
            CabeceraURL TransferDocument = new CabeceraURL();
            TransferDocument.Assignment = ObtenerDetalleURL(Mtx, U_VIS_Code_OHEM);
            return TransferDocument;
        }
        public List<Assignment> ObtenerDetalleURL(SAPbouiCOM.Matrix Mtx, string U_VIS_Code_OHEM)
        {
            List<Assignment> DetalleDocumentDetalls = new List<Assignment>();

            for (int oRows = 0; oRows < Mtx.RowCount; oRows++)
            {
                Assignment Detalle_ClassDocumentDetalls = new Assignment();
                if (Mtx.GetValueFromEditText("Col_7", oRows + 1) != "")
                {
                    string fileName = Mtx.GetValueFromEditText("Col_9", oRows + 1); /*Archivo*/

                    if (File.Exists(fileName))
                    {
                        byte[] AsBytes = File.ReadAllBytes(fileName);/*Lectura de PDF E IMAGENES*/
                        String AsBase64String = Convert.ToBase64String(AsBytes);
                        string a = Mtx.GetValueFromEditText("Col_3", oRows + 1);
                        FileInfo Archivo = new FileInfo(fileName);
                        var PesoArchivo = Archivo.Length;
                        if (a.Length == 8)
                        {
                            a = Mtx.GetValueFromEditText("Col_3", oRows + 1);
                        }
                        else
                        {
                            a = Convert.ToDateTime(Mtx.GetValueFromEditText("Col_3", oRows + 1)).ToString("yyyyMMdd");
                        }
                        

                       /*Envio de IMAGEN*/
                        ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                        RestClient client = new RestClient(ConfigurationManager.AppSettings.Get("LINK") + "upload");
                        client.AddDefaultHeader("system", "f78533fe5f610e2c45d0b855d66b8e09");
                        RestRequest request = new RestRequest(Method.POST);
                        request.AlwaysMultipartFormData = true;
                        request.AddHeader("Content-Type", "multipart/form-data");
                        request.AddFile("files", fileName);
                        IRestResponse result = client.Execute(request);
                        dynamic m = JsonConvert.DeserializeObject(result.Content.ToString());
                        var Message = m[0]["message"].ToString();

                        Detalle_ClassDocumentDetalls.CodeId = U_VIS_Code_OHEM + Mtx.GetValueFromEditText("Col_1", oRows + 1) /*Serie*/ + a;/*U_VIS_FechaEntrega*/
                       
                        Detalle_ClassDocumentDetalls.File = AsBase64String;
                    }
                    DetalleDocumentDetalls.Add(Detalle_ClassDocumentDetalls);
                }

            }
            return DetalleDocumentDetalls;
        }
        public CabeceraUpdate ActualizarEstadoObjetAsignaconCabecera(string Code, string LineId, string U_VIS_Estado)
        {
            CabeceraUpdate Actualizarobj = new CabeceraUpdate();
            Actualizarobj.Code = Code;
            Actualizarobj.VIS_ASIG_IS1Collection = ObtenerDetalleAsignacion(LineId, U_VIS_Estado);
            return Actualizarobj;
        }
        public List<VISASIGIS1Collection> ObtenerDetalleAsignacion(string LineId, string U_VIS_Estado)
        {

            List<VISASIGIS1Collection> VIS_TRN_REP_DDocumentDetalls = new List<VISASIGIS1Collection>();


            VISASIGIS1Collection DocumentoRutaTransportistaDetalls = new VISASIGIS1Collection();
            DocumentoRutaTransportistaDetalls.LineId = LineId;
            DocumentoRutaTransportistaDetalls.U_VIS_Estado = U_VIS_Estado;

            VIS_TRN_REP_DDocumentDetalls.Add(DocumentoRutaTransportistaDetalls);


            return VIS_TRN_REP_DDocumentDetalls;

        }
        public void ValidarAsignaciones(Recordset recordset, string Code, EditText ValidacionAsignaicon, EditText Code_Cabecera)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_VALIDAR_ASIGNACIONES('{0}')", Code);

            recordset.DoQuery(StrHANA);
            ValidacionAsignaicon.Value = recordset.Fields.Item("CantidadActivosAsignados").Value.ToString();
            Code_Cabecera.Value = recordset.Fields.Item("Code").Value.ToString();
        }
        public void ObtenerInfoUsuLog(Recordset recordset,string Usu, EditText EditText3)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_INFO_USU('{0}')", Usu);

            recordset.DoQuery(StrHANA);
            EditText3.Value = recordset.Fields.Item("Departamento").Value.ToString();
        }
        public bool ObtenerInfoUsuLogPerfil(Recordset recordset, string Usu)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_INFO_USU('{0}')", Usu);

            recordset.DoQuery(StrHANA);
            if (recordset.Fields.Item("Departamento").Value.ToString()=="Sistemas")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ObtenerSolicitudAsignacion(Recordset recordset, string U_VIS_Cod_OHEM)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_SOLICITUD_ASIGNACIONES('{0}')", U_VIS_Cod_OHEM);

            recordset.DoQuery(StrHANA);
            if (recordset.Fields.Item("DocEntry").Value.ToString() != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidarSeriesEquipos(Recordset recordset,string Modelo, string Serie)
        {
            bool ret = false;
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL SP_VIS_VALIDAR_SEIRE_EQUIPO('{0}','{1}')", Modelo, Serie);
            recordset.DoQuery(StrHANA);

            if (recordset.Fields.Item("Code").Value.ToString() != "")
            {
                ret = true;
            }

            return ret;

        }
        public bool ValidarSolicitudAsignacion(Recordset recordset, string DocNum, string U_VIS_Categoria,EditText EditText1)
        {
            bool ret = false;
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL VIS_GET_SOLICITUD_ASIGNACION('{0}','{1}')", DocNum, U_VIS_Categoria);
            recordset.DoQuery(StrHANA);

            if (recordset.Fields.Item("DocNum").Value.ToString() != "0")
            {
                EditText1.Value = recordset.Fields.Item("U_VIS_UsuSoli").Value.ToString();

                ret = true;
            }

            return ret;

        }
        public void ChooseFromList_Activos(SAPbouiCOM.Form oForm, string CFL_, string Alias, string condicion)
            {
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item(CFL_);
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = Alias;
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = condicion;
            cfl.SetConditions(cons);
        }
        public void ChooseFromList_Num_Soli(SAPbouiCOM.Form oForm, string CFL_, string Alias1, string condicion1)
        {
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item(CFL_);
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = Alias1;
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = condicion1;
            con.Relationship = BoConditionRelationship.cr_AND;
            con = cons.Add();
            con.Alias = "Status";
            con.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
            con.CondVal = "O";
            cfl.SetConditions(cons);
        }
        public void ChooseFromList_Emp_Diferente(SAPbouiCOM.Form oForm, string CFL_, string Alias, string condicion)
        {
            SAPbouiCOM.ChooseFromList cfl = oForm.ChooseFromLists.Item(CFL_);
            SAPbouiCOM.Conditions cons = cfl.GetConditions();
            SAPbouiCOM.Condition con;
            con = cons.Add();
            con.Alias = Alias;
            con.Operation = SAPbouiCOM.BoConditionOperation.co_NOT_EQUAL;
            con.CondVal = condicion;
            cfl.SetConditions(cons);
        }
        public void CargarAsignaciones(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix,string CodeOHEM)
        {
            SAPbouiCOM.DataTable udt;

                string strHANA = string.Format("CALL P_VIST_ASIGNACIONES_OHEM('{0}')", CodeOHEM);
                udt = oForm.DataSources.DataTables.Item("DT_0");
                udt.ExecuteQuery(strHANA);
                oMatrix = oForm.GetMatrix("Item_0");

                SAPbouiCOM.Columns oColumns;
                oColumns = oMatrix.Columns;
                var colItems = udt.Columns;
                // SAPbouiCOM.Column oColumn;
                oColumns = oMatrix.Columns;

                for (int oRows = 0; oRows < udt.Rows.Count; oRows++)
                {
                    SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource("@VIS_ASIG_IS1");
                    int rowCount = 0;

                    rowCount = oDatasource.Offset;

                    rowCount = rowCount + 1;

                    oDatasource.InsertRecord(oDatasource.Size);
                    oDatasource.Offset = oDatasource.Size - 1;

                    oDatasource.SetValue("Code", oRows, udt.GetString("Code", oRows));

                    oDatasource.SetValue("U_VIS_Cate", oRows, udt.GetString("U_VIS_Cate", oRows));
                    oDatasource.SetValue("U_VIS_Serie", oRows, udt.GetString("U_VIS_Serie", oRows));
                    oDatasource.SetValue("U_VIS_Estado", oRows, udt.GetString("U_VIS_Estado", oRows));

                    oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));
                    oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));

                   // object AA = udt.GetString("U_VIS_Num_Req", oRows);
                   // if (AA != null ||Convert.ToString(AA)!="") { 
                    oDatasource.SetValue("U_VIS_Num_Req", oRows, udt.GetString("U_VIS_Num_Req", oRows));
                   // }

                string U_VIS_FechaEntrega = udt.GetString("U_VIS_FechaEntrega", oRows);
                    if (U_VIS_FechaEntrega == "")
                    {

                    }
                    oDatasource.SetValue("U_VIS_FechaEntrega", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaEntrega", oRows)).ToString("yyyyMMdd"));

                    //oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));
                    if (udt.GetString("U_VIS_Estado", oRows) == "D")
                    {
                        oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));
                  
                    }
                    

                    if (udt.GetString("U_VIS_Archivo", oRows) != "" || udt.GetString("U_VIS_Archivo", oRows) != null)
                    {
                        //U_VIS_Code_OHEM + Mtx.GetValueFromEditText("Col_1", oRows + 1) /*Serie*/ + Mtx.GetValueFromEditText("Col_3", oRows + 1);/*ID UNICO*/
                        oDatasource.SetValue("U_VIS_FotoAsignacion", oRows, udt.GetString("U_VIS_FotoAsignacion", oRows));
                    }



                    oDatasource.SetValue("LineId", oRows, udt.GetString("LineId", oRows));

                    // string U_VIS_FechaFinalizacion = udt.GetString("U_VIS_FechaFinalizacion", oRows).ToString();

                    oDatasource.SetValue("U_VIS_Observacion", oRows, udt.GetString("U_VIS_Observacion", oRows));
                    oDatasource.SetValue("U_VIS_Archivo", oRows, udt.GetString("U_VIS_Archivo", oRows));
                    oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));
                    oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));

                    oDatasource.SetValue("U_VIS_Est_Alm", oRows, udt.GetString("U_VIS_Est_Alm", oRows));

                oMatrix.Columns.Item("Col_2").Editable = false;
                oMatrix.Columns.Item("Col_11").Visible = false;
                // oMatrix.Columns.Item("Col_2").Editable = false;
                
                oMatrix.LoadFromDataSource();
            }
                oMatrix.LoadFromDataSource();
                oMatrix.AutoResizeColumns();
                oMatrix.AssignLineNro();

            
        }
        public void CargarAsignacionesAlmacen(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, string CodeOHEM)
        {
            SAPbouiCOM.DataTable udt;

            string strHANA = string.Format("CALL P_VIST_ASIGNACIONES_OHEM('{0}')", CodeOHEM);
            udt = oForm.DataSources.DataTables.Item("DT_0");
            udt.ExecuteQuery(strHANA);
            oMatrix = oForm.GetMatrix("Item_4");

            SAPbouiCOM.Columns oColumns;
            oColumns = oMatrix.Columns;
            var colItems = udt.Columns;
            // SAPbouiCOM.Column oColumn;
            oColumns = oMatrix.Columns;

            for (int oRows = 0; oRows < udt.Rows.Count; oRows++)
            {
                SAPbouiCOM.DBDataSource oDatasource = oForm.GetDBDataSource("@VIS_ASIG_IS1");
                int rowCount = 0;

                rowCount = oDatasource.Offset;

                rowCount = rowCount + 1;

                oDatasource.InsertRecord(oDatasource.Size);
                oDatasource.Offset = oDatasource.Size - 1;

                oDatasource.SetValue("Code", oRows, udt.GetString("Code", oRows));

                oDatasource.SetValue("U_VIS_Cate", oRows, udt.GetString("U_VIS_Cate", oRows));
                oDatasource.SetValue("U_VIS_Serie", oRows, udt.GetString("U_VIS_Serie", oRows));
                oDatasource.SetValue("U_VIS_Estado", oRows, udt.GetString("U_VIS_Estado", oRows));

                oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));
                oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));

                string U_VIS_FechaEntrega = udt.GetString("U_VIS_FechaEntrega", oRows);
                if (U_VIS_FechaEntrega == "")
                {

                }
                oDatasource.SetValue("U_VIS_FechaEntrega", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaEntrega", oRows)).ToString("yyyyMMdd"));

                //oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));
                if (udt.GetString("U_VIS_Estado", oRows) == "D")
                {
                    oDatasource.SetValue("U_VIS_FechaFinalizacion", oRows, Convert.ToDateTime(udt.GetString("U_VIS_FechaFinalizacion", oRows)).ToString("yyyyMMdd"));

                }
                
                if (udt.GetString("U_VIS_Archivo", oRows) != "" || udt.GetString("U_VIS_Archivo", oRows) != null)
                {
                    //U_VIS_Code_OHEM + Mtx.GetValueFromEditText("Col_1", oRows + 1) /*Serie*/ + Mtx.GetValueFromEditText("Col_3", oRows + 1);/*ID UNICO*/
                    oDatasource.SetValue("U_VIS_FotoAsignacion", oRows,"[Ver Archivo]");
                }

                oDatasource.SetValue("U_VIS_Num_Req", oRows, udt.GetString("U_VIS_Num_Req", oRows));

                oDatasource.SetValue("LineId", oRows, udt.GetString("LineId", oRows));

                // string U_VIS_FechaFinalizacion = udt.GetString("U_VIS_FechaFinalizacion", oRows).ToString();

                oDatasource.SetValue("U_VIS_Observacion", oRows, udt.GetString("U_VIS_Observacion", oRows));
                oDatasource.SetValue("U_VIS_Archivo", oRows, udt.GetString("U_VIS_Archivo", oRows));
                oDatasource.SetValue("U_VIS_Modelo", oRows, udt.GetString("U_VIS_Modelo", oRows));
                oDatasource.SetValue("U_VIS_ID_Modelo", oRows, udt.GetString("U_VIS_ID_Modelo", oRows));

                oDatasource.SetValue("U_VIS_Est_Alm", oRows, udt.GetString("U_VIS_Est_Alm", oRows));
                oDatasource.SetValue("U_VIS_Archivo", oRows, udt.GetString("U_VIS_Archivo", oRows));
                
                oMatrix.Columns.Item("Col_2").Editable = false;
                //oMatrix.Columns.Item("Col_11").Visible = false;
                // oMatrix.Columns.Item("Col_2").Editable = false;

                oMatrix.LoadFromDataSource();
            }
            oMatrix.LoadFromDataSource();
            oMatrix.AutoResizeColumns();
            oMatrix.AssignLineNro();


        }
        public bool Layout_Preview(string ReportName, string IDEmp, Recordset oRS)
        {
           // SAPbobsCOM.Recordset oRS = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRS.DoQuery("SELECT \"GUID\" FROM OCMN WHERE \"Name\" = '" + ReportName + "' AND \"Type\" = 'C'");
            SAPbouiCOM.Form form2 = null;
            if (oRS.RecordCount > 0)
            {
                string MenuID = oRS.Fields.Item(0).Value.ToString();

                SAPbouiCOM.Framework.Application.SBO_Application.Menus.Item(MenuID).Activate();
                form2 = (SAPbouiCOM.Form)SAPbouiCOM.Framework.Application.SBO_Application.Forms.ActiveForm;
                ((EditText)form2.Items.Item("1000003").Specific).String = IDEmp;
                form2.Items.Item("1").Click(BoCellClickType.ct_Regular);
                return true;
            }
            else
            {
                SAPbouiCOM.Framework.Application.SBO_Application.MessageBox("Report layout " + ReportName + " not found.", 0, "OK", null, null);
                return false;
            }
        }
        public bool ValidarAsignacionesSeriesEquipos(Recordset recordset, string Serie,string Code)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("SELECT * FROM \"@VIS_ASIG_SIS\" T0 INNER JOIN \"@VIS_ASIG_IS1\" T1 " +
                                    "ON T0.\"Code\" = T1.\"Code\" where T1.\"U_VIS_Serie\" = '{0}' ", Serie);

            recordset.DoQuery(StrHANA);
            if (recordset.Fields.Item("U_VIS_Estado").Value.ToString() == "A")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ValidarSolicitudRequerimiento(Recordset recordset, string idEmpleado, EditText EditText2)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("select * from \"@VIS_SOL_REQ_C\" where \"U_VIS_Cod_OHEM\" = '{0}' ", idEmpleado);

            recordset.DoQuery(StrHANA);
            if (recordset.Fields.Item("DocEntry").Value.ToString() != "0")
            {
                EditText2.Value = recordset.Fields.Item("DocEntry").Value.ToString();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ValidarObtenerUltimoDocNum(Recordset recordset, EditText EditText4)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("select TOP 1 * from \"@VIS_SOL_REQ_C\" T0  ORDER BY 1 DESC");

            recordset.DoQuery(StrHANA);
            if (recordset.Fields.Item("DocNum").Value.ToString() != "0")
            {
                EditText4.Value =Convert.ToString(Convert.ToInt32(recordset.Fields.Item("DocNum").Value.ToString())+1);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ValidarObtenerUsuarioUD(Recordset recordset,string Usuario, EditText EditText5)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_USUARIOID('{0}')", Usuario);

            recordset.DoQuery(StrHANA);
                EditText5.Value = Convert.ToString(Convert.ToInt32(recordset.Fields.Item("USERID").Value.ToString()));
            
        }
        public void ValidarObtenerJefeDepart(Recordset recordset, string Usuario, EditText EditText7)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_JEFE_DEPART('{0}')", Usuario);

            recordset.DoQuery(StrHANA);
            EditText7.Value = Convert.ToString(recordset.Fields.Item("lastName").Value.ToString());

        }
        public void ValidarObtenerUsuarioSolicitante(Recordset recordset, string Usuario, EditText EditText5)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_USERSOLIC('{0}')", Usuario);

            recordset.DoQuery(StrHANA);
          //  EditText5.Value = Convert.ToString(Convert.ToInt32(recordset.Fields.Item("USER_CODE").Value.ToString()));
            EditText5.Value = Convert.ToString(recordset.Fields.Item("U_NAME").Value.ToString()); 

        }
        public void ValidarObtenerCodUser(Recordset recordset, string Usuario, EditText EditText5)
        {
            string StrHANA = string.Empty;
            StrHANA = string.Format("CALL P_VIST_OBTENER_USERSOLIC('{0}')", Usuario);

            recordset.DoQuery(StrHANA);
            EditText5.Value = Convert.ToString(recordset.Fields.Item("USER_CODE").Value.ToString());

        }
        public void EnviarCorreoOffice365(SAPbouiCOM.Form oForm, Recordset recordset, string DocNum, string Notificacion, string DT, string Asunto_Correo, string Cuerpo_Correo)
        {
            //Conexión a a la Plataforma de Microsofot Office 365 para enviar correo.
            var smtp = new System.Net.Mail.SmtpClient("smtp.office365.com");
            var mail = new System.Net.Mail.MailMessage();
            string userFrom = "admin@vistony.com"; //Mi cuenta de Office 365.
            // IMPORTANTE : Este Usuario mail.From, debe coincidir con el de NetworkCredential(), sino se genera error.
            mail.From = new System.Net.Mail.MailAddress(userFrom);
            //Correos Destino a los que les enviaré mail.

            /*Recorrido de correo*/
            string StrHANA = string.Format("CALL P_VIS_OBTENERCORREO_NOTIFI('{0}')", Notificacion);
            SAPbouiCOM.DataTable oDatatable;
            oDatatable = oForm.GetDataTable(DT);
            oDatatable.ExecuteQuery(StrHANA);
            for (int i = 0; i < oDatatable.Rows.Count; i++)
            {
                if (oDatatable.GetString("U_VIS_EMAIL", i) != "")
                {
                    StrHANA = string.Format("CALL P_VIST_OBTENER_USUARIOID('{0}')", oDatatable.GetString("U_VIS_USER_NOT", i));

                    recordset.DoQuery(StrHANA);
                    mail.To.Clear();
                    mail.To.Add(oDatatable.GetString("U_VIS_EMAIL", i));

                    string Str = Cuerpo_Correo;
                    mail.Subject = Asunto_Correo;     //Asunto del Correo

                    mail.Body = Str.Replace("nn", "\n") + " Estimado/a " +
                                recordset.Fields.Item("U_NAME").Value.ToString() +
                                " Se genero una nueva solicitud de requerimiento con el N° de Documento : " + DocNum; //Cuerpo del Mensaje
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    //Credenciales que se utilizan, cuando se autentica al correo de Office 365.
                    smtp.Credentials = new System.Net.NetworkCredential(userFrom, "Extr3m4S3cur1ty$2020$");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    smtp.Send(mail);

                }
            }


        }
        public static void EnviarCorreoOffice365_StaticUpdate(SAPbouiCOM.Form oForm, Recordset recordset,
                      string DocNum, string Notificacion, string DT, string DT2)
        {

            string Texto = System.IO.File.ReadAllText(@"Files\Texto_Correo - Respuesta.txt");
            string ReemplazaNumDocumento = Texto.Replace("@NumDocumento", DocNum);
            /*====================================================================================================*/
            string ObtrenerReque = string.Format("CALL P_VIS_OBTENER_REQUE_APRO('{0}')", DocNum);
            SAPbouiCOM.DataTable oDatatableReque;
            oDatatableReque = oForm.GetDataTable(DT2);
            oDatatableReque.ExecuteQuery(ObtrenerReque);
            string Lineas = "";
            for (int oRows = 0; oRows < oDatatableReque.Rows.Count; oRows++)
            {
                Lineas += "➢  " + oDatatableReque.GetString("U_VIS_Categoria", oRows) + "\n";
            }

            //Conexión a a la Plataforma de Microsofot Office 365 para enviar correo.
            var smtp = new System.Net.Mail.SmtpClient("smtp.office365.com");
            var mail = new System.Net.Mail.MailMessage();
            string userFrom = "admin@vistony.com"; //Mi cuenta de Office 365.
            // IMPORTANTE : Este Usuario mail.From, debe coincidir con el de NetworkCredential(), sino se genera error.
            mail.From = new System.Net.Mail.MailAddress(userFrom);
            //Correos Destino a los que les enviaré mail.

            /*Recorrido de correo*/
            string StrHANA = string.Format("CALL P_VIS_OBTENERCORREO_NOTIFI('{0}')", Notificacion);
            SAPbouiCOM.DataTable oDatatable;
            oDatatable = oForm.GetDataTable(DT);
            oDatatable.ExecuteQuery(StrHANA);
            for (int i = 0; i < oDatatable.Rows.Count; i++)
            {
                if (oDatatable.GetString("U_VIS_EMAIL", i)!="")
                {
                    StrHANA = string.Format("CALL P_VIST_OBTENER_USUARIOID('{0}')", oDatatable.GetString("U_VIS_USER_NOT", i));

                    recordset.DoQuery(StrHANA);
                    mail.Bcc.Clear();
                    mail.Bcc.Add(oDatatable.GetString("U_VIS_EMAIL", i)); /*Copia Oculta*/
                    mail.Priority = System.Net.Mail.MailPriority.Normal;
                    string ReemplazarAsignador = ReemplazaNumDocumento.Replace("@Asignador", recordset.Fields.Item("U_NAME").Value.ToString());
                    mail.Subject = "Respuesta de la solicitud de requerimiento";//Asunto del Correo

                    mail.Body = ReemplazarAsignador.Replace("@Detalle", Lineas);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    //Credenciales que se utilizan, cuando se autentica al correo de Office 365.
                    smtp.Credentials = new System.Net.NetworkCredential(userFrom, "Extr3m4S3cur1ty$2020$");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    smtp.Send(mail);

                }
            }
           

        }
        public static void EnviarCorreoOffice365_Static_Aprobador(SAPbouiCOM.Form oForm, Recordset recordset, 
            string DocNum, string Notificacion, string DT, string DT2, string Asunto_Correo, string Solicitante
           ,string Empleado,string MotivoAsignacion)
        {
            /*=====================================================================================*/
            /*Leer el TXT para el Aprobador*/
            string TextoAprobador = System.IO.File.ReadAllText(@"Files\Texto_Correo.txt");
            string TextoAccesos = System.IO.File.ReadAllText(@"Files\Texto_Correo - Accesos.txt");

            /*Obtener Detalle de Asignaciones*/
            string ObtrenerReque = string.Format("CALL P_VIS_OBTENER_REQUE('{0}')", DocNum);
            SAPbouiCOM.DataTable oDatatableReque = oForm.GetDataTable(DT2);
            oDatatableReque.ExecuteQuery(ObtrenerReque);
            string Lineas = "";
            for (int oRows = 0; oRows < oDatatableReque.Rows.Count; oRows++)
            {
                Lineas += "➢  " + oDatatableReque.GetString("U_VIS_Categoria", oRows) + "\n";
            }

            /*=====================================================================================*/
            /*Obtener Detalle de Accesos*/
            string ObtrenerAccesos = string.Format("CALL P_VIS_OBTENER_REQUE_ACCESOS('{0}')", DocNum);
            SAPbouiCOM.DataTable oDatatableAccesos = oForm.GetDataTable("DT_5");
            oDatatableAccesos.ExecuteQuery(ObtrenerAccesos);
            string LineasAccesos = "";
            for (int oRows = 0; oRows < oDatatableAccesos.Rows.Count; oRows++)
            {
                LineasAccesos = "➢  " + oDatatableAccesos.GetString("U_VIS_Categoria", oRows) + "\n";
            }

            /*=====================================================================================*/
            if (oDatatableReque.Rows.Count > 1)
            {
                EnviarCorreoAprobador(TextoAprobador, Lineas, Solicitante, Notificacion,
                oForm, DT, recordset, MotivoAsignacion, DocNum, Empleado, Asunto_Correo);
            }
            /*=====================================================================================*/
            if (oDatatableAccesos.Rows.Count > 0)
            {
                EnviarCorreoAccesos(TextoAccesos, LineasAccesos, Solicitante, "ASIGNACIÓN", oForm, DT,
                     recordset, MotivoAsignacion, DocNum, Empleado, Asunto_Correo);
            }
            /*========================================= FIN =========================================*/

        }

        public static void EnviarCorreoAprobador(string TextoAprobador,string Lineas,string Solicitante,string Notificacion,
            SAPbouiCOM.Form oForm,string DT,Recordset recordset,string MotivoAsignacion,string DocNum, string Empleado,
            string Asunto_Correo)
        {
            string ReemplazoDetalle = TextoAprobador.Replace("@Detalle", Lineas); /*Reemplazar el Valor Detalle*/
            string ReemplazoSolicitante = ReemplazoDetalle.Replace("@Solicitante", Solicitante);

            /*=====================================================================================*/
            //Conexión a a la Plataforma de Microsofot Office 365 para enviar correo.
            var smtp = new System.Net.Mail.SmtpClient("smtp.office365.com");
            var mail = new System.Net.Mail.MailMessage();
            string userFrom = "admin@vistony.com"; //Mi cuenta de Office 365.
            // IMPORTANTE : Este Usuario mail.From, debe coincidir con el de NetworkCredential(), sino se genera error.
            mail.From = new System.Net.Mail.MailAddress(userFrom);

            /*Recorrido de correo*/
            string StrHANA = string.Format("CALL P_VIS_OBTENERCORREO_NOTIFI('{0}')", Notificacion);
            SAPbouiCOM.DataTable oDatatable;
            oDatatable = oForm.GetDataTable(DT);
            oDatatable.ExecuteQuery(StrHANA);
            for (int i = 0; i < oDatatable.Rows.Count; i++)
            {
                if (oDatatable.GetString("U_VIS_EMAIL", i) != "")
                {

                    StrHANA = string.Format("CALL P_VIST_OBTENER_USUARIOID('{0}')", oDatatable.GetString("U_VIS_USER_NOT", i));
                    //Correos Destino a los que les enviaré mail.
                    recordset.DoQuery(StrHANA);
                    string ReemplazoAprobador = ReemplazoSolicitante.Replace("@Aprobador", recordset.Fields.Item("U_NAME").Value.ToString());
                    string ReemplazoNumDoc = ReemplazoAprobador.Replace("@NumDocumento", DocNum);
                    string ReemplazoEmpleado = ReemplazoNumDoc.Replace("@NombreEmpleado", Empleado);
                    if (MotivoAsignacion == "PNO")
                    {
                        MotivoAsignacion = "Puesto Nuevo";
                    }
                    else if (MotivoAsignacion == "RPO")
                    {
                        MotivoAsignacion = "Reemplazo";
                    }
                    else
                    {
                        //MotivoAsignacion = "";
                    }
                    string ReemplazoMotivoAsignacion = ReemplazoEmpleado.Replace("@MotivoAsignacion", MotivoAsignacion);

                    mail.Bcc.Clear();
                    mail.Bcc.Add(oDatatable.GetString("U_VIS_EMAIL", i)); /*Copia Oculta*/
                    mail.Priority = System.Net.Mail.MailPriority.Normal;
                    mail.Subject = Asunto_Correo;//Asunto del Correo
                    mail.Body = ReemplazoMotivoAsignacion.Replace("�n", "ón");

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    //Credenciales que se utilizan, cuando se autentica al correo de Office 365.
                    smtp.Credentials = new System.Net.NetworkCredential(userFrom, ConfigurationManager.AppSettings.Get("PassWordAdminOutlook"));
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    smtp.Send(mail);

                }
            }
        }


        public static void EnviarCorreoAccesos(string TextoAprobador, string LineasAccesos, string Solicitante, string Notificacion,
            SAPbouiCOM.Form oForm, string DT, Recordset recordset, string MotivoAsignacion, string DocNum, string Empleado,
            string Asunto_Correo)
        {
            string ReemplazoDetalle = TextoAprobador.Replace("@Detalle", LineasAccesos); /*Reemplazar el Valor Detalle*/

            /*=====================================================================================*/
            //Conexión a a la Plataforma de Microsofot Office 365 para enviar correo.
            var smtp = new System.Net.Mail.SmtpClient("smtp.office365.com");
            var mail = new System.Net.Mail.MailMessage();
            string userFrom = "admin@vistony.com"; //Mi cuenta de Office 365.
            // IMPORTANTE : Este Usuario mail.From, debe coincidir con el de NetworkCredential(), sino se genera error.
            mail.From = new System.Net.Mail.MailAddress(userFrom);

            /*Recorrido de correo*/
            string StrHANA = string.Format("CALL P_VIS_OBTENERCORREO_NOTIFI('{0}')", Notificacion);
            SAPbouiCOM.DataTable oDatatable;
            oDatatable = oForm.GetDataTable(DT);
            oDatatable.ExecuteQuery(StrHANA);
            for (int i = 0; i < oDatatable.Rows.Count; i++)
            {
                if (oDatatable.GetString("U_VIS_EMAIL", i) != "")
                {

                    StrHANA = string.Format("CALL P_VIST_OBTENER_USUARIOID('{0}')", oDatatable.GetString("U_VIS_USER_NOT", i));
                    //Correos Destino a los que les enviaré mail.
                    recordset.DoQuery(StrHANA);
                    string ReemplazoNumDoc = ReemplazoDetalle.Replace("@NumDocumento", DocNum);
                    string ReemplazoAsignador = ReemplazoNumDoc.Replace("@Asignador", recordset.Fields.Item("U_NAME").Value.ToString());
                    if (MotivoAsignacion == "PNO")
                    {
                        MotivoAsignacion = "Puesto Nuevo";
                    }
                    else if (MotivoAsignacion == "RPO")
                    {
                        MotivoAsignacion = "Reemplazo";
                    }
                    else
                    {
                        //MotivoAsignacion = "";
                    }
                    mail.Bcc.Clear();
                    mail.Bcc.Add(oDatatable.GetString("U_VIS_EMAIL", i)); /*Copia Oculta*/
                    mail.Priority = System.Net.Mail.MailPriority.Normal;
                    mail.Subject = Asunto_Correo;//Asunto del Correo
                    mail.Body = ReemplazoAsignador;

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    //Credenciales que se utilizan, cuando se autentica al correo de Office 365.
                    smtp.Credentials = new System.Net.NetworkCredential(userFrom, ConfigurationManager.AppSettings.Get("PassWordAdminOutlook"));
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    smtp.Send(mail);

                }
            }
        }

    }
}
