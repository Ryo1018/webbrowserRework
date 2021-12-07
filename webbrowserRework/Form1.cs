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

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //ページ移動した後のイベント
            txtUrl.Text = browser.Url.ToString();
            /*
            if (browser.CanGoBack)
            {
                btnBack.Enabled = true;
            }
            */

            btnBack.Enabled = browser.CanGoBack;
            btnForward.Enabled = browser.CanGoForward;
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                //Enterが押された時
                browser.Url = new Uri(txtUrl.Text);
            }
        }
    }
}
