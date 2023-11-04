using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            // Create an instance of MyStringList
            SpecialList stringList = new SpecialList
            {
                originator = "Common Alerting Protocol",
                event_type = "Practice Demo/Warning"
            };

            // Access values using property names
            string originatorValue = stringList.originator;
            string eventTypeValue = stringList.event_type;

        }
    }

    public class SpecialList
    {
        public string originator { get; set; }
        public string event_type { get; set; }
        public bool ebs_tone { get; set; }
        public bool nws_tone { get; set; }
        public bool bnu_tone { get; set; }
        public bool announcement_generated { get; set; }
        public bool endec_simulation { get; set; }
        public string starting { get; set; }
        public string ending { get; set; }
        public string locations { get; set; }
    }
}
