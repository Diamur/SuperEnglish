using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zuzeTransalor
{
    public partial class About : Form
    {
        string ComputerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
        public About()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You : "+ComputerName+"\n"+"For Using zuze Translator");
        }
    }
}
