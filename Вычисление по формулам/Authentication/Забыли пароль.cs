using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Вычисление_по_формулам
{
    public partial class Забыли_пароль : Form
    {
        public Забыли_пароль()
        {
            InitializeComponent();
        }

        private void email_btn_Click(object sender, EventArgs e)
        {
            string email = Convert.ToString(email_tb.Text);
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                if (addr.Address == email)
                {

                    Проверка_почты ch = new Проверка_почты();
                    ch.Show();
                    this.Close();

                    string ret = "";
                    string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int len = 8;
                    Random rnd = new Random();
                    for (int i = 0; i < len; i++)
                        ret += chars[rnd.Next(chars.Length)];

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(email);
                    mailMessage.From = new MailAddress("mathformul@gmail.com");
                    mailMessage.Body = "Ваш код - " + ret;
                    mailMessage.Subject = "Проверка на пользователя";

                    ch.ret1 = ret.ToString();
                    ch.email = email.ToString();

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential("mathformul@gmail.com", "opyugpidyrpeyale");

                    try
                    {
                        smtpClient.SendMailAsync(mailMessage);
                        MessageBox.Show($"Код был отправлен на почту {email}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }

                }
            }
            catch
            {
                MessageBox.Show("Неверный адрес");
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Забыли_пароль_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Забыли_пароль_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.LightSteelBlue;

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2 + 300;
        }

        private void Забыли_пароль_Paint(object sender, PaintEventArgs e)
        {
            Авторизация avt = new Авторизация();
            avt.FormRegionAndBorder(this, 15, e.Graphics, Color.Black, 0);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.BurlyWood, Color.LightSkyBlue, 120.0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void roundBtn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
