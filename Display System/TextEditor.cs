using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display_System
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }
        public string Caption { get; set; }
        public string FinalText { get; private set; }
        public string InitialText { get; set; }
        private void TextEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = InitialText;
            Text = Caption;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalText = textBox1.Text;
            Close();
        }
    }
}
