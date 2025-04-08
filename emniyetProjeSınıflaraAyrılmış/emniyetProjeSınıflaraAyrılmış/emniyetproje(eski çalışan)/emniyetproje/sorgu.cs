using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emniyetproje
{
    internal class sorgu
    {
        
        OleDbConnection con; //baglantı 
        OleDbCommand komut; //komut 
        OleDbDataAdapter sorguAdapter; 
        DataSet veriSeti; //verisetine çekip sonra datagridviewe aktarma
        string baglantiStringi = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=dataemniyet.accdb"; // dosya yolu
        public void sahisSorgu(DataGridView dataGridView1, TextBox tcnoSorguTxtBox)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                sorguAdapter = new OleDbDataAdapter("select * from [Tablo1]" + "where tcno like '" + tcnoSorguTxtBox.Text + "'", con);
            
                veriSeti = new DataSet();
                con.Open();
                sorguAdapter.Fill(veriSeti, "Tablo1");
                dataGridView1.DataSource = veriSeti.Tables["Tablo1"];
            }
        }
        public void plakaSorgu(DataGridView dataGridView1, TextBox plakaSorguTxtBox)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                sorguAdapter = new OleDbDataAdapter("select * from [Tablo2]" + "where plaka like '" + plakaSorguTxtBox.Text + "'", con);
              
                veriSeti = new DataSet();
                con.Open();
                sorguAdapter.Fill(veriSeti, "Tablo2");
                dataGridView1.DataSource = veriSeti.Tables["Tablo2"];
            }
        }

        public void saseSorgu(DataGridView dataGridView1, TextBox sasenoSorguTxtBox)
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                sorguAdapter = new OleDbDataAdapter("select * from [Tablo2]" + "where saseno like '" + sasenoSorguTxtBox.Text + "'", con);
               
                veriSeti = new DataSet();
                con.Open();
                sorguAdapter.Fill(veriSeti, "Tablo2");
                dataGridView1.DataSource = veriSeti.Tables["Tablo2"];
            }
        }
    }
}
