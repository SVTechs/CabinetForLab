using CabinetMgr.Config;
using Hardware.DeviceInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private delegate void AddLineDelegate(string lineStr);
        public void AddLine(string lineStr)
        {
            try
            {
                if (richTextBox1.InvokeRequired)
                {
                    AddLineDelegate d = AddLine;
                    richTextBox1.Invoke(d, lineStr);
                }
                else
                {
                    richTextBox1.Text = lineStr + "\n" + richTextBox1.Text;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

    }
}
