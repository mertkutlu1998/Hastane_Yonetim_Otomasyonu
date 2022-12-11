using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneBilgiYonetimSistemi
{

    public partial class Giris_Ekrani : Form
    {
        public int id;
        public string secim;
        public long tc;
        public Giris_Ekrani()
        {
            InitializeComponent();
        }
        baglantı bgl = new baglantı();

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;


        }

        public void button1_Click(object sender, EventArgs e)
        {

            if ((maskedTextBox1.Text.Length == 11 || textBox1.Text != String.Empty) && textBox2.Text != String.Empty)
            {
                if (secim == "personel")
                {
                    try
                    {


                        id = Convert.ToInt32(textBox1.Text.Trim());
                        string sifre = textBox2.Text.Trim(); //TRim boşlukları keser 

                        SqlCommand komut = new SqlCommand($"select * from tbl_Personel where sifre='{sifre}' and Personel_id='{id}'", bgl.bagla());
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            maskedTextBox1.Clear();
                            textBox2.Clear();
                            Yonetici_paneli pnelyonetici = new Yonetici_paneli();
                            Doktor1 doktor = new Doktor1();
                            Muhasebe muhasebe = new Muhasebe();

                            Sekreter_paneli sekreter_Paneli = new Sekreter_paneli();
                            for (int i = 1; i <= 4; i++)
                            {
                                SqlCommand komut1 = new SqlCommand($"select * from tbl_Personel where yetki={i} and Personel_id='{id}'", bgl.bagla());
                                DataTable yetki = new DataTable();
                                SqlDataAdapter yetkiad = new SqlDataAdapter(komut1);
                                yetkiad.Fill(yetki);
                                if (yetki.Rows.Count > 0)
                                {

                                    switch (i)
                                    {
                                        case 1:

                                            doktor.kul_id = id;
                                            doktor.Visible = true;
                                            this.Hide(); break;
                                        case 2:
                                            sekreter_Paneli.Kul_id = id;
                                            sekreter_Paneli.Visible = true;
                                            this.Hide(); break;
                                        case 3:
                                            muhasebe.muhasebeid = id;
                                            muhasebe.Visible = true;
                                            this.Hide(); break;
                                        case 4:
                                            pnelyonetici.kul_id1 = id;
                                            pnelyonetici.Visible = true;
                                            this.Hide(); break; //Yönetim giriş paneli
                                        default:
                                            MessageBox.Show("Giriş Yetkniz Yoktur");

                                            break;
                                    }
                                }
                            }
                        }

                        else
                        {
                            MessageBox.Show("Hatalı Giriş");
                        }
                        //Giriş Yapan kullanıcının yetki numarası alınacak ona gore formlara yonlendırılecek              
                        bgl.bagla().Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

                else if (secim == "hasta")
                {//Kayıtlı Hasta girişi için

                    tc = long.Parse(maskedTextBox1.Text.Trim());
                    string sifre = textBox2.Text.Trim(); //TRim boşlukları keser 

                    SqlCommand komut = new SqlCommand($"select * from tbl_Hasta where Tc='{tc}'", bgl.bagla());
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        SqlCommand komut1 = new SqlCommand($"select * from tbl_Hasta where Parola='{sifre}' and Tc='{tc}'", bgl.bagla());
                        DataTable dt1 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(komut1);
                        da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            Sekreter_paneli sekreter_Paneli = new Sekreter_paneli();
                            sekreter_Paneli.Text = "Hasta Randevu Ekranı";
                            sekreter_Paneli.tck = tc;
                            sekreter_Paneli.maskedTextBox1.Text = tc.ToString();
                            sekreter_Paneli.panel4.Visible = false;
                            sekreter_Paneli.panel1.Location = new Point(10, 8);
                            sekreter_Paneli.Visible = true;

                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Şifrenizi Kontrol ediniz");
                        }

                    }

                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Kaydınız bulunamamıştır Yeni Üyelik Oluşturmak İster misiniz", "Dikkat", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Sekreter_paneli sekreter_Paneli = new Sekreter_paneli();
                            sekreter_Paneli.Text = "Hasta Kayıt Ekranı";

                            sekreter_Paneli.tck = this.tc;
                            sekreter_Paneli.sec = this.secim;
                            sekreter_Paneli.Visible = true;
                            this.Visible = false;
                        }
                        else
                        {
                            maskedTextBox1.Clear();
                            textBox2.Clear();
                        }
                        //Yes no olarak butona tıklama olayları kontrol edıldı
                    }
                    //Giriş Yapan kullanıcının yetki numarası alınacak ona gore formlara yonlendırılecek              
                    bgl.bagla().Close();


                }
            }

            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız");
            }



        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;//checkbox basılı ıse sıfrelemıyor
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }
        void sil(){
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
        }

        private void btn_Hasta_Click(object sender, EventArgs e)
        {
            sil();
            maskedTextBox1.Visible = true;
            textBox1.Visible = false;
            secim = "hasta";
            label1.Text = "Hasta T.C.";
            panel1.Visible = true;

        }

        private void btn_Pers_Click(object sender, EventArgs e)
        {
            sil();
            maskedTextBox1.Visible = false;
            textBox1.Visible = true;
            secim = "personel";
            label1.Text = "Personel Id";
            panel1.Visible = true;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }

}
