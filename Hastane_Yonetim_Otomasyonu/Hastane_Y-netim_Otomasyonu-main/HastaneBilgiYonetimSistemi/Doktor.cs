using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneBilgiYonetimSistemi
{
    public partial class Doktor1 : Form 
    {
        baglantı bgl = new baglantı();
        public int kul_id;
        public string tanı;
        public Doktor1()
        {
            InitializeComponent();
        }
        public int hastaid;
        public int randevuid;
        private void Doktor_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd"); //bugunse bugunku randevular cıkması ıcın 
            //select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where Personel_id=1
            SqlCommand komut = new SqlCommand($"select P_Ad+' '+P_Soyad as 'Ad Soyad' from tbl_Personel where Personel_id={kul_id}", bgl.bagla());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);           
            da.Fill(dt);
            SqlDataReader oku = komut.ExecuteReader();         
            {
                if (oku.Read())
                {
                    label1.Text = (oku["Ad Soyad"]).ToString();
                    
                }
            }
            dateTimePicker1.Text=DateTime.Now.ToString();
            bgl.bagla().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tanı = "bugun";
            dataGridView1.Visible = true;
            label4.Visible = true;
            goster();
        }
        private void goster()
        {
            string metin = dateTimePicker1.Value.ToString();
            string yenimetin = metin.Replace('.', '-');
            yenimetin = yenimetin.Remove(yenimetin.Length - 9, 9);
            SqlCommand sqlData = new SqlCommand($"select h.Hasta_id,r.Randevu_id,h.Tc,h.Ad + ' ' + h.Soyad as 'Ad Soyad',h.Cinsiyet,r.Sikayet,r.R_Saat from tbl_Randevular r inner join tbl_Hasta h on r.Hasta_id=h.Hasta_id inner join tbl_Personel p on p.Personel_id=r.Doktor_id where p.Personel_id={kul_id} and R_Gun like'%{yenimetin}%'", bgl.bagla());
            DataTable dataTable = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sqlData);
            sd.Fill(dataTable);
            sqlData.ExecuteNonQuery();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Randevu_id"].Visible = false;
            dataGridView1.Columns["Hasta_id"].Visible = false;


            bgl.bagla().Close();

        }

  

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (tanı!="tık")
            {
                try
                {
                    randevuid = int.Parse(dataGridView1.CurrentRow.Cells["Randevu_id"].Value.ToString());
                    hastaid = int.Parse(dataGridView1.CurrentRow.Cells["Hasta_id"].Value.ToString());
                    dataGridView1.Visible = false;
                    panel1.Visible = true;

                    panel2guncelle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bu Alanda Düzenleme Yapamazsınız");
            }


        }
        void panel2guncelle()
        {

            SqlCommand sqlData = new SqlCommand($"select ha.Hasta_id,p.P_Ad+ ' '+ p.P_Soyad as 'Doktor Ad Soyad',ha.Ad+' '+ha.Soyad as 'Hasta Ad Soyad',ra.R_Gun as 'Randevu Tarihi',Acıklama from tbl_Receteler re  inner join tbl_Randevular ra on ra.Randevu_id=re.Randevu_id inner join tbl_Hasta ha on ha.Hasta_id=ra.Hasta_id inner join tbl_Personel p on p.Personel_id=Doktor_id where ha.Hasta_id={hastaid}", bgl.bagla());
            DataTable dataTable = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sqlData);
            sd.Fill(dataTable);
            sqlData.ExecuteNonQuery();
            dataGridView2.DataSource = dataTable;

            bgl.bagla().Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            //Reçete veya tahlil istemek için receteler tablosunu kullandık 
            // recetelere datagrıdvıevde çift tıklanan hastanın randevu ıdsı ve textboxa ırılecek deger alınıp aktarıldı
            SqlCommand command0 = new SqlCommand();

            command0.CommandText = String.Format($"insert into tbl_Receteler(Randevu_id,Acıklama) Values('{randevuid}','{textBox1.Text}')");
            command0.Connection = bgl.bagla();
            bgl.bagla();
            int eklendi = command0.ExecuteNonQuery();
            if (eklendi > 0)
            {
                MessageBox.Show("Eklendi");
                panel2guncelle();
            }
            else
            {
                MessageBox.Show("Eklenmedı");
            }
            bgl.bagla().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {label4.Visible = false;
            tanı = "tık";
            panel1.Visible = false;
            dataGridView1.Visible = true;
            SqlCommand sqlData = new SqlCommand($"select re.Randevu_id,ha.Tc,ha.Ad+ ' '+ha.Soyad as 'Ad Soyad',re.Acıklama from tbl_Receteler re inner join tbl_Randevular ra on ra.Randevu_id=re.Randevu_id inner join tbl_Hasta ha on ra.Hasta_id=ha.Hasta_id where Doktor_id={kul_id}", bgl.bagla());
            DataTable dataTable = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sqlData);
            sd.Fill(dataTable);
            sqlData.ExecuteNonQuery();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Randevu_id"].Visible = false;

            bgl.bagla().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command0 = new SqlCommand();

            command0.CommandText = String.Format($"update tbl_Receteler set Acıklama = '{textBox1.Text}' where Randevu_id={randevuid}");
            command0.Connection = bgl.bagla();
            bgl.bagla();
            int eklendi = command0.ExecuteNonQuery();
            if (eklendi > 0)
            {
                MessageBox.Show("Guncellendi");
                panel2guncelle();
            }
            else
            {
                MessageBox.Show("Önce Ekleme Yapmalısınız");
            }
            bgl.bagla().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            tanı = "tum";
            SqlCommand sqlData = new SqlCommand($"select  h.Hasta_id, r.Randevu_id,h.Tc,h.Ad + ' ' + h.Soyad as 'Ad Soyad',h.Cinsiyet,r.Sikayet,r.R_Saat from tbl_Randevular r inner join tbl_Hasta h on r.Hasta_id=h.Hasta_id inner join tbl_Personel p on p.Personel_id=r.Doktor_id where p.Personel_id={kul_id} ", bgl.bagla());
            DataTable dataTable = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(sqlData);
            sd.Fill(dataTable);
            sqlData.ExecuteNonQuery();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Randevu_id"].Visible = false;
            dataGridView1.Columns["Hasta_id"].Visible = false;



            bgl.bagla().Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            goster();

        
          
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  
        private void button6_Click_1(object sender, EventArgs e)
        {
            Giris_Ekrani giris = new Giris_Ekrani();
            this.Close();
            giris.Visible = true;
        }
    }
}
