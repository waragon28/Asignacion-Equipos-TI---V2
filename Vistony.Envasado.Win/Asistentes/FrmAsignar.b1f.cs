using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Vistony.AddonName.Win.Asistentes
{
    [FormAttribute("Vistony.AddonName.Win.Asistentes.FrmAsignar", "Asistentes/FrmAsignar.b1f")]
    class FrmAsignar : UserFormBase
    {
        public FrmAsignar()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
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

        }
    }
}
