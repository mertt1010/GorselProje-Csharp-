using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emniyetproje
{
    public partial class Form2 : Form
    {
        OleDbConnection con; //baglantı kurmak için 
        OleDbCommand komut; //komut vermek için
        OleDbDataAdapter sorguAdapter;
        DataSet veriSeti;
        string baglantiStringi = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=dataemniyet.accdb";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                sorguAdapter = new OleDbDataAdapter(" SELECT Tablo1.Kimlik,Tablo1.isimSoyisim,Tablo1.dogumTarihi, Tablo1.sehir  , Tablo1.aramaDurumu , Tablo1.gbt , Tablo1.tcno  FROM Tablo1 WHERE (((Tablo1.aramaDurumu)=True))", con);
                veriSeti = new DataSet();
                con.Open();
                sorguAdapter.Fill(veriSeti, "Tablo1");
                dataGridView1.DataSource = veriSeti.Tables["Tablo1"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                con.Open();
                string sql = "SELECT Kimlik,isimSoyisim,dogumTarihi, sehir , aramaDurumu , gbt , tcno  FROM Tablo1 Where dogumTarihi BETWEEN @tar1 and @tar2";
                DataTable dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, con);
                adp.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
                adp.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
                adp.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
