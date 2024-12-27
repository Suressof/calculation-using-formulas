namespace Вычисление_по_формулам
{
    partial class Просмотр_пройденных_тестов
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Просмотр_пройденных_тестов));
            this.BD_prod_Test = new System.Windows.Forms.DataGridView();
            this.comboBox_Student = new System.Windows.Forms.ComboBox();
            this.ученикBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тест_по_формуламDataSet = new Вычисление_по_формулам.Тест_по_формуламDataSet();
            this.ученикTableAdapter = new Вычисление_по_формулам.Тест_по_формуламDataSetTableAdapters.УченикTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kol_verno_lb = new System.Windows.Forms.Label();
            this.kol_neverno_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BD_prod_Test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ученикBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тест_по_формуламDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BD_prod_Test
            // 
            this.BD_prod_Test.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.BD_prod_Test.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.BD_prod_Test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BD_prod_Test.Cursor = System.Windows.Forms.Cursors.Default;
            this.BD_prod_Test.Location = new System.Drawing.Point(-2, 0);
            this.BD_prod_Test.Name = "BD_prod_Test";
            this.BD_prod_Test.ReadOnly = true;
            this.BD_prod_Test.RowHeadersVisible = false;
            this.BD_prod_Test.Size = new System.Drawing.Size(665, 237);
            this.BD_prod_Test.TabIndex = 0;
            // 
            // comboBox_Student
            // 
            this.comboBox_Student.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ученикBindingSource, "login", true));
            this.comboBox_Student.DataSource = this.ученикBindingSource;
            this.comboBox_Student.DisplayMember = "login";
            this.comboBox_Student.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Student.FormattingEnabled = true;
            this.comboBox_Student.Location = new System.Drawing.Point(152, 243);
            this.comboBox_Student.Name = "comboBox_Student";
            this.comboBox_Student.Size = new System.Drawing.Size(121, 28);
            this.comboBox_Student.TabIndex = 1;
            this.comboBox_Student.ValueMember = "Id";
            this.comboBox_Student.TextChanged += new System.EventHandler(this.comboBox_Student_TextChanged);
            // 
            // ученикBindingSource
            // 
            this.ученикBindingSource.DataMember = "Ученик";
            this.ученикBindingSource.DataSource = this.тест_по_формуламDataSet;
            // 
            // тест_по_формуламDataSet
            // 
            this.тест_по_формуламDataSet.DataSetName = "Тест_по_формуламDataSet";
            this.тест_по_формуламDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ученикTableAdapter
            // 
            this.ученикTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбирите логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(293, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Верно -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(379, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Не верно -";
            // 
            // kol_verno_lb
            // 
            this.kol_verno_lb.AutoSize = true;
            this.kol_verno_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kol_verno_lb.Location = new System.Drawing.Point(353, 246);
            this.kol_verno_lb.Name = "kol_verno_lb";
            this.kol_verno_lb.Size = new System.Drawing.Size(0, 20);
            this.kol_verno_lb.TabIndex = 3;
            // 
            // kol_neverno_lb
            // 
            this.kol_neverno_lb.AutoSize = true;
            this.kol_neverno_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kol_neverno_lb.Location = new System.Drawing.Point(462, 246);
            this.kol_neverno_lb.Name = "kol_neverno_lb";
            this.kol_neverno_lb.Size = new System.Drawing.Size(0, 20);
            this.kol_neverno_lb.TabIndex = 3;
            // 
            // Просмотр_пройденных_тестов
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 277);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kol_neverno_lb);
            this.Controls.Add(this.kol_verno_lb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Student);
            this.Controls.Add(this.BD_prod_Test);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Просмотр_пройденных_тестов";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр пройденных тестов";
            this.Load += new System.EventHandler(this.Просмотр_пройденных_тестов_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BD_prod_Test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ученикBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тест_по_формуламDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BD_prod_Test;
        private System.Windows.Forms.ComboBox comboBox_Student;
        private Тест_по_формуламDataSet тест_по_формуламDataSet;
        private System.Windows.Forms.BindingSource ученикBindingSource;
        private Тест_по_формуламDataSetTableAdapters.УченикTableAdapter ученикTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label kol_verno_lb;
        private System.Windows.Forms.Label kol_neverno_lb;
    }
}