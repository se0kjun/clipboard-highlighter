using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClipboardHtmlProj
{
    class ClipboardChangedEventArgs : EventArgs
    {
        public readonly System.Windows.Forms.IDataObject DataObject;

        public ClipboardChangedEventArgs(System.Windows.Forms.IDataObject dataObj)
        {
            this.DataObject = dataObj;
        }
    }
}
