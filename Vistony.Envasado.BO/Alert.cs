using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.AddonName.BO
{
    public class Alert
    {
        public class Rootobject
        {
            public List<Messagedatacolumn> MessageDataColumns { get; set; }
            public List<Recipientcollection> RecipientCollection { get; set; }
            public string Subject { get; set; }
            public string Text { get; set; }
        }
        public class Messagedatacolumn
        {
            public string ColumnName { get; set; }
            public string Link { get; set; }
            public List<Messagedataline> MessageDataLines { get; set; }
        }
        public class Messagedataline
        {
            public string Object { get; set; }
            public string ObjectKey { get; set; }
            public string Value { get; set; }
        }
        public class Recipientcollection
        {
            public string SendInternal { get; set; }
            public string UserCode { get; set; }
        }

    }
}
