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
            this.generateAudio = new System.Windows.Forms.Button();
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
            this.porLanguage = new System.Windows.Forms.Button();
            this.engLanguage = new System.Windows.Forms.Button();
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
            this.panelTextInteraction.Controls.Add(this.generateAudio);
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
            // generateAudio
            // 
            this.generateAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(103)))), ((int)(((byte)(136)))));
            this.generateAudio.Enabled = false;
            this.generateAudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateAudio.ForeColor = System.Drawing.Color.White;
            this.generateAudio.Location = new System.Drawing.Point(47, 211);
            this.generateAudio.Name = "generateAudio";
            this.generateAudio.Size = new System.Drawing.Size(75, 30);
            this.generateAudio.TabIndex = 9;
            this.generateAudio.Text = "Generate";
            this.generateAudio.UseVisualStyleBackColor = false;
            this.generateAudio.Click += new System.EventHandler(this.generateAudio_Click);
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
            this.compareTexts.Enabled = false;
            this.compareTexts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareTexts.ForeColor = System.Drawing.Color.White;
            this.compareTexts.Location = new System.Drawing.Point(139, 211);
            this.compareTexts.Name = "compareTexts";
            this.compareTexts.Size = new System.Drawing.Size(75, 30);
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
            // actualPresets
            // 
            this.actualPresets.AutoSize = true;
            this.actualPresets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualPresets.ForeColor = System.Drawing.Color.White;
            this.actualPresets.Location = new System.Drawing.Point(498, 436);
            this.actualPresets.Name = "actualPresets";
            this.actualPresets.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.actualPresets.Size = new System.Drawing.Size(56, 17);
            this.actualPresets.TabIndex = 15;
            this.actualPresets.Text = "Presets:";
            this.actualPresets.TextChanged += new System.EventHandler(this.actualPresets_TextChanged);
            // 
            // porLanguage
            // 
            this.porLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.porLanguage.Image = ((System.Drawing.Image)(resources.GetObject("porLanguage.Image")));
            this.porLanguage.Location = new System.Drawing.Point(732, 440);
            this.porLanguage.Name = "porLanguage";
            this.porLanguage.Size = new System.Drawing.Size(40, 40);
            this.porLanguage.TabIndex = 17;
            this.porLanguage.UseVisualStyleBackColor = false;
            this.porLanguage.Click += new System.EventHandler(this.porLanguage_Click);
            // 
            // engLanguage
            // 
            this.engLanguage.BackColor = System.Drawing.Color.White;
            this.engLanguage.Image = global::Project_Audio.Properties.Resources.engLanguage;
            this.engLanguage.Location = new System.Drawing.Point(688, 440);
            this.engLanguage.Name = "engLanguage";
            this.engLanguage.Size = new System.Drawing.Size(40, 40);
            this.engLanguage.TabIndex = 16;
            this.engLanguage.UseVisualStyleBackColor = false;
            this.engLanguage.Click += new System.EventHandler(this.engLanguage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(498, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 353);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // cleanImages
            // 
            this.cleanImages.BackColor = System.Drawing.Color.White;
            this.cleanImages.Image = global::Project_Audio.Properties.Resources.trashImages;
            this.cleanImages.Location = new System.Drawing.Point(722, 12);
            this.cleanImages.Name = "cleanImages";
            this.cleanImages.Size = new System.Drawing.Size(50, 50);
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
            this.listPresets.Location = new System.Drawing.Point(666, 12);
            this.listPresets.Name = "listPresets";
            this.listPresets.Size = new System.Drawing.Size(50, 50);
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
            this.peoplesFaces.Location = new System.Drawing.Point(610, 12);
            this.peoplesFaces.Name = "peoplesFaces";
            this.peoplesFaces.Size = new System.Drawing.Size(50, 50);
            this.peoplesFaces.TabIndex = 11;
            this.peoplesFaces.UseVisualStyleBackColor = false;
            this.peoplesFaces.Click += new System.EventHandler(this.peoplesFaces_Click);
            this.peoplesFaces.MouseEnter += new System.EventHandler(this.peoplesFaces_MouseEnter);
            this.peoplesFaces.MouseLeave += new System.EventHandler(this.peoplesFaces_MouseLeave);
            // 
            // voiceCommands
            // 
            this.voiceCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.voiceCommands.Image = global::Project_Audio.Properties.Resources.voiceCommand;
            this.voiceCommands.Location = new System.Drawing.Point(554, 12);
            this.voiceCommands.Name = "voiceCommands";
            this.voiceCommands.Size = new System.Drawing.Size(50, 50);
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
            this.geometricShapes.Location = new System.Drawing.Point(498, 12);
            this.geometricShapes.Name = "geometricShapes";
            this.geometricShapes.Size = new System.Drawing.Size(50, 50);
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
            this.microphone.Location = new System.Drawing.Point(368, 12);
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
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.porLanguage);
            this.Controls.Add(this.engLanguage);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        public System.Windows.Forms.Button voiceCommands;
        private System.Windows.Forms.Button peoplesFaces;
        private System.Windows.Forms.Button generateAudio;
        private System.Windows.Forms.Button listPresets;
        private System.Windows.Forms.Button cleanImages;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label actualPresets;
        private System.Windows.Forms.Button engLanguage;
        private System.Windows.Forms.Button porLanguage;
    }
}

