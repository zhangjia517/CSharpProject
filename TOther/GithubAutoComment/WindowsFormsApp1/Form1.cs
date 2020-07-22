using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        public HtmlDocument dom;
        public HtmlElement btn;
        public HtmlElement textarea;
        private string address;

        public Form1()
        {
            InitializeComponent();

            webBrowser1.ScriptErrorsSuppressed = true;

            address = "http://localhost:44321/Home/Index";
            address = "https://github.com/getlantern/forum/issues/8894#issuecomment-374114897";
            address = "https://github.com/naidansoft/asd/issues/1";

            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (UriFormatException)
            {
                return;
            }
        }

        private void ThreadStartExe(object sender, ElapsedEventArgs e)
        {
            try
            {
                webBrowser1.Invoke(new ThreadStart(delegate
                {
                    Application.DoEvents();
                    dom = webBrowser1.Document;
                    if (dom == null)
                    {
                        return;
                    }

                    textarea = dom.GetElementById("new_comment_field");
                    textarea.SetAttribute("value", "Fuck 0mixxim0");

                    foreach (HtmlElement he in dom.GetElementsByTagName("button"))
                    {
                        if (he.GetAttribute("value") != "Comment") continue;
                        he.InvokeMember("click");
                        return;
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Timers.Timer tt = new System.Timers.Timer(10000 * 1);
            tt.Elapsed += new ElapsedEventHandler(ThreadStartExe);
            tt.AutoReset = true;
            tt.Enabled = true;
            tt.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dom = webBrowser1.Document;
            if (dom == null)
            {
                return;
            }

            foreach (HtmlElement he in dom.GetElementsByTagName("button"))
            {
                if (he.GetAttribute("value") != "Comment") continue;
                Console.WriteLine(he.GetAttribute("value"));
                return;
            }
        }
    }
}