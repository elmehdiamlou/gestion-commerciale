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
    public partial class consultation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=vente;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        info forminfo;

        public consultation()
        {
            InitializeComponent();
        }

        private void consultation_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from Commande", con);
            con.Open();
            dt1.Clear();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt1.Load(dr);
                dataGridView1.DataSource = dt1;
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand($"select Détail.CodeArt,Désignation,PU,Détail.qte,Détail.Qte*Article.PU as montant from Article,Détail,Commande where Article.CodeArt=Détail.CodeArt and Détail.NumCom=Commande.NumCom and Détail.NumCom='{dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()}'", con);
            con.Open();
            dt2.Clear();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
                dataGridView2.DataSource = dt2;
                con.Close();
            }
            else
            {
                con.Close();
                forminfo = new info();
                forminfo.labelinfo("Aucuns détails !");
                forminfo.ShowDialog(this);
            }
        }
    }
}
