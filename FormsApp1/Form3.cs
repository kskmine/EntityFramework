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
    public partial class Form3 : BseClss
    {
        public Form3()
        {
            InitializeComponent();
        }
       

        private void buttonMail_Click(object sender, EventArgs e)
        {
            var isim = textBox1.Text;
            var mail = textBox2.Text;

            var deneme = db.tbl_Kullanıcı.Where(w => w.kullanıcıAd == isim).FirstOrDefault();
            
            if (deneme != null)
            {
                if (deneme.kullanıcıEmail==mail) {
                    try
                    {
                        SmtpClient sc = new SmtpClient();
                        sc.Port = 587;
                        sc.Host = "smtp.gmail.com";
                        sc.EnableSsl = true;

                        string icerik = Tools.sifreCoz(deneme.kullanıcıSifre);

                        sc.Credentials = new NetworkCredential("busra38kalkan@gmail.com", ".kelebek12E");

                        MailMessage email = new MailMessage();
                        email.From = new MailAddress("busra38kalkan@gmail.com");

                        email.To.Add(Tools.sifreCoz(mail));

                        email.Subject = "Şifre Bilgilendirme";
                        email.IsBodyHtml = true;
                        email.Body = icerik;
                        sc.Send(email);

                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Close();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("   Mail Gönderme Hatası:\nİnternet Bağlantınızı Kontrol Ediniz");
                    }
                }else  MessageBox.Show("Yanlış mail girdiniz");

            }
            else MessageBox.Show("kullanıcı bulunamadı");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 180);
        }
    }
}
