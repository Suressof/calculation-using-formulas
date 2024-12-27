using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Вычисление_по_формулам
{
    public partial class Авторизация : Form
    {
        private SqlConnection sqlConnection = null;
        public Авторизация()
        {
            InitializeComponent();
        }
        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void перейтиКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Вычисление f = new Вычисление();

            if (loginUser != null)
            {
                f.login_vich.Text = "Логин: " + loginUser.ToString();
                f.login_view = loginUser.ToString();
                f.login_pass = loginPass.ToString();

                f.авторизацияToolStripMenuItem.Visible = false;
                f.exit.Visible = true;
                f.ввестиВБДToolStripMenuItem.Visible = true;
                f.базаДанныхToolStripMenuItem.Visible = true;
                f.пройтиТестToolStripMenuItem.Visible = true;
            }

            f.Show();
            this.Hide();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Авторизация_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;
            
            pass_pr.PasswordChar = true;
            voidi_v_acc.FlatAppearance.BorderSize = 0;
            vihod_is_progr.FlatAppearance.BorderSize = 0;

            GraphicsPath gp = new GraphicsPath();
            Graphics g = CreateGraphics();
            // Создадим новый прямоугольник с размерами кнопки 
            Rectangle smallRectangle = vihod_is_progr.ClientRectangle;
            // уменьшим размеры прямоугольника 
            smallRectangle.Inflate(0, 5);
            // создадим эллипс, используя полученные размеры 
            gp.AddEllipse(smallRectangle);
            voidi_v_acc.Region = new Region(gp);
            vihod_is_progr.Region = new Region(gp);
            // освобождаем ресурсы 
            g.Dispose();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.Gray;

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 3;
        }

        public GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize - 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize - 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 3.0F, borderSize / 3.0F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void Авторизация_Paint(object sender, PaintEventArgs e)
        {

            FormRegionAndBorder(this, 10, e.Graphics, Color.LightSteelBlue, 5);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightSteelBlue, Color.LightSkyBlue, 0.0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void обАвторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Об_авторах ob_avt = new Об_авторах();
            ob_avt.Show();
        }

        public string loginUser;
        public string loginPass;
        private void voidi_v_acc_Click(object sender, EventArgs e)
        {
            loginUser = login_pr.Text;
            loginPass = pass_pr.Text;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            sqlConnection.Open();


            DataTable tableStudent = new DataTable();
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlDataAdapter adapterTeacher = new SqlDataAdapter();

            SqlCommand commandStudent = new SqlCommand("Select * from Ученик where login = @userLogin And pass = @userPass", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = loginUser;
            commandStudent.Parameters.Add("@userPass", SqlDbType.VarChar).Value = loginPass;

            SqlCommand commandTeacher = new SqlCommand("Select * from Учитель where login = @userLogin And pass = @userPass", sqlConnection);
            commandTeacher.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = loginUser;
            commandTeacher.Parameters.Add("@userPass", SqlDbType.VarChar).Value = loginPass;

            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableStudent);

            adapterTeacher.SelectCommand = commandTeacher;
            adapterTeacher.Fill(tableTeacher);


            if (tableStudent.Rows.Count > 0)
            {
                if (voidi_v_acc.Text == "Войти") {
                    MessageBox.Show($"Вы ввошли, как Ученик{Environment.NewLine}Вам будет выдан тест{Environment.NewLine}" +
                        $"И возможность сохранять решения формул с графиком", "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    vvedide_login_and_pass.Text = "Приветствую, " + loginUser;
                    func_avt_lb_after.Visible = true;
                    linkLabel_func_avt_after.Visible = true;
                    linkLabel_pass_forget.Visible = false;

                    SqlCommand Student = new SqlCommand($"SELECT email from [Ученик] where login = @login", sqlConnection);
                    Student.Parameters.AddWithValue("login", loginUser);

                    label_lb_reg_new.Text = "Итог теста будет приходить вам на";
                    label_lb_reg_new.Font = new Font("Segoe Script", 10, FontStyle.Bold);
                    linkLabel_lb_reg_new.Text = Student.ExecuteScalar().ToString();
                    linkLabel_lb_reg_new.Font = new Font("Segoe Script", 10, FontStyle.Bold);
                    linkLabel_lb_reg_new.Location = new Point(410, 239);
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Вам будет выдано 2 минуты{Environment.NewLine}Вы уверены, что хотите пройти тест?", "Сообщение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        Тест test = new Тест();
                        test.Show();

                        test.Uchetnaya_sapis.Text = "Ученик - ";
                        test.login_stud.Text = loginUser;

                        test.Vvod_question.Visible = false;
                        test.Vvod_question_2.Visible = false;
                        test.Vvod_question_3.Visible = false;
                        test.Vvod_question_4.Visible = false;
                        test.Vvod_question_5.Visible = false;

                        test.label_vvod_sadania.Visible = false;
                        test.label_vvod_sadania_2.Visible = false;
                        test.label_vvod_sadania_3.Visible = false;
                        test.label_vvod_sadania_4.Visible = false;
                        test.label_vvod_sadania_5.Visible = false;

                        test.OpenImage.Visible = false;
                        test.OpenImage_2.Visible = false;
                        test.OpenImage_3.Visible = false;
                        test.OpenImage_4.Visible = false;
                        test.OpenImage_5.Visible = false;

                        test.lb_choose_image.Visible = false;
                        test.lb_choose_image_2.Visible = false;
                        test.lb_choose_image_3.Visible = false;
                        test.lb_choose_image_4.Visible = false;
                        test.lb_choose_image_5.Visible = false;

                        //Image
                        //SqlCommand com1 = new SqlCommand("Select Image from Тест where id = 1", sqlConnection);
                        //MemoryStream ms = new MemoryStream((byte[])com1.ExecuteScalar());
                        //Image returnImage = Image.FromStream(ms);

                        //test.ViewImage.Image = returnImage;
                        //test.ViewImage.SizeMode = PictureBoxSizeMode.Zoom;
                        test.Save_test.Visible = false;
                        test.Save_test_2.Visible = false;
                        test.Save_test_3.Visible = false;
                        test.Save_test_4.Visible = false;
                        test.Save_test_5.Visible = false;

                        test.Save_test.Location = new Point(797, 12);

                        test.bt_viewTest.Text = "Отправить Тест на проверку";
                    }
                    else { }
                    
                }
                voidi_v_acc.Text = "Тест";

            }
            else if (tableTeacher.Rows.Count > 0)
            {
                if (voidi_v_acc.Text == "Войти")
                {
                    MessageBox.Show("Вы ввошли, как Учитель");
                }
                else
                {
                    Тест test = new Тест();
                    test.Show();
                    test.Uchetnaya_sapis.Text = "Учитель";
                    test.Question.Visible = false;

                    test.vvedite_otvet.Text += ", который должен быть:";
                    test.input_otvet.Location = new Point(330, 338);

                    test.vvedite_otvet_2.Text += ", который должен быть:";
                    test.input_otvet_2.Location = new Point(330, 338);

                    test.vvedite_otvet_3.Text += ", который должен быть:";
                    test.input_otvet_3.Location = new Point(330, 338);

                    test.vvedite_otvet_4.Text += ", который должен быть:";
                    test.input_otvet_4.Location = new Point(330, 338);

                    test.vvedite_otvet_5.Text += ", который должен быть:";
                    test.input_otvet_5.Location = new Point(330, 338);

                    test.timer_ostalos.Visible = false;

                    test.pre_TabPages.Visible = false;
                    test.next_TabPages.Visible = false;
                    test.pre_TabPages_2.Visible = false;
                    test.next_TabPages_2.Visible = false;
                    test.pre_TabPages_3.Visible = false;
                    test.next_TabPages_3.Visible = false;
                    test.pre_TabPages_4.Visible = false;
                    test.next_TabPages_4.Visible = false;
                    test.pre_TabPages_5.Visible = false;
                    test.next_TabPages_5.Visible = false;
                }
                voidi_v_acc.Text = "Тест";
            }
            else
            {
                MessageBox.Show($"У вас не получилось войти{Environment.NewLine}Проверьте ввели ли вы правильно данные", "Сообщение");
            }
        }



        private void p_eye_MouseHover(object sender, EventArgs e)
        {
            Image p = Image.FromFile(@"..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\eye.png");
            p_eye.BackgroundImage = p;
            pass_pr.PasswordChar = false;
        }

        private void p_eye_MouseLeave(object sender, EventArgs e)
        {
            Image p = Image.FromFile(@"..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\closeeye.png");
            p_eye.BackgroundImage = p;
            pass_pr.PasswordChar = true;
        }

        private void vihod_is_progr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (voidi_v_acc.Text == "Войти")
            {
                Регистрация reg = new Регистрация();
                reg.Show();
            }
            else {
                System.Diagnostics.Process.Start("https://www.google.com/intl/ru/gmail/about/");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Забыли_пароль pass = new Забыли_пароль();
            pass.Show();
        }

        private void RegistrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            func_reg.Show();
        }

        private void login_pr_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.LightSkyBlue;
        }

        private void linkLabel_func_avt_after_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            func_reg.Show();
        }
    }
}
