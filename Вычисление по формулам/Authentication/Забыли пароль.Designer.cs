namespace Вычисление_по_формулам
{
    partial class Забыли_пароль
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Забыли_пароль));
            this.label1 = new System.Windows.Forms.Label();
            this.email_btn = new Вычисление_по_формулам.RoundBtn();
            this.email_tb = new Вычисление_по_формулам.RoundTextBox();
            this.roundBtn1 = new Вычисление_по_формулам.RoundBtn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 166);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите свою почту, \r\nчтобы мы смогли отправить код для подтверждения почты";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Забыли_пароль_MouseDown);
            // 
            // email_btn
            // 
            this.email_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.email_btn.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.email_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.email_btn.Location = new System.Drawing.Point(170, 216);
            this.email_btn.Name = "email_btn";
            this.email_btn.Radius = 15;
            this.email_btn.Size = new System.Drawing.Size(81, 31);
            this.email_btn.TabIndex = 2;
            this.email_btn.Text = "Отправить";
            this.email_btn.UseVisualStyleBackColor = false;
            this.email_btn.Click += new System.EventHandler(this.email_btn_Click);
            // 
            // email_tb
            // 
            this.email_tb.BackColor = System.Drawing.Color.White;
            this.email_tb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.email_tb.BorderFocusColor = System.Drawing.Color.Black;
            this.email_tb.BorderRadius = 15;
            this.email_tb.BorderSize = 1;
            this.email_tb.Font = new System.Drawing.Font("Open Sans Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_tb.Location = new System.Drawing.Point(12, 170);
            this.email_tb.Multiline = false;
            this.email_tb.Name = "email_tb";
            this.email_tb.Padding = new System.Windows.Forms.Padding(7);
            this.email_tb.PasswordChar = false;
            this.email_tb.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.email_tb.PlaceholderText = "test@gmail.com";
            this.email_tb.Size = new System.Drawing.Size(239, 32);
            this.email_tb.TabIndex = 1;
            this.email_tb.UnderlinedStyle = false;
            // 
            // roundBtn1
            // 
            this.roundBtn1.BackColor = System.Drawing.Color.OrangeRed;
            this.roundBtn1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.roundBtn1.ForeColor = System.Drawing.Color.Maroon;
            this.roundBtn1.Location = new System.Drawing.Point(12, 216);
            this.roundBtn1.Name = "roundBtn1";
            this.roundBtn1.Radius = 15;
            this.roundBtn1.Size = new System.Drawing.Size(81, 31);
            this.roundBtn1.TabIndex = 2;
            this.roundBtn1.Text = "Отменить";
            this.roundBtn1.UseVisualStyleBackColor = false;
            this.roundBtn1.Click += new System.EventHandler(this.roundBtn1_Click);
            // 
            // Забыли_пароль
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 259);
            this.Controls.Add(this.roundBtn1);
            this.Controls.Add(this.email_btn);
            this.Controls.Add(this.email_tb);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Забыли_пароль";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Забыли пароль";
            this.Load += new System.EventHandler(this.Забыли_пароль_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Забыли_пароль_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Забыли_пароль_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundTextBox email_tb;
        private RoundBtn email_btn;
        private RoundBtn roundBtn1;
    }
}