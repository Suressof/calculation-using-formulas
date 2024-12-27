using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Вычисление_по_формулам
{
    public partial class Просмотр_пройденных_тестов : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;

        public Просмотр_пройденных_тестов()
        {
            InitializeComponent();
        }

        private void Просмотр_пройденных_тестов_Load(object sender, EventArgs e)
        {
            //GraphicsPath gp = new GraphicsPath();
            //Graphics g = CreateGraphics();
            //// Создадим новый прямоугольник с размерами кнопки 
            //Rectangle smallRectangle = comboBox_Student.ClientRectangle;
            //// уменьшим размеры прямоугольника 
            //smallRectangle.Inflate(0, 5);
            //// создадим эллипс, используя полученные размеры 
            //gp.AddEllipse(smallRectangle);
            //comboBox_Student.Region = new Region(gp);
            //// освобождаем ресурсы 
            //g.Dispose();


            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("Select id, login from Ученик", sqlConnection);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            comboBox_Student.DataSource = dt;
            comboBox_Student.DisplayMember = "login";
            comboBox_Student.ValueMember = "id";
            //comboBox_Student.SelectedIndex = 0;


            string selectedItem = comboBox_Student.Text;
            adapter = new SqlDataAdapter("SELECT Question, Answer, Total FROM ПройденныйТест where Login = '" + selectedItem + "'", sqlConnection);
            table = new DataTable();
            adapter.Fill(table);
            BD_prod_Test.DataSource = table;

            BD_prod_Test.AllowUserToAddRows = false;

            int verno = 0;
            int neverno = 0;
            for (int i = 0; i < BD_prod_Test.RowCount; i++)
            {
                for (int j = 0; j < BD_prod_Test.ColumnCount; j++)
                {
                    if (BD_prod_Test.Rows[i].Cells[j].Value.ToString() == "Не Верно")
                    {
                        BD_prod_Test.Rows[i].Cells[j].Style.BackColor = Color.Pink;
                        neverno++;
                    }

                    else if (BD_prod_Test.Rows[i].Cells[j].Value.ToString() == "Верно")
                    {
                        BD_prod_Test.Rows[i].Cells[j].Style.BackColor = Color.LightSeaGreen;
                        verno++;
                    }
                }
            }
            kol_neverno_lb.ForeColor = Color.Red;
            kol_neverno_lb.Text = Convert.ToString(neverno);
            kol_verno_lb.ForeColor = Color.Green;
            kol_verno_lb.Text = Convert.ToString(verno);

            this.BD_prod_Test.Columns[0].Width = 450;
            this.BD_prod_Test.Columns[0].HeaderText = "Вопрос";
            this.BD_prod_Test.Columns[1].HeaderText = "Ответ";
            this.BD_prod_Test.Columns[2].HeaderText = "Итог";
        }

        private void comboBox_Student_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BD_prod_Test.AllowUserToAddRows = false;

                string selectedItem = comboBox_Student.Text;
                adapter = new SqlDataAdapter("SELECT Question, Answer, Total FROM ПройденныйТест where Login = '" + selectedItem + "'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                BD_prod_Test.DataSource = table;

                int verno = 0;
                int neverno = 0;
                for (int i = 0; i < BD_prod_Test.RowCount; i++)
                {
                    for (int j = 0; j < BD_prod_Test.ColumnCount; j++)
                    {
                        if (BD_prod_Test.Rows[i].Cells[j].Value.ToString() == "Не Верно")
                        {
                            BD_prod_Test.Rows[i].Cells[j].Style.BackColor = Color.Pink;
                            neverno++;
                        }

                        else if (BD_prod_Test.Rows[i].Cells[j].Value.ToString() == "Верно")
                        {
                            BD_prod_Test.Rows[i].Cells[j].Style.BackColor = Color.LightSeaGreen;
                            verno++;
                        }
                    }
                }
                kol_neverno_lb.ForeColor = Color.Red;
                kol_neverno_lb.Text = Convert.ToString(neverno);
                kol_verno_lb.ForeColor = Color.Green;
                kol_verno_lb.Text = Convert.ToString(verno);
            }
            catch { }
        }
    }
}
