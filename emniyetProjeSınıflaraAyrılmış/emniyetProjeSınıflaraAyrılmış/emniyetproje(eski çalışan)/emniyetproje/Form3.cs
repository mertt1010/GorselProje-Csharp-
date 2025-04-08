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
    public partial class Form3 : Form
    {
        OleDbConnection con; //baglantı kurmak için 
        OleDbCommand komut; //komut vermek için
        OleDbDataAdapter sorguAdapter;
        DataSet veriSeti;
        string baglantiStringi = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=dataemniyet.accdb";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
               
                con.Open();
                string sql = "SELECT Kimlik, saseno ,sahipAdSoyad ,cezaTutar ,sigortaTarih , plaka , muayeneTarihi  FROM Tablo2 Where sigortaTarih BETWEEN @tarihA and @tarihB";
                DataTable dt = new DataTable();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, con);
                adp.SelectCommand.Parameters.AddWithValue("@tarihA", dateTimePicker1.Value);
                adp.SelectCommand.Parameters.AddWithValue("@tarihB", dateTimePicker2.Value);
                adp.Fill(dt);
                con.Close();
                dataGridView1.DataSource = dt;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                DataTable dt = new DataTable();
                OleDbCommand komut = new OleDbCommand("select * from Tablo2 where muayeneTarihi>=@tarihA and muayeneTarihi <@tarihB", con);
                komut.Parameters.AddWithValue("tarihA", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("tarihB", dateTimePicker2.Value);
                OleDbDataAdapter sorguAdapter = new OleDbDataAdapter(komut);
                sorguAdapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
