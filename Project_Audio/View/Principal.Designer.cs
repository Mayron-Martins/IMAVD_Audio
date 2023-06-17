namespace Project_Audio
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panelTextInteraction = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.differenceTexts = new System.Windows.Forms.TextBox();
            this.compareTexts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.generatedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.insertedText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.Label();
            this.microphone = new System.Windows.Forms.Button();
            this.speechToText = new System.Windows.Forms.Button();
            this.textToSpeech = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.pathAudioFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTextInteraction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTextInteraction
            // 
            this.panelTextInteraction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panelTextInteraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextInteraction.Controls.Add(this.label3);
            this.panelTextInteraction.Controls.Add(this.differenceTexts);
            this.panelTextInteraction.Controls.Add(this.compareTexts);
            this.panelTextInteraction.Controls.Add(this.label2);
            this.panelTextInteraction.Controls.Add(this.generatedText);
            this.panelTextInteraction.Controls.Add(this.label1);
            this.panelTextInteraction.Controls.Add(this.insertedText);
            this.panelTextInteraction.Enabled = false;
            this.panelTextInteraction.Location = new System.Drawing.Point(12, 80);
            this.panelTextInteraction.Name = "panelTextInteraction";
            this.panelTextInteraction.Size = new System.Drawing.Size(262, 353);
            this.panelTextInteraction.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Difference Between Texts";
            // 
            // differenceTexts
            // 
            this.differenceTexts.Enabled = false;
            this.differenceTexts.Location = new System.Drawing.Point(7, 271);
            this.differenceTexts.Multiline = true;
            this.differenceTexts.Name = "differenceTexts";
            this.differenceTexts.Size = new System.Drawing.Size(245, 66);
            this.differenceTexts.TabIndex = 8;
            // 
            // compareTexts
            // 
            this.compareTexts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(109)))), ((int)(((byte)(36)))));
            this.compareTexts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareTexts.ForeColor = System.Drawing.Color.White;
            this.compareTexts.Location = new System.Drawing.Point(94, 211);
            this.compareTexts.Name = "compareTexts";
            this.compareTexts.Size = new System.Drawing.Size(75, 30);
            this.compareTexts.TabIndex = 4;
            this.compareTexts.Text = "Compare";
            this.compareTexts.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Generated Text";
            // 
            // generatedText
            // 
            this.generatedText.Enabled = false;
            this.generatedText.Location = new System.Drawing.Point(7, 130);
            this.generatedText.Multiline = true;
            this.generatedText.Name = "generatedText";
            this.generatedText.Size = new System.Drawing.Size(245, 66);
            this.generatedText.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text for Interaction";
            // 
            // insertedText
            // 
            this.insertedText.Location = new System.Drawing.Point(7, 32);
            this.insertedText.Multiline = true;
            this.insertedText.Name = "insertedText";
            this.insertedText.Size = new System.Drawing.Size(245, 66);
            this.insertedText.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.description);
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 25);
            this.panel1.TabIndex = 4;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(12, 7);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 15);
            this.description.TabIndex = 0;
            // 
            // microphone
            // 
            this.microphone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.microphone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.microphone.Image = global::Project_Audio.Properties.Resources.audioOff;
            this.microphone.Location = new System.Drawing.Point(362, 12);
            this.microphone.Name = "microphone";
            this.microphone.Size = new System.Drawing.Size(50, 50);
            this.microphone.TabIndex = 5;
            this.microphone.UseVisualStyleBackColor = false;
            this.microphone.Click += new System.EventHandler(this.microphone_Click);
            this.microphone.MouseEnter += new System.EventHandler(this.microphone_MouseEnter);
            this.microphone.MouseLeave += new System.EventHandler(this.microphone_MouseLeave);
            // 
            // speechToText
            // 
            this.speechToText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.speechToText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.speechToText.Image = global::Project_Audio.Properties.Resources.speechToText;
            this.speechToText.Location = new System.Drawing.Point(174, 12);
            this.speechToText.Name = "speechToText";
            this.speechToText.Size = new System.Drawing.Size(100, 50);
            this.speechToText.TabIndex = 2;
            this.speechToText.UseVisualStyleBackColor = false;
            this.speechToText.Click += new System.EventHandler(this.speechToText_Click);
            this.speechToText.MouseEnter += new System.EventHandler(this.speechToText_MouseEnter);
            this.speechToText.MouseLeave += new System.EventHandler(this.speechToText_MouseLeave);
            // 
            // textToSpeech
            // 
            this.textToSpeech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.textToSpeech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.textToSpeech.Image = ((System.Drawing.Image)(resources.GetObject("textToSpeech.Image")));
            this.textToSpeech.Location = new System.Drawing.Point(68, 12);
            this.textToSpeech.Name = "textToSpeech";
            this.textToSpeech.Size = new System.Drawing.Size(100, 50);
            this.textToSpeech.TabIndex = 1;
            this.textToSpeech.UseVisualStyleBackColor = false;
            this.textToSpeech.Click += new System.EventHandler(this.textToSpeech_Click);
            this.textToSpeech.MouseEnter += new System.EventHandler(this.textToSpeech_MouseEnter);
            this.textToSpeech.MouseLeave += new System.EventHandler(this.textToSpeech_MouseLeave);
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.White;
            this.openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.Location = new System.Drawing.Point(12, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(50, 50);
            this.openFile.TabIndex = 0;
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            this.openFile.MouseEnter += new System.EventHandler(this.openFile_MouseEnter);
            this.openFile.MouseLeave += new System.EventHandler(this.openFile_MouseLeave);
            // 
            // pathAudioFile
            // 
            this.pathAudioFile.Enabled = false;
            this.pathAudioFile.Location = new System.Drawing.Point(12, 460);
            this.pathAudioFile.Name = "pathAudioFile";
            this.pathAudioFile.Size = new System.Drawing.Size(262, 20);
            this.pathAudioFile.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Path to Audio File";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pathAudioFile);
            this.Controls.Add(this.microphone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTextInteraction);
            this.Controls.Add(this.speechToText);
            this.Controls.Add(this.textToSpeech);
            this.Controls.Add(this.openFile);
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Form1";
            this.panelTextInteraction.ResumeLayout(false);
            this.panelTextInteraction.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button textToSpeech;
        private System.Windows.Forms.Button speechToText;
        private System.Windows.Forms.Panel panelTextInteraction;
        private System.Windows.Forms.TextBox insertedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox generatedText;
        private System.Windows.Forms.Button compareTexts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox differenceTexts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button microphone;
        private System.Windows.Forms.TextBox pathAudioFile;
        private System.Windows.Forms.Label label4;
    }
}

