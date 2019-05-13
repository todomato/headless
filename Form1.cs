using Newtonsoft.Json;
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

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var turl = txt_url.Text;
            var express = $"Array.from(document.querySelectorAll('{txt_express.Text}')).map(a => a.innerText);";
            await NewMethod(turl, express);

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var turl = txt_url2.Text;
            var express = $"Array.from(document.querySelectorAll('{txt_express2.Text}')).map(a => a.innerText);";
            await NewMethod(turl, express);

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("測試訊息！！！Form1！！！");
            var strAry = txt_url3.Text.Split(',').Select(c => c.Trim()).ToList();

            var turl = $"https://forum.gamer.com.tw/ajax/moreCommend.php?bsn={strAry[0]}&snB={strAry[1]}&returnHtml=1";

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
                        textBox2.Text += input.InnerText;
                        Debug.Print(input.InnerText);
                    }
                }
            }
        }

        public class Rootobject
        {
            public int next_snC { get; set; }
            public string[] html { get; set; }
        }

        private async Task NewMethod(string turl, string express)
        {
            textBox2.Text = "";
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
                var artist = await page.EvaluateExpressionAsync<string[]>(express);
                var num = 1;
                foreach (string url in artist)
                {
                    var content = $"{num++} :  {url.Replace("\n", "\r\n")}{Environment.NewLine}";
                    //var content = $"{num++} :  {url.Replace("\n", "\r\n")}";
                    textBox2.Text += content;
                    Debug.Print(content);
                }

            }
        }
    }          

}
