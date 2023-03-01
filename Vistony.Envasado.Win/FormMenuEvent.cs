using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;
using Forxap.AddonName.UI.Constans;
using Forxap.AddonName.UI.Win.Configuracion;

namespace Forxap.AddonName.UI.Win
{
    public class FormMenuEvent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_FormMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {

                switch (Application.SBO_Application.Forms.ActiveForm.TypeEx)
                {

                    case AddonWinForms.frmvis_FrmAsiTI:
                        {
                           // FrmAsignaciones.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }
                    case AddonWinForms.frmAsignacionActivos_Ti:
                        {
                            //FrmAsignaciones_TI.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }
                    case AddonWinForms.frmAlertNotification:
                        {
                            //FrmGenerarSolicitud_Requerimiento.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }
                    case AddonWinForms.FrmSoliNoti:
                        {
                          //  FrmGenerarSolicitud_Requerimiento.MenuEvent(ref pVal, out BubbleEvent);
                            break;
                        }
                }

            }
            catch (Exception ex)
            {

                // TODO: crear un log de forma asincrona
                //Forxap.Framework.UI.Messages.ShowError(ex.ToString());
            }



        }// fin del metodo FormMenuEvent



    }// fin de la clase

}// fin del namespace
