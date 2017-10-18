using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KF2Tool
{
    public partial class Overwrite : Form
    {
        string file;
        string source;

        public Overwrite(string sourceFile, string newfile)
        {
            InitializeComponent();
            file = newfile;
            source = sourceFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Copy(source, file,true);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Overwrite_Load(object sender, EventArgs e)
        {

        }
    }
}
