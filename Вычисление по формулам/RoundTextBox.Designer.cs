namespace Вычисление_по_формулам
{
    partial class RoundTextBox
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Location = new System.Drawing.Point(7, 7);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(136, 13);
            this.TextBox.TabIndex = 0;
            this.TextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.TextBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            this.TextBox.MouseEnter += new System.EventHandler(this.TextBox_MouseEnter);
            this.TextBox.MouseLeave += new System.EventHandler(this.TextBox_MouseLeave);
            // 
            // RoundTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBox);
            this.Name = "RoundTextBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(150, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TextBox;
    }
}
