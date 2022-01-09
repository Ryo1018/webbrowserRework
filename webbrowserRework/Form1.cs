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
            {
                FavoriteData data = new FavoriteData();
                data.Title = "google";
                data.Url = "http://google.co.jp/";
                lstFavorite.Items.Add(data);
            }

            {
                FavoriteData data = new FavoriteData();
                data.Title = "goo";
                data.Url = "http://goo.ne.jp/";
                lstFavorite.Items.Add(data);
            }
            
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //お気に入りのダブルクリックイベント
        private void lstFavorite_DoubleClick(object sender, EventArgs e)
        {
            FavoriteData data = (FavoriteData)lstFavorite.Items[lstFavorite.SelectedIndex];
            
            browser.Url = new Uri(data.Url);
        }

        //お気に入り追加処理
        private void btnAddFavorite_Click(object sender, EventArgs e)
        {
            //お気に入りデータの設定
            FavoriteData data = new FavoriteData();
            data.Title = browser.DocumentTitle;
            data.Url = browser.Url.ToString();

            //リストにお気に入りデータを追加
            lstFavorite.Items.Add(data);
        }

        //お気に入り削除処理
        private void btnDeleteFavorite_Click(object sender, EventArgs e)
        {
            //選択されているお気に入りデータの取得
            FavoriteData data = (FavoriteData)lstFavorite.Items[lstFavorite.SelectedIndex];

            //リストからお気に入りデータを削除
            lstFavorite.Items.Remove(data);
        }
    }

    public class FavoriteData
    {
        public String Title = "";
        public String Url = "";

        public override String ToString()
        {
            return Title;
        }
    }
}
