using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class Form2 : Form
    {
        private string formMessage;
        public Form2(string message)
        {
            InitializeComponent();
            formMessage = message;
            label2.Text = formMessage;
        }
    }
}
