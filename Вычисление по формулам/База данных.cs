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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;

namespace Вычисление_по_формулам
{
    public partial class База_данных : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;

        public База_данных()
        {
            InitializeComponent();
        }

        private void База_данных_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_formul"].ConnectionString);
            sqlConnection.Open();

            toolTextBox_Search.Text = "Поиск";
            //BD_Formuls_View.BackgroundColor = Color.FromArgb(30, 30, 30);
            //BD_Formuls_View.DefaultCellStyle.BackColor = Color.CadetBlue;

            BD_Formuls_View.AllowUserToAddRows = false;

        }

        private void toolTextBox_Search_Enter(object sender, EventArgs e)
        {
            toolTextBox_Search.Text = "";
            toolTextBox_Search.ForeColor = Color.Black;
        }

        private void toolTextBox_Search_Leave(object sender, EventArgs e)
        {
            if (toolTextBox_Search.Text == "")
            {
                toolTextBox_Search.Text = "Поиск";
                toolTextBox_Search.ForeColor = Color.DimGray;
            }
        }

        public string login_add;
        private void toolStrip_Discriminant_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], b, a, c, D, x1, x2 FROM Дискриминант where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            table = new DataTable();
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;

            StripLabel_Formul.Text = "Открыт Дискриминант";

            graphic_choose_formul.Series["Series2"].Points.Clear();
            graphic_choose_formul.Series["Series1"].Points.Clear();
            graphic_choose_formul.Series["Series_xy"].Points.Clear();
            graphic_choose_formul.Series["Series_allips"].Points.Clear();
            graphic_choose_formul.Series["Series_tochki_allips"].Points.Clear();

            graphic_choose_formul.Visible = true;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Minimum = -5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Minimum = -5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Maximum = 5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Interval = 1;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Interval / 2; ;

            graphic_choose_formul.Series["Series2"].BorderWidth = 2;

            //Указываем ширину у осей X и Y
            //=================================================================================
            StripLine stripLine = new StripLine() //Ось y
            {
                StripWidth = 0.05,
                IntervalOffset = 0,
                BackColor = Color.Black
            };

            StripLine stripLine1 = new StripLine() //Ось x
            {
                StripWidth = 0.07,
                IntervalOffset = 0,
                BackColor = Color.Black
            };

            //Объявляем их 
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine1);
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);
            //=================================================================================

            //Подписываем оси X и Y
            //========================================================
            DataPoint Y = new DataPoint(0.3, 5)
            {
                Label = "y",
                Font = new Font("Times New Roman", 14),
                IsValueShownAsLabel = true //Показать значение в точке
            };
            this.graphic_choose_formul.Series["Series_xy"].Points.Add(Y);

            DataPoint X = new DataPoint(4.8, -0.2)
            {
                Label = "x",
                Font = new Font("Times New Roman", 14),
                IsValueShownAsLabel = true //Показать значение в точке
            };
            this.graphic_choose_formul.Series["Series_xy"].Points.Add(X);


            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }
        }

        private void toolStrip_Allips_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], a, b, S, L, C FROM Эллипс where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            table = new DataTable();
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;

            StripLabel_Formul.Text = "Открыт Эллипс";

            graphic_choose_formul.Series["Series2"].Points.Clear();
            graphic_choose_formul.Series["Series1"].Points.Clear();
            graphic_choose_formul.Series["Series_xy"].Points.Clear();
            graphic_choose_formul.Series["Series_allips"].Points.Clear();
            graphic_choose_formul.Series["Series_tochki_allips"].Points.Clear();

            graphic_choose_formul.Visible = true;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Minimum = -5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Minimum = -5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Maximum = 5;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Interval = 1;
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval =
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.Interval / 2; ;

            graphic_choose_formul.Series["Series_allips"].BorderWidth = 2;

            StripLine stripLine = new StripLine()
            {
                StripWidth = 0.02,
                IntervalOffset = 0,
                BackColor = Color.Black
            };

            StripLine stripLine1 = new StripLine()
            {
                StripWidth = 0.03,
                IntervalOffset = 0,
                BackColor = Color.Black
            };

            graphic_choose_formul.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);
            graphic_choose_formul.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine1);

            //Подписываем оси X и Y
            //========================================================
            DataPoint Y_ = new DataPoint(0.3, 5)
            {
                Label = "y",
                Font = new Font("Times New Roman", 14),
                IsValueShownAsLabel = true //Показать значение в точке
            };
            this.graphic_choose_formul.Series["Series_xy"].Points.Add(Y_);

            DataPoint X = new DataPoint(4.7, 0.001)
            {
                Label = "x",
                Font = new Font("Times New Roman", 14),
                IsValueShownAsLabel = true //Показать значение в точке
            };
            this.graphic_choose_formul.Series["Series_xy"].Points.Add(X);

            fig_formul.Visible = false;

            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }
        }

        private void toolStrip_Cub_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], a, d, S, V FROM Куб where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            table = new DataTable();
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;


            StripLabel_Formul.Text = "Открыт Куб";

            graphic_choose_formul.Visible = false;
            fig_formul.Visible = true;
            fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\cube.png");
            fig_formul.SizeMode = PictureBoxSizeMode.Zoom;

            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }

        }

        private void toolStrip_Celinder_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], R, h, S, V FROM Цилиндр where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            table = new DataTable();
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;

            StripLabel_Formul.Text = "Открыт Цилиндр";

            graphic_choose_formul.Visible = false;
            fig_formul.Visible = true;
            fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Cylinder_geometry.png");
            fig_formul.SizeMode = PictureBoxSizeMode.Zoom;

            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }

            //BD_Formuls_View.Columns[3].Width = 290;
            //BD_Formuls_View.Columns[4].Width = 200;
        }

        private void toolStrip_Conus_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], R, h, L, S, V FROM Конус where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;

            StripLabel_Formul.Text = "Открыт Конус";

            graphic_choose_formul.Visible = false;
            fig_formul.Visible = true;
            fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\konus.png");
            fig_formul.SizeMode = PictureBoxSizeMode.Zoom;

            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }

            //BD_Formuls_View.Columns[0].Width = 100;
            //BD_Formuls_View.Columns[1].Width = 100;
            //BD_Formuls_View.Columns[2].Width = 100;
            //BD_Formuls_View.Columns[3].Width = 100;
            //BD_Formuls_View.Columns[4].Width = 100;
            //BD_Formuls_View.Columns[5].Width = 100;
        }

        private void toolStrip_Shar_Click(object sender, EventArgs e)
        {
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlCommand commandStudent = new SqlCommand("SELECT [№], R, S, V FROM Шар where login_add = @userLogin", sqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_add;
            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableTeacher);
            BD_Formuls_View.DataSource = tableTeacher;

            StripLabel_Formul.Text = "Открыт Шар";

            graphic_choose_formul.Visible = false;
            fig_formul.Visible = true;
            fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\shar.png");
            fig_formul.SizeMode = PictureBoxSizeMode.Zoom;

            this.BD_Formuls_View.Columns[0].Width = 70;

            for (int i = 0; i < tableTeacher.Rows.Count; i++)
            {
                BD_Formuls_View[0, i].Value = i + 1;
            }

            //BD_Formuls_View.Columns[2].Width = 200;
            //BD_Formuls_View.Columns[3].Width = 200;
        }

        private void toolTextBox_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (StripLabel_Formul.Text == "Открыт Дискриминант")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("b like '{0}%' or a like '{1}%'" +
                    " or c like '{2}%' or D like '{3}%' or x1 like '{4}%' or x2 like '{5}%'", toolTextBox_Search.Text,
                    toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
            else if (StripLabel_Formul.Text == "Открыт Эллипс")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("a like '{0}%' or b like '{1}%'" +
                    " or c like '{2}%' or S like '{3}%' or L like '{4}%' or C like '{5}%'", toolTextBox_Search.Text,
                    toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
            else if (StripLabel_Formul.Text == "Открыт Куб")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("a like '{0}%' or d like '{1}%'" +
                    " or S like '{2}%' or V like '{3}%'", toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
            else if (StripLabel_Formul.Text == "Открыт Цилиндр")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("R like '{0}%' or h like '{1}%'" +
                    " or S like '{2}%' or V like '{3}%'", toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
            else if (StripLabel_Formul.Text == "Открыт Конус")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("R like '{0}%' or h like '{1}%'" +
                    " or L like '{2}%' or S like '{3}%' or V like '{4}%'", toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
            else if (StripLabel_Formul.Text == "Открыт Шар")
            {
                (BD_Formuls_View.DataSource as DataTable).DefaultView.RowFilter = string.Format("R like '{0}%' or S like '{1}%'" +
                    " or V like '{2}%'", toolTextBox_Search.Text, toolTextBox_Search.Text, toolTextBox_Search.Text);
            }
        }

        private void BD_Formuls_View_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void BD_Formuls_View_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (StripLabel_Formul.Text == "Открыт Дискриминант")
                {
                    graphic_choose_formul.Series["Series2"].Points.Clear();
                    graphic_choose_formul.Series["Series1"].Points.Clear();

                    double b = Convert.ToDouble(BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value);
                    double a = Convert.ToDouble(BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value);
                    double c = Convert.ToDouble(BD_Formuls_View.Rows[e.RowIndex].Cells[3].Value);

                    double d = b * b - 4 * a * c;
                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);

                    double x0 = (-b / (2 * a));
                    double y0 = (-d / (4 * a));

                    //Точки в Chart
                    DataPoint dp = new DataPoint(x1, 0)
                    {
                        MarkerStyle = MarkerStyle.Circle,
                        MarkerBorderColor = Color.Red,
                        MarkerBorderWidth = 1,
                        IsValueShownAsLabel = true //Показать значение в точке               
                    };
                    DataPoint dp1 = new DataPoint(x2, 0)
                    {
                        MarkerStyle = MarkerStyle.Circle,
                        MarkerBorderColor = Color.Red,
                        MarkerBorderWidth = 1,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    DataPoint dp2 = new DataPoint(x0, y0)
                    {
                        MarkerStyle = MarkerStyle.Circle,
                        MarkerBorderColor = Color.Red,
                        MarkerBorderWidth = 1,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };

                    this.graphic_choose_formul.Series["Series1"].Points.Add(dp);
                    this.graphic_choose_formul.Series["Series1"].Points.Add(dp2);
                    this.graphic_choose_formul.Series["Series1"].Points.Add(dp1);

                    double x__ = -10;
                    double y__;

                    //Изображаем параболу

                    if (d < 0)
                    {
                        graphic_choose_formul.Series["Series1"].Points.Clear();
                        graphic_choose_formul.Series["Series2"].Points.Clear();
                        graphic_choose_formul.Visible = false;
                    }
                    else
                    {
                        graphic_choose_formul.Visible = true;
                        for (int i = 0; i < 200; i++)
                        {
                            x__ = x__ + 0.1;
                            y__ = a * x__ * x__ + b * x__ + c;
                            graphic_choose_formul.Series["Series2"].Points.AddXY(x__, y__);
                        }
                    }
                }
                else if (StripLabel_Formul.Text == "Открыт Эллипс")
                {

                    graphic_choose_formul.Series["Series_allips"].Points.Clear();
                    graphic_choose_formul.Series["Series_tochki_allips"].Points.Clear();

                    double a = Convert.ToDouble(BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value);
                    double b = Convert.ToDouble(BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value);

                    double x;
                    double y;
                    double t = 0;
                    for (int i = 0; i < 90; i++)
                    {
                        t = t + 0.1;
                        x = a * Math.Cos(t);

                        y = b * Math.Sin(t);
                        graphic_choose_formul.Series["Series_allips"].Points.AddXY(x, y);
                    }

                    //-----------------------------------------------------------
                    //Показываем на графике точки a, -a, b и -b
                    //========================================================================
                    DataPoint a_ = new DataPoint(-a, 0)
                    {
                        Label = "      -a",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(a_);

                    DataPoint b_ = new DataPoint(0, b)
                    {
                        Label = "    b",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(b_);

                    DataPoint a1 = new DataPoint(a, 0)
                    {
                        Label = "   a",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(a1);

                    DataPoint b1 = new DataPoint(0, -b)
                    {
                        Label = "    -b",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(b1);

                    DataPoint o = new DataPoint(0, 0)
                    {
                        Label = "   0",
                        MarkerColor = Color.RoyalBlue,
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(o);
                    //========================================================================

                    if (a > b) // Нахождение фокусов в эллипсе
                    {

                        double c = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b, 2)); //F1 and F2

                        //F1 и F2 на графике
                        //=====================================================================
                        DataPoint F1 = new DataPoint(-c, 0)
                        {
                            Label = "F1",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(F1);

                        DataPoint F2 = new DataPoint(c, 0)
                        {
                            Label = "F2",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(F2);
                        //=====================================================================
                    }

                    if (b > a) // Нахождение фокусов в эллипсе
                    {
                        double c = Math.Sqrt(Math.Pow(b, 2) - Math.Pow(a, 2)); //F1 and F2
                        //F1 и F2 на графике
                        //=====================================================================
                        DataPoint F1 = new DataPoint(0, -c)
                        {
                            Label = "     F2",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(F1);

                        DataPoint F2 = new DataPoint(0, c)
                        {
                            Label = "     F1",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_choose_formul.Series["Series_tochki_allips"].Points.Add(F2);
                        //=====================================================================
                    }
                    if (b == a) //Получается Окружность
                    {

                    }

                }
                else if (StripLabel_Formul.Text == "Открыт Куб")
                {
                    fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\cube.png");

                    Graphics part = Graphics.FromImage(fig_formul.Image);
                    part.DrawString("a = " + BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 26, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(540, 890, 0, 340));

                    Graphics part1 = Graphics.FromImage(fig_formul.Image);
                    part1.DrawString("d = " + BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 26, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(540, 490, 500, 340));

                    Graphics part2 = Graphics.FromImage(fig_formul.Image);
                    part2.DrawString("S = " + BD_Formuls_View.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 26, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(0, 0, 500, 340));

                    Graphics part3 = Graphics.FromImage(fig_formul.Image);
                    part3.DrawString("V = " + BD_Formuls_View.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 26, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(0, 970, 500, 340));
                }
                else if (StripLabel_Formul.Text == "Открыт Цилиндр")
                {
                    fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Cylinder_geometry.png");

                    Graphics part = Graphics.FromImage(fig_formul.Image);
                    part.DrawString("R = " + BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular),
                    new SolidBrush(Color.Black), new RectangleF(100, 275, 110, 340));

                    Graphics part1 = Graphics.FromImage(fig_formul.Image);
                    part1.DrawString("h = " + BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular),
                    new SolidBrush(Color.Black), new RectangleF(90, 150, 110, 340));


                    Graphics part3 = Graphics.FromImage(fig_formul.Image);
                    part3.DrawString("S = " + BD_Formuls_View.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular),
                    new SolidBrush(Color.Black), new RectangleF(10, 15, 445, 40));

                    Graphics part4 = Graphics.FromImage(fig_formul.Image);
                    part4.DrawString("V = " + BD_Formuls_View.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 18, FontStyle.Regular),
                    new SolidBrush(Color.Black), new RectangleF(5, 40, 445, 40));
                }
                else if (StripLabel_Formul.Text == "Открыт Конус")
                {
                    fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\konus.png");

                    Graphics part = Graphics.FromImage(fig_formul.Image);
                    part.DrawString("R = " + BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 34, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(500, 750, 500, 340));

                    Graphics part1 = Graphics.FromImage(fig_formul.Image);
                    part1.DrawString("h = " + BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 34, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(380, 500, 500, 340));

                    Graphics part3 = Graphics.FromImage(fig_formul.Image);
                    part3.DrawString("L = " + BD_Formuls_View.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 34, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(5, 30, 800, 60));

                    Graphics part4 = Graphics.FromImage(fig_formul.Image);
                    part4.DrawString("S = " + BD_Formuls_View.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 34, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(5, 80, 800, 60));

                    Graphics part5 = Graphics.FromImage(fig_formul.Image);
                    part5.DrawString("V = " + BD_Formuls_View.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 34, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(5, 130, 800, 60));
                }
                else if (StripLabel_Formul.Text == "Открыт Шар")
                {
                    fig_formul.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\shar.png");

                    Graphics part = Graphics.FromImage(fig_formul.Image);
                    part.DrawString("R = " + BD_Formuls_View.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 48, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(650, 460, 500, 340));

                    Graphics part4 = Graphics.FromImage(fig_formul.Image);
                    part4.DrawString("S = " + BD_Formuls_View.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 48, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(200, 100, 800, 60));

                    Graphics part5 = Graphics.FromImage(fig_formul.Image);
                    part5.DrawString("V = " + BD_Formuls_View.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    new System.Drawing.Font("Times New Roman", 48, FontStyle.Bold),
                    new SolidBrush(Color.Black), new RectangleF(200, 150, 800, 60));
                }
            }
            catch
            {

            }
        }
    }
}
