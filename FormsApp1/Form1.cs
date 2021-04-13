using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp1
{
    public partial class Form1 :BseClss
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            var isim = textBox1.Text;
            var sifre = Tools.sifrele(textBox2.Text);

            var deneme = db.tbl_Kullanıcı.Where(w => w.kullanıcıAd == isim).FirstOrDefault();
            if (deneme != null)
            {
                if (deneme.kullanıcıSifre == sifre)
                {
                    Form2 form2 = new Form2();

                    form2.Show();
                    Hide();
                }
                else MessageBox.Show("şifre yanlış");
            }
            else MessageBox.Show("kullanıcı yok");
        }

        private void buttonSifre_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 180);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }else
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
