namespace PForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_express = new System.Windows.Forms.TextBox();
            this.txt_express2 = new System.Windows.Forms.TextBox();
            this.txt_url2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_express3 = new System.Windows.Forms.TextBox();
            this.txt_url3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(714, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_ClickAsync);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(0, 208);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(458, 54);
            this.textBox2.TabIndex = 12;
            // 
            // txt_url
            // 
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.Location = new System.Drawing.Point(124, 12);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(322, 25);
            this.txt_url.TabIndex = 13;
            this.txt_url.Text = "https://forum.gamer.com.tw/B.php?bsn=23805&subbsn=0";
            // 
            // txt_express
            // 
            this.txt_express.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_express.Location = new System.Drawing.Point(124, 43);
            this.txt_express.Name = "txt_express";
            this.txt_express.Size = new System.Drawing.Size(322, 25);
            this.txt_express.TabIndex = 14;
            this.txt_express.Text = ".b-list__tile";
            // 
            // txt_express2
            // 
            this.txt_express2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_express2.Location = new System.Drawing.Point(124, 105);
            this.txt_express2.Name = "txt_express2";
            this.txt_express2.Size = new System.Drawing.Size(322, 25);
            this.txt_express2.TabIndex = 17;
            this.txt_express2.Text = ".c-article__content";
            // 
            // txt_url2
            // 
            this.txt_url2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url2.Location = new System.Drawing.Point(124, 74);
            this.txt_url2.Name = "txt_url2";
            this.txt_url2.Size = new System.Drawing.Size(322, 25);
            this.txt_url2.TabIndex = 16;
            this.txt_url2.Text = "https://forum.gamer.com.tw/C.php?bsn=23805&snA=619486&tnum=19";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 56);
            this.button3.TabIndex = 15;
            this.button3.Text = "search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_express3
            // 
            this.txt_express3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_express3.Location = new System.Drawing.Point(124, 167);
            this.txt_express3.Name = "txt_express3";
            this.txt_express3.Size = new System.Drawing.Size(322, 25);
            this.txt_express3.TabIndex = 20;
            this.txt_express3.Text = ".reply-content__article";
            // 
            // txt_url3
            // 
            this.txt_url3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url3.Location = new System.Drawing.Point(124, 136);
            this.txt_url3.Name = "txt_url3";
            this.txt_url3.Size = new System.Drawing.Size(322, 25);
            this.txt_url3.TabIndex = 19;
            this.txt_url3.Text = "23805, 3650095";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 56);
            this.button4.TabIndex = 18;
            this.button4.Text = "search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 262);
            this.Controls.Add(this.txt_express3);
            this.Controls.Add(this.txt_url3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_express2);
            this.Controls.Add(this.txt_url2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_express);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "爬蟲測試";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_express;
        private System.Windows.Forms.TextBox txt_express2;
        private System.Windows.Forms.TextBox txt_url2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_express3;
        private System.Windows.Forms.TextBox txt_url3;
        private System.Windows.Forms.Button button4;
    }
}

