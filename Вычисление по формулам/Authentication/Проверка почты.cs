using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вычисление_по_формулам
{
    public partial class Проверка_почты : Form
    {
        public string ret1;
        public string login;
        public string pass;
        public string email;
        public Проверка_почты()
        {
            InitializeComponent();
        }

        private void Проверка_почты_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.Gray;

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2 + this.Width;
        }

        private void Проверка_почты_Paint(object sender, PaintEventArgs e)
        {
            Авторизация avt = new Авторизация();

            avt.FormRegionAndBorder(this, 15, e.Graphics, Color.LightSteelBlue, 0);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Teal, Color.Gray, 90.0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Проверка_почты_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public SqlConnection SqlConnection = null;
        private void checkEmail_btn_Click(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            SqlConnection.Open();

            if (email_check.Text == ret1)
            {
                try
                {
                    SqlCommand Student = new SqlCommand(
                    $"INSERT INTO [Ученик] (login, pass, email) VALUES (@login, @pass, @email)",
                    SqlConnection);

                    Student.Parameters.AddWithValue("login", login);
                    Student.Parameters.AddWithValue("pass", pass);
                    Student.Parameters.AddWithValue("email", email);

                    Student.ExecuteNonQuery().ToString();

                    MessageBox.Show($"Код был введен верно.{Environment.NewLine}Поздравляем Вы зарегистрировались и теперь можете зайти под этой учеткой");
                    this.Close();
                }
                catch
                {
                    SqlCommand Student = new SqlCommand($"SELECT login from [Ученик] where email = @email", SqlConnection);
                    Student.Parameters.AddWithValue("email", email);

                    Изменение_пароля pass = new Изменение_пароля();
                    pass.login = Student.ExecuteScalar().ToString();
                    pass.Show();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Код был введен не верно.");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void retry_send_Click(object sender, EventArgs e)
        {
            ret1 = "";
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int len = 8;
            Random rnd = new Random();
            for (int i = 0; i < len; i++)
                ret1 += chars[rnd.Next(chars.Length)];

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(email);
            mailMessage.From = new MailAddress("mathformul@gmail.com");
            mailMessage.Body = "Ваш повторный код - " + ret1;
            mailMessage.Subject = "Проверка на пользователя";


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

        private void close_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Teal;
        }

        private void checkEmail_btn_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Teal;
        }
    }
}
