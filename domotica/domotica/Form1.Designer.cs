namespace domotica
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TestConnectionButton = new System.Windows.Forms.Button();
            this.testConnectionListBox = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.getVoice = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.Location = new System.Drawing.Point(13, 13);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Size = new System.Drawing.Size(75, 74);
            this.TestConnectionButton.TabIndex = 0;
            this.TestConnectionButton.Text = "test button";
            this.TestConnectionButton.UseVisualStyleBackColor = true;
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // testConnectionListBox
            // 
            this.testConnectionListBox.FormattingEnabled = true;
            this.testConnectionListBox.Location = new System.Drawing.Point(94, 18);
            this.testConnectionListBox.Name = "testConnectionListBox";
            this.testConnectionListBox.Size = new System.Drawing.Size(306, 69);
            this.testConnectionListBox.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // getVoice
            // 
            this.getVoice.Location = new System.Drawing.Point(13, 94);
            this.getVoice.Name = "getVoice";
            this.getVoice.Size = new System.Drawing.Size(75, 75);
            this.getVoice.TabIndex = 2;
            this.getVoice.Text = "getVoice";
            this.getVoice.UseVisualStyleBackColor = true;
            this.getVoice.Click += new System.EventHandler(this.getVoice_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(95, 94);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(305, 333);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(423, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 264);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.getVoice);
            this.Controls.Add(this.testConnectionListBox);
            this.Controls.Add(this.TestConnectionButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestConnectionButton;
        private System.Windows.Forms.ListBox testConnectionListBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button getVoice;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

