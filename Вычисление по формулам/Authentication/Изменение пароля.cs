using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Вычисление_по_формулам
{
    public partial class Изменение_пароля : Form
    {
        public Изменение_пароля()
        {
            InitializeComponent();
        }

        public string login;
        private void Изменение_пароля_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            lb_login.Text = login;

            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2 + this.Width + 20;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Изменение_пароля_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Изменение_пароля_Paint(object sender, PaintEventArgs e)
        {
            Авторизация avt = new Авторизация();

            avt.FormRegionAndBorder(this, 15, e.Graphics, Color.LightSteelBlue, 0);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Teal, Color.Gray, 270.0F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void roundTextBox2_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Teal;
        }

        private void roundTextBox1_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Teal;
        }
        public SqlConnection SqlConnection = null;
        private void change_pass_Click(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            SqlConnection.Open();

            if (pass_tb.Text == "" || pass_tb_check.Text == "")
            {
                MessageBox.Show("У вас пустые значения, введите новый пароль!");
            }
            else
            {
                if (pass_tb.Text == pass_tb_check.Text)
                {
                    SqlCommand Student = new SqlCommand($"UPDATE [Ученик] set pass = @pass where login = @login", SqlConnection);
                    Student.Parameters.AddWithValue("login", login);
                    Student.Parameters.AddWithValue("pass", pass_tb.Text);

                    Student.ExecuteNonQuery().ToString();

                    this.Close();
                    MessageBox.Show($"Пароль был изменен и теперь вы можете зайти под этой учеткой с новым паролем");
                }
                else
                {
                    MessageBox.Show("У вас пароли не совпадают");
                }
            }
        }

        private void change_pass_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Teal;
        }

        private void roundBtn3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundBtn3_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Teal;
        }
    }
}
