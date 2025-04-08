using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emniyetproje
{
    internal class kayit
    {
        
        OleDbConnection con; //baglantı
        OleDbCommand komut; //komut 
        OleDbDataAdapter sorguAdapter; 
        DataSet veriSeti; //sorguyu verisetine çekip sonra datagridviewe aktarma
        string baglantiStringi = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=dataemniyet.accdb"; // dosya yolu

         public void sahisKayit(TextBox tcTxtBox, TextBox isimsoyisimTxtBox,DateTimePicker dogumTarihiPicker,ComboBox sehirComboBox,CheckBox checkBox1,TextBox gbtTxtBox, RadioButton radioButton1, RadioButton radioButton2) //Burda girdiğimiz değerler void içinde kullanılcak değişkenler Tipi çok önemli bi tarih seçiciye textbox giremezsin hata verir
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                con.Open();
                string sorgu = "INSERT INTO Tablo1 (tcno,isimSoyisim,dogumTarihi,sehir,aramaDurumu,gbt,Cinsiyet) VALUES" + "(@tcno,@isimSoyisim,@dogumTarihi, @sehir, @aramaDurumu , @gbt, @Cinsiyet)"; //Sorguyu yapıyoruz
                komut = new OleDbCommand(sorgu, con); //sorgu çalıştırma

                komut.Parameters.AddWithValue("@tcno", tcTxtBox.Text);
                komut.Parameters.AddWithValue("@isimSoyisim", isimsoyisimTxtBox.Text);
                komut.Parameters.AddWithValue("@dogumTarihi", dogumTarihiPicker.Value);
                komut.Parameters.AddWithValue("@sehir", sehirComboBox.SelectedItem);
                komut.Parameters.AddWithValue("@aramaDurumu", checkBox1.Checked);
                komut.Parameters.AddWithValue("@gbt", gbtTxtBox.Text);
                if (radioButton1.Checked)
                {
                    komut.Parameters.AddWithValue("@Cinsiyet", radioButton1.Text);
                }
                else if (radioButton2.Checked)
                {
                    komut.Parameters.AddWithValue("@Cinsiyet", radioButton2.Text);
                }
                else
                {
                    MessageBox.Show("LüTFEN CİNSİYETİNİZİ SEÇİNİZ");
                }


                if (komut.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Kayıt başarıyla oluşturuldu");
                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }
        }
         public void aracKayit(TextBox saseTxtBox,TextBox sahipAdSoyadTxtBox,TextBox cezaTutarTxtBox, DateTimePicker sigortaTarihPicker, TextBox plakaTxtBox,DateTimePicker muayenepicker) //Aynı Şekilde gereken bileşenleri buraya sebebi form sınıfı doğrudan formdaki objelerle bağlantılı fakat yeni açtığımız classlar bağlantılı değil
        {
            using (OleDbConnection con = new OleDbConnection(baglantiStringi))
            {
                con.Open();
                string sorgu = "INSERT INTO Tablo2 (saseno,sahipAdSoyad,cezaTutar,sigortaTarih,plaka,muayeneTarihi) VALUES" + "(@saseno,@sahipAdSoyad,@cezaTutar, @sigortaTarih, @plaka, @muayeneTarihi)";
                komut = new OleDbCommand(sorgu, con);
                komut.Parameters.AddWithValue("@saseno", saseTxtBox.Text);
                komut.Parameters.AddWithValue("@sahipAdSoyad", sahipAdSoyadTxtBox.Text);
                komut.Parameters.AddWithValue("@cezaTutar", cezaTutarTxtBox.Text);
                komut.Parameters.AddWithValue("@sigortaTarih", sigortaTarihPicker.Text);
                komut.Parameters.AddWithValue("@plaka", plakaTxtBox.Text);
                komut.Parameters.AddWithValue("@muayeneTarihi", muayenepicker.Text);

                if (komut.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Kayıt başarıyla oluşturuldu");
                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }
        }
    }
}
