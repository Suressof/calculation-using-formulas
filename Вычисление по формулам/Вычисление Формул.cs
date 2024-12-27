using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.IO;
using Application = System.Windows.Forms.Application;

namespace Вычисление_по_формулам
{
    public partial class Вычисление : Form
    {
        public SqlConnection SqlConnection = null;
        public string login_view;
        public string login_pass;
        public Вычисление()
        {
            InitializeComponent();
            //Chart - Это График, в котором будут находится наши значения, функции
            //Series - Это Линия, которая будет находится в Chart
            //ChartAreas - Это Область, в котором находится наши Series
        }
        private void Programm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Очистка при нажатии TextBox, где мы указали промежуток, в котором пользователь должен ввести число
        //=============================================================================================

        private void b_sn_Click_1(object sender, EventArgs e)
        {
            b_sn.Clear(); //Очищение при нажатии b
            b_sn.ForeColor = Color.Black;
        }
        private void a_sn_Click(object sender, EventArgs e)
        {
            a_sn.Clear(); //Очищение при нажатии a
            a_sn.ForeColor = Color.Black;
        }
        private void c_sn_Click(object sender, EventArgs e)
        {
            c_sn.Clear(); //Очищение при нажатии c
            c_sn.ForeColor = Color.Black;
        }
        private void y2_Click(object sender, EventArgs e)
        {
            y2.Clear(); //Очищение при нажатии 
            y2.ForeColor = Color.Black;
        }
        private void x2_Click(object sender, EventArgs e)
        {
            x2.Clear(); //Очищение при нажатии 
            x2.ForeColor = Color.Black;
        }
        private void x1_Click(object sender, EventArgs e)
        {
            x1.Clear(); //Очищение при нажатии 
            x1.ForeColor = Color.Black;
        }
        private void y1_Click(object sender, EventArgs e)
        {
            y1.Clear(); //Очищение при нажатии 
            y1.ForeColor = Color.Black;
        }
        private void k_Click(object sender, EventArgs e)
        {
            k.Clear(); //Очищение при нажатии 
            k.ForeColor = Color.Black;
        }
        private void a_giper_Click(object sender, EventArgs e)
        {
            a_giper.Clear(); //Очищение при нажатии 
            a_giper.ForeColor = Color.Black;
        }
        private void b_giper_Click(object sender, EventArgs e)
        {
            b_giper.Clear(); //Очищение при нажатии 
            b_giper.ForeColor = Color.Black;
        }
        private void a_allips_Click(object sender, EventArgs e)
        {
            a_allips.Clear(); //Очищение при нажатии 
            a_allips.ForeColor = Color.Black;
        }
        private void b_allips_Click(object sender, EventArgs e)
        {
            b_allips.Clear(); //Очищение при нажатии 
            b_allips.ForeColor = Color.Black;
        }
        //=============================================================================================

        private void otvet_discriminant_Click(object sender, EventArgs e) // График Дискриминанта и ввод значения b, a и с
        {
            try
            {
                graphic_parabola.Visible = true;

                double a = Convert.ToInt64(a_sn.Text);
                double b = Convert.ToInt64(b_sn.Text);
                double c = Convert.ToInt64(c_sn.Text);

                if (this.b_sn.Text == "" || this.a_sn.Text == "" || this.c_sn.Text == "") //Проверка значений a, b, c
                {
                    корень.Text = "Введите все коэффициенты";
                    return;
                }
                discr.Text = "D = " + b + "^2 - 4 * " + a + " * " + c;


                // Данные что введены в TextBox, записываем в переменные,
                // чтобы потом вычислить по формуле
                double d = b * b - 4 * a * c;
                double x1, x2, x0, y0;

                if (a < -5 || a > 5 || b < -5 || b > 5 || c < -5 || c > 5)  //Выходит за промежуток указанный в TextBox //Ограничение
                {
                    graphic_parabola.Visible = false;
                    MessageBox.Show("Проверьте значения, возможно у вас выходят a, b или с за промежутки от -5 до 5 ", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    discriminant.Text = "D = . . .";
                    корень.Text = "X1 = ";
                    корень2.Text = "X2 = ";
                }

                if ((a >= -5 && a <= 5) && (b >= -5 && b <= 5) && (c >= -5 && c <= 5)) //Входит в промежуток
                {
                    if (d > 0)
                    {
                        //Очистка при повторным выводе графика
                        //==================================================
                        graphic_parabola.Series["Series2"].Points.Clear();
                        graphic_parabola.Series["Series1"].Points.Clear();
                        graphic_parabola.Series["Series_xy"].Points.Clear();
                        //==================================================

                        discriminant.Text = "D = " + d;
                        x1 = (-b + Math.Sqrt(d)) / (2 * a);
                        x2 = (-b - Math.Sqrt(d)) / (2 * a);
                        корень.Text = "X1 = " + Math.Round(x1, 2);
                        корень2.Text = "X2 = " + Math.Round(x2, 2);

                        //Обьявление изображении Chart //Как он будет выглядить статическом виде
                        // "ChartArea1" название ChartAreas (Название области Chart)
                        //=======================================================================
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Minimum = -5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Minimum = -5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Maximum = 5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Interval = 1;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval =
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Interval / 2; ;
                        //=======================================================================

                        x0 = (-b / (2 * a));
                        graphic_parabola.Series["Series2"].BorderWidth = 3;
                        y0 = (-d / (4 * a));

                        //Указываем ширину у осей X и Y
                        //=================================================================================
                        StripLine stripLine = new StripLine() //Ось y
                        {
                            StripWidth = 0.03,
                            IntervalOffset = 0,
                            BackColor = Color.Black
                        };

                        StripLine stripLine1 = new StripLine() //Ось x
                        {
                            StripWidth = 0.03,
                            IntervalOffset = 0,
                            BackColor = Color.Black
                        };

                        //Объявляем их 
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine1);
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);
                        //=================================================================================

                        //Подписываем оси X и Y
                        //========================================================
                        DataPoint Y = new DataPoint(0.15, 5)
                        {
                            Label = "y",
                            Font = new Font("Times New Roman", 14),
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_parabola.Series["Series_xy"].Points.Add(Y);

                        DataPoint X = new DataPoint(4.8, -0.2)
                        {
                            Label = "x",
                            Font = new Font("Times New Roman", 14),
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.graphic_parabola.Series["Series_xy"].Points.Add(X);
                        //========================================================

                        if (a < 0 || a > 0)
                        {

                            graphic_parabola.Series["Series2"].Points.Clear();
                            graphic_parabola.Series["Series1"].Points.Clear();

                            //Точки в Chart
                            DataPoint dp = new DataPoint(x1, 0)
                            {
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerBorderColor = Color.Red,
                                MarkerBorderWidth = 4,
                                IsValueShownAsLabel = true //Показать значение в точке               
                            };
                            DataPoint dp1 = new DataPoint(x2, 0)
                            {
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerBorderColor = Color.Red,
                                MarkerBorderWidth = 4,
                                IsValueShownAsLabel = true //Показать значение в точке
                            };
                            DataPoint dp2 = new DataPoint(x0, y0)
                            {
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerBorderColor = Color.Red,
                                MarkerBorderWidth = 4,
                                IsValueShownAsLabel = true //Показать значение в точке
                            };

                            this.graphic_parabola.Series["Series1"].Points.Add(dp);
                            this.graphic_parabola.Series["Series1"].Points.Add(dp2);
                            this.graphic_parabola.Series["Series1"].Points.Add(dp1);

                            double x__ = -10;
                            double y__;

                            //Изображаем параболу

                            for (int i = 0; i < 200; i++)
                            {
                                x__ = x__ + 0.1;
                                y__ = a * x__ * x__ + b * x__ + c;
                                graphic_parabola.Series["Series2"].Points.AddXY(x__, y__);
                            }
                        }

                        if (a == 0)
                        {
                            graphic_parabola.Visible = false;
                            корень.Text = "Обязательное условие — a ≠ 0";
                            корень2.Text = " ";
                        }
                        graphic_parabola.Series["Series2"].ChartType = SeriesChartType.Line;
                    }

                    else if (d == 0)
                    {
                        graphic_parabola.Series["Series2"].Points.Clear();
                        graphic_parabola.Series["Series1"].Points.Clear();
                        discriminant.Text = "D = " + d;
                        x1 = (-b / (2 * a));
                        корень.Text = "Уравнение имеет один корень.";
                        корень2.Text = "X1 = " + Math.Round(x1, 2);

                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Maximum = 5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Minimum = -5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Minimum = -5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Maximum = 5;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.Interval = 1;

                        StripLine stripLine = new StripLine()
                        {
                            StripWidth = 0.03,
                            IntervalOffset = 0,
                            BackColor = Color.Black
                        };
                        StripLine stripLine1 = new StripLine()
                        {
                            StripWidth = 0.03,
                            IntervalOffset = 0,
                            BackColor = Color.Black
                        };
                        graphic_parabola.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine1);
                        graphic_parabola.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);

                        if (a == 0)
                        {
                            graphic_parabola.Visible = false;
                            корень.Text = "Обязательное условие — a ≠ 0";
                            корень2.Text = " ";
                        }

                        if (x1 == 0)
                        {
                            if (a > 0)
                            {

                                graphic_parabola.Series["Series2"].Points.Clear();
                                graphic_parabola.Series["Series1"].Points.Clear();

                                DataPoint dp0 = new DataPoint(0, 0)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp = new DataPoint(1, 1)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp2 = new DataPoint(2, 4)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                this.graphic_parabola.Series["Series1"].Points.Add(dp0);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp2);

                                DataPoint dp1 = new DataPoint(-1, 1)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp3 = new DataPoint(-2, 4)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                this.graphic_parabola.Series["Series1"].Points.Add(dp1);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp3);

                                double x00 = -10;

                                for (int i = 0; i < 200; i++)
                                {
                                    x00 = x00 + 0.1;
                                    y0 = x00 * x00;
                                    graphic_parabola.Series["Series2"].Points.AddXY(x00, y0);
                                }
                            }
                            if (a < 0)
                            {
                                graphic_parabola.Series["Series2"].Points.Clear();
                                graphic_parabola.Series["Series1"].Points.Clear();

                                double x00 = -10;

                                DataPoint dp0 = new DataPoint(0, 0)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp = new DataPoint(1, -1)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp2 = new DataPoint(2, -4)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                this.graphic_parabola.Series["Series1"].Points.Add(dp0);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp2);

                                DataPoint dp1 = new DataPoint(-1, -1)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                DataPoint dp3 = new DataPoint(-2, -4)
                                {
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerBorderColor = Color.Red,
                                    MarkerBorderWidth = 4,
                                    IsValueShownAsLabel = true //Показать значение в точке
                                };

                                this.graphic_parabola.Series["Series1"].Points.Add(dp1);
                                this.graphic_parabola.Series["Series1"].Points.Add(dp3);

                                for (int i = 0; i < 200; i++)
                                {
                                    x00 = x00 + 0.1;
                                    y0 = -(x00 * x00);
                                    graphic_parabola.Series["Series2"].Points.AddXY(x00, y0);

                                }
                            }
                        }
                        if (x1 != 0)
                        {
                            if (a > 0 || a < 0)
                            {

                                graphic_parabola.Series["Series2"].Points.Clear();
                                graphic_parabola.Series["Series1"].Points.Clear();

                                double x_ = -10;
                                double y_;

                                for (int i = 0; i < 200; i++)
                                {
                                    x_ = x_ + 0.1;
                                    y_ = a * x_ * x_ + b * x_ + c;
                                    graphic_parabola.Series["Series2"].Points.AddXY(x_, y_);

                                    if (y_ == 0)
                                    {
                                        DataPoint dp2 = new DataPoint(x_, y_)
                                        {
                                            MarkerStyle = MarkerStyle.Circle,
                                            MarkerBorderColor = Color.Red,
                                            MarkerBorderWidth = 4,
                                            IsValueShownAsLabel = true //Показать значение в точке
                                        };
                                        this.graphic_parabola.Series["Series1"].Points.Add(dp2);
                                    }
                                }

                            }
                        }
                        graphic_parabola.Series["Series2"].BorderWidth = 3;
                        graphic_parabola.Series["Series2"].ChartType = SeriesChartType.Line;
                    }
                    else if (d < 0)
                    {
                        graphic_parabola.Series["Series1"].Points.Clear();
                        graphic_parabola.Series["Series2"].Points.Clear();
                        discriminant.Text = "D = " + d;
                        корень.Text = "Действительных корней нет.";
                        корень2.Text = " ";
                        graphic_parabola.Visible = false;
                    }
                }
            }
            catch
            {
                graphic_parabola.Visible = false;
                MessageBox.Show("Заполните поля или проверьте значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button_allips_Click(object sender, EventArgs e)
        {
            try
            {
                allips_graphic.Series["Series_xy"].Points.Clear();
                allips_graphic.Visible = true;
                //Обьявление изображении Chart //Как он будет выглядить статическом виде
                // "ChartArea_allips" название ChartAreas (Название области Chart)
                //=======================================================================
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.MinorGrid.Enabled = true;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisX.Maximum = 5;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisX.Minimum = -5;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.Minimum = -5;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.Maximum = 5;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisX.Interval = 1;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.Interval = 1;
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.MinorGrid.Interval =
                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.Interval / 2; ;
                //=======================================================================

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

                allips_graphic.ChartAreas["ChartArea_allips"].AxisY.StripLines.Add(stripLine);
                allips_graphic.ChartAreas["ChartArea_allips"].AxisX.StripLines.Add(stripLine1);

                //Подписываем оси X и Y
                //========================================================
                DataPoint Y_ = new DataPoint(0.3, 5)
                {
                    Label = "y",
                    Font = new Font("Times New Roman", 14),
                    IsValueShownAsLabel = true //Показать значение в точке
                };
                this.allips_graphic.Series["Series_xy"].Points.Add(Y_);

                DataPoint X = new DataPoint(4.7, 0.001)
                {
                    Label = "x",
                    Font = new Font("Times New Roman", 14),
                    IsValueShownAsLabel = true //Показать значение в точке
                };
                this.allips_graphic.Series["Series_xy"].Points.Add(X);
                //========================================================

                double a = Convert.ToDouble(a_allips.Text);
                double b = Convert.ToDouble(b_allips.Text);

                if (a < 1 || a > 5 || b < 1 || b > 5)  //Выходит за промежуток указанный в TextBox //Ограничение
                {
                    allips_graphic.Visible = false;
                    MessageBox.Show("Проверьте значения, возможно у вас выходят за промежутки a или b от 1 до 5", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    S_allips.Text = ". . .";
                    L_allips.Text = ". . .";
                    C_label.Text = ". . .";
                    a__.Text = "a^2";
                    b__.Text = "b^2";
                }

                if ((a >= 1 && a <= 5) && (b >= 1 && b <= 5))  //Входит в промежуток указанный в TextBox
                {

                    allips_graphic.Series["Series_allips"].Points.Clear();
                    allips_graphic.Series["Series_tochki_allips"].Points.Clear();

                    //-----------------------------------------------------------
                    //Построение графика Эллипса 
                    //Уравнения в параметрической форме
                    //x = a * cos t 
                    //y = b * sin t 
                    //где t - параметр
                    //-----------------------------------------------------------

                    double x;
                    double y;
                    double t = 0;
                    for (int i = 0; i < 90; i++)
                    {
                        t = t + 0.1;
                        x = a * Math.Cos(t);

                        y = b * Math.Sin(t);
                        allips_graphic.Series["Series_allips"].Points.AddXY(x, y);
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
                    this.allips_graphic.Series["Series_tochki_allips"].Points.Add(a_);

                    DataPoint b_ = new DataPoint(0, b)
                    {
                        Label = "    b",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.allips_graphic.Series["Series_tochki_allips"].Points.Add(b_);

                    DataPoint a1 = new DataPoint(a, 0)
                    {
                        Label = "   a",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.allips_graphic.Series["Series_tochki_allips"].Points.Add(a1);

                    DataPoint b1 = new DataPoint(0, -b)
                    {
                        Label = "    -b",
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.allips_graphic.Series["Series_tochki_allips"].Points.Add(b1);

                    DataPoint o = new DataPoint(0, 0)
                    {
                        Label = "   0",
                        MarkerColor = Color.RoyalBlue,
                        MarkerBorderWidth = 3,
                        IsValueShownAsLabel = true //Показать значение в точке
                    };
                    this.allips_graphic.Series["Series_tochki_allips"].Points.Add(o);
                    //========================================================================

                    if (a > b) // Нахождение фокусов в эллипсе
                    {
                        allips_graphic.Visible = true;
                        uravnenie_allipsa_vivod.Text = "- Конечное уравнение";
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
                        this.allips_graphic.Series["Series_tochki_allips"].Points.Add(F1);

                        DataPoint F2 = new DataPoint(c, 0)
                        {
                            Label = "F2",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.allips_graphic.Series["Series_tochki_allips"].Points.Add(F2);
                        //=====================================================================

                        C_label.Text = "±" + Convert.ToString(string.Format("{0:0.##}", c)) + " - F1 и F2";

                        a__.Text = Convert.ToString(a) + "^2";
                        b__.Text = Convert.ToString(b) + "^2";

                        double s = Math.Round(3.14 * a * b);
                        S_allips.Text = Convert.ToString(s) + " eд^2 - Площадь Эллипса"; // Площадь

                        double l = Math.Round(4 * ((3.14 * a * b + Math.Pow((a - b), 2)) / (a + b)));
                        L_allips.Text = Convert.ToString(l) + " eд - Периметр Эллипса"; // Периметр
                    }

                    if (b > a) // Нахождение фокусов в эллипсе
                    {
                        allips_graphic.Visible = true;
                        uravnenie_allipsa_vivod.Text = "- Конечное уравнение";
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
                        this.allips_graphic.Series["Series_tochki_allips"].Points.Add(F1);

                        DataPoint F2 = new DataPoint(0, c)
                        {
                            Label = "     F1",
                            MarkerColor = Color.Green,
                            MarkerBorderWidth = 3,
                            IsValueShownAsLabel = true //Показать значение в точке
                        };
                        this.allips_graphic.Series["Series_tochki_allips"].Points.Add(F2);
                        //=====================================================================

                        C_label.Text = "±" + Convert.ToString(string.Format("{0:0.##}", c)) + " - F1 и F2";

                        a__.Text = Convert.ToString(a) + "^2";
                        b__.Text = Convert.ToString(b) + "^2";

                        double s = Math.Round(3.14 * a * b);
                        S_allips.Text = Convert.ToString(s) + " eд^2 - Площадь Эллипса"; // Площадь

                        double l = Math.Round(4 * ((3.14 * a * b + Math.Pow((a - b), 2)) / (a + b)));
                        L_allips.Text = Convert.ToString(l) + " eд - Периметр Эллипса"; // Периметр
                    }

                    if (b == a) //Получается Окружность
                    {
                        allips_graphic.Visible = true;
                        C_label.Text = "0 - F1 и F2";
                        uravnenie_allipsa_vivod.Text = "- Конечное уравнение";

                        a__.Text = Convert.ToString(a) + "^2";
                        b__.Text = Convert.ToString(b) + "^2";

                        double s = Math.Round(3.14 * a * b);
                        S_allips.Text = Convert.ToString(s) + " eд^2 - Площадь Эллипса"; // Площадь

                        double l = Math.Round(4 * ((3.14 * a * b + Math.Pow((a - b), 2)) / (a + b)));
                        L_allips.Text = Convert.ToString(l) + " eд - Периметр Эллипса"; // Периметр
                    }
                }
            }
            catch
            {
                allips_graphic.Visible = false;
                S_allips.Text = ". . .";
                L_allips.Text = ". . .";
                a__.Text = "a^2";
                b__.Text = "b^2";
                MessageBox.Show("Заполните поля или проверьте значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void vihod_iz_programm_Click(object sender, EventArgs e) // Выход из программы
        {
            this.Close();
        }

        //=================================================================================================================
        //При наведении на картинку, чтобы она расширялась
        //=================================================================================================================

        private void cv_MouseHover(object sender, EventArgs e) //cv_img
        {
            cv_img.Width = 484;
            cv_img.Height = 45;
            cv_img.Location = new Point(6, 31);

            cv_img.BringToFront();
        }

        private void cv_MouseLeave(object sender, EventArgs e)
        {
            cv_img.Width = 334;
            cv_img.Height = 30;
            cv_img.Location = new Point(6, 31);
        }

        private void D_MouseHover(object sender, EventArgs e) //D_img
        {
            D_img.Width = 184;
            D_img.Height = 174;
            D_img.Location = new Point(346, 31);

            D_img.BringToFront();
        }

        private void D_MouseLeave(object sender, EventArgs e)
        {
            D_img.Width = 154;
            D_img.Height = 144;
            D_img.Location = new Point(346, 31);
        }

        private void graphic_paraboli_MouseHover(object sender, EventArgs e) //graphic_paraboli_img
        {
            graphic_paraboli_img.Width = 474;
            graphic_paraboli_img.Height = 249;
            graphic_paraboli_img.Location = new Point(6, 67);

            graphic_paraboli_img.BringToFront();
        }

        private void graphic_paraboli_MouseLeave(object sender, EventArgs e)
        {
            graphic_paraboli_img.Width = 334;
            graphic_paraboli_img.Height = 199;
            graphic_paraboli_img.Location = new Point(6, 67);
        }

        private void graphic_allips_MouseHover(object sender, EventArgs e) //graphic_allips_img
        {
            graphic_allips_img.Width = 415; 
            graphic_allips_img.Height = 321;
            graphic_allips_img.Location = new Point(8, 30);

            graphic_allips_img.BringToFront();
        }

        private void graphic_allips_MouseLeave(object sender, EventArgs e)
        {
            graphic_allips_img.Width = 315;
            graphic_allips_img.Height = 221;
            graphic_allips_img.Location = new Point(8, 30);
        }

        private void uravn_allips_MouseHover(object sender, EventArgs e) //uravn_allips_img
        {
            uravn_allips_img.Width = 258;
            uravn_allips_img.Height = 128;
            uravn_allips_img.Location = new Point(8, 257);

            uravn_allips_img.BringToFront();
        }

        private void uravn_allips_MouseLeave(object sender, EventArgs e)
        {
            uravn_allips_img.Width = 158;
            uravn_allips_img.Height = 80;
            uravn_allips_img.Location = new Point(8, 257);
        }

        private void plosh_allips_MouseHover(object sender, EventArgs e) //plosh_allips_img
        {
            plosh_allips_img.Width = 238;
            plosh_allips_img.Height = 128;
            plosh_allips_img.Location = new Point(173, 257);

            plosh_allips_img.BringToFront();
        }

        private void plosh_allips_MouseLeave(object sender, EventArgs e)
        {
            plosh_allips_img.Width = 150;
            plosh_allips_img.Height = 80;
            plosh_allips_img.Location = new Point(173, 257);
        }

        private void perimetr_allip_MouseHover(object sender, EventArgs e) //perimetr_allip_img
        {
            perimetr_allip_img.Width = 238;
            perimetr_allip_img.Height = 128;
            perimetr_allip_img.Location = new Point(173, 344);

            perimetr_allip_img.BringToFront();
        }

        private void perimetr_allip_MouseLeave(object sender, EventArgs e)
        {
            perimetr_allip_img.Width = 150;
            perimetr_allip_img.Height = 93;
            perimetr_allip_img.Location = new Point(173, 344);
        }

        //=================================================================================================================

        //Menu_Strip
        //Переход к форме Об авторах
        private void обАвторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Об_авторах ob_avt = new Об_авторах();
            ob_avt.Show();
        }

        private void ввестиВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Navigation.SelectedIndex == 0)
            {
                //Переносим переменные в другую форму
                try
                {
                    if (discriminant.Text == "D = . . .")
                    {
                        MessageBox.Show("Выведите корни дискриминанта", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                        pod_BD.formula_index.Text = "ф. Дискриминанта?";
                        pod_BD.Show();

                        pod_BD.b_sn = Convert.ToInt32(b_sn.Text);
                        pod_BD.a_sn = Convert.ToInt32(a_sn.Text);
                        pod_BD.c_sn = Convert.ToInt32(c_sn.Text);

                        pod_BD.D = discriminant.Text;
                        pod_BD.x1 = корень.Text;
                        pod_BD.x2 = корень2.Text;
                        pod_BD.Login_ADD = login_view;
                    }
                }
                catch
                {
                    MessageBox.Show("Введите значение или выведите корни дискриминанта", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            else if (Navigation.SelectedIndex == 1)
            {
                try
                {
                    if (S_allips.Text == ". . .")
                    {
                        MessageBox.Show("Выведите Периметр и Площадь Эллипса", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                        pod_BD.formula_index.Text = "ф. Эллипса?";
                        pod_BD.Show();

                        //Переносим переменные в другую форму
                        pod_BD.a_allips = Convert.ToInt32(a_allips.Text);
                        pod_BD.b_allips = Convert.ToInt32(b_allips.Text);

                        pod_BD.S = S_allips.Text;
                        pod_BD.L = L_allips.Text;
                        pod_BD.C = C_label.Text;
                        pod_BD.Login_ADD = login_view;
                    }

                }
                catch
                {
                    MessageBox.Show("Введите значение или выведите корни дискриминанта", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            else if (Navigation.SelectedIndex == 2) //Фигуры
            {
                if (Choose_fig.SelectedIndex == 1)//Куб
                {
                    try
                    {
                        if (value_fig3.Text == "...")
                        {
                            MessageBox.Show("Выведите Итоговые значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else 
                        {
                            Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                            //Переносим переменные в другую форму
                            pod_BD.a_kub = Convert.ToDouble(input_value_fig1.Text);

                            pod_BD.formula_index.Text = "ф. Куба?";
                            pod_BD.Show();

                            pod_BD.d_kub = value_fig2.Text;
                            pod_BD.S_kub = value_fig3.Text;
                            pod_BD.V_kub = value_fig4.Text;
                            pod_BD.Login_ADD = login_view;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Введите значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (Choose_fig.SelectedIndex == 2) //Цилиндр
                {
                    try
                    {
                        if (value_fig3.Text == "...")
                        {
                            MessageBox.Show("Выведите Итоговые значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                            //Переносим переменные в другую форму
                            pod_BD.R_cilinder = Convert.ToDouble(input_value_fig1.Text);
                            pod_BD.h_cilinder = Convert.ToDouble(input_value_fig2.Text);

                            pod_BD.formula_index.Text = "ф. Цилиндр?";
                            pod_BD.Show();

                            pod_BD.S_cilinder = value_fig3.Text;
                            pod_BD.V_cilinder = value_fig4.Text;
                            pod_BD.Login_ADD = login_view;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Введите значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (Choose_fig.SelectedIndex == 3) //Конус
                {
                    try
                    {
                        if (value_fig3.Text == "...")
                        {
                            MessageBox.Show("Выведите Итоговые значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                            //Переносим переменные в другую форму
                            pod_BD.R_conus = Convert.ToDouble(input_value_fig1.Text);
                            pod_BD.h_conus = Convert.ToDouble(input_value_fig2.Text);

                            pod_BD.formula_index.Text = "ф. Конус?";
                            pod_BD.Show();

                            pod_BD.L_conus = value_fig2.Text;
                            pod_BD.S_conus = value_fig3.Text;
                            pod_BD.V_conus = value_fig4.Text;
                            pod_BD.Login_ADD = login_view;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Введите значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (Choose_fig.SelectedIndex == 4) //Шар
                {
                    try
                    {
                        if (value_fig3.Text == "...")
                        {
                            MessageBox.Show("Выведите Итоговые значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            Подтверждение_внесение_в_БД pod_BD = new Подтверждение_внесение_в_БД();
                            //Переносим переменные в другую форму
                            pod_BD.R_shar = Convert.ToDouble(input_value_fig1.Text);

                            pod_BD.formula_index.Text = "ф. Шар?";
                            pod_BD.Show();

                            pod_BD.S_shar = value_fig3.Text;
                            pod_BD.V_shar = value_fig4.Text;
                            pod_BD.Login_ADD = login_view;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Введите значение", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            База_данных bd = new База_данных();
            bd.Show();

            if (login_view != null)
            {
                bd.login_add = login_view.ToString();
            }
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Авторизация avt = new Авторизация();
            avt.Show();
            this.Hide();
            
            if (login_view != null)
            {
                MessageBox.Show("Вы вышли из учетной записи!");
            }
        }

        private void Programm_Load(object sender, EventArgs e)
        {
            //Загрузка в ComboBox значений
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_formul"].ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select Description, Name_Formul from [Поиск по формулам]", SqlConnection);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tab = new DataTable();
            da.Fill(tab);

            DataRow item = tab.NewRow();
            item[1] = "Выберите фигуру";
            tab.Rows.InsertAt(item, 0);

            Choose_fig.DataSource = tab;
            Choose_fig.DisplayMember = "Name_Formul";
            Choose_fig.ValueMember = "Description";

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //При выборе из определенного индекса ComboBox, выводит два GroupBox'а
        {
            if (Choose_fig.SelectedIndex == 0)
            {
                vvod_data_kub.Visible = false;
                vivod_data_kub.Visible = false;
                pic_fig.Visible = false;
                lb_description.Visible = false;
                vivod_pl_ob_pov.Visible = false;
            }
            else if (Choose_fig.SelectedIndex == 1)
            {
                pic_fig.Visible = true;
                lb_description.Visible = true;
                input_value_fig1.Text = "";
                value_fig2.Text = "...";
                value_fig3.Text = "...";
                value_fig4.Text = "...";

                vvod_data_kub.Visible = true;
                vvod_data_kub.Text = "Ввод данных";
                vvod_data_kub.Width = 328;
                vvod_data_kub.Height = 40;
                vivod_data_kub.Visible = true;
                vivod_data_kub.Text = "Вывод данных";
                vivod_data_kub.Width = 328;
                vivod_data_kub.Height = 100;
                vivod_data_kub.Location = new Point(14, 104);

                label_fg_1.Text = "a =";
                label_opis_per1.Text = "- длина ребра";
                label_fg_2.Text = "d =";
                label_fg_2.Visible = true;
                value_fig2.Visible = true;
                value_fig2.Location = new Point(53, 16);

                label_fg_3.Text = "S =";
                label_fg_3.Location = new Point(16, 42);
                value_fig3.Location = new Point(53, 42);

                label_fg_4.Text = "V =";
                label_fg_4.Location = new Point(16, 71);
                value_fig4.Location = new Point(53, 71);
                vivod_pl_ob_pov.Visible = true;

                pic_fig.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Куб.png");
                pic_fig.SizeMode = PictureBoxSizeMode.Zoom;

                lb_description.Visible = true;
            }
            else if (Choose_fig.SelectedIndex == 2)
            {
                pic_fig.Visible = true;
                lb_description.Visible = true;
                input_value_fig1.Text = "";
                input_value_fig2.Text = "";
                value_fig3.Text = "...";
                value_fig4.Text = "...";

                vvod_data_kub.Visible = true;
                vvod_data_kub.Text = "Ввод данных";
                vvod_data_kub.Width = 328;
                vvod_data_kub.Height = 65;
                vivod_data_kub.Visible = true;
                vivod_data_kub.Width = 328;
                vivod_data_kub.Height = 80;
                vivod_data_kub.Location = new Point(14, 129);
                vivod_data_kub.Text = "Вывод данных";

                label_fg_1.Text = "R =";
                label_opis_per1.Text = "- радиус основания";

                label_fg_1_2.Text = "h =";
                label_fg_1_2.Location = new Point(17, 40);
                label_fg_1_2.Visible = true;
                input_value_fig2.Visible = true;
                input_value_fig2.Location = new Point(54, 40);
                label_opis_per2.Text = "- высота";
                label_opis_per2.Visible = true;
                label_opis_per2.Location = new Point(108, 40);

                label_fg_2.Visible = false;
                value_fig2.Visible = false;

                label_fg_3.Text = "S =";
                label_fg_3.Location = new Point(16, 16);
                value_fig3.Location = new Point(53, 16);

                label_fg_4.Text = "V =";
                label_fg_4.Location = new Point(16, 42);
                value_fig4.Location = new Point(53, 42);
                vivod_pl_ob_pov.Visible = true;

                pic_fig.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Цилиндр.png");
                pic_fig.SizeMode = PictureBoxSizeMode.Zoom;

                lb_description.Visible = true;
            }
            else if (Choose_fig.SelectedIndex == 3)
            {
                pic_fig.Visible = true;
                lb_description.Visible = true;
                input_value_fig1.Text = "";
                input_value_fig2.Text = "";
                value_fig2.Text = "...";
                value_fig3.Text = "...";
                value_fig4.Text = "...";

                vvod_data_kub.Visible = true;
                vvod_data_kub.Text = "Ввод данных";
                vvod_data_kub.Width = 328;
                vvod_data_kub.Height = 65;
                vivod_data_kub.Visible = true;
                vivod_data_kub.Width = 328;
                vivod_data_kub.Height = 80;
                vivod_data_kub.Location = new Point(14, 129);
                vivod_data_kub.Text = "Вывод данных";

                label_fg_1.Text = "R =";
                label_opis_per1.Text = "- радиус основания";

                label_fg_1_2.Text = "h =";
                label_fg_1_2.Location = new Point(17, 40);
                label_fg_1_2.Visible = true;
                input_value_fig2.Visible = true;
                input_value_fig2.Location = new Point(54, 40);
                label_opis_per2.Text = "- высота";
                label_opis_per2.Visible = true;
                label_opis_per2.Location = new Point(108, 40);

                label_fg_2.Text = "L =";
                label_fg_2.Visible = true;
                label_fg_2.Location = new Point(16, 16);
                value_fig2.Visible = true;
                value_fig2.Location = new Point(53, 16);

                label_fg_3.Text = "S =";
                label_fg_3.Location = new Point(16, 35);
                value_fig3.Location = new Point(53, 35);

                label_fg_4.Text = "V =";
                label_fg_4.Location = new Point(16, 55);
                value_fig4.Location = new Point(53, 55);
                vivod_pl_ob_pov.Visible = true;

                pic_fig.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Конус.png");
                pic_fig.SizeMode = PictureBoxSizeMode.Zoom;

                lb_description.Visible = true;
            }
            else if (Choose_fig.SelectedIndex == 4)
            {
                pic_fig.Visible = true;
                lb_description.Visible = true;
                input_value_fig1.Text = "";
                input_value_fig2.Text = "";
                value_fig2.Text = "...";
                value_fig3.Text = "...";
                value_fig4.Text = "...";

                vvod_data_kub.Visible = true;
                vvod_data_kub.Text = "Ввод данных";
                vvod_data_kub.Width = 328;
                vvod_data_kub.Height = 40;
                vivod_data_kub.Visible = true;
                vivod_data_kub.Text = "Вывод данных";
                vivod_data_kub.Width = 328;
                vivod_data_kub.Height = 100;
                vivod_data_kub.Location = new Point(14, 104);

                label_fg_1.Text = "R =";
                label_opis_per1.Text = "- радиус шара";

                label_fg_2.Visible = false;
                value_fig2.Visible = false;

                label_fg_3.Text = "S =";
                label_fg_3.Location = new Point(16, 25);
                value_fig3.Location = new Point(53, 20);

                label_fg_4.Text = "V =";
                label_fg_4.Location = new Point(16, 60);
                value_fig4.Location = new Point(53, 60);
                vivod_pl_ob_pov.Visible = true;

                pic_fig.Image = Image.FromFile("..\\..\\..\\..\\Вычисление по формулам с базой данных\\Picture\\Шар.png");
                pic_fig.SizeMode = PictureBoxSizeMode.Zoom;

                lb_description.Visible = true;
            }
        }

        private void vivod_pl_ob_pov_Click(object sender, EventArgs e)
        {
            try
            {
                if (Choose_fig.SelectedIndex == 1)
                {

                    double d = Math.Round(Convert.ToDouble(input_value_fig1.Text) * Math.Sqrt(3), 2);
                    double S = 6 * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2);
                    double V = Math.Pow(Convert.ToDouble(input_value_fig1.Text), 3);

                    value_fig2.Text = d + " - Длина диагонали";
                    value_fig3.Text = S + " - Площадь Куба";
                    value_fig4.Text = V + " - Объем Куба";
                }
                else if (Choose_fig.SelectedIndex == 2)
                {

                    double V = Math.Round(Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2) * Convert.ToDouble(input_value_fig2.Text), 2);
                    double S = Math.Round((2 * Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2)) + (2 * Math.PI * Convert.ToDouble(input_value_fig1.Text) * Convert.ToDouble(input_value_fig2.Text)), 2);

                    value_fig3.Text = S + " - Площадь Целиндра";
                    value_fig4.Text = V + " - Объем Целиндра";
                }
                else if (Choose_fig.SelectedIndex == 3)
                {
     
                    double L = Math.Round(Math.Sqrt(Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2) + Math.Pow(Convert.ToDouble(input_value_fig2.Text), 2)), 2);
                    double V = Math.Round(1.00/3.00 * Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2) * Convert.ToDouble(input_value_fig2.Text), 2);
                    double S = Math.Round(Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2) + Math.PI * Convert.ToDouble(input_value_fig1.Text) * L, 2);

                    value_fig2.Text = L + " - Образующая Конуса";
                    value_fig3.Text = S + " - Площадь Конуса";
                    value_fig4.Text = V + " - Объем Конуса";
                }
                else if (Choose_fig.SelectedIndex == 4)
                {

                    double V = Math.Round(4.00 / 3.00 * Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 3), 2);
                    double S = Math.Round(4 * Math.PI * Math.Pow(Convert.ToDouble(input_value_fig1.Text), 2), 2);
                  
                    value_fig3.Text = S + " - Площадь Шара";
                    value_fig4.Text = V + " - Объем Шара";
                }
            }
            catch
            {
                MessageBox.Show("Проверьте, вы ввели не правильные значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Choose_fig_SelectedValueChanged(object sender, EventArgs e)
        {
            Description.Text = Choose_fig.SelectedValue as string;
        }

        private void пройтиТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            SqlConnection.Open();

            DataTable tableStudent = new DataTable();
            DataTable tableTeacher = new DataTable();
            SqlDataAdapter adapterStudent = new SqlDataAdapter();
            SqlDataAdapter adapterTeacher = new SqlDataAdapter();

            SqlCommand commandStudent = new SqlCommand("Select * from Ученик where login = @userLogin And pass = @userPass", SqlConnection);
            commandStudent.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_view;
            commandStudent.Parameters.Add("@userPass", SqlDbType.VarChar).Value = login_pass;

            SqlCommand commandTeacher = new SqlCommand("Select * from Учитель where login = @userLogin And pass = @userPass", SqlConnection);
            commandTeacher.Parameters.Add("@userLogin", SqlDbType.VarChar).Value = login_view;
            commandTeacher.Parameters.Add("@userPass", SqlDbType.VarChar).Value = login_pass;

            adapterStudent.SelectCommand = commandStudent;
            adapterStudent.Fill(tableStudent);

            adapterTeacher.SelectCommand = commandTeacher;
            adapterTeacher.Fill(tableTeacher);


            if (tableStudent.Rows.Count > 0)
            {

                DialogResult result = MessageBox.Show($"Вам будет выдано 2 минуты{Environment.NewLine}Вы уверены, что хотите пройти тест?", "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Тест test = new Тест();
                    test.Show();

                    test.Uchetnaya_sapis.Text = "Ученик - ";
                    test.login_stud.Text = login_view;

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
            else if (tableTeacher.Rows.Count > 0)
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
            else
            {
                MessageBox.Show($"У вас не получилось войти{Environment.NewLine}Проверьте ввели ли вы правильно данные", "Сообщение");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Авторизация avt = new Авторизация();
            avt.Show();
            this.Hide();

            if (login_view != null)
            {
                MessageBox.Show("Вы вышли из учетной записи!");
            }
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Калькулятор c = new Калькулятор();
            c.Show();
        }
    }
}