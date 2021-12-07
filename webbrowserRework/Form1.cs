using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbrowserRework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //browser.Url = new Uri("https://google.com");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            browser.Url = new Uri("https://google.com");
        }

        //戻る
        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.GoBack();
        }

        //進む
        private void btnForward_Click(object sender, EventArgs e)
        {
            browser.GoForward();
        }
    }
}
