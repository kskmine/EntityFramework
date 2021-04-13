using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp1
{
    public partial class Form2 : BseClss
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 180);
            doldur();
        }
        void doldur()
        {
            db = new entityDenemeEntities();
            dataGridView1.DataSource = db.tbl_Kullanıcı.ToList();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            var isim=textBox1.Text;
            var soyisim=textBox2.Text;
            var sifre=Tools.sifrele(textBox3.Text);
            var email=textBox4.Text;

            var deneme = db.tbl_Kullanıcı.Where(w => w.kullanıcıAd == isim).FirstOrDefault();
            if (deneme == null)
            {
                tbl_Kullanıcı ekle = new tbl_Kullanıcı();
                ekle.kullanıcıAd = isim;
                ekle.kullanıcıSoyad = soyisim;
                ekle.kullanıcıSifre = sifre;
                ekle.kullanıcıEmail = email;
                db.tbl_Kullanıcı.Add(ekle);
                db.SaveChanges();
                MessageBox.Show("Kayıt Başarılı");

            }else MessageBox.Show("Bu isimde bir kullanıcı var başka bir kullanıcı adı giriniz");
            doldur();
            textBox1.Text= "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(textBox5.Text);
            var silinecekkisi = db.tbl_Kullanıcı.Where(w => w.kullanıcıID == id).FirstOrDefault();
            db.tbl_Kullanıcı.Remove(silinecekkisi);
            db.SaveChanges();
            doldur();
            textBox5.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var id = Convert.ToInt32( row.Cells["KullanıcıId"].Value.ToString());
                
                PopUpForm popUp = new PopUpForm(id);
                DialogResult dialogResult = popUp.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    popUp.Dispose();

                }
                if (dialogResult == DialogResult.OK)
                {
                    doldur();
                }
                
            }
            //doldur();
        }
        
    }
}
