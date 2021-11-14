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
using System.Drawing.Imaging;
using System.IO;

namespace GestionCommercial
{
    public partial class articles : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=vente;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt = new DataTable();
        DataTable dtrech = new DataTable();
        int pos;
        info forminfo;
        static string filename = "";

        public articles()
        {
            InitializeComponent();
        }

        private void articles_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Article", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Clear();
            dt.Load(dr);
            con.Close();
            if (dt.Rows.Count > 0)
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
            txtcodeart.Text = dt.Rows[i][0].ToString();
            txtdesignation.Text = dt.Rows[i][1].ToString();
            byte[] img = (byte[])dt.Rows[i][2];
            MemoryStream ms = new MemoryStream(img);
            pictureboximage.Image = Image.FromStream(ms);
            txtpu.Text = dt.Rows[i][3].ToString();
            txtstock.Text = dt.Rows[i][4].ToString();
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
            txtcodeart.Text = txtdesignation.Text = txtpu.Text = txtstock.Text = txtdesignationrech.Text = txtpurech1.Text = txtpurech2.Text = "";
        }

        private void btnchoisirimage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files|*.jpg;*.jpeg;*.png", ValidateNames = true, Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    pictureboximage.Image = Image.FromFile(filename);
                }
            }
        }

        private byte[] convertimagetobytearray(Image image,ImageFormat imageFormat)
        {
            byte[] bytearray;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, imageFormat);
                    bytearray = ms.ToArray();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return bytearray;
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            if (txtcodeart.Text != "" && txtdesignation.Text != "" && txtpu.Text != "" && txtstock.Text != "")
            {
                cmd = new SqlCommand($"select * from Article where CodeArt = '{txtcodeart.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code article existe déja !");
                    forminfo.ShowDialog(this);
                }
                else
                {
                    con.Close();
                    Image image = Image.FromFile(filename);
                    byte[] img = convertimagetobytearray(image, ImageFormat.Jpeg);
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("insert into Article values(@code,@des,@img,@pu,@stock)", con);
                    cmd.Parameters.AddWithValue("@code", txtcodeart.Text);
                    cmd.Parameters.AddWithValue("@des", txtdesignation.Text);
                    cmd.Parameters.AddWithValue("@img", img);
                    cmd.Parameters.AddWithValue("@pu", decimal.Parse(txtpu.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(txtstock.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Article ajouté avec succès");
                    forminfo.ShowDialog(this);
                    pos = dt.Rows.Count;
                    articles_Load(sender, e);
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
            if (txtcodeart.Text != "" && txtdesignation.Text != "" && txtpu.Text != "" && txtstock.Text != "")
            {
                cmd = new SqlCommand($"select * from Article where CodeArt = '{txtcodeart.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    try 
                    { 
                        Image image =  Image.FromFile(filename);
                        byte[] img = convertimagetobytearray(image, ImageFormat.Jpeg);
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("update Article set Désignation = @des, pic = @img, PU = @pu, QStock = @stock where CodeArt = @code", con);
                        cmd.Parameters.AddWithValue("@img", img);
                        cmd.Parameters.AddWithValue("@code", txtcodeart.Text);
                        cmd.Parameters.AddWithValue("@des", txtdesignation.Text);
                        cmd.Parameters.AddWithValue("@pu", decimal.Parse(txtpu.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(txtstock.Text));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception) { }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd = new SqlCommand("update Article set Désignation = @des, PU = @pu, QStock = @stock where CodeArt = @code", con);
                        cmd.Parameters.AddWithValue("@code", txtcodeart.Text);
                        cmd.Parameters.AddWithValue("@des", txtdesignation.Text);
                        cmd.Parameters.AddWithValue("@pu", decimal.Parse(txtpu.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(txtstock.Text));
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Article modifié avec succès");
                    forminfo.ShowDialog(this);
                    articles_Load(sender, e);

                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code article n'existe pas !");
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
            if (txtcodeart.Text != "")
            {
                cmd = new SqlCommand($"select * from Article where CodeArt = '{txtcodeart.Text}'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand("delete from Article where CodeArt = @code", con);
                    cmd.Parameters.AddWithValue("@code", txtcodeart.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Article supprimé avec succès");
                    forminfo.ShowDialog(this);
                    articles_Load(sender, e);

                }
                else
                {
                    con.Close();
                    forminfo = new info();
                    forminfo.labelinfo("Code article n'existe pas !");
                    forminfo.ShowDialog(this);
                }
            }
            else
            {
                forminfo = new info();
                forminfo.labelinfo("Veuillez saisir le code de l'article !");
                forminfo.ShowDialog(this);
            }
        }

        private void btnrechercher_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand($"select * from Article where Désignation like '{txtdesignationrech.Text}%' and PU between {decimal.Parse(txtpurech1.Text==String.Empty?0.ToString():txtpurech1.Text)} and {decimal.Parse(txtpurech2.Text == String.Empty ? 999999999.ToString() : txtpurech2.Text)}", con);
            con.Open();
            dtrech.Clear();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dtrech.Load(dr);
                dataGridView1.DataSource = dtrech;
                con.Close();
            }
            else
            {
                con.Close();
                forminfo = new info();
                forminfo.labelinfo("Aucun article n'a été trouvé !");
                forminfo.ShowDialog(this);
            }
        }
    }
}
