namespace Вычисление_по_формулам
{
    partial class Регистрация
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.vvedite_login_reg = new System.Windows.Forms.Label();
            this.vvedite_pass_reg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.check_input_reg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pass_pod = new System.Windows.Forms.TextBox();
            this.bt_reg_exit = new Вычисление_по_формулам.RoundBtn();
            this.bt_reg = new Вычисление_по_формулам.RoundBtn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // vvedite_login_reg
            // 
            this.vvedite_login_reg.AutoSize = true;
            this.vvedite_login_reg.BackColor = System.Drawing.Color.Transparent;
            this.vvedite_login_reg.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vvedite_login_reg.Location = new System.Drawing.Point(8, 89);
            this.vvedite_login_reg.Name = "vvedite_login_reg";
            this.vvedite_login_reg.Size = new System.Drawing.Size(123, 21);
            this.vvedite_login_reg.TabIndex = 1;
            this.vvedite_login_reg.Text = "Введите логин";
            this.vvedite_login_reg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // vvedite_pass_reg
            // 
            this.vvedite_pass_reg.AutoSize = true;
            this.vvedite_pass_reg.BackColor = System.Drawing.Color.Transparent;
            this.vvedite_pass_reg.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vvedite_pass_reg.Location = new System.Drawing.Point(8, 178);
            this.vvedite_pass_reg.Name = "vvedite_pass_reg";
            this.vvedite_pass_reg.Size = new System.Drawing.Size(131, 21);
            this.vvedite_pass_reg.TabIndex = 1;
            this.vvedite_pass_reg.Text = "Введите пароль";
            this.vvedite_pass_reg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Введите почта";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 111);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(249, 20);
            this.textBox_login.TabIndex = 3;
            // 
            // textBox_pass
            // 
            this.textBox_pass.Location = new System.Drawing.Point(12, 200);
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.Size = new System.Drawing.Size(249, 20);
            this.textBox_pass.TabIndex = 3;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(12, 155);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(249, 20);
            this.textBox_email.TabIndex = 3;
            // 
            // check_input_reg
            // 
            this.check_input_reg.BackColor = System.Drawing.Color.Red;
            this.check_input_reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.check_input_reg.ForeColor = System.Drawing.Color.White;
            this.check_input_reg.Location = new System.Drawing.Point(12, 283);
            this.check_input_reg.Name = "check_input_reg";
            this.check_input_reg.Size = new System.Drawing.Size(249, 31);
            this.check_input_reg.TabIndex = 4;
            this.check_input_reg.Text = "Вы не ввели все значения!";
            this.check_input_reg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_input_reg.Visible = false;
            this.check_input_reg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Подтверждение пароля";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            // 
            // textBox_pass_pod
            // 
            this.textBox_pass_pod.Location = new System.Drawing.Point(12, 245);
            this.textBox_pass_pod.Name = "textBox_pass_pod";
            this.textBox_pass_pod.Size = new System.Drawing.Size(249, 20);
            this.textBox_pass_pod.TabIndex = 3;
            // 
            // bt_reg_exit
            // 
            this.bt_reg_exit.BackColor = System.Drawing.Color.Red;
            this.bt_reg_exit.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.bt_reg_exit.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_reg_exit.Location = new System.Drawing.Point(12, 324);
            this.bt_reg_exit.Name = "bt_reg_exit";
            this.bt_reg_exit.Radius = 15;
            this.bt_reg_exit.Size = new System.Drawing.Size(80, 25);
            this.bt_reg_exit.TabIndex = 5;
            this.bt_reg_exit.Text = "Выйти";
            this.bt_reg_exit.UseVisualStyleBackColor = false;
            this.bt_reg_exit.Click += new System.EventHandler(this.bt_reg_exit_Click);
            this.bt_reg_exit.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_reg_Paint);
            // 
            // bt_reg
            // 
            this.bt_reg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bt_reg.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.bt_reg.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_reg.Location = new System.Drawing.Point(98, 324);
            this.bt_reg.Name = "bt_reg";
            this.bt_reg.Radius = 15;
            this.bt_reg.Size = new System.Drawing.Size(163, 25);
            this.bt_reg.TabIndex = 5;
            this.bt_reg.Text = "Зарегистрироваться";
            this.bt_reg.UseVisualStyleBackColor = false;
            this.bt_reg.Click += new System.EventHandler(this.bt_reg_Click);
            this.bt_reg.Paint += new System.Windows.Forms.PaintEventHandler(this.bt_reg_Paint);
            // 
            // Регистрация
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 362);
            this.Controls.Add(this.bt_reg_exit);
            this.Controls.Add(this.bt_reg);
            this.Controls.Add(this.check_input_reg);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_pass_pod);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vvedite_pass_reg);
            this.Controls.Add(this.vvedite_login_reg);
            this.Controls.Add(this.label1);
            this.Name = "Регистрация";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.Регистрация_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Регистрация_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Регистрация_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label vvedite_login_reg;
        private System.Windows.Forms.Label vvedite_pass_reg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label check_input_reg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pass_pod;
        private RoundBtn bt_reg;
        private RoundBtn bt_reg_exit;
    }
}