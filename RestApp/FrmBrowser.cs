using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestApp
{
    public partial class FrmBrowser : Form
    {
        public FrmBrowser()
        {
            InitializeComponent();
        }

        public string Url { get; internal set; }

        private void FrmBrowser_Load(object sender, EventArgs e)
        {
            var browser = new ChromiumWebBrowser(Url);
            this.Controls.Add(browser);

            browser.LoadUrl(Url);
        }
    }
}
