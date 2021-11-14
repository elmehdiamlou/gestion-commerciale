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
    public partial class commandes : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=vente;Integrated Security=True");
        SqlCommand cmd;
        DataTable dtclient = new DataTable();
        DataTable dtarticle = new DataTable();
        info forminfo;
        decimal total = 0;
        bool add = false;

        public commandes()
        {
            InitializeComponent();
        }

        private void commandes_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Client", con);
            con.Open();
            SqlDataReader drcl = cmd.ExecuteReader();
            while (drcl.Read())
            {
                comboBoxCodecl.Items.Add(drcl["CodeCl"].ToString());
            }
            drcl.Close();
            drcl = cmd.ExecuteReader();
            dtclient.Load(drcl);
            con.Close();
            cmd = new SqlCommand("select * from Article", con);
            con.Open();
            SqlDataReader drart = cmd.ExecuteReader();
            while (drart.Read())
            {
                comboBoxCodeArt.Items.Add(drart["CodeArt"].ToString());
            }
            drart.Close();
            drart = cmd.ExecuteReader();
            dtarticle.Load(drart);
            con.Close();
        }

        private void comboBoxCodecl_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtclient.Rows)
            {
                if (dr[0].ToString() == comboBoxCodecl.SelectedItem.ToString())
                {
                    txtnom.Text = dr[1].ToString();
                    txtville.Text = dr[2].ToString();
                    return;
                }
            }
        }

        private void comboBoxCodeArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtarticle.Rows)
            {
                if (dr[0].ToString() == comboBoxCodeArt.SelectedItem.ToString())
                {
                    txtdesignation.Text = dr[1].ToString();
                    txtpu.Text = dr[3].ToString();
                    txtquantite_TextChanged(sender, e);
                    return;
                }
            }
        }
        
        private void btnajouterligne_Click(object sender, EventArgs e)
        {
            if (comboBoxCodeArt.SelectedIndex != -1 && txtquantite.Text != "" && txtmontant.Text != "")
            {
                cmd.Parameters.Clear();
                cmd = new SqlCommand("select * from Article where CodeArt = @code and QStock >= @qte", con);
                cmd.Parameters.AddWithValue("@code", comboBoxCodeArt.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@qte", txtquantite.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        string val1 = dgvr.Cells[0].Value.ToString();
                        string val2 = comboBoxCodeArt.SelectedItem.ToString();
                        if (val1 == val2)
                        {
                            add = true;
                            dgvr.Cells[3].Value = (int.Parse(dgvr.Cells[3].Value.ToString()) + int.Parse(txtquantite.Text)).ToString();
                            dgvr.Cells[4].Value = (decimal.Parse(dgvr.Cells[4].Value.ToString()) + decimal.Parse(txtmontant.Text)).ToString();
                            total = total + decimal.Parse(txtmontant.Text);
                            lbltotal.Text = total.ToString();
                        }
                    }
                    if(add == false)
                    {
                        String[] row = { comboBoxCodeArt.SelectedItem.ToString(), txtdesignation.Text, txtpu.Text, txtquantite.Text, txtmontant.Text };
                        dataGridView1.Rows.Add(row);
                        total = total + decimal.Parse(txtmontant.Text);
                        lbltotal.Text = total.ToString();
                    }
                    else
                    {
                        add = false;
                    }
                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Stock insuffisant !");
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

        private void btnsupprimerligne_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                total = total - decimal.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                lbltotal.Text = total.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Aucune ligne sélectionnée !");
                forminfo.ShowDialog(this);
            }
        }

        private void txtquantite_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCodeArt.SelectedIndex != -1 && txtquantite.Text != "")
            {
                txtmontant.Text = (int.Parse(txtquantite.Text) * decimal.Parse(txtpu.Text)).ToString();
            }
        }

        private void txtnumcmd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtquantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnenregistrer_Click(object sender, EventArgs e)
        {
            if (txtnumcmd.Text != "" && comboBoxCodecl.SelectedIndex != -1)
            {
                cmd = new SqlCommand($"select * from Commande where NumCom = '{txtnumcmd.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Numéro du commande existe déja !");
                    forminfo.ShowDialog(this);
                }
                else
                {
                    con.Close();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("insert into Commande values(@num,@date,@codecl)", con);
                        cmd.Parameters.AddWithValue("@num", txtnumcmd.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePickercommande.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@codecl", comboBoxCodecl.SelectedItem.ToString());
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd = new SqlCommand($"insert into Détail values(@num,@codeart,@qte)", con);
                            cmd.Parameters.AddWithValue("@num", txtnumcmd.Text);
                            cmd.Parameters.AddWithValue("@codeart", dataGridView1.Rows[i].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@qte", dataGridView1.Rows[i].Cells[3].Value);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        forminfo = new info();
                        forminfo.labelinfo("Commande ajouté avec succès");
                        forminfo.ShowDialog(this);
                    }
                    else
                    {
                        forminfo = new info();
                        forminfo.labelinfo("Aucune commande à sauvgarder !");
                        forminfo.ShowDialog(this);
                    }
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
