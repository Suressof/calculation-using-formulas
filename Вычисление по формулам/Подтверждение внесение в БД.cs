using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Вычисление_по_формулам
{
    public partial class Подтверждение_внесение_в_БД : Form
    {
        public SqlConnection SqlConnection = null;

        //Переменные для Дискриминанта 
        public int b_sn;
        public int a_sn;
        public int c_sn;
        public string D;
        public string x1;
        public string x2;

        //Переменные для Эллипса 
        public int a_allips;
        public int b_allips;
        public string S;
        public string L;
        public string C;

        //Переменные для ф. Куба                         
        public double a_kub;
        public string d_kub;
        public string S_kub;
        public string V_kub;

        //Переменные для ф. Цилиндр                         
        public double R_cilinder;
        public double h_cilinder;
        public string S_cilinder;
        public string V_cilinder;

        //Переменные для ф. Цилиндр                         
        public double R_conus;
        public double h_conus;
        public string L_conus;
        public string S_conus;
        public string V_conus;

        //Переменные для ф. Цилиндр                         
        public double R_shar;
        public string S_shar;
        public string V_shar;

        //Login
        public string Login_ADD;

        public Подтверждение_внесение_в_БД()
        {
            InitializeComponent();
        }

        private void vihod_pod_BD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vvod_pod_BD_Click(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_formul"].ConnectionString);
            SqlConnection.Open();

            Вычисление main_form = new Вычисление();

            if (formula_index.Text == "ф. Дискриминанта?")
            {

                SqlCommand Discriminant = new SqlCommand(
                    $"INSERT INTO [Дискриминант] (b, a, c, D, x1, x2, login_add) VALUES (@b, @a, @c, @D, @x1, @x2, @login)",
                SqlConnection);


                Discriminant.Parameters.AddWithValue("b", b_sn);
                Discriminant.Parameters.AddWithValue("a", a_sn);
                Discriminant.Parameters.AddWithValue("c", c_sn);
                Discriminant.Parameters.AddWithValue("D", D);
                Discriminant.Parameters.AddWithValue("x1", x1);
                Discriminant.Parameters.AddWithValue("x2", x2);
                Discriminant.Parameters.AddWithValue("login", Login_ADD);

                Discriminant.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.Close();
            }

            else if (formula_index.Text == "ф. Эллипса?")
            {
                SqlCommand Allips = new SqlCommand(
                    $"INSERT INTO [Эллипс] (a, b, S, L, C, login_add) VALUES (@a, @b, @S, @L, @C, @login)",
                SqlConnection);

                Allips.Parameters.AddWithValue("a", a_allips);
                Allips.Parameters.AddWithValue("b", b_allips);
                Allips.Parameters.AddWithValue("S", S);
                Allips.Parameters.AddWithValue("L", L);
                Allips.Parameters.AddWithValue("C", C);
                Allips.Parameters.AddWithValue("login", Login_ADD);

                Allips.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.Close();
            }

            else if(formula_index.Text == "ф. Куба?")
            {
                SqlCommand Kub = new SqlCommand(
                    $"INSERT INTO [Куб] (a, d, S, V, login_add) VALUES (@a, @d, @S, @V, @login)",
                SqlConnection);

                Kub.Parameters.AddWithValue("a", a_kub);
                Kub.Parameters.AddWithValue("d", d_kub);
                Kub.Parameters.AddWithValue("S", S_kub);
                Kub.Parameters.AddWithValue("V", V_kub);
                Kub.Parameters.AddWithValue("login", Login_ADD);

                Kub.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }

            else if (formula_index.Text == "ф. Цилиндр?")
            {
                SqlCommand Cilinder = new SqlCommand(
                    $"INSERT INTO [Цилиндр] (R, h, S, V, login_add) VALUES (@R, @h, @S, @V, @login)",
                SqlConnection);

                Cilinder.Parameters.AddWithValue("R", R_cilinder);
                Cilinder.Parameters.AddWithValue("h", h_cilinder);
                Cilinder.Parameters.AddWithValue("S", S_cilinder);
                Cilinder.Parameters.AddWithValue("V", V_cilinder);
                Cilinder.Parameters.AddWithValue("login", Login_ADD);

                Cilinder.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            
            else if (formula_index.Text == "ф. Конус?")
            {
                SqlCommand Conus = new SqlCommand(
                    $"INSERT INTO [Конус] (R, h, L, S, V, login_add) VALUES (@R, @h, @L, @S, @V, @login)",
                SqlConnection);

                Conus.Parameters.AddWithValue("R", R_conus);
                Conus.Parameters.AddWithValue("h", h_conus);
                Conus.Parameters.AddWithValue("L", L_conus);
                Conus.Parameters.AddWithValue("S", S_conus);
                Conus.Parameters.AddWithValue("V", V_conus);
                Conus.Parameters.AddWithValue("login", Login_ADD);

                Conus.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }

            else if (formula_index.Text == "ф. Шар?")
            {
                SqlCommand Shar = new SqlCommand(
                    $"INSERT INTO [Шар] (R, S, V, login_add) VALUES (@R, @S, @V, @login)",
                SqlConnection);

                Shar.Parameters.AddWithValue("R", R_shar);
                Shar.Parameters.AddWithValue("S", S_shar);
                Shar.Parameters.AddWithValue("V", V_shar);
                Shar.Parameters.AddWithValue("login", Login_ADD);

                Shar.ExecuteNonQuery().ToString();
                MessageBox.Show("Вы внесли данные в Базу данных!", "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }


        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Подтверждение_внесение_в_БД_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Подтверждение_внесение_в_БД_Load(object sender, EventArgs e)
        {
            vvod_pod_BD.FlatAppearance.BorderSize = 0;
            vihod_pod_BD.FlatAppearance.BorderSize = 0;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(2);
            this.BackColor = Color.Gray;
        }

        private void Подтверждение_внесение_в_БД_Paint(object sender, PaintEventArgs e)
        {
            Авторизация avt = new Авторизация();
            avt.FormRegionAndBorder(this, 15, e.Graphics, Color.LightSteelBlue, 0);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightSteelBlue, Color.LightSkyBlue, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void vihod_pod_BD_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
        }
    }
}
