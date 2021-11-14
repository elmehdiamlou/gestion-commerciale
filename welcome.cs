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
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        confirmexit formconfirmexit;
        private void lblexit_Click(object sender, EventArgs e)
        {
            formconfirmexit = new confirmexit();
            DialogResult dr = formconfirmexit.ShowDialog(this);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (dr == DialogResult.No)
            {
                formconfirmexit.Close();
            }
        }

        private void lblreduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblreduire_MouseEnter(object sender, EventArgs e)
        {
            lblreduire.BackColor = Color.FromArgb(58,196,255);
        }
        private void lblreduire_MouseLeave(object sender, EventArgs e)
        {
            lblreduire.BackColor = Color.Transparent;

        }

        private void lblexit_MouseEnter(object sender, EventArgs e)
        {
            lblexit.BackColor = Color.FromArgb(58, 196, 255);
        }

        private void lblexit_MouseLeave(object sender, EventArgs e)
        {
            lblexit.BackColor = Color.Transparent;
        }

        private void btninscrire_Click(object sender, EventArgs e)
        {
            inscription forminscription = new inscription();
            forminscription.Show();
            this.Hide();
        }

        private void btnidentifier_Click(object sender, EventArgs e)
        {
            identification formidentification = new identification();
            formidentification.Show();
            this.Hide();
        }
    }
}
