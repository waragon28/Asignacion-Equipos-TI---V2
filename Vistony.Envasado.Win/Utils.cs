using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using SAPbobsCOM;
using Forxap.Framework.Extensions;



//using Forxap.AddonName.Win;


namespace Forxap.AddonName.UI.Win
{
    public class Utils
    {
        public static void LoadQueryDynamic(ref SAPbouiCOM.ComboBox oComboBox, string Query)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Forxap.Framework.DI.ValidValues.GetQueryCombos(Query);
                foreach (var item in listObject)
                {
                        oComboBox.ValidValues.Add(item.Key, item.Value);
                }
                 //oComboBox.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
                 oComboBox.Item.DisplayDesc = true;
            }

        }
        
         public static void LoadQueryDynamic2(ref SAPbouiCOM.ComboBox oComboBox, string Query)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.ValidValues.GetQueryCombos(Query);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

        public static void LoadQueryDynamic3(ref SAPbouiCOM.ComboBox oComboBox, string Query)
        {
            Dictionary<string, string> listObject;
            if (oComboBox != null)
            {

                listObject = Framework.DI.ValidValues.GetQueryCombos(Query);
                foreach (var item in listObject)
                {
                    oComboBox.ValidValues.Add(item.Key, item.Value);
                }

                oComboBox.Item.DisplayDesc = true;
            }

        }

    }// fin de la clase

}// fin del namespace
