using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneBilgiYonetimSistemi
{
    public partial class Yonetici_paneli : Form
    {
        public Yonetici_paneli()
        {
            InitializeComponent();
        }
        baglantı bgl = new baglantı();
        int yetki;
        public int kul_id1;
        int personelid;
        int silid;
        public string sifre = "--";

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text.Length >= 11)
                {


                    bgl.bagla();
                    SqlCommand sorgulama = new SqlCommand($"select * from tbl_Personel where P_Tc={maskedTextBox1.Text}", bgl.bagla());
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {
                        personelid = oku.GetInt32(0);
                        textBox2.Text = oku[1].ToString();//AD
                        textBox3.Text = oku[2].ToString();
                        maskedTextBox2.Text = oku[3].ToString();//dt
                        comboBox2.Text = oku[5].ToString();
                        yetki = int.Parse(oku[6].ToString());
                        maskedTextBox3.Text = oku[7].ToString();
                        textBox4.Text = oku[8].ToString();//adres
                        textBox5.Text = oku[9].ToString();//Sifre
                        Pidler();
                        btn_Personel_Ekle.Enabled = false;
                        button1.Enabled = true;
                        switch (yetki)
                        {
                            case 0: comboBox3.SelectedIndex = 4; break;
                            case 1: comboBox3.SelectedIndex = 1; break;
                            case 2: comboBox3.SelectedIndex = 2; break;
                            case 3: comboBox3.SelectedIndex = 3; break;
                            case 4: comboBox3.SelectedIndex = 0; break;
                            case 5: comboBox3.SelectedIndex = 5; break;

                            default:
                                break;
                        }
                        button7.Enabled = true;


                        //  panel1.Visible = true;

                    }
                }
                else if (maskedTextBox1.Text.Length < 11)
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    comboBox2.Text = "";
                    maskedTextBox2.Clear();
                    maskedTextBox3.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    btn_Personel_Ekle.Enabled = true;
                    button7.Enabled = false;
                    button1.Enabled=false;

                    //****************************cb3 silinmeme

                    //comboBox4.Text = "";

                }
                bgl.bagla().Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void yonetici_paneli_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel_personel.Visible = false;
            panel2.Visible = false;
            SqlCommand komut = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where Personel_id={kul_id1}", bgl.bagla());
            SqlDataReader oku = komut.ExecuteReader();
            {
                if (oku.Read())
                {
                    label13.Text = (oku["Ad Soyad"]).ToString();

                }
            }
            bgl.bagla().Close();
            this.Text = "Yönetici " + label13.Text;
        }

        private void button7_Click(object sender, EventArgs e) //Silme
        {/////****************
            SqlCommand aktpsf = new SqlCommand($"select*from tbl_Personel where Personel_id='{label16.Text}'", bgl.bagla());
            SqlDataReader dr=aktpsf.ExecuteReader();
            if (dr.Read())
            {
                int atama =int.Parse(dr["Durum"].ToString());
                MessageBox.Show(atama.ToString());
                if (atama==1)
                {
                    SqlCommand gnclaktfpsf = new SqlCommand($"update tbl_Personel set Durum={0} where Personel_id='{label16.Text}'", bgl.bagla());
                    gnclaktfpsf.ExecuteNonQuery();
                    MessageBox.Show("Pasif Hale geldi");
                }
                else
                {
                    SqlCommand gnclaktfpsf = new SqlCommand($"update tbl_Personel set Durum={1} where Personel_id='{label16.Text}'", bgl.bagla());
                    gnclaktfpsf.ExecuteNonQuery();
                    MessageBox.Show("Akitf Hale Geldi");
                }
                bgl.bagla().Close();

            }
            


        }

        private void btn_Personel_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Visible)
                {
                    sifre = textBox5.Text;
                }
                if (maskedTextBox1.Text.Length == 11 && textBox2.Text.Trim() != String.Empty && textBox3.Text.Trim() != String.Empty && maskedTextBox2.Text.Length == 10 && comboBox3.Text != String.Empty && comboBox2.Text != String.Empty && maskedTextBox3.Text.Length == 14 && textBox4.Text.Trim() != String.Empty && textBox5.Text.Trim() != String.Empty)
                {


                    SqlCommand prsnlEkle = new SqlCommand($"insert into tbl_Personel(P_Ad,P_Soyad,P_Dogum_Tarihi,P_TC,P_Görev,Yetki,P_Telefon,P_Adres,sifre) values('{textBox2.Text}','{textBox3.Text}','{maskedTextBox2.Text}','{maskedTextBox1.Text}','{comboBox2.Text}',{yetki},'{maskedTextBox3.Text}','{textBox4.Text}','{sifre}')", bgl.bagla());
                    int eklendi = prsnlEkle.ExecuteNonQuery();
                    if (eklendi > 0)
                    {
                        MessageBox.Show("Personel Eklendi");
                        Pidler();
                    }
                    else
                    {
                        MessageBox.Show("Personel Kayıtlı");
                    }
                    bgl.bagla().Close();
                }
                else
                {
                    MessageBox.Show("Alanlar Boş veya Eksik Geçilemez");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Pidler()
        {
            SqlCommand prnslıd = new SqlCommand($"select*from tbl_Personel where P_TC='{maskedTextBox1.Text}'", bgl.bagla());
            SqlDataReader dr = prnslıd.ExecuteReader();
            if (dr.Read())
            {
                label16.Text = dr["Personel_id"].ToString();
                button7.Enabled = true;
            }
            else
            {
                MessageBox.Show("IT departmanına başvurunuz.");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            maskedTextBox4.Clear();
            panel_personel.Visible = false;
            panel2.Visible = true;
            dataGridView1.Visible = false;








        }



     
        string secim;
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string persongorev = "";

            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select * from tbl_Personel where (P_Ad+' '+P_Soyad) = '{comboBox1.SelectedItem}'", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {
                personelid = int.Parse(oku[0].ToString());
                persongorev = oku[5].ToString();
            }

            bgl.bagla().Close();
            oku.Close();

            SqlCommand sorgu2 = new SqlCommand($"select*from tbl_Maas where Personel_id={personelid}", bgl.bagla());
            SqlDataReader okuid = sorgu2.ExecuteReader();
            if (okuid.Read())
            {
                maskedTextBox4.Text = okuid[2].ToString();
                label12.Text = persongorev.ToString();
                secim = "var";
                button5.Text = "Güncelle";



            }
            else
            {
                maskedTextBox4.Text = "";
                secim = "yok";
                button5.Text = "Ekle";

            }
            bgl.bagla().Close();
            //select*from tbl_Maas where Personel_id=21

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (secim!="var")
            {//uoksa
                try
                {
                    bgl.bagla();
                    SqlCommand maasEkle = new SqlCommand($"insert into tbl_Maas (Maas,Personel_id) values('{float.Parse(maskedTextBox4.Text)}','{personelid}')", bgl.bagla());

                    int maas = maasEkle.ExecuteNonQuery();
                    if (maas > 0)
                    {
                        MessageBox.Show("Eklendi");
                    }
                    bgl.bagla().Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Böyle bir Personel Yoktur.");

                }
                comboBox1.Items.Clear();
                maskedTextBox4.Clear();
            }
            else
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand($"update tbl_Maas set  Maas={maskedTextBox4.Text} where Personel_id={personelid}", bgl.bagla());
                    int gnclmaas = sqlCommand.ExecuteNonQuery();
                    if (gnclmaas > 0)
                    {
                        MessageBox.Show("Maaş Güncellendi.");
                    }
                    bgl.bagla().Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                maskedTextBox4.Clear();
            }
            

        }

       

        private void comboBox3_Click(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: yetki = 4; break;
                case 1: yetki = 1; break;
                case 2: yetki = 2; break;
                case 3: yetki = 3; break;
                case 4: yetki = 0; break;
                case 5: yetki = 5; break;
                default: yetki = 1; break;
            }
            if (comboBox3.SelectedIndex <= 3)
            {
                label10.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label10.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand bolum = new SqlCommand($"select DISTINCT P_Görev from tbl_Personel where Yetki={yetki}", bgl.bagla());
            SqlDataReader dataReader;
            bgl.bagla();
            dataReader = bolum.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader["P_Görev"]);
            }
            bgl.bagla().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand prslgnclle = new SqlCommand($"update tbl_Personel set P_Ad='{textBox2.Text}' ,P_Soyad='{textBox3.Text}', P_Adres='{textBox4.Text}',P_Görev='{comboBox2.Text}',P_Telefon='{maskedTextBox2.Text}',sifre={textBox5.Text} where Personel_id='{label16.Text}'",bgl.bagla());
            int deneme = prslgnclle.ExecuteNonQuery();
            if (deneme>0)
            {
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("Güncelleme Başarısız.");
            }
            bgl.bagla().Close();

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel p where Durum={1}", bgl.bagla());
            SqlDataReader dataReader;

            dataReader = sorgulama.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader["Ad Soyad"]);
            }


            bgl.bagla().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel_personel.Visible = false;
            dataGridView1.Visible = true;

            try
            {
                bgl.bagla();
                SqlCommand sqlData = new SqlCommand($"select top 3 p.P_Ad+' '+p.P_Soyad as 'Ad Soyad',P_Görev as 'Poliklinik',COUNT(r.Randevu_id) as 'Toplam Hasta' from tbl_Personel p inner join tbl_Randevular r on r.Doktor_id=p.Personel_id where Doktor_id>0 group by P_Ad,P_Soyad,P_Görev order by [Toplam Hasta] desc", bgl.bagla());
                DataTable dataTable = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(sqlData);
                sd.Fill(dataTable);
                sqlData.ExecuteNonQuery();
                dataGridView1.DataSource = dataTable;
                bgl.bagla().Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);    
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel2.Visible = false;
            panel_personel.Visible = true;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Giris_Ekrani giris = new Giris_Ekrani();
            this.Close();
            giris.Visible = true;
        }
    }
}
