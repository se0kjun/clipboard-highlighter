namespace ClipboardHtmlProj
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyLang = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cpp = new System.Windows.Forms.ToolStripMenuItem();
            this.csharp = new System.Windows.Forms.ToolStripMenuItem();
            this.html4strict = new System.Windows.Forms.ToolStripMenuItem();
            this.javascript = new System.Windows.Forms.ToolStripMenuItem();
            this.java = new System.Windows.Forms.ToolStripMenuItem();
            this.python = new System.Windows.Forms.ToolStripMenuItem();
            this.ruby = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyLang
            // 
            this.notifyLang.ContextMenuStrip = this.contextTray;
            this.notifyLang.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyLang.Icon")));
            this.notifyLang.Text = "notifyIcon1";
            this.notifyLang.Visible = true;
            // 
            // contextTray
            // 
            this.contextTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cpp,
            this.csharp,
            this.html4strict,
            this.javascript,
            this.java,
            this.python,
            this.ruby,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripMenuItem8});
            this.contextTray.Name = "contextTray";
            this.contextTray.Size = new System.Drawing.Size(200, 393);
            // 
            // cpp
            // 
            this.cpp.CheckOnClick = true;
            this.cpp.Name = "cpp";
            this.cpp.Size = new System.Drawing.Size(199, 40);
            this.cpp.Text = "C++";
            // 
            // csharp
            // 
            this.csharp.Name = "csharp";
            this.csharp.Size = new System.Drawing.Size(199, 40);
            this.csharp.Text = "C#";
            // 
            // html4strict
            // 
            this.html4strict.Name = "html4strict";
            this.html4strict.Size = new System.Drawing.Size(199, 40);
            this.html4strict.Text = "HTML";
            // 
            // javascript
            // 
            this.javascript.Name = "javascript";
            this.javascript.Size = new System.Drawing.Size(199, 40);
            this.javascript.Text = "Javascript";
            // 
            // java
            // 
            this.java.Name = "java";
            this.java.Size = new System.Drawing.Size(199, 40);
            this.java.Text = "Java";
            // 
            // python
            // 
            this.python.Name = "python";
            this.python.Size = new System.Drawing.Size(199, 40);
            this.python.Text = "Python";
            // 
            // ruby
            // 
            this.ruby.Name = "ruby";
            this.ruby.Size = new System.Drawing.Size(199, 40);
            this.ruby.Text = "Ruby";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 39);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(199, 40);
            this.toolStripMenuItem8.Text = "종료";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 668);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextTray.ResumeLayout(false);
            this.contextTray.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyLang;
        private System.Windows.Forms.ContextMenuStrip contextTray;
        private System.Windows.Forms.ToolStripMenuItem cpp;
        private System.Windows.Forms.ToolStripMenuItem csharp;
        private System.Windows.Forms.ToolStripMenuItem html4strict;
        private System.Windows.Forms.ToolStripMenuItem javascript;
        private System.Windows.Forms.ToolStripMenuItem java;
        private System.Windows.Forms.ToolStripMenuItem python;
        private System.Windows.Forms.ToolStripMenuItem ruby;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;

    }
}

