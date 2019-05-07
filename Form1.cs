using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
                //await page.GoToAsync("https://github.com/kblok/puppeteer-sharp");
                //var element = await page.QuerySelectorAsync("h1");
                //var innerHtml = await element.GetPropertyAsync("innerHTML").Result.JsonValueAsync<string>();
                //textBox2.Text = innerHtml;

                //var jsSelectAllAnchors = @"Array.from(document.querySelectorAll('a')).map(a => a.href);";
                //var jsSelectAllAnchors = @"Array.from(document.querySelectorAll('.markdown-body'));";
                //var urls = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);
                //foreach (string url in urls)
                //{
                //    textBox2.Text += $"Url: {url} {Environment.NewLine}";
                //}

                await page.GoToAsync(turl, ops);
                var artist = await page.EvaluateExpressionAsync<string[]>(express);
                var num = 1;
                foreach (string url in artist)
                {
                    //var content = $"{num++} :  {url.Replace("\n", "\r\n")}{Environment.NewLine}";
                    var content = $"{num++} :  {url.Replace("\n", "\r\n")}";
                    textBox2.Text += content;
                    Debug.Print(content);
                }

            }  
        }      
    }          

}
