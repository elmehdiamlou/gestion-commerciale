using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCommercial
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void btnnon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        public void labelinfo(string info)
        {
            lblinfo.Text = info;
        }
    }
}
