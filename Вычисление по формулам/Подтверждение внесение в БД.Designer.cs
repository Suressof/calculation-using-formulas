namespace Вычисление_по_формулам
{
    partial class Подтверждение_внесение_в_БД
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Подтверждение_внесение_в_БД));
            this.label1 = new System.Windows.Forms.Label();
            this.formula_index = new System.Windows.Forms.Label();
            this.vihod_pod_BD = new Вычисление_по_формулам.RoundBtn();
            this.vvod_pod_BD = new Вычисление_по_формулам.RoundBtn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вы хотите ввести данные";
            // 
            // formula_index
            // 
            this.formula_index.BackColor = System.Drawing.Color.Transparent;
            this.formula_index.Cursor = System.Windows.Forms.Cursors.Default;
            this.formula_index.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.formula_index.Location = new System.Drawing.Point(12, 46);
            this.formula_index.Name = "formula_index";
            this.formula_index.Size = new System.Drawing.Size(312, 22);
            this.formula_index.TabIndex = 3;
            this.formula_index.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vihod_pod_BD
            // 
            this.vihod_pod_BD.BackColor = System.Drawing.Color.White;
            this.vihod_pod_BD.Location = new System.Drawing.Point(224, 95);
            this.vihod_pod_BD.Name = "vihod_pod_BD";
            this.vihod_pod_BD.Radius = 15;
            this.vihod_pod_BD.Size = new System.Drawing.Size(75, 23);
            this.vihod_pod_BD.TabIndex = 4;
            this.vihod_pod_BD.Text = "Нет";
            this.vihod_pod_BD.UseVisualStyleBackColor = false;
            this.vihod_pod_BD.Click += new System.EventHandler(this.vihod_pod_BD_Click);
            this.vihod_pod_BD.Paint += new System.Windows.Forms.PaintEventHandler(this.vihod_pod_BD_Paint);
            // 
            // vvod_pod_BD
            // 
            this.vvod_pod_BD.BackColor = System.Drawing.Color.White;
            this.vvod_pod_BD.Location = new System.Drawing.Point(42, 95);
            this.vvod_pod_BD.Name = "vvod_pod_BD";
            this.vvod_pod_BD.Radius = 15;
            this.vvod_pod_BD.Size = new System.Drawing.Size(75, 23);
            this.vvod_pod_BD.TabIndex = 4;
            this.vvod_pod_BD.Text = "Да";
            this.vvod_pod_BD.UseVisualStyleBackColor = false;
            this.vvod_pod_BD.Click += new System.EventHandler(this.vvod_pod_BD_Click);
            this.vvod_pod_BD.Paint += new System.Windows.Forms.PaintEventHandler(this.vihod_pod_BD_Paint);
            // 
            // Подтверждение_внесение_в_БД
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(336, 142);
            this.ControlBox = false;
            this.Controls.Add(this.vvod_pod_BD);
            this.Controls.Add(this.vihod_pod_BD);
            this.Controls.Add(this.formula_index);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Подтверждение_внесение_в_БД";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подтверждение внесение в БД";
            this.Load += new System.EventHandler(this.Подтверждение_внесение_в_БД_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Подтверждение_внесение_в_БД_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Подтверждение_внесение_в_БД_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label formula_index;
        private RoundBtn vihod_pod_BD;
        private RoundBtn vvod_pod_BD;
    }
}