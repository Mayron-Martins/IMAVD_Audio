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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.differenceTexts = new System.Windows.Forms.TextBox();
            this.compareTexts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.generatedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.insertedText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.Label();
            this.pathAudioFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.actualPresets = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cleanImages = new System.Windows.Forms.Button();
            this.listPresets = new System.Windows.Forms.Button();
            this.peoplesFaces = new System.Windows.Forms.Button();
            this.voiceCommands = new System.Windows.Forms.Button();
            this.geometricShapes = new System.Windows.Forms.Button();
            this.microphone = new System.Windows.Forms.Button();
            this.speechToText = new System.Windows.Forms.Button();
            this.textToSpeech = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.panelTextInteraction.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTextInteraction
            // 
            this.panelTextInteraction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panelTextInteraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextInteraction.Controls.Add(this.button1);
            this.panelTextInteraction.Controls.Add(this.label3);
            this.panelTextInteraction.Controls.Add(this.differenceTexts);
            this.panelTextInteraction.Controls.Add(this.compareTexts);
            this.panelTextInteraction.Controls.Add(this.label2);
            this.panelTextInteraction.Controls.Add(this.generatedText);
            this.panelTextInteraction.Controls.Add(this.label1);
            this.panelTextInteraction.Controls.Add(this.insertedText);
            this.panelTextInteraction.Enabled = false;
            this.panelTextInteraction.Location = new System.Drawing.Point(16, 98);
            this.panelTextInteraction.Margin = new System.Windows.Forms.Padding(4);
            this.panelTextInteraction.Name = "panelTextInteraction";
            this.panelTextInteraction.Size = new System.Drawing.Size(349, 434);
            this.panelTextInteraction.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(103)))), ((int)(((byte)(136)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(63, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 309);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Difference Between Texts";
            // 
            // differenceTexts
            // 
            this.differenceTexts.Enabled = false;
            this.differenceTexts.Location = new System.Drawing.Point(9, 334);
            this.differenceTexts.Margin = new System.Windows.Forms.Padding(4);
            this.differenceTexts.Multiline = true;
            this.differenceTexts.Name = "differenceTexts";
            this.differenceTexts.Size = new System.Drawing.Size(325, 80);
            this.differenceTexts.TabIndex = 8;
            // 
            // compareTexts
            // 
            this.compareTexts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(109)))), ((int)(((byte)(36)))));
            this.compareTexts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareTexts.ForeColor = System.Drawing.Color.White;
            this.compareTexts.Location = new System.Drawing.Point(185, 260);
            this.compareTexts.Margin = new System.Windows.Forms.Padding(4);
            this.compareTexts.Name = "compareTexts";
            this.compareTexts.Size = new System.Drawing.Size(100, 37);
            this.compareTexts.TabIndex = 4;
            this.compareTexts.Text = "Compare";
            this.compareTexts.UseVisualStyleBackColor = false;
            this.compareTexts.Click += new System.EventHandler(this.compareTexts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Generated Text";
            // 
            // generatedText
            // 
            this.generatedText.Enabled = false;
            this.generatedText.Location = new System.Drawing.Point(9, 160);
            this.generatedText.Margin = new System.Windows.Forms.Padding(4);
            this.generatedText.Multiline = true;
            this.generatedText.Name = "generatedText";
            this.generatedText.Size = new System.Drawing.Size(325, 80);
            this.generatedText.TabIndex = 6;
            this.generatedText.TextChanged += new System.EventHandler(this.generatedText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text for Interaction";
            // 
            // insertedText
            // 
            this.insertedText.Location = new System.Drawing.Point(9, 39);
            this.insertedText.Margin = new System.Windows.Forms.Padding(4);
            this.insertedText.Multiline = true;
            this.insertedText.Name = "insertedText";
            this.insertedText.Size = new System.Drawing.Size(325, 80);
            this.insertedText.TabIndex = 4;
            this.insertedText.TextChanged += new System.EventHandler(this.insertedText_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.description);
            this.panel1.Location = new System.Drawing.Point(0, 598);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 31);
            this.panel1.TabIndex = 4;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(16, 9);
            this.description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 20);
            this.description.TabIndex = 0;
            // 
            // pathAudioFile
            // 
            this.pathAudioFile.Enabled = false;
            this.pathAudioFile.Location = new System.Drawing.Point(16, 566);
            this.pathAudioFile.Margin = new System.Windows.Forms.Padding(4);
            this.pathAudioFile.Name = "pathAudioFile";
            this.pathAudioFile.Size = new System.Drawing.Size(348, 22);
            this.pathAudioFile.TabIndex = 6;
            this.pathAudioFile.TextChanged += new System.EventHandler(this.pathAudioFile_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 542);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Path to Audio File";
            // 
            // actualPresets
            // 
            this.actualPresets.AutoSize = true;
            this.actualPresets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualPresets.ForeColor = System.Drawing.Color.White;
            this.actualPresets.Location = new System.Drawing.Point(664, 537);
            this.actualPresets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.actualPresets.Name = "actualPresets";
            this.actualPresets.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.actualPresets.Size = new System.Drawing.Size(136, 23);
            this.actualPresets.TabIndex = 15;
            this.actualPresets.Text = "Presets: Default";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(664, 98);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 434);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // cleanImages
            // 
            this.cleanImages.BackColor = System.Drawing.Color.White;
            this.cleanImages.Image = global::Project_Audio.Properties.Resources.trashImages;
            this.cleanImages.Location = new System.Drawing.Point(963, 15);
            this.cleanImages.Margin = new System.Windows.Forms.Padding(4);
            this.cleanImages.Name = "cleanImages";
            this.cleanImages.Size = new System.Drawing.Size(67, 62);
            this.cleanImages.TabIndex = 13;
            this.cleanImages.UseVisualStyleBackColor = false;
            this.cleanImages.Click += new System.EventHandler(this.cleanImages_Click);
            this.cleanImages.MouseEnter += new System.EventHandler(this.trashImages_MouseEnter);
            this.cleanImages.MouseLeave += new System.EventHandler(this.cleanImages_MouseLeave);
            // 
            // listPresets
            // 
            this.listPresets.BackColor = System.Drawing.Color.White;
            this.listPresets.Image = global::Project_Audio.Properties.Resources.listPresets;
            this.listPresets.Location = new System.Drawing.Point(888, 15);
            this.listPresets.Margin = new System.Windows.Forms.Padding(4);
            this.listPresets.Name = "listPresets";
            this.listPresets.Size = new System.Drawing.Size(67, 62);
            this.listPresets.TabIndex = 12;
            this.listPresets.UseVisualStyleBackColor = false;
            this.listPresets.Click += new System.EventHandler(this.listPresets_Click);
            this.listPresets.MouseEnter += new System.EventHandler(this.listPresets_MouseEnter);
            this.listPresets.MouseLeave += new System.EventHandler(this.listPresets_MouseLeave);
            // 
            // peoplesFaces
            // 
            this.peoplesFaces.BackColor = System.Drawing.Color.White;
            this.peoplesFaces.Image = global::Project_Audio.Properties.Resources.faces;
            this.peoplesFaces.Location = new System.Drawing.Point(813, 15);
            this.peoplesFaces.Margin = new System.Windows.Forms.Padding(4);
            this.peoplesFaces.Name = "peoplesFaces";
            this.peoplesFaces.Size = new System.Drawing.Size(67, 62);
            this.peoplesFaces.TabIndex = 11;
            this.peoplesFaces.UseVisualStyleBackColor = false;
            this.peoplesFaces.MouseEnter += new System.EventHandler(this.peoplesFaces_MouseEnter);
            this.peoplesFaces.MouseLeave += new System.EventHandler(this.peoplesFaces_MouseLeave);
            // 
            // voiceCommands
            // 
            this.voiceCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.voiceCommands.Image = global::Project_Audio.Properties.Resources.voiceCommand;
            this.voiceCommands.Location = new System.Drawing.Point(739, 15);
            this.voiceCommands.Margin = new System.Windows.Forms.Padding(4);
            this.voiceCommands.Name = "voiceCommands";
            this.voiceCommands.Size = new System.Drawing.Size(67, 62);
            this.voiceCommands.TabIndex = 10;
            this.voiceCommands.UseVisualStyleBackColor = false;
            this.voiceCommands.Click += new System.EventHandler(this.voiceCommands_Click);
            this.voiceCommands.MouseEnter += new System.EventHandler(this.voiceCommands_MouseEnter);
            this.voiceCommands.MouseLeave += new System.EventHandler(this.voiceCommands_MouseLeave);
            // 
            // geometricShapes
            // 
            this.geometricShapes.BackColor = System.Drawing.Color.White;
            this.geometricShapes.Image = global::Project_Audio.Properties.Resources.geometricShapes;
            this.geometricShapes.Location = new System.Drawing.Point(664, 15);
            this.geometricShapes.Margin = new System.Windows.Forms.Padding(4);
            this.geometricShapes.Name = "geometricShapes";
            this.geometricShapes.Size = new System.Drawing.Size(67, 62);
            this.geometricShapes.TabIndex = 9;
            this.geometricShapes.UseVisualStyleBackColor = false;
            this.geometricShapes.Click += new System.EventHandler(this.geometricShapes_Click);
            this.geometricShapes.MouseEnter += new System.EventHandler(this.geometricShapes_MouseEnter);
            this.geometricShapes.MouseLeave += new System.EventHandler(this.geometricShapes_MouseLeave);
            // 
            // microphone
            // 
            this.microphone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.microphone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.microphone.Image = global::Project_Audio.Properties.Resources.audioOff;
            this.microphone.Location = new System.Drawing.Point(491, 15);
            this.microphone.Margin = new System.Windows.Forms.Padding(4);
            this.microphone.Name = "microphone";
            this.microphone.Size = new System.Drawing.Size(67, 62);
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
            this.speechToText.Location = new System.Drawing.Point(232, 15);
            this.speechToText.Margin = new System.Windows.Forms.Padding(4);
            this.speechToText.Name = "speechToText";
            this.speechToText.Size = new System.Drawing.Size(133, 62);
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
            this.textToSpeech.Location = new System.Drawing.Point(91, 15);
            this.textToSpeech.Margin = new System.Windows.Forms.Padding(4);
            this.textToSpeech.Name = "textToSpeech";
            this.textToSpeech.Size = new System.Drawing.Size(133, 62);
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
            this.openFile.Location = new System.Drawing.Point(16, 15);
            this.openFile.Margin = new System.Windows.Forms.Padding(4);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(67, 62);
            this.openFile.TabIndex = 0;
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            this.openFile.MouseEnter += new System.EventHandler(this.openFile_MouseEnter);
            this.openFile.MouseLeave += new System.EventHandler(this.openFile_MouseLeave);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1045, 629);
            this.Controls.Add(this.actualPresets);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cleanImages);
            this.Controls.Add(this.listPresets);
            this.Controls.Add(this.peoplesFaces);
            this.Controls.Add(this.voiceCommands);
            this.Controls.Add(this.geometricShapes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pathAudioFile);
            this.Controls.Add(this.microphone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTextInteraction);
            this.Controls.Add(this.speechToText);
            this.Controls.Add(this.textToSpeech);
            this.Controls.Add(this.openFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Form1";
            this.panelTextInteraction.ResumeLayout(false);
            this.panelTextInteraction.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button textToSpeech;
        private System.Windows.Forms.Button speechToText;
        private System.Windows.Forms.Panel panelTextInteraction;
        public System.Windows.Forms.TextBox insertedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox generatedText;
        private System.Windows.Forms.Button compareTexts;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox differenceTexts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button microphone;
        private System.Windows.Forms.TextBox pathAudioFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button geometricShapes;
        private System.Windows.Forms.Button voiceCommands;
        private System.Windows.Forms.Button peoplesFaces;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button listPresets;
        private System.Windows.Forms.Button cleanImages;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label actualPresets;
    }
}

