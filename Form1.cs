using Newtonsoft.Json;
using PForm.Model;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //移除
            //this.tabControl1.TabPages.Remove(this.tabPage1);
            //this.tabControl1.TabPages.Remove(this.tabPage2);
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

        }

        
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://www.google.com");

            var outputFile = Application.StartupPath + "/Download/a.test.pdf";

            // 截圖
            //await page.ScreenshotAsync();

            // 產PDF
            //await page.PdfAsync(outputFile);

        }

        // list
        private async void btn_serach1_ClickAsync(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var turl = txt_url.Text;
            var express = $"Array.from(document.querySelectorAll('{txt_express.Text}')).map(a => a.innerText + '(' + a.href + ')');";
            await ParseUrl(turl, express);

        }

        // detail
        private async void btn_serach2_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var turl = txt_url2.Text;
            var express = $"Array.from(document.querySelectorAll('{txt_express2.Text}')).map(a => a.innerText);";
            await ParseUrl(turl, express);

        }

        // comment用- 用HtmlAgilityPack parse json 內的 html
        private async void btn_serach3_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var strAry = txt_url3.Text.Split(',').Select(c => c.Trim()).ToList();

            var turl = $"https://forum.gamer.com.tw/ajax/moreCommend.php?bsn={strAry[0]}&snB={strAry[1]}&returnHtml=1";
            //Array.from(document.querySelectorAll('.more-reply')).map(a => a.id);

            // 建立 webclient
            using (WebClient webClient = new WebClient())
            {
                // 指定 WebClient 的編碼
                webClient.Encoding = Encoding.UTF8;
                // 指定 WebClient 的 Content-Type header
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                // 從網路 url 上取得資料
                var body = webClient.DownloadString(turl);
                var jsonObj = JsonConvert.DeserializeObject<Rootobject>(body);

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                foreach (var item in jsonObj.html)
                {
                    htmlDoc.LoadHtml(item);
                    var inputs = from input in htmlDoc.DocumentNode.Descendants("article")
                                 select input;

                    foreach (var input in inputs)
                    {
                        richtxt.Text += input.InnerText;
                        Debug.Print(input.InnerText);
                    }
                }
            }
        }

        private async void btn_serach4_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var turl = txt_url4.Text;
            var express = txt_express4.Text;
            await ParseUrl(turl, express);
        }

        private async void btn_serach5_Click(object sender, EventArgs e)
        {
            var turl = txt_url5.Text;
            var express = txt_express5.Text;
            await ParseUrl(turl, express);
        }

        public class Rootobject
        {
            public int next_snC { get; set; }
            public string[] html { get; set; }
        }

        private async Task ParseUrl(string turl, string express)
        {
            richtxt.Text = "";
            var launchOptions = new LaunchOptions()
            {
                Headless = true,
                Timeout = 1000000
            };
            var ops = new NavigationOptions()
            {
                Timeout = 120000,
            };
            using (var browser = await Puppeteer.LaunchAsync(launchOptions))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(turl, ops);
                await page.SetCookieAsync(new CookieParam
                {
                    Name = "over18",
                    Value = "1",
                });
                await page.GoToAsync(turl, ops);
                var artist = await page.EvaluateExpressionAsync<string[]>(express);
                var num = 1;
                foreach (string url in artist)
                {
                    var content = $"{num++} :  {url.Replace("\n", "\r\n")}{Environment.NewLine}";
                    //var content = $"{num++} :  {url.Replace("\n", "\r\n")}";
                    richtxt.Text += content;
                    Debug.Print(content);
                }

            }
        }

        // 點擊連結事件
        private async void richtxt_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var url = e.LinkText;
            var express = "";
            if (url.IndexOf("forum.gamer.com.tw") > 0)
            {
                express = "Array.from(document.querySelectorAll('.c-article__content')).map(a => a.innerText)";
            }
            else if (url.IndexOf("M.") > 0)
            {
                express = "Array.from($('#main-container')).map(a => a.innerText + ' (' + a.href + ')');";
            }
            else if (url.IndexOf("bbs/") > 0)
            {
                express = "Array.from($('.title a')).map(a => a.innerText + ' (' + a.href + ')').concat(Array.from($('.action-bar a')).map(a => a.innerText + '(' + a.href + ')'));;";
            }
           

            await ParseUrl(url, express);
        }

        private async void btn_ptt_gospi_Click(object sender, EventArgs e)
        {
            var turl = "https://www.ptt.cc/bbs/Gossiping/index.html";
            var express = "Array.from($('.title a')).map(a => a.innerText + ' (' + a.href + ')').concat(Array.from($('.action-bar a')).map(a => a.innerText + '(' + a.href + ')'));;";
            await ParseUrl(turl, express);
        }

        private async void btn_ptt_hot_Click(object sender, EventArgs e)
        {
            var turl = "https://www.ptt.cc/bbs/hotboards.html";
            var express = "Array.from(document.querySelectorAll('.board')).map(a => a.innerText.substr(0, a.innerText.indexOf(' ')) + ' (' + a.href + ')').concat(Array.from($('.action-bar a')).map(a => a.innerText + '(' + a.href + ')'));;";
            await ParseUrl(turl, express);
        }

        private async void btn_ptt_nba_Click(object sender, EventArgs e)
        {
            var turl = "https://www.ptt.cc/bbs/NBA/index.html";
            var express = "Array.from($('.title a')).map(a => a.innerText + ' (' + a.href + ')').concat(Array.from($('.action-bar a')).map(a => a.innerText + '(' + a.href + ')'));;";
            await ParseUrl(turl, express);
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //TabPage current = (sender as TabControl).SelectedTab;

            // Validate the current page. To cancel the select, use:
            //if (current.Name == "tabPage4")
            //{
            //    MessageBox.Show("沒付錢還想用豪華版!");
            //}
        }

     
        private async void btn_saveDb(object sender, EventArgs e)
        {
            // baha 存DB
            var turl = txt_6.Text;
            var express = $"Array.from(document.querySelectorAll('{txt_express.Text}')).map(a => a.innerText + '$$$' + a.href );";
            var list = await ParseUrlSaveDB(turl, express);

            using (var db = new CrawlerEntities1())
            {
                var oldData = db.Baha.AsNoTracking().ToList();

                foreach (var item in list)
                {
                    var row = new Baha();
                    row.Title = item.Split(new string[] { "$$$" }, System.StringSplitOptions.RemoveEmptyEntries)[0];
                    if (oldData.Any(c => c.Title == row.Title))
                    {
                        
                    }
                    else
                    {
                        row.Url = item.Split(new string[] { "$$$" }, System.StringSplitOptions.RemoveEmptyEntries)[1];
                        row.CreateTime = DateTime.Now;
                        db.Baha.Add(row);
                    }
                    //$$$
                }
                db.SaveChanges();
            }

        }

        private async void btn_saveDetail_Click(object sender, EventArgs e)
        {
            using (var db = new CrawlerEntities1())
            {
                var oldData = db.Baha.Where(c => c.Url != null && c.Detail == null).ToList();

                foreach (var item in oldData)
                {
                    var turl = item.Url;
                    var express = $"Array.from(document.querySelectorAll('{txt_express2.Text}')).map(a => a.innerText);";
                    try
                    {
                        var data = await ParseUrlSaveDB(turl, express);
                        item.Detail = data[0];
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        private async Task<List<string>> ParseUrlSaveDB(string turl, string express)
        {
            richtxt.Text = "";
            var launchOptions = new LaunchOptions()
            {
                Headless = true,
                Timeout = 1000000
            };
            var ops = new NavigationOptions()
            {
                Timeout = 120000,
            };

            using (var browser = await Puppeteer.LaunchAsync(launchOptions))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(turl, ops);
                await page.SetCookieAsync(new CookieParam
                {
                    Name = "over18",
                    Value = "1",
                });
                await page.GoToAsync(turl, ops);
                var artist = await page.EvaluateExpressionAsync<string[]>(express);
                var list = new List<string>();
                foreach (string url in artist)
                {
                    list.Add(url.Replace("\n", "\r\n"));
                }

                return list;

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //儲存 每一層+comment
            // baha 存DB
            var turl = "https://forum.gamer.com.tw/C.php?page={0}&bsn=23805&snA=610529&tnum=1520";
            var express = "Array.from(document.querySelectorAll('.FM-P2')).map(a => a.innerText + '$$$' + a.id);";

            for (int i = 1; i < 77; i++)
            {
                var list = await ParseUrlSaveDB(string.Format(turl,i), express);

                var num = 1;
                using (var db = new CrawlerEntities1())
                {
                    //var oldData = db.Content.AsNoTracking().ToList();
                    var id = 23805;
                    foreach (var item in list)
                    {
                        var row = new Content();
                        row.ArticleID = id;
                        row.Article = item.Split(new string[] { "$$$" }, System.StringSplitOptions.RemoveEmptyEntries)[0];

                        row.CommentID = item.Split(new string[] { "$$$" }, System.StringSplitOptions.RemoveEmptyEntries)[1];
                        row.CreateTime = DateTime.Now;
                        row.Sort = num++;
                        db.Content.Add(row);
                    }
                    db.SaveChanges();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new CrawlerEntities1())
            {
                var id = 23805;
                var articlList = db.Content.AsNoTracking().ToList();
                foreach (var item in articlList)
                {
                    var turl = $"https://forum.gamer.com.tw/ajax/moreCommend.php?bsn={id}&snB={item.CommentID.Replace("cf","")}&returnHtml=1";
                    // 建立 webclient
                    using (WebClient webClient = new WebClient())
                    {
                        // 指定 WebClient 的編碼
                        webClient.Encoding = Encoding.UTF8;
                        // 指定 WebClient 的 Content-Type header
                        webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        // 從網路 url 上取得資料
                        var body = webClient.DownloadString(turl);
                        var jsonObj = JsonConvert.DeserializeObject<Rootobject>(body);

                        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        var num = 0;
                        foreach (var obj in jsonObj.html)
                        {
                            htmlDoc.LoadHtml(obj);
                            var inputs = from input in htmlDoc.DocumentNode.Descendants("article")
                                         select input;
                            foreach (var input in inputs)
                            {
                                var row = new Comment();
                                row.CommentID = item.CommentID;
                                row.Comment1 = input.InnerText;
                                row.Sort = num++;
                                db.Comment.Add(row);
                            }
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new CrawlerEntities1())
            {
                var articlList = db.Database.SqlQuery<contentViewModel>("select top 1000 * from [Content] order by id ").ToList();
                var commentList = db.Comment.AsNoTracking().ToList();
                foreach (var item in articlList)
                {
                    item.comments = commentList.Where(c => c.CommentID == item.CommentID).OrderBy(c => c.Sort).ToList();
                }
                string json = JsonConvert.SerializeObject(articlList);
                richtxt.Text = json;
            }

        }
    }          
}
