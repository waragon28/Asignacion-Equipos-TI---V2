using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.UI;
using Forxap.Framework.Extensions;
using Forxap.AddonName.UI.Constans;
using Forxap.AddonName.UI.Win;
using Vistony.AddonName.BLL;
using SAPbobsCOM;
using Vistony.AddonName.BO;
using Newtonsoft.Json;
using RestSharp;

namespace Vistony.AddonName.Win.Asistentes
{
    [FormAttribute("Vistony.AddonName.Win.Asistentes.FrmAsistenteAsignacionTI", "Asistentes/FrmAsistenteAsignacionTI.b1f")]
    class FrmAsistenteAsignacionTI : UserFormBase
    {
        public int PaneLevel { get; set; }
        public int PaneMax = 4;
        SAPbouiCOM.Form oForm;
        AsignacionHEM11_BO AsignacionHEM11_BLL = new AsignacionHEM11_BO();
        Cabecera Cabecera = new Cabecera();
        public void PriorPane()
        {
            if (Button1.Item.Enabled == true)
            {
                Button0.Caption = "Siguiente >";
                if (oForm.PaneLevel + 1 >= 2)
                {
                    oForm.PaneLevel -= 1;
                }

                if (oForm.PaneLevel == 2)
                {
                }
                if (oForm.PaneLevel == 1)
                {
                    Button1.Caption = "";
                    Button1.Item.Enabled = false;
                }
            }

            StaticText0.Caption = oForm.PaneLevel + " de " + PaneMax;
        }
        public void NextPane()
        {
            Button1.Caption = "< Anterior";
            Button1.Item.Enabled = true;
            if (PaneLevel < PaneMax)
            {
                oForm.PaneLevel += 1;
            }

            if (oForm.PaneLevel == 1)
            {

            }
            if (oForm.PaneLevel == 2)
            {

            }
            if (oForm.PaneLevel == 3)
            {

            }

            if (oForm.PaneLevel == 4)
            {
              /*  oForm.PaneLevel = 3;
                var Message = Sb1Messages.ShowMessageBox("Se generara una orden de venta en la compañia Vistony " + "\n" + "¿Desea Continuar?");

                if (Message == 2 || Message == 3)
                {
                    oForm.PaneLevel = 3;
                }
                else
                {
                   
                  

                }*/

                Button0.Caption = "Terminar";
                Button1.Caption = "";
                Button1.Item.Enabled = false;
            }

            StaticText0.Caption = oForm.PaneLevel + " de " + PaneMax;
        }
        public FrmAsistenteAsignacionTI()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_8").Specific));
            this.EditText1.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText1_ChooseFromListAfter);
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_9").Specific));
            this.EditText2.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText2_ChooseFromListAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Grid0.ClickBefore += new SAPbouiCOM._IGridEvents_ClickBeforeEventHandler(this.Grid0_ClickBefore);
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_11").Specific));
            this.ComboBox0.ComboSelectBefore += new SAPbouiCOM._IComboBoxEvents_ComboSelectBeforeEventHandler(this.ComboBox0_ComboSelectBefore);
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.EditText0.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText0_ClickAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_14").Specific));
            this.Button3.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button3_ClickBefore);
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_16").Specific));
            this.ComboBox1.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox1_ComboSelectAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_19").Specific));
            this.EditText3.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText3_ClickAfter);
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_23").Specific));
            this.ComboBox2.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox2_ComboSelectAfter);
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("Item_24").Specific));
            this.Button5.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button5_ClickAfter);
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_26").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_28").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_30").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_32").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_33").Specific));
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("Item_31").Specific));
            this.Button6.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button6_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            Grid0.AutoResizeColumns();
            Grid0.ReadOnlyColumns();
            Utils.LoadQueryDynamic(ref ComboBox1,string.Format(AddonMessageInfo.QueryListValoresValidos, "@VIS_ASIG_IS1","2"));
            Utils.LoadQueryDynamic(ref ComboBox0,AddonMessageInfo.QueryListCategoriaActivos);
            StaticText1.SetBold();
            StaticText1.SetHeight(10);
            oForm.PaneLevel = 2;
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText5;
        SAPbobsCOM.Recordset recordSet = null;
        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            NextPane();
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            PriorPane();
        }

        private void EditText1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg chooseFromListEvent = ((SAPbouiCOM.SBOChooseFromListEventArg)(pVal));
            try
            {

                if (chooseFromListEvent.SelectedObjects != null)
                {
                    if (chooseFromListEvent.SelectedObjects.Rows.Count > 0)
                    {
                        EditText1.Value = chooseFromListEvent.SelectedObjects.GetValue("empID", 0).ToString();
                        EditText2.Value = chooseFromListEvent.SelectedObjects.GetValue("lastName", 0).ToString() + " " +
                                          chooseFromListEvent.SelectedObjects.GetValue("firstName", 0).ToString() + " " +
                                          chooseFromListEvent.SelectedObjects.GetValue("middleName", 0).ToString();
                    }
                }

            }
            catch
            {
            }
        }

        private void EditText2_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            cleanComboBox(ComboBox2);
            string Query = string.Format(AddonMessageInfo.QueryListModeloActivos, ComboBox0.GetSelectedDescription());
            LoadQueryDynamic2(ref ComboBox2, Query);
            ComboBox2.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
            EditText0.Value = "";
        }
        public static void LoadQueryDynamic2(ref SAPbouiCOM.ComboBox oComboBox,string Query)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                int i = 0;
                while (oComboBox.ValidValues.Count > 0)
                {
                    try
                    {
                        oComboBox.ValidValues.Remove(i , SAPbouiCOM.BoSearchKey.psk_Index);
                    }
                    catch (Exception ex)
                    {
                        Forxap.Framework.UI.Sb1Messages.ShowMessage(ex.ToString());
                    }
                }




                listObject = Forxap.Framework.DI.Sb1Users.GetListFromSQL(Query);
                foreach (var item in listObject)
                {
                   
                        oComboBox.ValidValues.Add(item.Key, item.Value);
                    
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        public static void cleanComboBox(SAPbouiCOM.ComboBox oComboBox)
        {
            int i = 0;
            while (oComboBox.ValidValues.Count -1 > 0)
            {
                try
                {
                    oComboBox.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                }
                catch (Exception ex)
                {
                    Forxap.Framework.UI.Sb1Messages.ShowMessage(ex.ToString());
                }
            }
        }

        private void ComboBox2_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
           AsignacionHEM11_BLL.StockModeloEquipo(ComboBox2.GetSelectedDescription(), recordSet, StaticText11);
        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           string ID = oForm.UniqueID.ToString();
           Asistentes.FrmSerieActivos form = new Asistentes.FrmSerieActivos(this, ComboBox2.GetSelectedDescription());
           form.Show();
        }

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            if (ComboBox2.GetSelectedDescription()=="")
            {
                BubbleEvent = false;
                Sb1Messages.ShowError("Debe seleccionar un modelo");
            }
            else
            {
                BubbleEvent = true;
            }
        }

        private SAPbouiCOM.StaticText StaticText11;
        public void GetSerie(string Serie)
        {
            EditText0.Value = Serie;
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                oForm.Freeze(true);
                SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");

                AsignacionHEM11_BLL.GetSerieAcivos(string.Format(AddonMessageInfo.QueryListAsignacionesOHEM, EditText1.Value), oDT);
                Grid0.AssignLineNro();
                Grid0.AutoResizeColumns();
                Grid0.ReadOnlyColumns();
                GirdFormat();
                CamposActivos(true);
                if (Grid0.Rows.Count > 0)
                {
                    string strSQL = "''";
                    recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    strSQL = string.Format("SELECT T0.\"Code\" FROM \"@VIS_ASIG_SIS\" T0 WHERE T0.\"U_VIS_Code_OHEM\" ='{0}' ", EditText1.Value);
                    recordSet.DoQuery(strSQL);

                    EditText6.Value = recordSet.Fields.Item("Code").Value.ToString();

                    if (EditText6.Value != "")
                    {
                        Button5.Caption = "Agregar";
                    }
                    else
                    {
                        Button5.Caption = "Crear";

                    }
                }
            }
            catch (Exception e)
            {
                Sb1Messages.ShowError(e.ToString());
            }
            finally
            {
                oForm.Freeze(false);
            }
           

        }
        public void GirdFormat()
        {
            Grid0.Columns.Item(0).Visible = false;
            Grid0.Columns.Item(1).Visible = false;
            Grid0.Columns.Item(2).Visible = false;
            Grid0.Columns.Item(3).Visible = false;
            Grid0.Columns.Item(5).Visible = false;
            Grid0.Columns.Item("Categoria").LinkedObjectType(Grid0, "Categoria", "VIS_ACT_SIST");
        }
        public void CamposActivos(bool Activo)
        {
            ComboBox0.Item.Enabled = Activo;
            ComboBox1.Item.Enabled = Activo;
            ComboBox2.Item.Enabled = Activo;
            EditText4.Item.Enabled = Activo;
            Button3.Item.Enabled = Activo;
            Button4.Item.Enabled = Activo;
            Button5.Item.Enabled = Activo;
        }

        private SAPbouiCOM.LinkedButton LinkedButton0;

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (true)
            {

            }
            if (Grid0.Rows.Count>0)
            {
                EditText9.Value = "";
                recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string CodLinea = Grid0.DataTable.GetValue("LineId", pVal.Row).ToString();
                AsignacionHEM11_BLL.GetLineAsignacion(recordSet, string.Format(AddonMessageInfo.QueryGetAsignacionLine,
                                                    EditText6.Value + "-" + CodLinea), ComboBox0,
                                                    ComboBox2, EditText0, ComboBox1, EditText3,
                                                    EditText4, Button5, StaticText12,EditText8, EditText9);


               // CamposActivos(false);
                ComboBox1.Item.Enabled = true;
            }

        }

        private void Button5_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (EditText0.Value=="")
            {
                Sb1Messages.ShowError("Debe Seleccionar una Serie");
            }
            else
            {

                Sb1Messages.ShowWarning("Iniciando Creacion de Asignacion");

                int EmpleadoID = EditText1.GetInt();
                string NombreEmpleado = EditText2.GetString();
                string Categoria = ComboBox0.GetValue();
                string Cod_Modelo = "";
                string Modelo = ComboBox2.GetValue();
                string Serie = EditText0.GetString();
                string EstadoAsignacion = ComboBox1.GetValue();
                string FotoAsignacion = EditText3.GetString();
                string Observaciones = EditText4.GetString();
                string FechaAsignacion = EditText8.Value;
                string EstadoAlmacen = "";
                string FechaFinalizacion = EditText9.Value;
                if (EstadoAsignacion=="D")
                {
                    EstadoAlmacen = "L";
                }
                else if (EstadoAsignacion == "N")
                {
                    EstadoAlmacen = "D";
                }
                else
                {
                    EstadoAlmacen = EstadoAsignacion;
                }

                string LineId = StaticText12.Caption;

                if (Button5.Caption == "Crear")
                {
                    FechaAsignacion = DateTime.Now.ToString("yyyyMMdd");
                    Cabecera ObjCabeceraAgregar = AsignacionHEM11_BLL.AgregarCabeceraAsignacionTI(EmpleadoID, NombreEmpleado, Categoria, Cod_Modelo,
                                               Modelo, Serie, EstadoAsignacion, FotoAsignacion, Observaciones, FechaAsignacion, FechaFinalizacion);
                    string JsonObtener = JsonConvert.SerializeObject(ObjCabeceraAgregar);

                    IRestResponse responsde;
                    Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
                    dynamic entrada = JsonObtener;
                    responsde = Methods.POST("VIS_ASIG_SIS", entrada.ToString());
                    dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());
                    Console.Write(responsde.StatusDescription);

                    if (responsde.StatusDescription == "Created")
                    {

                        var Code = m["Code"].ToString();

                        if (Code != "")
                        {
                            Sb1Messages.ShowSuccess("Se Asigno Correctamente");

                         
                            recordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            string SQL2 = string.Format("CALL P_VIST_VERIFICACION_ASIGNACIONES_ALMACEN_FILA('{0}','{1}')", Serie, EstadoAlmacen);
                            recordSet.DoQuery(SQL2);
                            Button2.Item.Click();
                            EditText0.Value = "";
                        }
                        else
                        {
                            Sb1Messages.ShowError("Error al Asignar este equipo");
                        }

                    }

                }
                else if (Button5.Caption == "Actualizar")
                {
                   
                    Sb1Messages.ShowWarning("Se esta Actualizando");
                    string SQL = string.Format("CALL P_VIST_VERIFICACION_ASIGNACIONES_FILA_OHEM('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                        EditText6.Value, NombreEmpleado, EmpleadoID, LineId, Categoria, Serie,
                                                        EstadoAsignacion, FechaAsignacion, FechaFinalizacion, FotoAsignacion, Observaciones,
                                                        "", Modelo
                                                        );

                    recordSet.DoQuery(SQL);

                    string SQL2 = string.Format("CALL P_VIST_VERIFICACION_ASIGNACIONES_ALMACEN_FILA('{0}','{1}')", Serie, EstadoAlmacen);
                    recordSet.DoQuery(SQL2);
                    Sb1Messages.ShowSuccess("Se Actualizo Correctamente");
                    EditText0.Value = "";
                    Button2.Item.Click();

                }
                else if (Button5.Caption == "Agregar")
                {
                    Cabecera ObjCabeceraActualizar = null;

                    ObjCabeceraActualizar = AsignacionHEM11_BLL.ActualizarCabeceraAsignacionTI(EditText6.Value, EmpleadoID, NombreEmpleado, Categoria, Cod_Modelo,
                                                            Modelo, Serie, EstadoAsignacion, FotoAsignacion, Observaciones, FechaAsignacion, FechaFinalizacion);
                    string JsonObtener = JsonConvert.SerializeObject(ObjCabeceraActualizar);

                    IRestResponse responsde;
                    Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
                    dynamic entrada = JsonObtener;
                    responsde = Methods.PATCH("VIS_ASIG_SIS", EditText6.Value, entrada.ToString());
                    dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());
                    Console.Write(responsde.StatusDescription);

                    string SQL2 = string.Format("CALL P_VIST_VERIFICACION_ASIGNACIONES_ALMACEN_FILA('{0}','{1}')", Serie, EstadoAlmacen);
                    recordSet.DoQuery(SQL2);
                    Sb1Messages.ShowSuccess("Se Agrego Correctamente");
                    EditText0.Value = "";
                    Button2.Item.Click();

                }
                ComboBox0.Clear();
                //Utils.LoadQueryDynamic(ref ComboBox1, string.Format(AddonMessageInfo.QueryListValoresValidos, "@VIS_ASIG_IS1", "2"));
                //Utils.LoadQueryDynamic(ref ComboBox0, AddonMessageInfo.QueryListCategoriaActivos);
            }

        }
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText12;

        private void ComboBox0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
        }

        private void EditText0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private void EditText3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;

        private void ComboBox1_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            if (ComboBox1.GetValue()=="A"|| ComboBox1.GetValue() == "P")
            {
                EditText8.Value = DateTime.Now.ToString("yyyyMMdd");
                EditText9.Value = "";
            }
            else
            {
                EditText9.Value = DateTime.Now.ToString("yyyyMMdd");
            }
        }

        private SAPbouiCOM.Button Button6;

        private void Button6_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbobsCOM.Recordset oRS = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            AsignacionHEM11_BLL.Layout_Preview("Asignacion Equipo",EditText1.Value, oRS);
        }

        private void Button7_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }

        private void Grid0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            
            string consolidado = string.Empty;
            int rowIndex;
            int rowSelected;

                rowSelected = pVal.Row;
                rowIndex = rowSelected;

                if (rowIndex > -1)
                {
                    consolidado = Grid0.DataTable.GetValue("Estado", Grid0.GetDataTableRowIndex(rowIndex)).ToString();
                }

                // si ya se encuentra consolidado no debe permitir seleccionar
                if (consolidado=="Devuelto" ||
                    consolidado == "Dañado" ||
                    consolidado == "Vendido" ||
                    consolidado == "Perdido"||
                    consolidado == "Robado" ||
                    consolidado == "Donado" ||
                    consolidado == "Garantia")
                {
                    BubbleEvent = false;
                    Sb1Messages.ShowError("No se puede Actualizar esta asignacion por que ya se devolvio al almacen");
                }
        }
    }
}
