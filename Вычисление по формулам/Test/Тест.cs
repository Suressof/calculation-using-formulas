using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Application = System.Windows.Forms.Application;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Net;

namespace Вычисление_по_формулам
{
    public partial class Тест : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;

        public string ConvertImage;
        public string ConvertImage_2;
        public string ConvertImage_3;
        public string ConvertImage_4;
        public string ConvertImage_5;
        public string loginUs;

        public string Vvod_que;
        public string input_otv;
        public byte[] image_bytes;

        public string Vvod_que_2;
        public string input_otv_2;
        public byte[] image_bytes_2;

        public string Vvod_que_3;
        public string input_otv_3;
        public byte[] image_bytes_3;

        public string Vvod_que_4;
        public string input_otv_4;
        public byte[] image_bytes_4;

        public string Vvod_que_5;
        public string input_otv_5;
        public byte[] image_bytes_5;

        //timer 
        Timer t = new Timer();
        int s = 120;
        public Тест()
        {
            InitializeComponent();
        }
        public void Тест_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_TEST_formul"].ConnectionString);
            sqlConnection.Open();
        }
        void next_tabPage() //Переход на следующую страницу
        {
            int nind = tab_control.SelectedIndex + 1;
            if (nind >= tab_control.TabPages.Count)
            {
                nind = 0;
            }
            tab_control.SelectedIndex = nind;
        }
        void pre_tabPage() //Переход на прошлую страницу
        {
            int nind = tab_control.SelectedIndex - 1;
            if (nind < 0)
            {
                nind = tab_control.TabPages.Count - 1;
            }
            tab_control.SelectedIndex = nind;
        }

        public string Open_Dialog(PictureBox pb)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Картинка была вставлена");

                pb.Image = new Bitmap(openFileDialog.FileName);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                return openFileDialog.FileName;

            }
            else
            {
                DialogResult result = MessageBox.Show("Картинка не была вставлена");
                pb.Image = null;
                return null;
            }
        }

        private void OpenImage_Click(object sender, EventArgs e)
        {
            ConvertImage = Open_Dialog(ViewImage);
        }
        private void OpenImage_2_Click(object sender, EventArgs e)
        {
            ConvertImage_2 = Open_Dialog(ViewImage_2);
        }
        private void OpenImage_3_Click(object sender, EventArgs e)
        {
            ConvertImage_3 = Open_Dialog(ViewImage_3);
        }
        private void OpenImage_4_Click(object sender, EventArgs e)
        {
            ConvertImage_4 = Open_Dialog(ViewImage_4);
        }
        private void OpenImage_5_Click(object sender, EventArgs e)
        {
            ConvertImage_5 = Open_Dialog(ViewImage_5);
        }

        public void SaveTest(string Vvod_que, string input_otv, byte[] image_bytes, int id, string ConvertImage, TextBox Vvod_question, TextBox input_otvet)
        {
            if (Uchetnaya_sapis.Text == "Учитель")
            {
                try
                {
                    if (ConvertImage != null)
                    {

                        image_bytes = File.ReadAllBytes(ConvertImage); // получаем байты выбранного файла


                        Vvod_que = Convert.ToString(Vvod_question.Text);
                        input_otv = Convert.ToString(input_otvet.Text);

                        SqlCommand com = new SqlCommand("Update [Тест] Set Question = @Question, Image = @Image, Answer = @Answer where id = " + id, sqlConnection);

                        com.Parameters.Add("@Image", SqlDbType.Image, 1000000);
                        com.Parameters["@Image"].Value = image_bytes;
                        com.Parameters.AddWithValue("@Question", Vvod_que);
                        com.Parameters.AddWithValue("@Answer", input_otv);
                        com.ExecuteNonQuery();

                        MessageBox.Show("Данные были вставлены");
                    }
                    else
                    {
                        Vvod_que = Convert.ToString(Vvod_question.Text);
                        input_otv = Convert.ToString(input_otvet.Text);

                        SqlCommand com = new SqlCommand("Update [Тест] Set Question = @Question, Image = null, Answer = @Answer where id = " + id, sqlConnection);

                        com.Parameters.AddWithValue("@Question", Vvod_que);
                        com.Parameters.AddWithValue("@Answer", input_otv);
                        com.ExecuteNonQuery();

                        MessageBox.Show("Данные были вставлены");
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте, возможно, вы что то забыли ввести или ввели не правильно");
                }

            }
        }

        private void Save_test_Click(object sender, EventArgs e)
        {
            SaveTest(Vvod_que, input_otv, image_bytes, 1, ConvertImage, Vvod_question, input_otvet);
        }
        private void Save_test_2_Click(object sender, EventArgs e)
        {
            SaveTest(Vvod_que_2, input_otv_2, image_bytes_2, 2, ConvertImage_2, Vvod_question_2, input_otvet_2);
        }
        private void Save_test_3_Click(object sender, EventArgs e)
        {
            SaveTest(Vvod_que_3, input_otv_3, image_bytes_3, 3, ConvertImage_3, Vvod_question_3, input_otvet_3);
        }
        private void Save_test_4_Click(object sender, EventArgs e)
        {
            SaveTest(Vvod_que_4, input_otv_4, image_bytes_4, 4, ConvertImage_4, Vvod_question_4, input_otvet_4);
        }
        private void Save_test_5_Click(object sender, EventArgs e)
        {
            SaveTest(Vvod_que_5, input_otv_5, image_bytes_5, 5, ConvertImage_5, Vvod_question_5, input_otvet_5);
        }

        private void bt_viewTest_Click(object sender, EventArgs e)
        {
            if (Uchetnaya_sapis.Text == "Учитель")
            {
                Просмотр_пройденных_тестов view = new Просмотр_пройденных_тестов();
                view.Show();
            }
            else //Когда у нас ученик-----------------Отправление Теста
            {

                //try
                //{
                DialogResult result = MessageBox.Show($"Вы готовы сдать свой тест{Environment.NewLine}", "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {



                    String que = Convert.ToString(Question.Text);
                    String que_2 = Convert.ToString(Question_2.Text);
                    String que_3 = Convert.ToString(Question_3.Text);
                    String que_4 = Convert.ToString(Question_4.Text);
                    String que_5 = Convert.ToString(Question_5.Text);

                    String input_otv = input_otvet.Text;
                    String input_otv_2 = input_otvet_2.Text;
                    String input_otv_3 = input_otvet_3.Text;
                    String input_otv_4 = input_otvet_4.Text;
                    String input_otv_5 = input_otvet_5.Text;

                    string log = login_stud.Text;

                    SqlDataAdapter adapterQuesAnsw = new SqlDataAdapter();
                    SqlDataAdapter adapterQuesAnsw_2 = new SqlDataAdapter();
                    SqlDataAdapter adapterQuesAnsw_3 = new SqlDataAdapter();
                    SqlDataAdapter adapterQuesAnsw_4 = new SqlDataAdapter();
                    SqlDataAdapter adapterQuesAnsw_5 = new SqlDataAdapter();

                    SqlCommand QuesAnsw = new SqlCommand("Select * from Тест where Answer = @input_otv AND id = 1", sqlConnection);
                    //QuesAnsw.Parameters.Add("@input_otv", SqlDbType.VarChar).Value = input_otv;
                    QuesAnsw.Parameters.AddWithValue("@input_otv", input_otv);
                    SqlCommand QuesAnsw_2 = new SqlCommand("Select * from Тест where Answer = @input_otv_2 AND id = 2", sqlConnection);
                    //QuesAnsw_2.Parameters.Add("@input_otv_2", SqlDbType.VarChar).Value = input_otv_2;
                    QuesAnsw_2.Parameters.AddWithValue("@input_otv_2", input_otv_2);
                    SqlCommand QuesAnsw_3 = new SqlCommand("Select * from Тест where Answer = @input_otv_3 AND id = 3", sqlConnection);
                    //QuesAnsw_3.Parameters.Add("@input_otv_3", SqlDbType.VarChar).Value = input_otv_3;
                    QuesAnsw_3.Parameters.AddWithValue("@input_otv_3", input_otv_3);
                    SqlCommand QuesAnsw_4 = new SqlCommand("Select * from Тест where Answer = @input_otv_4 AND id = 4", sqlConnection);
                    //QuesAnsw_4.Parameters.Add("@input_otv_4", SqlDbType.VarChar).Value = input_otv_4;
                    QuesAnsw_4.Parameters.AddWithValue("@input_otv_4", input_otv_4);
                    SqlCommand QuesAnsw_5 = new SqlCommand("Select * from Тест where Answer = @input_otv_5 AND id = 5", sqlConnection);
                    //QuesAnsw_5.Parameters.Add("@input_otv_5", SqlDbType.VarChar).Value = input_otv_5;
                    QuesAnsw_5.Parameters.AddWithValue("@input_otv_5", input_otv_5);

                    DataTable tableQuesAnsw = new DataTable();
                    adapterQuesAnsw.SelectCommand = QuesAnsw;
                    adapterQuesAnsw.Fill(tableQuesAnsw);

                    DataTable tableQuesAnsw_2 = new DataTable();
                    adapterQuesAnsw_2.SelectCommand = QuesAnsw_2;
                    adapterQuesAnsw_2.Fill(tableQuesAnsw_2);

                    DataTable tableQuesAnsw_3 = new DataTable();
                    adapterQuesAnsw_3.SelectCommand = QuesAnsw_3;
                    adapterQuesAnsw_3.Fill(tableQuesAnsw_3);

                    DataTable tableQuesAnsw_4 = new DataTable();
                    adapterQuesAnsw_4.SelectCommand = QuesAnsw_4;
                    adapterQuesAnsw_4.Fill(tableQuesAnsw_4);

                    DataTable tableQuesAnsw_5 = new DataTable();
                    adapterQuesAnsw_5.SelectCommand = QuesAnsw_5;
                    adapterQuesAnsw_5.Fill(tableQuesAnsw_5);

                    int RightAnswer = 0;
                    string mailBody = "<h3 style='text-align: center;'>Итог вашего пройденного теста</h3>";
                    mailBody += "<table style='-webkit-border-radius: 10px; -moz-border-radius: 10px; -khtml-border-radius: 10px; border: 1px solid #dddddd; width: 100%; border-radius: 20px;'>";
                    mailBody += "<tr>";
                    mailBody += "<th>Вопрос</th>";
                    mailBody += "<th>Ваш ответ</th>";
                    mailBody += "<th>Итог</th>";
                    mailBody += "</tr>";
                    mailBody += "<tr>";
                    if (tableQuesAnsw.Rows.Count > 0)
                    {
                        RightAnswer++;

                        string otvet = "Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que);
                        com.Parameters.AddWithValue("@Answer", input_otv);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv + " </td>";
                        mailBody += "<td style='background-color:green; border: 1px solid #dddddd; text-align: center; padding: 8px;'>" + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        string otvet = "Не Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que);
                        com.Parameters.AddWithValue("@Answer", input_otv);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv + " </td>";
                        mailBody += "<td style='background-color:red; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    mailBody += "</tr>";
                    mailBody += "<tr>";
                    if (tableQuesAnsw_2.Rows.Count > 0)
                    {
                        RightAnswer++;

                        string otvet = "Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_2);
                        com.Parameters.AddWithValue("@Answer", input_otv_2);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_2 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_2 + " </td>";
                        mailBody += "<td style='background-color:green; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        string otvet = "Не Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_2);
                        com.Parameters.AddWithValue("@Answer", input_otv_2);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_2 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_2 + " </td>";
                        mailBody += "<td style='background-color:red; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    mailBody += "</tr>";
                    mailBody += "<tr>";
                    if (tableQuesAnsw_3.Rows.Count > 0)
                    {
                        RightAnswer++;
                        string otvet = "Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_3);
                        com.Parameters.AddWithValue("@Answer", input_otv_3);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_3 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_3 + " </td>";
                        mailBody += "<td style='background-color:green; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        string otvet = "Не Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_3);
                        com.Parameters.AddWithValue("@Answer", input_otv_3);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_3 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_3 + " </td>";
                        mailBody += "<td style='background-color:red; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    mailBody += "</tr>";
                    mailBody += "<tr>";
                    if (tableQuesAnsw_4.Rows.Count > 0)
                    {
                        RightAnswer++;

                        string otvet = "Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_4);
                        com.Parameters.AddWithValue("@Answer", input_otv_4);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_4 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_4 + " </td>";
                        mailBody += "<td style='background-color:green; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        string otvet = "Не Верно";
                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_4);
                        com.Parameters.AddWithValue("@Answer", input_otv_4);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_4 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_4 + " </td>";
                        mailBody += "<td style='background-color:red; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    mailBody += "</tr>";
                    mailBody += "<tr>";
                    if (tableQuesAnsw_5.Rows.Count > 0)
                    {
                        RightAnswer++;

                        string otvet = "Верно";

                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_5);
                        com.Parameters.AddWithValue("@Answer", input_otv_5);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_5 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_5 + " </td>";
                        mailBody += "<td style='background-color:green; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        string otvet = "Не Верно";
                        SqlCommand com = new SqlCommand("INSERT INTO [ПройденныйТест] (Question, Answer, Login, Total) Values (@Question, @Answer, @Login, @Total)", sqlConnection);

                        com.Parameters.AddWithValue("@Question", que_5);
                        com.Parameters.AddWithValue("@Answer", input_otv_5);
                        com.Parameters.AddWithValue("@Login", log);
                        com.Parameters.AddWithValue("@Total", otvet);

                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + que_5 + " </td>";
                        mailBody += "<td style='border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + input_otv_5 + " </td>";
                        mailBody += "<td style='background-color:red; border: 1px solid #dddddd; text-align: center; padding: 8px;'> " + otvet + " </td>";

                        com.ExecuteNonQuery().ToString();
                    }
                    mailBody += "</tr>";
                    mailBody += "</table>";

                    //Отправка итога теста
                    SqlCommand Student = new SqlCommand($"SELECT email from [Ученик] where login = @login", sqlConnection);
                    Student.Parameters.AddWithValue("login", log);
                    string email = Student.ExecuteScalar().ToString();

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(email);
                    mailMessage.From = new MailAddress("mathformul@gmail.com");
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = mailBody;
                    mailMessage.Subject = "Итог пройденного теста";


                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential("mathformul@gmail.com", "opyugpidyrpeyale");

                    try
                    {
                        smtpClient.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }

                    Timer.Enabled = false;
                    DialogResult result1 = MessageBox.Show($"Данные за пройденный тест были отправлены вам на почту", "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (result1 == DialogResult.OK)
                    {
                        this.Hide();
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e) //Timer----
        {
            if (Uchetnaya_sapis.Text == "Ученик - ")
            {
                if (s > 0)
                {
                    s--;
                    timer_label.Text = s.ToString() + " cек.";

                    if (s == 0)
                    {
                        Timer.Enabled = false;
                        Save_test.Enabled = false;

                        DialogResult result = MessageBox.Show($"Вы не успели отправить ответ{Environment.NewLine}Хотите ли выйти из программы{Environment.NewLine}", "Сообщение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            Timer.Enabled = false;
                            Application.Exit();
                        }
                        else
                        {
                            Timer.Enabled = false;
                            this.Close();
                        }
                    }
                }

            }
        }

        public void ViewImage_SelectedIndexChanged()
        {
            int ind = 1 + tab_control.SelectedIndex;
            //Проверка на то, что есть ли картинка к заданию
            try
            {
                ViewImage.Image = null;
                ViewImage_2.Image = null;
                ViewImage_3.Image = null;
                ViewImage_4.Image = null;
                ViewImage_5.Image = null;

                SqlCommand com1 = new SqlCommand("Select Image from Тест where id = " + ind, sqlConnection);
                MemoryStream ms = new MemoryStream((byte[])com1.ExecuteScalar());
                Image returnImage = Image.FromStream(ms);

                ViewImage.Image = returnImage;
                ViewImage.SizeMode = PictureBoxSizeMode.Zoom;
                ViewImage_2.Image = returnImage;
                ViewImage_2.SizeMode = PictureBoxSizeMode.Zoom;
                ViewImage_3.Image = returnImage;
                ViewImage_3.SizeMode = PictureBoxSizeMode.Zoom;
                ViewImage_4.Image = returnImage;
                ViewImage_4.SizeMode = PictureBoxSizeMode.Zoom;
                ViewImage_5.Image = returnImage;
                ViewImage_5.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Uchetnaya_sapis.Text == "Ученик - ")
            {
                ViewImage_SelectedIndexChanged();
            }
            else if (Uchetnaya_sapis.Text == "Учитель")
            {
                ViewImage_SelectedIndexChanged();
            }
        }

        private void Тест_Shown(object sender, EventArgs e)
        {
            if (Uchetnaya_sapis.Text == "Ученик - ")
            {
                int ind = 1 + tab_control.SelectedIndex;
                SqlCommand com = new SqlCommand("Select Question from Тест where id = 1", sqlConnection);
                string Ques = com.ExecuteScalar().ToString();
                Question.Text = Ques;
                SqlCommand com_2 = new SqlCommand("Select Question from Тест where id = 2", sqlConnection);
                string Ques_2 = com_2.ExecuteScalar().ToString();
                Question_2.Text = Ques_2;
                SqlCommand com_3 = new SqlCommand("Select Question from Тест where id = 3", sqlConnection);
                string Ques_3 = com_3.ExecuteScalar().ToString();
                Question_3.Text = Ques_3;
                SqlCommand com_4 = new SqlCommand("Select Question from Тест where id = 4", sqlConnection);
                string Ques_4 = com_4.ExecuteScalar().ToString();
                Question_4.Text = Ques_4;
                SqlCommand com_5 = new SqlCommand("Select Question from Тест where id = 5", sqlConnection);
                string Ques_5 = com_5.ExecuteScalar().ToString();
                Question_5.Text = Ques_5;

                //Проверка на то, что есть ли картинка к заданию
                try
                {
                    SqlCommand com1 = new SqlCommand("Select Image from Тест where id = " + ind, sqlConnection);
                    MemoryStream ms = new MemoryStream((byte[])com1.ExecuteScalar());
                    Image returnImage = Image.FromStream(ms);

                    ViewImage.Image = returnImage;
                    ViewImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
            else if (Uchetnaya_sapis.Text == "Учитель")
            {
                int ind = 1 + tab_control.SelectedIndex;
                SqlCommand com = new SqlCommand("Select Question from Тест where id = 1", sqlConnection);
                string Ques = com.ExecuteScalar().ToString();
                Vvod_question.Text = Ques;
                SqlCommand com_2 = new SqlCommand("Select Question from Тест where id = 2", sqlConnection);
                string Ques_2 = com_2.ExecuteScalar().ToString();
                Vvod_question_2.Text = Ques_2;
                SqlCommand com_3 = new SqlCommand("Select Question from Тест where id = 3", sqlConnection);
                string Ques_3 = com_3.ExecuteScalar().ToString();
                Vvod_question_3.Text = Ques_3;
                SqlCommand com_4 = new SqlCommand("Select Question from Тест where id = 4", sqlConnection);
                string Ques_4 = com_4.ExecuteScalar().ToString();
                Vvod_question_4.Text = Ques_4;
                SqlCommand com_5 = new SqlCommand("Select Question from Тест where id = 5", sqlConnection);
                string Ques_5 = com_5.ExecuteScalar().ToString();
                Vvod_question_5.Text = Ques_5;

                SqlCommand command = new SqlCommand("Select Answer from Тест where id = 1", sqlConnection);
                string answer = command.ExecuteScalar().ToString();
                input_otvet.Text = answer;
                SqlCommand command_2 = new SqlCommand("Select Answer from Тест where id = 2", sqlConnection);
                string answer_2 = command_2.ExecuteScalar().ToString();
                input_otvet_2.Text = answer_2;
                SqlCommand command_3 = new SqlCommand("Select Answer from Тест where id = 3", sqlConnection);
                string answer_3 = command_3.ExecuteScalar().ToString();
                input_otvet_3.Text = answer_3;
                SqlCommand command_4 = new SqlCommand("Select Answer from Тест where id = 4", sqlConnection);
                string answer_4 = command_4.ExecuteScalar().ToString();
                input_otvet_4.Text = answer_4;
                SqlCommand command_5 = new SqlCommand("Select Answer from Тест where id = 5", sqlConnection);
                string answer_5 = command_5.ExecuteScalar().ToString();
                input_otvet_5.Text = answer_5;


                //Проверка на то, что есть ли картинка к заданию
                try
                {
                    SqlCommand com2 = new SqlCommand("Select Image from Тест where id = " + ind, sqlConnection);
                    MemoryStream ms1 = new MemoryStream((byte[])com2.ExecuteScalar());
                    Image returnImage1 = Image.FromStream(ms1);

                    ViewImage.Image = returnImage1;
                    ViewImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch { }
            }
        }

        private void next_TapPages_Click(object sender, EventArgs e)
        {
            next_tabPage();
        }

        private void pre_TabPages_Click(object sender, EventArgs e)
        {
            pre_tabPage();
        }

        private void next_TabPages_2_Click(object sender, EventArgs e)
        {
            next_tabPage();
        }

        private void pre_TabPages_2_Click(object sender, EventArgs e)
        {
            pre_tabPage();
        }

        private void next_TabPages_3_Click(object sender, EventArgs e)
        {
            next_tabPage();
        }

        private void pre_TabPages_3_Click(object sender, EventArgs e)
        {
            pre_tabPage();
        }

        private void next_TabPages_4_Click(object sender, EventArgs e)
        {
            next_tabPage();
        }

        private void pre_TabPages_4_Click(object sender, EventArgs e)
        {
            pre_tabPage();
        }

        private void next_TabPages_5_Click(object sender, EventArgs e)
        {
            next_tabPage();
        }

        private void pre_TabPages_5_Click(object sender, EventArgs e)
        {
            pre_tabPage();
        }
    }
}
