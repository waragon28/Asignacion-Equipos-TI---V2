using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Vistony.AddonName.BLL;
using Forxap.AddonName.UI.Constans;
using System.Threading;

namespace Vistony.AddonName.Win.Asistentes
{
    [FormAttribute("FrmSerieActivos", "Asistentes/FrmSerieActivos.b1f")]
    class FrmSerieActivos : UserFormBase
    {
        SAPbouiCOM.Form oForm;
        FrmAsistenteAsignacionTI OwnerForm;
        string ModeloFrmAsignacionTI="";
        AsignacionHEM11_BO AsignacionHEM11_BO = new AsignacionHEM11_BO();
        bool Modal = true;
        string IDForm = "";

        public FrmSerieActivos(FrmAsistenteAsignacionTI ownerForm,string Modelo)
        {
            ModeloFrmAsignacionTI = Modelo;
            OwnerForm = ownerForm;
            SAPbouiCOM.DataTable oDT = oForm.GetDataTable("DT_0");
            AsignacionHEM11_BO.GetSerieAcivos(string.Format(AddonMessageInfo.QueryListModelo_Serie_Activos, ModeloFrmAsignacionTI), oDT);
            Grid0.AssignLineNro();
            Grid0.AutoResizeColumns();
            Grid0.ReadOnlyColumns();
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_1").Specific));
            this.Grid0.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.Grid0_DoubleClickAfter);
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

        }

        private SAPbouiCOM.Grid Grid0;

        private void Grid0_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
                string Serie = Grid0.DataTable.GetValue("Serie", pVal.Row).ToString();
            
                FrmAsistenteAsignacionTI owner = this.OwnerForm;

                Thread myNewThread = new Thread(() => owner.GetSerie(Serie));
                myNewThread.Start();
                oForm.Close();

        }
    }
}
