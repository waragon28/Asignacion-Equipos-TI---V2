using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.AddonName.Win
{
    class ItemEvent
    {
        public void SB1_Application_ItemEvent(String formUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            switch (pVal.FormTypeEx)
            {

                case "vis_FrmAlertNotification":
                   // FrmGenerarSolicitud_Requerimiento.itemEvent(ref pVal, out BubbleEvent);
                    break;
                case "47940":
                    
                   // FrmGenerarSolicitud_Requerimiento.itemEvent(ref pVal, out BubbleEvent);
                    break;
            }

        }

    }
}
