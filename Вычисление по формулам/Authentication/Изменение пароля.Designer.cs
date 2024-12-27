namespace Вычисление_по_формулам
{
    partial class Изменение_пароля
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Изменение_пароля));
            this.label1 = new System.Windows.Forms.Label();
            this.lb_login = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.roundBtn3 = new Вычисление_по_формулам.RoundBtn();
            this.change_pass = new Вычисление_по_формулам.RoundBtn();
            this.pass_tb_check = new Вычисление_по_формулам.RoundTextBox();
            this.pass_tb = new Вычисление_по_формулам.RoundTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш логин:";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Изменение_пароля_MouseDown);
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.BackColor = System.Drawing.Color.Transparent;
            this.lb_login.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_login.Location = new System.Drawing.Point(148, 9);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(75, 30);
            this.lb_login.TabIndex = 1;
            this.lb_login.Text = "label2";
            this.lb_login.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Изменение_пароля_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Новый пароль";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Изменение_пароля_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Повторите его";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Изменение_пароля_MouseDown);
            // 
            // roundBtn3
            // 
            this.roundBtn3.BackColor = System.Drawing.Color.Red;
            this.roundBtn3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.roundBtn3.ForeColor = System.Drawing.Color.Maroon;
            this.roundBtn3.Location = new System.Drawing.Point(17, 139);
            this.roundBtn3.Name = "roundBtn3";
            this.roundBtn3.Radius = 15;
            this.roundBtn3.Size = new System.Drawing.Size(106, 23);
            this.roundBtn3.TabIndex = 3;
            this.roundBtn3.Text = "Отменить";
            this.roundBtn3.UseVisualStyleBackColor = false;
            this.roundBtn3.Click += new System.EventHandler(this.roundBtn3_Click);
            this.roundBtn3.Paint += new System.Windows.Forms.PaintEventHandler(this.roundBtn3_Paint);
            // 
            // change_pass
            // 
            this.change_pass.BackColor = System.Drawing.Color.Lime;
            this.change_pass.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_pass.ForeColor = System.Drawing.Color.Green;
            this.change_pass.Location = new System.Drawing.Point(171, 139);
            this.change_pass.Name = "change_pass";
            this.change_pass.Radius = 15;
            this.change_pass.Size = new System.Drawing.Size(106, 23);
            this.change_pass.TabIndex = 3;
            this.change_pass.Text = "Изменить";
            this.change_pass.UseVisualStyleBackColor = false;
            this.change_pass.Click += new System.EventHandler(this.change_pass_Click);
            this.change_pass.Paint += new System.Windows.Forms.PaintEventHandler(this.change_pass_Paint);
            // 
            // pass_tb_check
            // 
            this.pass_tb_check.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pass_tb_check.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.pass_tb_check.BorderFocusColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pass_tb_check.BorderRadius = 10;
            this.pass_tb_check.BorderSize = 2;
            this.pass_tb_check.Location = new System.Drawing.Point(171, 95);
            this.pass_tb_check.Multiline = false;
            this.pass_tb_check.Name = "pass_tb_check";
            this.pass_tb_check.Padding = new System.Windows.Forms.Padding(7);
            this.pass_tb_check.PasswordChar = true;
            this.pass_tb_check.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.pass_tb_check.PlaceholderText = "";
            this.pass_tb_check.Size = new System.Drawing.Size(107, 28);
            this.pass_tb_check.TabIndex = 2;
            this.pass_tb_check.UnderlinedStyle = false;
            this.pass_tb_check.Paint += new System.Windows.Forms.PaintEventHandler(this.roundTextBox2_Paint);
            // 
            // pass_tb
            // 
            this.pass_tb.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pass_tb.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.pass_tb.BorderFocusColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pass_tb.BorderRadius = 10;
            this.pass_tb.BorderSize = 2;
            this.pass_tb.Location = new System.Drawing.Point(171, 51);
            this.pass_tb.Multiline = false;
            this.pass_tb.Name = "pass_tb";
            this.pass_tb.Padding = new System.Windows.Forms.Padding(7);
            this.pass_tb.PasswordChar = true;
            this.pass_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.pass_tb.PlaceholderText = "";
            this.pass_tb.Size = new System.Drawing.Size(107, 28);
            this.pass_tb.TabIndex = 2;
            this.pass_tb.UnderlinedStyle = false;
            this.pass_tb.Paint += new System.Windows.Forms.PaintEventHandler(this.roundTextBox1_Paint);
            // 
            // Изменение_пароля
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 174);
            this.Controls.Add(this.roundBtn3);
            this.Controls.Add(this.change_pass);
            this.Controls.Add(this.pass_tb_check);
            this.Controls.Add(this.pass_tb);
            this.Controls.Add(this.lb_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Изменение_пароля";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Изменение пароля";
            this.Load += new System.EventHandler(this.Изменение_пароля_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Изменение_пароля_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Изменение_пароля_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundTextBox pass_tb;
        private RoundTextBox pass_tb_check;
        private RoundBtn change_pass;
        private RoundBtn roundBtn3;
    }
}