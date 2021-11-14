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
    public partial class inscription : Form
    {
        public inscription()
        {
            InitializeComponent();
        }
        confirmexit formconfirmexit;
        info forminfo;
        identification formidentification;
        SqlConnection con = new SqlConnection("server=localhost;database=Vente;trusted_connection=true");
        SqlCommand cmd;

        private void inscription_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
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

        private void linklblidentifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            identification formidentification = new identification();
            formidentification.Show();
            this.Hide();
        }

        private void btninscrire_Click(object sender, EventArgs e)
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
            if(continuer)
            {
                cmd = new SqlCommand("select * from Utilisateur where CIN = '" + txtcin.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("CIN utilisateur existe déja !");
                    forminfo.ShowDialog(this);
                }
                else
                {
                    dr.Close();
                    con.Close();
                    cmd = new SqlCommand("insert into Utilisateur values('" + txtcin.Text + "','" + txtnom.Text + "','" + txtmdp.Text + "')", con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        formidentification = new identification();
                        formidentification.redirectfrominsc(txtcin.Text, txtmdp.Text);
                        formidentification.Show();
                        this.Close();
                    }
                    catch
                    {
                        forminfo = new info();
                        forminfo.labelinfo("Une erreur s'est produite Veuillez réessayer !");
                        forminfo.Show();
                        this.Close();
                    }
                    con.Close();
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
