namespace Вычисление_по_формулам
{
    partial class Проверка_почты
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Проверка_почты));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.retry_send = new Вычисление_по_формулам.RoundBtn();
            this.close = new Вычисление_по_формулам.RoundBtn();
            this.checkEmail_btn = new Вычисление_по_формулам.RoundBtn();
            this.email_check = new Вычисление_по_формулам.RoundTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мы отправили код на почту, Вам требуется ввести этот код, чтобы подтвердить, что " +
    "это ваша почта";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Проверка_почты_MouseDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 43);
            this.label2.TabIndex = 0;
            this.label2.Text = "Если вам не пришел код, то попробуйте отпавить его ещё раз\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Проверка_почты_MouseDown);
            // 
            // retry_send
            // 
            this.retry_send.BackColor = System.Drawing.Color.Cyan;
            this.retry_send.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.retry_send.ForeColor = System.Drawing.Color.Teal;
            this.retry_send.Location = new System.Drawing.Point(267, 149);
            this.retry_send.Name = "retry_send";
            this.retry_send.Radius = 15;
            this.retry_send.Size = new System.Drawing.Size(77, 29);
            this.retry_send.TabIndex = 5;
            this.retry_send.Text = "Отправить";
            this.retry_send.UseVisualStyleBackColor = false;
            this.retry_send.Click += new System.EventHandler(this.retry_send_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Crimson;
            this.close.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.close.Location = new System.Drawing.Point(10, 103);
            this.close.Name = "close";
            this.close.Radius = 15;
            this.close.Size = new System.Drawing.Size(77, 28);
            this.close.TabIndex = 4;
            this.close.Text = "Отменить";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.Paint += new System.Windows.Forms.PaintEventHandler(this.close_Paint);
            // 
            // checkEmail_btn
            // 
            this.checkEmail_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.checkEmail_btn.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.checkEmail_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.checkEmail_btn.Location = new System.Drawing.Point(267, 103);
            this.checkEmail_btn.Name = "checkEmail_btn";
            this.checkEmail_btn.Radius = 15;
            this.checkEmail_btn.Size = new System.Drawing.Size(77, 28);
            this.checkEmail_btn.TabIndex = 4;
            this.checkEmail_btn.Text = "Проверка";
            this.checkEmail_btn.UseVisualStyleBackColor = false;
            this.checkEmail_btn.Click += new System.EventHandler(this.checkEmail_btn_Click);
            this.checkEmail_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.checkEmail_btn_Paint);
            // 
            // email_check
            // 
            this.email_check.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.email_check.BorderColor = System.Drawing.Color.Gray;
            this.email_check.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.email_check.BorderRadius = 10;
            this.email_check.BorderSize = 2;
            this.email_check.Font = new System.Drawing.Font("Open Sans Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.email_check.Location = new System.Drawing.Point(130, 101);
            this.email_check.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.email_check.Multiline = false;
            this.email_check.Name = "email_check";
            this.email_check.Padding = new System.Windows.Forms.Padding(7);
            this.email_check.PasswordChar = false;
            this.email_check.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.email_check.PlaceholderText = "";
            this.email_check.Size = new System.Drawing.Size(100, 30);
            this.email_check.TabIndex = 3;
            this.email_check.UnderlinedStyle = false;
            // 
            // Проверка_почты
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 194);
            this.Controls.Add(this.retry_send);
            this.Controls.Add(this.close);
            this.Controls.Add(this.checkEmail_btn);
            this.Controls.Add(this.email_check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Проверка_почты";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка почты";
            this.Load += new System.EventHandler(this.Проверка_почты_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Проверка_почты_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Проверка_почты_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundTextBox email_check;
        private RoundBtn checkEmail_btn;
        private RoundBtn close;
        private RoundBtn retry_send;
        private System.Windows.Forms.Label label2;
    }
}