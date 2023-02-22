using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANO_Anti_Virus
{
    public partial class System_Information : Form
    {
        public System_Information()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the RANO Anti-Virus?", "See you soon", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //nothing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void System_Information_Load(object sender, EventArgs e)
        {
            
        }
        
        private string GetOsName(OperatingSystem os_info)
        {
            string version =
                os_info.Version.Major.ToString() + "." +
                os_info.Version.Minor.ToString();
            switch (version)
            {
                case "10.0": return "10 / Server 2016";
                case "6.3": return "8.1 / Server 2012 R2";
                case "6.2": return "8 / Server 2012";
                case "6.1": return "7  /Server 2008 R2";
                case "6.0": return "Server 2008 / Vista";
                case "5.2": return "Server 2003 R2 / Server 2003 / XP 64-Bit Edition";
                case "5.1": return "XP";
                case "5.0": return "2000";
            }
            return "Unknown";
        }
    }
}
