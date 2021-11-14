using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionCommercial
{
    public partial class identification : Form
    {
        public identification()
        {
            InitializeComponent();
        }

        private void identification_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        confirmexit formconfirmexit;
        info forminfo;
        Principal formprincipal;
        SqlConnection con = new SqlConnection("server=localhost;database=Vente;trusted_connection=true");
        SqlCommand cmd;

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

        private void linklblinscrire_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            inscription forminscription = new inscription();
            forminscription.Show();
            this.Hide();
        }

        public void redirectfrominsc(string code,string mdp)
        {
            txtcin.Text = code;
            txtmdp.Text = mdp;
        }

        private void btnidentifier_Click(object sender, EventArgs e)
        {
            bool continuer = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        continuer = false;
                    }
                }
            }
            if (continuer)
            {
                cmd = new SqlCommand("select Nom from Utilisateur where CIN = '" + txtcin.Text + "' and MDP = '" + txtmdp.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        utilisateur.unom = dr.GetString(0);
                    }
                    dr.Close();
                    con.Close();
                    formprincipal = new Principal();
                    formprincipal.Show();
                    this.Close();
                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Informations incorrectes !");
                    forminfo.ShowDialog(this);
                }
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Veuillez remplir tous les champs !");
                forminfo.ShowDialog(this);
            }
        }
    }
}
