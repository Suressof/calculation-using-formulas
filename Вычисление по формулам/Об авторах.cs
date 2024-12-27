using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вычисление_по_формулам
{
    public partial class Об_авторах : Form
    {
        public Об_авторах()
        {
            InitializeComponent();
        }

        private void vihod_iz_programm_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Об_авторах_Load(object sender, EventArgs e)
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            MaximizeBox = false;
        }
    }
}
