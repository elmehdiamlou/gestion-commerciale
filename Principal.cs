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
    public partial class Principal : Form
    {
        confirmexit formconfirmexit;
        bool mousedown = false;
        int x, y;
        private Button currentbtn;
        private Form activeform;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lblnom.Text = " - " + utilisateur.unom;
        }

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
            lblreduire.BackColor = Color.FromArgb(58, 196, 255);
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

        private void panelbare_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            mousedown = true;
        }

        private void panelbare_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.SetDesktopLocation(MousePosition.X - x, MousePosition.Y - y);
            }
        }

        private void panelbare_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
        
        private void activebutton(object btnsender)
        {
            if(btnsender!= null)
            {
                if (currentbtn != (Button)btnsender)
                {
                    disablebutton();
                    currentbtn = (Button)btnsender;
                    currentbtn.BackColor = Color.FromArgb(1, 138, 211);
                }
            }
        }

        private void disablebutton()
        {
            foreach(Control previousbtn in panelmenu.Controls)
            {
                if (previousbtn.GetType() == typeof(Button))
                {
                    previousbtn.BackColor = Color.FromArgb(0, 113, 183);
                }
            }
        }

        private void openchildform(Form childform, object btnsender)
        {
            if(activeform != null)
            {
                activeform.Close();
            }
            activebutton(btnsender);
            activeform = childform;
            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            childform.FormBorderStyle = FormBorderStyle.None;
            this.panelcontenu.Controls.Add(childform);
            this.panelcontenu.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void btnclients_Click(object sender, EventArgs e)
        {
            openchildform(new clients(), sender);
        }

        private void btnarticles_Click(object sender, EventArgs e)
        {
            openchildform(new articles(), sender);
        }

        private void btnconsultations_Click(object sender, EventArgs e)
        {
            openchildform(new consultation(), sender);
        }

        private void btncommandes_Click(object sender, EventArgs e)
        {
            openchildform(new commandes(), sender);
        }
    }
}
