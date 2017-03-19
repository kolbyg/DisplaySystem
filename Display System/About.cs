using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display_System
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            string version = "";
            if (ApplicationDeployment.IsNetworkDeployed)
                version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(3);
            else
                version = "DEBUG";
            lblAbout.Text = "Display System\nVersion: " + version + "\nCopyright 2016 Kolby's Computers\nAll Rights Reserved\n\nPlease contact us if you discover a bug:\nEmail: info@kolbyscomputers.ca";
            lblLicense.Text = "Product Unlicenced\nNon-Commercial Use Only\n\nTo obtain a licence visit:\nhttp://kolbyscomputers.ca/display-system";
        }
    }
}
