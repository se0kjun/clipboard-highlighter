using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClipboardHtmlProj
{
    public partial class Form1 : Form
    {
        private KeyboardHook keyboardhook;
        private ClipboardLinkInput linkInput;

        //private string language;
        //private string font_size;
        //private Boolean line_number_flag;

        //private string[] lang_type = { "C++", "C#", "HTML", "Javascript", "PHP", "Java", "Python", "Ruby" };
        //private string[] lang_name = { "cpp", "csharp", "HTML", "javascript", "php", "java", "python", "ruby" };

        public Form1() 
        {
            linkInput = new ClipboardLinkInput();
            linkInput.ClipboardChanged += new EventHandler<ClipboardChangedEventArgs>(linkInput_ClipboardChanged);

            keyboardhook = new KeyboardHook();
            keyboardhook.KeyPressed += new EventHandler<KeyPressedEventArgs>(keyboardhook_KeyPressed);
            keyboardhook.RegisterHotKey(ClipboardHtmlProj.ModifierKeys.Control | ClipboardHtmlProj.ModifierKeys.Shift, Keys.C);

            InitializeComponent();

            notifyLang = new NotifyIcon();
            contextTray.ItemClicked += new ToolStripItemClickedEventHandler(contextTray_ItemClicked);
            toolStripTextBox1.KeyPress += new KeyPressEventHandler(toolStripTextBox1_KeyPress);
            toolStripMenuItem8.Click += new EventHandler(toolStripMenuItem8_Click);
        }

        void linkInput_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string url_pattern = ClipboardHighlighterProperty.instance.UrlPattern;
                Regex urlRegex = new Regex(url_pattern, RegexOptions.IgnoreCase);
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (urlRegex.IsMatch(text))
                {
                    string res = GoogleApiConnector.GetShortenURL(text);
                    if(res != null)
                        Clipboard.SetData(DataFormats.Text, res);
                }
            }
        }

        void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            notifyLang.Visible = false;
            this.Close();
            Application.Exit();
        }

        void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;
            ClipboardHighlighterProperty.instance.FontSize = textBox.Text;
        }

        void keyboardhook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            SendKeys.SendWait("^c");
            Thread thread = new Thread(() =>
            {
                try
                {
                    string code = (string)Clipboard.GetData(DataFormats.Text);
                    if (code != null && ClipboardHighlighterProperty.instance.Language != null)
                    {
                        SyntaxHighlighter syntax = new SyntaxHighlighter(encode(code), ClipboardHighlighterProperty.instance.Language);
                        string result = ClipboardHtmlHelper.GetHtmlClipboardFormat(syntax.GetHighlightCode());
                        Clipboard.SetData(DataFormats.Html, result);
                        //MessageBox.Show(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.StackTrace);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        void contextTray_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "종료")
                return;
            ClipboardHighlighterProperty.instance.Language = e.ClickedItem.Name;
            
            for (int i = 0; i < contextTray.Items.Count; i++)
            {
                if (contextTray.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)contextTray.Items[i]).Checked = false;
                }
            }
            ((ToolStripMenuItem)e.ClickedItem).Checked = true;
        }

        public string encode(string plain)
        {
            var plainText = System.Text.Encoding.UTF8.GetBytes(plain);
            return System.Convert.ToBase64String(plainText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
