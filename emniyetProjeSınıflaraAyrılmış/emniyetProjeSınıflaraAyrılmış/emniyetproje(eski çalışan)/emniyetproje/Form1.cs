using System.Data;
using System.Data.OleDb;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace emniyetproje
{
    public partial class Form1 : Form
    {
        kayit kayit = new kayit();
        sorgu sorgu = new sorgu();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  form elemanlarýyla sýnýfý baðdaþtýrýyoruz
            kayit.sahisKayit(tcTxtBox, isimsoyisimTxtBox, dogumTarihiPicker, sehirComboBox, checkBox1, gbtTxtBox, radioButton1, radioButton2);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            kayit.aracKayit(saseTxtBox, sahipAdSoyadTxtBox, cezaTutarTxtBox, sigortaTarihPicker, plakaTxtBox, muayenepicker);
            
        }

        private void sahisSorguBtn_Click(object sender, EventArgs e)
        {
            sorgu.sahisSorgu(dataGridView1,tcnoSorguTxtBox);
            
        }

        private void plakaSorguBtn_Click(object sender, EventArgs e)
        {
            sorgu.plakaSorgu(dataGridView1,plakaSorguTxtBox);
         
        }

        private void saseSorguBtn_Click(object sender, EventArgs e)
        {
            sorgu.saseSorgu(dataGridView1,sasenoSorguTxtBox);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
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
