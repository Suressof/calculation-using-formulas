using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вычисление_по_формулам
{
    public partial class Регистрация : Form
    {
        public SqlConnection SqlConnection = null;

        public Регистрация()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Регистрация_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.Gray;

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2 + 300;

            textBox_pass.PasswordChar = '*';
            textBox_pass_pod.PasswordChar = '*';

            GraphicsPath gp = new GraphicsPath();
            Graphics g = CreateGraphics();
            // Создадим новый прямоугольник с размерами кнопки 
            Rectangle smallRectangle = check_input_reg.ClientRectangle;
            // уменьшим размеры прямоугольника 
            smallRectangle.Inflate(4, 20);
            // создадим эллипс, используя полученные размеры 
            gp.AddEllipse(smallRectangle);
            check_input_reg.Region = new Region(gp);
            // освобождаем ресурсы 
            g.Dispose();
        }

        private void Регистрация_Paint(object sender, PaintEventArgs e)
        {
            Авторизация avt = new Авторизация();
            avt.FormRegionAndBorder(this, 15, e.Graphics, Color.LightSteelBlue, 0);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.BurlyWood, Color.LightSkyBlue, 120.0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void bt_reg_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void bt_reg_Click(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            SqlConnection.Open();

            string login = Convert.ToString(textBox_login.Text);
            string pass = Convert.ToString(textBox_pass.Text);
            string check = Convert.ToString(textBox_pass_pod.Text);
            string email = Convert.ToString(textBox_email.Text);

            if (login.Length == 0 || pass.Length == 0 || email.Length == 0)
            {
                check_input_reg.Visible = true;
            }
            else
            {
                check_input_reg.Visible = false;

                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);

                    if (addr.Address == email)
                    {
                        DataTable tableStudent = new DataTable();
                        SqlDataAdapter adapterStudent = new SqlDataAdapter();

                        SqlCommand commandStudent = new SqlCommand("Select * from Ученик where login = @userLogin", SqlConnection);
                        commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login;

                        adapterStudent.SelectCommand = commandStudent;
                        adapterStudent.Fill(tableStudent);

                        if (tableStudent.Rows.Count > 0)
                        {
                            MessageBox.Show("Такой пользователь с таким логином уже есть", 
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DataTable tableStudentEmail = new DataTable();
                            SqlDataAdapter adapterStudentEmail = new SqlDataAdapter();
                            SqlCommand commandStudentEmail = new SqlCommand("Select * from Ученик where email = @userEmail", SqlConnection);
                            commandStudentEmail.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email;
                            adapterStudentEmail.SelectCommand = commandStudentEmail;
                            adapterStudentEmail.Fill(tableStudentEmail);

                            if (tableStudentEmail.Rows.Count > 0)
                            {
                                MessageBox.Show("Такой пользователь с такой почтой уже есть", 
                                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                if (check != pass)
                                {
                                    MessageBox.Show("Подверждение пароля не соответствует введенному", 
                                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
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
                                    mailMessage.Subject = "Проверка пользователя";

                                    // Передачя переменных в другую форму
                                    ch.ret1 = ret.ToString();
                                    ch.login = login.ToString();
                                    ch.pass = pass.ToString();
                                    ch.email = email.ToString();

                                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                                    smtpClient.EnableSsl = true;
                                    smtpClient.Port = 587;
                                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtpClient.Credentials = new NetworkCredential("mathformul@gmail.com", "opyugpidyrpeyale");

                                    try
                                    {
                                        smtpClient.SendMailAsync(mailMessage);
                                        MessageBox.Show ($"Код был отправлен на почту {email}");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show ($"{ex.Message}");
                                    }

                                    //SqlCommand Student = new SqlCommand(
                                    //$"INSERT INTO [Ученик] (login, pass, email) VALUES (@login, @pass, @email)",
                                    //SqlConnection);

                                    //Student.Parameters.AddWithValue("login", login);
                                    //Student.Parameters.AddWithValue("pass", pass);
                                    //Student.Parameters.AddWithValue("email", email);

                                    //Student.ExecuteNonQuery().ToString();
                                    //MessageBox.Show($"Вы зарегистрировались!{Environment.NewLine}И теперь вы можете пройти тест", 
                                    //    "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный адрес");
    
                }
            }
        }

        private void bt_reg_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
        }
    }
}
