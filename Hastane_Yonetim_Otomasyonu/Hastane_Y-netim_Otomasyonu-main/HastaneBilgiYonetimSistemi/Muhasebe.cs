using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneBilgiYonetimSistemi
{
    public partial class Muhasebe : Form
    {
        public Muhasebe()
        {
            InitializeComponent();
        }
        baglantı bgl = new baglantı();
        public int muhasebeid;
        public int tedarik_id;
        int total = 0;
        int degisenpara;
        int kasadakiparalar;
        private void Muhasebe_Load(object sender, EventArgs e)
        {
           
            pnl_Tedarikci.Visible = false;
            pnl_Malzeme.Visible=false;
            kasadakipara();
            SqlCommand sorgulama = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where Personel_id={muhasebeid}", bgl.bagla());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sorgulama);
            da.Fill(dt);
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {

                label13.Text = (oku["Ad Soyad"]).ToString();
            }
        }
       public void kasadakipara()
        {
            SqlCommand sorgulama = new SqlCommand($"select*from tbl_Kasa", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {

               kasadakiparalar = int.Parse(oku[1].ToString());
                label12.Text = kasadakiparalar.ToString();
            }
           
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_Tedarikci.Visible = true;
            pnl_Malzeme.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand tedarikciEkle = new SqlCommand($"insert into tbl_Tedarikciler (T_Ad,T_Adres,T_Telefon) values ('{textBox2.Text}','{textBox1.Text}','{maskedTextBox1.Text.ToString()}')", bgl.bagla());

                int oldumu = tedarikciEkle.ExecuteNonQuery();
                if (oldumu > 0)
                {
                    MessageBox.Show("Oldu Kardeşim");
                }
                else
                {
                    MessageBox.Show("Olmadı Kardeşim");
                }
                bgl.bagla().Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand($"update tbl_Tedarikciler set T_Ad='{textBox2.Text}',T_Adres='{textBox1.Text}',T_Telefon='{maskedTextBox1.Text}' where Tedarikci_id={tedarik_id}", bgl.bagla());
                int oldumu = guncelle.ExecuteNonQuery();
                if (oldumu > 0)
                {
                    MessageBox.Show("Firma Güncellendi");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select*from tbl_Tedarikciler where T_Ad='{textBox2.Text}'", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {
               tedarik_id = int.Parse(oku[0].ToString());

                textBox1.Text = oku[2].ToString();
                maskedTextBox1.Text = oku[3].ToString();
                MessageBox.Show("Firma vardır");
            }
            else
                MessageBox.Show("Kayıtlarda hasta bulunamadı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnl_Malzeme.Visible = true;
            pnl_Tedarikci.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            SqlCommand komut = new SqlCommand($"select T_Ad from tbl_Tedarikciler", bgl.bagla());

            SqlDataReader dataReader;

            bgl.bagla();
            dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader["T_Ad"]);
            }
            bgl.bagla().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {//insert into tbl_Malzemeler (Tedarik_id,Adı,Adet,Ucret,Detay) values()
            total = int.Parse(maskedTextBox2.Text.Trim()) * int.Parse(maskedTextBox3.Text.Trim());
            degisenpara = int.Parse(label12.Text.Trim()) - total;
            label12.Text=degisenpara.ToString();
            try
            {
                SqlCommand urunekle = new SqlCommand($"insert into tbl_Malzemeler (Tedarik_id,Adı,Adet,Ucret,Detay) values({tedarik_id},'{textBox5.Text.Trim()}',{maskedTextBox2.Text.Trim()},{float.Parse(maskedTextBox3.Text.Trim())},'{textBox4.Text}')", bgl.bagla()); 

                int oldumu = urunekle.ExecuteNonQuery();
                if (oldumu > 0)
                {
                    MessageBox.Show("Ürün Eklendi");
                    kasadakipara();
                }
                else
                {
                    MessageBox.Show("Ürün Eklenemedi");
                }
                bgl.bagla().Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();


            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select * from tbl_Tedarikciler", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {
                tedarik_id = int.Parse(oku[0].ToString());
            }
            bgl.bagla().Close();
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void kasadandusenpara(object sender, EventArgs e)
        {
            if (total!=0)
            {
                SqlCommand urunodeme = new SqlCommand($"update tbl_Kasa set total={degisenpara}",bgl.bagla());
                int i = urunodeme.ExecuteNonQuery();
                if (i>0)
                {
                    MessageBox.Show($"Kasadan {total} TL ödeme yapılddı");
                }
                bgl.bagla().Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
          

            int date = DateTime.Now.Date.DayOfYear;
            if (date % 30 == 0)
            {
                SqlCommand maasode = new SqlCommand($"select Sum(Maas) as 'Maas' from tbl_Maas m inner join tbl_Personel t on m.Personel_id=t.Personel_id where t.Durum=1 group by Durum", bgl.bagla());
                SqlDataReader sqlDataReader = maasode.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    kasadakiparalar -= int.Parse(sqlDataReader[0].ToString());
                    label12.Text = kasadakiparalar.ToString();
                }
            }
            else
            {
                MessageBox.Show("Yalnızca 30. günü ödeme talimatı verilebilir");
            }

        }
    }
}
