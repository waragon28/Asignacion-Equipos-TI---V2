using System;
using System.Collections.Generic;
using System.Text;

using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;

using Forxap.AddonName.UI.Constans;

using Forxap.AddonName.UI.Win.Configuracion;

namespace Forxap.AddonName.UI.Win
{
   public  class MainMenuEvent
    {

       static SAPbouiCOM.Form oForm;

        /// <summary>
        /// Capturo los eventos del Menu del AddOn Iker One

        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_MainMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction)
                {
                    switch (pVal.MenuUID)
                    {
                        #region Modulos/Alm_Sistemas

                        case AddonMenuItem.FrmAsignacion_Activos:
                            {
                                OnShowFrmAsignacion_Activos();
                            }
                            break;
                        case AddonMenuItem.FrmAsignacion_Activos_Almacen:
                            {
                                OnShowFrmAsignacion_Activos_Almacen();
                            }
                            break;
                        case AddonMenuItem.FrmAlertNotification:
                            {
                                OnShowFrmAlertNotification();
                            }
                            break;
                        case AddonMenuItem.FrmSoliNoti:
                            {
                                OnShowFrmSoliNoti();
                            }
                            break;
                        case AddonMenuItem.frmvis_FrmAsiTI:
                            {
                                OnShowFrmAsignacion_Activos();
                            }
                            break;
                        //case "47940":
                        //    {
                        //        OnShowFrmAlertNotification();
                        //    }
                        //    break;
                        #endregion


                        default:
                            break;

                    } // fin dl switch

                }// fin del IF


            }

            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }/// fin del  metodo

        private  void OnShowFrmAsignacion_Activos()
        {
            try
            {
                Vistony.AddonName.Win.Asistentes.FrmAsistenteAsignacionTI form1 = new Vistony.AddonName.Win.Asistentes.FrmAsistenteAsignacionTI();
                form1.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        
            private void OnShowFrmAlertNotification()
             {
                try
                {
              //  FrmGenerarSolicitud_Requerimiento form1 = new FrmGenerarSolicitud_Requerimiento();
                 //   form1.Show();
                }
                catch (Exception ex)
                {

                    Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
                }
            }

        private void OnShowFrmSoliNoti()
        {
            try
            {
               // FrmGenerarSolicitud_Requerimiento form1 = new FrmGenerarSolicitud_Requerimiento();
             //   form1.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        private void OnShowFrmAsignacion_Activos_Almacen()
        {
            try
            {
               //  FrmBandejaAsignacion form1 = new FrmBandejaAsignacion();
               //  form1.Show();
            }
            catch (Exception ex)
            {

                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }

        // integración de SelesForce con SAP

        private void OnShowInicializar()
       {
           try
           {
              //frmInicializar form  = new  frmInicializar();
              //form.Show();
           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
           }
       }
        
     
       private void OnShowConfigForm(string tableName )
       {
           SAPbouiCOM.Form activeForm = null;
           SAPbouiCOM.Button oButton = null;
           SAPbouiCOM.Matrix oMatrix = null;
           //SAPbouiCOM.MenuItem oMenuItem = null;
           //SAPbouiCOM.Menus oMenu = null;
           string menuID = string.Empty;
           string menuCaption = string.Empty;
           int index = 0;

           try
           {



               menuID = Forxap.Framework.UI.Menu.GetMenuID(tableName, SboMenuItem.WindowsDefinedUser );

               Application.SBO_Application.ActivateMenuItem(menuID);

               menuCaption = Application.SBO_Application.Menus.Item(menuID).String;

               
               

               index = menuCaption.IndexOf("-", 0);


                
               activeForm = Application.SBO_Application.Forms.ActiveForm;
               activeForm.Freeze(true);

               activeForm.Title = menuCaption.Substring(index + 2);
               
               // SAPbouiCOM.Item oItem = null;
              // SAPbouiCOM.StaticText lblInfo = null;



               oButton = activeForm.GetButton("2");
               oMatrix = activeForm.GetMatrix("3");

               oMatrix.Columns.Item(3).TitleObject.Caption = "Código";
               oMatrix.Columns.Item(4).TitleObject.Caption = "Descripción";

               
           //    oMatrix.CommonSetting.MergeCell(1,3,true); 

               
               //oItem = activeForm.Items.Add("lblInfo1", SAPbouiCOM.BoFormItemTypes.it_STATIC);
               //oItem.Left = oButton.Item.Left + 75;
               //oItem.Width = oMatrix.Item.Width;
               //oItem.Top = oButton.Item.Top - oButton.Item.Height;
               //oItem.Height = oButton.Item.Height;
               //oItem.Enabled = true;
               //lblInfo = ((SAPbouiCOM.StaticText)(oItem.Specific));
               //lblInfo.Caption = "Height : " + oItem.Height.ToString() + "Top : " +  oItem.Top.ToString();



               activeForm.Freeze(false);




            
           }
           catch (Exception ex)
           {
               Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
           }
           finally
           {
              
               // libero recursos

               if (activeForm != null)
               {
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(activeForm);
                   activeForm = null;
                   GC.Collect();
               }

               if (oMatrix != null)
               {
                   System.Runtime.InteropServices.Marshal.ReleaseComObject(oMatrix);
                   oMatrix = null;
                   GC.Collect();
               }

           }
    
       }








       //private void OnShowAsisAnulaDoc()
       //{
       //    try
       //    {
       //       //wzdAnulacion wzd = new wzdAnulacion();

       //        wzdConciliar wzd = new wzdConciliar();
       //        wzd.Show();
       //    }
       //    catch (Exception ex)
       //    {
       //        Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
       //    }
       //}


    


    }// fin de la clase


}// fin del namespace
