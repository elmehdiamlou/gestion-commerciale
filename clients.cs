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
    public partial class clients : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=vente;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt = new DataTable();
        int pos;
        info forminfo;

        public clients()
        {
            InitializeComponent();
        }
        
        private void clients_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Client", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Clear();
            dt.Load(dr);
            con.Close();
            if(dt.Rows.Count>0)
            {
                pos = 0;
                charger(pos);
            }
            else
            {
                pos = -1;
            }
        }

        public void charger(int i)
        {
            txtcodecl.Text = dt.Rows[i][0].ToString();
            txtnom.Text = dt.Rows[i][1].ToString();
            txtville.Text = dt.Rows[i][2].ToString();
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                pos = 0;
                charger(pos);
            }
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos--;
                charger(pos);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (pos < dt.Rows.Count - 1)
            {
                pos++;
                charger(pos);
            }
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                pos = dt.Rows.Count - 1;
                charger(pos);
            }
        }

        private void btninitialiser_Click(object sender, EventArgs e)
        {
            txtcodecl.Text = txtnom.Text = txtville.Text = txtcodeclrech.Text = "";
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            if (txtcodecl.Text != "" && txtnom.Text != "" && txtville.Text != "")
            {
                cmd = new SqlCommand($"select * from Client where CodeCl = '{txtcodecl.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code client existe déja !");
                    forminfo.ShowDialog(this);
                }
                else
                {
                    con.Close();
                    cmd = new SqlCommand("insert into Client values(@code,@nom,@ville)", con);
                    cmd.Parameters.AddWithValue("@code", txtcodecl.Text);
                    cmd.Parameters.AddWithValue("@nom", txtnom.Text);
                    cmd.Parameters.AddWithValue("@ville", txtville.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Client ajouté avec succès");
                    forminfo.ShowDialog(this);
                    pos = dt.Rows.Count;
                    clients_Load(sender, e);
                }
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Veuillez remplir tous les champs !");
                forminfo.ShowDialog(this);
            }
        }

        private void btnmodifier_Click(object sender, EventArgs e)
        {
            if (txtcodecl.Text != "" && txtnom.Text != "" && txtville.Text != "")
            {
                cmd = new SqlCommand($"select * from Client where CodeCl = '{txtcodecl.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    cmd = new SqlCommand("update Client set Nom = @nom, Ville = @ville where CodeCl = @code", con);
                    cmd.Parameters.AddWithValue("@nom", txtnom.Text);
                    cmd.Parameters.AddWithValue("@ville", txtville.Text);
                    cmd.Parameters.AddWithValue("@code", txtcodecl.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Client modifié avec succès");
                    forminfo.ShowDialog(this);
                    clients_Load(sender, e);
                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code client n'existe pas !");
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

        private void btnsupprimer_Click(object sender, EventArgs e)
        {
            if (txtcodecl.Text != "")
            {
                cmd = new SqlCommand($"select * from Client where CodeCl = '{txtcodecl.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    try
                    {
                        con.Close();
                        cmd = new SqlCommand("delete from Client where CodeCl= @code", con);
                        cmd.Parameters.AddWithValue("@code", txtcodecl.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        forminfo = new info();
                        forminfo.labelinfo("Client supprimé avec succès");
                        forminfo.ShowDialog(this);
                        clients_Load(sender, e);
                    }
                    catch
                    {
                        con.Close();
                        forminfo = new info();
                        forminfo.labelinfo("Cette action ne peut pas être réalisée");
                        forminfo.ShowDialog(this);
                    }
                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code client n'existe pas !");
                    forminfo.ShowDialog(this);
                }
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Veuillez saisir le code du client !");
                forminfo.ShowDialog(this);
            }
        }

        private void btnrechercher_Click(object sender, EventArgs e)
        {
            if (txtcodeclrech.Text != "")
            {
                cmd = new SqlCommand($"select CodeCl from Client where CodeCl = '{txtcodeclrech.Text}'", con);
                con.Open();
                var resultat = cmd.ExecuteScalar();
                if (resultat != null)
                {
                    con.Close();
                    for (int i = 0; i < dt.Rows.Count; i++) 
                    {
                        if (resultat.ToString() == dt.Rows[i][0].ToString())
                        {
                            pos = i;
                            charger(pos);
                            return;
                        }
                    }
                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code client n'existe pas !");
                    forminfo.ShowDialog(this);
                }
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Veuillez saisir le code du client !");
                forminfo.ShowDialog(this);
            }
        }
    }
}
