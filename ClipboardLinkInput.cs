using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ComponentModel;

namespace ClipboardHtmlProj
{
    [DefaultEvent("ClipboardChanged")]
    class ClipboardLinkInput : Control
    {
        IntPtr nextClipboardViewer;

        public ClipboardLinkInput() 
        {
            this.BackColor = Color.Red;
            this.Visible = false;

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        public event EventHandler<ClipboardChangedEventArgs> ClipboardChanged;

        protected override void Dispose(bool disposing)
        {
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
        }

        [DllImport("user32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        protected static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    OnClipboardChanged();
                    //SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                //case WM_CHANGECBCHAIN:
                //    if (m.WParam == nextClipboardViewer)
                //        nextClipboardViewer = m.LParam;
                //    else
                //        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                //    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void OnClipboardChanged()
        {
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (ClipboardChanged != null)
                {
                    ClipboardChanged(this, new ClipboardChangedEventArgs(iData));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
