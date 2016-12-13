using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevCompressWin
{
    public partial class SetPath : Form
    {
        public bool IsOK { get; set; }
        public string Path { get; set; }

        
        public SetPath(string fileName)
        {
            InitializeComponent();

            this.label1.Text = fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsOK = true;
            this.Path = this.textBox1.Text;
            this.Close();
        }
    }
}
