using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;

namespace Vistony.AddonName.Win.Maestros
{
    [FormAttribute("60100", "Maestros/OHEM.b1f")]
    class OHEM : SystemFormBase
    {
        SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Button Button0;

        public OHEM()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
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
            int HeigthButton= oForm.GetButton("234000250").Item.Height;
            int LeftButton= oForm.GetButton("234000250").Item.Left;
            int TopButton= oForm.GetButton("234000250").Item.Top;

            oForm.GetButton("Item_0").Item.Height = HeigthButton;
            oForm.GetButton("Item_0").Item.Left = LeftButton;
           // oForm.GetButton("Item_0").Item.Height = TopButton;
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           Asistentes.FrmAsistenteAsignacionTI frmasistenteasignacionTI = new Asistentes.FrmAsistenteAsignacionTI();
            frmasistenteasignacionTI.Show();
        }
    }
}
