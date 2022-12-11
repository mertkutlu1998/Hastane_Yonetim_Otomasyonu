using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneBilgiYonetimSistemi
{
    public partial class Sekreter_paneli : Form
    {
        public int Kul_id;
        int doktor_id;
        Giris_Ekrani giris = new Giris_Ekrani();

        public Sekreter_paneli()
        {
            InitializeComponent();
        }
        public void Hastatcden_id()
        {
            if (tck != 0)
            {
                maskedTextBox1.Text = tck.ToString();
            }
            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select * from tbl_Hasta where Tc={maskedTextBox1.Text}", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {
                hasta_id = int.Parse(oku[0].ToString());
            }
            bgl.bagla().Close();
        }
        baglantı bgl = new baglantı();
        int hasta_id;

        public long tck = 0;
        public string sec;




        private void button2_Click(object sender, EventArgs e)
        {
            if (tck == 0)
            {
                if (button2.Text == "Hasta Ekle")
                {
                    hastasekreterfarkı();
                }
                else
                {
                    SqlCommand kaydet = new SqlCommand($"update tbl_Hasta set Ad='{textBox2.Text}',Soyad='{textBox4.Text}',Cinsiyet='{comboBox1.Text}',Doğum_Tarihi='{maskedTextBox3.Text}',Telefon='{maskedTextBox2.Text}',Ssk_Durum='{comboBox4.Text}',Parola='{textBox3.Text}' where Tc='{maskedTextBox1.Text}'", bgl.bagla());

                    int eklendı = kaydet.ExecuteNonQuery();
                    if (eklendı > 0)
                    {
                        MessageBox.Show("Güncellendi");
                        panel1.Visible = true;
                        Hastatcden_id();
                    }
                }

            }
            else
            {
                maskedTextBox1.Text = tck.ToString();
                hastasekreterfarkı();
                panel1.Visible = false;
                this.Hide();
                giris.Visible = true;

            }







        }
        void hastasekreterfarkı()
        {
            try
            {
                if (textBox2.Text.Trim() != String.Empty && textBox4.Text.Trim() != String.Empty && comboBox1.Text != String.Empty && maskedTextBox3.Text.Length >= 8 && maskedTextBox2.Text.Length == 12 && comboBox4.Text != String.Empty && textBox3.Text.Trim() != String.Empty)
                {
                    bgl.bagla();
                    SqlCommand sorgulama = new SqlCommand($"select * from tbl_Hasta where Tc={maskedTextBox1.Text}", bgl.bagla());
                    sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read() == false)
                    {

                        SqlCommand kaydet = new SqlCommand($"insert into tbl_Hasta (Ad,Soyad,Cinsiyet,Tc,Doğum_Tarihi,Telefon,Ssk_Durum,Parola) Values ('{textBox2.Text}','{textBox4.Text}','{comboBox1.Text}','{maskedTextBox1.Text}','{maskedTextBox3.Text}','{maskedTextBox2.Text}','{comboBox4.Text}','{textBox3.Text}')", bgl.bagla());

                        int eklendı = kaydet.ExecuteNonQuery();
                        if (eklendı > 0)
                        {
                            MessageBox.Show("Hasta Eklendi");
                            panel1.Visible = true;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Boş Alan Bırakmayınız");

                    }
                    bgl.bagla().Close();
                    Hastatcden_id();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //update tbl_Hasta set Ad='asa',Soyad='asd' where Tc=26056519915


        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();
            comboBox3.Text = "";
            SqlCommand komut = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where P_Görev = '{comboBox2.SelectedItem}' and Durum=1", bgl.bagla());

            SqlDataReader dataReader;

            bgl.bagla();
            dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox3.Items.Add(dataReader["Ad Soyad"]);
            }
            bgl.bagla().Close();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            bgl.bagla();
            SqlCommand sorgulama = new SqlCommand($"select * from tbl_Personel where (P_Ad+' '+P_Soyad) = '{comboBox3.SelectedItem}'", bgl.bagla());
            SqlDataReader oku = sorgulama.ExecuteReader();
            if (oku.Read())
            {
                doktor_id = int.Parse(oku[0].ToString());
            }
            bgl.bagla().Close();
        }
        public int randevuid = 0;



        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {


            if (maskedTextBox4.Text.Length >= 9)
            {
                SqlCommand randevunvarmı = new SqlCommand($"select*from tbl_Randevular where Hasta_id={hasta_id} and Doktor_id={doktor_id} and R_Gun='{maskedTextBox4.Text}'", bgl.bagla());

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(randevunvarmı);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    SqlDataReader oku1 = randevunvarmı.ExecuteReader();
                    if (oku1.Read())
                    {
                        randevuid = int.Parse(oku1[0].ToString());

                    }


                    button3.Text = "Randevu Güncelle";
                    DialogResult dr = MessageBox.Show("Mevcut randevunuzu Silmek İster Misiniz", "Uyarı", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        SqlCommand sil = new SqlCommand($"Delete From tbl_Randevular where Randevu_id={randevuid}", bgl.bagla()); ;
                        int i = sil.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Randevu Başarıyla silindi");
                            icerigitemizle();
                        }
                        else
                        {
                            MessageBox.Show("Muayene olunan randevu silinemez");
                        }
                    }

                }

                else
                {
                    button3.Text = "Randevu Ekle";
                }
                bgl.bagla().Close();


            }


        }
        void icerigitemizle()
        {
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            maskedTextBox4.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            maskedTextBox7.Clear();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            maskedTextBox10.Clear();
            textBox1.Clear();

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (maskedTextBox1.Text.Length >= 11)
                {


                    bgl.bagla();
                    SqlCommand sorgulama = new SqlCommand($"select * from tbl_Hasta where Tc={maskedTextBox1.Text}", bgl.bagla());
                    sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    SqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {

                        textBox2.Text = oku[1].ToString();
                        textBox4.Text = oku[2].ToString();
                        comboBox1.Text = oku[3].ToString();
                        maskedTextBox3.Text = oku[5].ToString();
                        maskedTextBox2.Text = oku[6].ToString();
                        comboBox4.Text = oku[7].ToString();
                        hasta_id = int.Parse(oku[0].ToString());
                        textBox3.Text = oku[8].ToString();

                        panel1.Visible = true;
                        button2.Visible = true;
                        button2.Text = "Hasta Güncelle";

                    }


                    else
                    {
                        button2.Text = "Hasta Ekle";

                        button2.Visible = true;
                    }


                }
                else if (maskedTextBox1.Text.Length < 11)
                {
                    textBox2.Clear();
                    textBox4.Clear();
                    comboBox1.Text = "";
                    maskedTextBox3.Clear();
                    maskedTextBox2.Clear();
                    comboBox4.Text = "";
                    panel1.Visible = false;
                    button2.Visible = false;
                    textBox3.Clear();
                }
                bgl.bagla().Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label21.Text = maskedTextBox6.Text.ToString();
                panel3.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                panel3.Visible = false;
                panel2.Visible = true;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox8.TextLength >= 16 && maskedTextBox7.TextLength >= 4 && maskedTextBox9.TextLength >= 3 && maskedTextBox10.Text != string.Empty)
            {

                panel3.Visible = false;
                panel2.Visible = true;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //insert into tbl_Hasta (Ad,Soyad,Cinsiyet,Tc,Doğum_Tarihi,Telefon,Ssk_Durum) Values 
            if (comboBox2.Text != String.Empty && comboBox3.Text != String.Empty && maskedTextBox4.Text.Trim().Length == 10 && comboBox5.Text != String.Empty && maskedTextBox6.Text != String.Empty && textBox1.Text != String.Empty)
            {
                if (button3.Text == "Randevu Ekle")
                {
                    try
                    {
                        bgl.bagla();
                        SqlCommand eklerandevu = new SqlCommand($"insert into tbl_Randevular (Hasta_id,Doktor_id,R_Saat,R_Gun,Sikayet,Ucret) values ({hasta_id},{doktor_id},'{comboBox5.Text}','{maskedTextBox4.Text.Trim()}','{textBox1.Text}',{float.Parse(maskedTextBox6.Text)})", bgl.bagla());

                        int eklendı = eklerandevu.ExecuteNonQuery();
                        if (eklendı > 0)
                        {
                            MessageBox.Show("Hasta Eklendi");
                            icerigitemizle();

                        }
                        bgl.bagla().Close();
                        if (maskedTextBox6.Text != String.Empty)
                        {

                            SqlCommand sorgulama = new SqlCommand($"select*from tbl_Kasa", bgl.bagla());
                            SqlDataReader oku = sorgulama.ExecuteReader();
                            if (oku.Read())
                            {

                                int kasadakiparalar = int.Parse(oku[1].ToString());
                                kasadakiparalar += int.Parse(maskedTextBox6.Text);
                                SqlCommand urunodeme = new SqlCommand($"update tbl_Kasa set total={kasadakiparalar}", bgl.bagla());
                                urunodeme.ExecuteNonQuery();


                            }
                            bgl.bagla().Close();
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Boş Alan Bırakmayınız");
                    }
                }
                else
                {// button3.Text = "Randevu Güncelle" ise

                    SqlCommand guncelleradevu = new SqlCommand($"update tbl_Randevular set R_Saat='{comboBox5.Text}',Sikayet='{textBox1.Text}' where Randevu_id={randevuid} ", bgl.bagla());

                    int eklendı = guncelleradevu.ExecuteNonQuery();
                    if (eklendı > 0)
                    {
                        MessageBox.Show("Güncellendi");
                        icerigitemizle();
                    }

                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız");
            }
            if (tck==0)
            {
                maskedTextBox6.Clear();

            }

        }

        private void Sekreter_paneli_Load(object sender, EventArgs e)
        {


            if (tck == 0)
            {
                SqlCommand komut = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where Personel_id={Kul_id}", bgl.bagla());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                SqlDataReader oku = komut.ExecuteReader();
                {
                    if (oku.Read())
                    {
                        label16.Text = (oku["Ad Soyad"]).ToString();

                    }
                }
                bgl.bagla().Close();
            }
            else
            {
                maskedTextBox1.Text = tck.ToString();
                maskedTextBox1.Enabled = false;//
                button2.Text = "Hasta Ekle";
                button2.Visible = true;
                label16.Text = "Yalnızca ilk muayene içindir";
                label16.BackColor = Color.Red;
                maskedTextBox6.Text = "150";
                maskedTextBox6.Enabled = false;

            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {//select DISTINCT P_Görev from tbl_Personel where Yetki=1
            comboBox2.Items.Clear();
            SqlCommand bolum = new SqlCommand("select DISTINCT P_Görev from tbl_Personel where Yetki=1", bgl.bagla());
            SqlDataReader dataReader;

            bgl.bagla();
            dataReader = bolum.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader["P_Görev"]);
            }
            bgl.bagla().Close();


        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            comboBox5.Items.Add("08:00");
            comboBox5.Items.Add("09:00");
            comboBox5.Items.Add("10:00");
            comboBox5.Items.Add("11:00");
            comboBox5.Items.Add("13:00");
            comboBox5.Items.Add("14:00");
            comboBox5.Items.Add("15:00");
            comboBox5.Items.Add("16:00");
            SqlCommand sqlCommand1 = new SqlCommand($"select R_Saat from tbl_Randevular  where Doktor_id ={doktor_id} and  R_Gun='{maskedTextBox4.Text}'", bgl.bagla());
            SqlDataReader rd;
            bgl.bagla();
            rd = sqlCommand1.ExecuteReader();
            while (rd.Read())
            {
                comboBox5.Items.Remove(rd["R_Saat"]);
            }
            bgl.bagla().Close();
            //Eğer hasta aynı gun ıcınde aynı doktora randevu almamıs ıse randevu alabılır.
            //
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            maskedTextBox1.Clear();
            this.Close();
            giris.Visible=true;

        }
    }
}
