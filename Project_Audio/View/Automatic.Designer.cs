namespace Project_Audio.View
{
    partial class Automatic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Automatic));
            this.saveList = new System.Windows.Forms.Button();
            this.listCommands = new System.Windows.Forms.TextBox();
            this.commandVoice = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listName = new System.Windows.Forms.TextBox();
            this.existingCommands = new System.Windows.Forms.ComboBox();
            this.deleteList = new System.Windows.Forms.Button();
            this.cleanContent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveList
            // 
            this.saveList.BackColor = System.Drawing.Color.White;
            this.saveList.Image = global::Project_Audio.Properties.Resources.saveLarge;
            this.saveList.Location = new System.Drawing.Point(240, 111);
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(50, 50);
            this.saveList.TabIndex = 1;
            this.saveList.UseVisualStyleBackColor = false;
            this.saveList.Click += new System.EventHandler(this.saveList_Click);
            this.saveList.MouseEnter += new System.EventHandler(this.saveList_MouseEnter);
            this.saveList.MouseLeave += new System.EventHandler(this.saveList_MouseLeave);
            // 
            // listCommands
            // 
            this.listCommands.BackColor = System.Drawing.Color.White;
            this.listCommands.Enabled = false;
            this.listCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listCommands.Location = new System.Drawing.Point(12, 55);
            this.listCommands.Multiline = true;
            this.listCommands.Name = "listCommands";
            this.listCommands.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.listCommands.Size = new System.Drawing.Size(210, 218);
            this.listCommands.TabIndex = 2;
            // 
            // commandVoice
            // 
            this.commandVoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.commandVoice.Image = global::Project_Audio.Properties.Resources.voiceCommand;
            this.commandVoice.Location = new System.Drawing.Point(240, 55);
            this.commandVoice.Name = "commandVoice";
            this.commandVoice.Size = new System.Drawing.Size(50, 50);
            this.commandVoice.TabIndex = 0;
            this.commandVoice.UseVisualStyleBackColor = false;
            this.commandVoice.Click += new System.EventHandler(this.commandVoice_Click);
            this.commandVoice.MouseEnter += new System.EventHandler(this.commandVoice_MouseEnter);
            this.commandVoice.MouseLeave += new System.EventHandler(this.commandVoice_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.description);
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 25);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 10;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(12, 6);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 15);
            this.description.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "AUTOMATIC COMMANDS";
            // 
            // listName
            // 
            this.listName.BackColor = System.Drawing.Color.White;
            this.listName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listName.Location = new System.Drawing.Point(12, 29);
            this.listName.Name = "listName";
            this.listName.Size = new System.Drawing.Size(210, 22);
            this.listName.TabIndex = 12;
            // 
            // existingCommands
            // 
            this.existingCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.existingCommands.FormattingEnabled = true;
            this.existingCommands.Location = new System.Drawing.Point(12, 283);
            this.existingCommands.Name = "existingCommands";
            this.existingCommands.Size = new System.Drawing.Size(210, 21);
            this.existingCommands.TabIndex = 13;
            this.existingCommands.SelectedIndexChanged += new System.EventHandler(this.existingCommands_SelectedIndexChanged);
            // 
            // deleteList
            // 
            this.deleteList.BackColor = System.Drawing.Color.White;
            this.deleteList.Image = global::Project_Audio.Properties.Resources.removeCommand;
            this.deleteList.Location = new System.Drawing.Point(240, 167);
            this.deleteList.Name = "deleteList";
            this.deleteList.Size = new System.Drawing.Size(50, 50);
            this.deleteList.TabIndex = 14;
            this.deleteList.UseVisualStyleBackColor = false;
            this.deleteList.Click += new System.EventHandler(this.deleteList_Click);
            this.deleteList.MouseEnter += new System.EventHandler(this.deleteList_MouseEnter);
            this.deleteList.MouseLeave += new System.EventHandler(this.deleteList_MouseLeave);
            // 
            // cleanContent
            // 
            this.cleanContent.BackColor = System.Drawing.Color.White;
            this.cleanContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cleanContent.Image = global::Project_Audio.Properties.Resources.cleanContent;
            this.cleanContent.Location = new System.Drawing.Point(240, 223);
            this.cleanContent.Name = "cleanContent";
            this.cleanContent.Size = new System.Drawing.Size(50, 50);
            this.cleanContent.TabIndex = 15;
            this.cleanContent.UseVisualStyleBackColor = false;
            this.cleanContent.Click += new System.EventHandler(this.cleanContent_Click);
            this.cleanContent.MouseEnter += new System.EventHandler(this.cleanContent_MouseEnter);
            this.cleanContent.MouseLeave += new System.EventHandler(this.cleanContent_MouseLeave);
            // 
            // Automatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(312, 335);
            this.Controls.Add(this.cleanContent);
            this.Controls.Add(this.deleteList);
            this.Controls.Add(this.existingCommands);
            this.Controls.Add(this.listName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listCommands);
            this.Controls.Add(this.saveList);
            this.Controls.Add(this.commandVoice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Automatic";
            this.Text = "Automatic";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commandVoice;
        private System.Windows.Forms.Button saveList;
        public System.Windows.Forms.TextBox listCommands;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox listName;
        public  System.Windows.Forms.ComboBox existingCommands;
        private System.Windows.Forms.Button deleteList;
        private System.Windows.Forms.Button cleanContent;
    }
}