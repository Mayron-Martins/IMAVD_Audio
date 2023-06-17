﻿namespace Project_Audio.View
{
    partial class Presets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Presets));
            this.label1 = new System.Windows.Forms.Label();
            this.presetsList = new System.Windows.Forms.ComboBox();
            this.presetDetails = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNewPreset = new System.Windows.Forms.Panel();
            this.presetName = new System.Windows.Forms.TextBox();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.specificAction = new System.Windows.Forms.ComboBox();
            this.mainAction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commandName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveCommand = new System.Windows.Forms.Button();
            this.savePreset = new System.Windows.Forms.Button();
            this.microphone = new System.Windows.Forms.Button();
            this.removeCommand = new System.Windows.Forms.Button();
            this.updateCommand = new System.Windows.Forms.Button();
            this.addComand = new System.Windows.Forms.Button();
            this.addPreset = new System.Windows.Forms.Button();
            this.definePreset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelNewPreset.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRESETS";
            // 
            // presetsList
            // 
            this.presetsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetsList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.presetsList.FormattingEnabled = true;
            this.presetsList.Items.AddRange(new object[] {
            "Default"});
            this.presetsList.Location = new System.Drawing.Point(15, 29);
            this.presetsList.Name = "presetsList";
            this.presetsList.Size = new System.Drawing.Size(200, 25);
            this.presetsList.TabIndex = 1;
            // 
            // presetDetails
            // 
            this.presetDetails.AutoScroll = true;
            this.presetDetails.BackColor = System.Drawing.Color.White;
            this.presetDetails.ColumnCount = 2;
            this.presetDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.presetDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.presetDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.presetDetails.Location = new System.Drawing.Point(15, 65);
            this.presetDetails.Name = "presetDetails";
            this.presetDetails.RowCount = 1;
            this.presetDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.presetDetails.Size = new System.Drawing.Size(200, 238);
            this.presetDetails.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.description);
            this.panel1.Location = new System.Drawing.Point(1, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 25);
            this.panel1.TabIndex = 8;
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
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Preset Name";
            // 
            // panelNewPreset
            // 
            this.panelNewPreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panelNewPreset.Controls.Add(this.presetName);
            this.panelNewPreset.Controls.Add(this.label2);
            this.panelNewPreset.Enabled = false;
            this.panelNewPreset.Location = new System.Drawing.Point(308, 29);
            this.panelNewPreset.Name = "panelNewPreset";
            this.panelNewPreset.Size = new System.Drawing.Size(172, 50);
            this.panelNewPreset.TabIndex = 10;
            this.panelNewPreset.EnabledChanged += new System.EventHandler(this.panelNewPreset_EnabledChanged);
            // 
            // presetName
            // 
            this.presetName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.presetName.Location = new System.Drawing.Point(8, 24);
            this.presetName.Name = "presetName";
            this.presetName.Size = new System.Drawing.Size(156, 23);
            this.presetName.TabIndex = 10;
            // 
            // panelCommands
            // 
            this.panelCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(46)))));
            this.panelCommands.Controls.Add(this.specificAction);
            this.panelCommands.Controls.Add(this.mainAction);
            this.panelCommands.Controls.Add(this.label4);
            this.panelCommands.Controls.Add(this.commandName);
            this.panelCommands.Controls.Add(this.label3);
            this.panelCommands.Enabled = false;
            this.panelCommands.Location = new System.Drawing.Point(308, 85);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(172, 106);
            this.panelCommands.TabIndex = 11;
            this.panelCommands.EnabledChanged += new System.EventHandler(this.panelCommands_EnabledChanged);
            // 
            // specificAction
            // 
            this.specificAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specificAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specificAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.specificAction.FormattingEnabled = true;
            this.specificAction.Location = new System.Drawing.Point(82, 76);
            this.specificAction.Name = "specificAction";
            this.specificAction.Size = new System.Drawing.Size(82, 21);
            this.specificAction.TabIndex = 15;
            // 
            // mainAction
            // 
            this.mainAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.mainAction.FormattingEnabled = true;
            this.mainAction.Items.AddRange(new object[] {
            "Rotate",
            "Move to",
            "Resize",
            "Color"});
            this.mainAction.Location = new System.Drawing.Point(8, 76);
            this.mainAction.Name = "mainAction";
            this.mainAction.Size = new System.Drawing.Size(68, 21);
            this.mainAction.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Action";
            // 
            // commandName
            // 
            this.commandName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.commandName.Location = new System.Drawing.Point(8, 27);
            this.commandName.Name = "commandName";
            this.commandName.Size = new System.Drawing.Size(156, 23);
            this.commandName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Command";
            // 
            // saveCommand
            // 
            this.saveCommand.BackColor = System.Drawing.Color.White;
            this.saveCommand.Enabled = false;
            this.saveCommand.Image = ((System.Drawing.Image)(resources.GetObject("saveCommand.Image")));
            this.saveCommand.Location = new System.Drawing.Point(486, 161);
            this.saveCommand.Name = "saveCommand";
            this.saveCommand.Size = new System.Drawing.Size(30, 30);
            this.saveCommand.TabIndex = 13;
            this.saveCommand.UseVisualStyleBackColor = false;
            this.saveCommand.Visible = false;
            // 
            // savePreset
            // 
            this.savePreset.BackColor = System.Drawing.Color.White;
            this.savePreset.Enabled = false;
            this.savePreset.Image = ((System.Drawing.Image)(resources.GetObject("savePreset.Image")));
            this.savePreset.Location = new System.Drawing.Point(486, 49);
            this.savePreset.Name = "savePreset";
            this.savePreset.Size = new System.Drawing.Size(30, 30);
            this.savePreset.TabIndex = 12;
            this.savePreset.UseVisualStyleBackColor = false;
            this.savePreset.Visible = false;
            // 
            // microphone
            // 
            this.microphone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.microphone.Image = global::Project_Audio.Properties.Resources.audioOff;
            this.microphone.Location = new System.Drawing.Point(243, 253);
            this.microphone.Name = "microphone";
            this.microphone.Size = new System.Drawing.Size(50, 50);
            this.microphone.TabIndex = 7;
            this.microphone.UseVisualStyleBackColor = false;
            this.microphone.Click += new System.EventHandler(this.microphone_Click);
            this.microphone.MouseEnter += new System.EventHandler(this.microphone_MouseEnter);
            this.microphone.MouseLeave += new System.EventHandler(this.microphone_MouseLeave);
            // 
            // removeCommand
            // 
            this.removeCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.removeCommand.Image = global::Project_Audio.Properties.Resources.removeCommand;
            this.removeCommand.Location = new System.Drawing.Point(243, 197);
            this.removeCommand.Name = "removeCommand";
            this.removeCommand.Size = new System.Drawing.Size(50, 50);
            this.removeCommand.TabIndex = 6;
            this.removeCommand.UseVisualStyleBackColor = false;
            this.removeCommand.Click += new System.EventHandler(this.removeCommand_Click);
            this.removeCommand.MouseEnter += new System.EventHandler(this.removeCommand_MouseEnter);
            this.removeCommand.MouseLeave += new System.EventHandler(this.removeCommand_MouseLeave);
            // 
            // updateCommand
            // 
            this.updateCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.updateCommand.Image = global::Project_Audio.Properties.Resources.updateCommand;
            this.updateCommand.Location = new System.Drawing.Point(243, 141);
            this.updateCommand.Name = "updateCommand";
            this.updateCommand.Size = new System.Drawing.Size(50, 50);
            this.updateCommand.TabIndex = 5;
            this.updateCommand.UseVisualStyleBackColor = false;
            this.updateCommand.Click += new System.EventHandler(this.updateCommand_Click);
            this.updateCommand.MouseEnter += new System.EventHandler(this.updateCommand_MouseEnter);
            this.updateCommand.MouseLeave += new System.EventHandler(this.updateCommand_MouseLeave);
            // 
            // addComand
            // 
            this.addComand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.addComand.Image = global::Project_Audio.Properties.Resources.voiceCommand;
            this.addComand.Location = new System.Drawing.Point(243, 85);
            this.addComand.Name = "addComand";
            this.addComand.Size = new System.Drawing.Size(50, 50);
            this.addComand.TabIndex = 4;
            this.addComand.UseVisualStyleBackColor = false;
            this.addComand.Click += new System.EventHandler(this.addComand_Click);
            this.addComand.MouseEnter += new System.EventHandler(this.addComand_MouseEnter);
            this.addComand.MouseLeave += new System.EventHandler(this.addComand_MouseLeave);
            // 
            // addPreset
            // 
            this.addPreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.addPreset.Image = global::Project_Audio.Properties.Resources.addPreset;
            this.addPreset.Location = new System.Drawing.Point(243, 29);
            this.addPreset.Name = "addPreset";
            this.addPreset.Size = new System.Drawing.Size(50, 50);
            this.addPreset.TabIndex = 3;
            this.addPreset.UseVisualStyleBackColor = false;
            this.addPreset.Click += new System.EventHandler(this.addPreset_Click);
            this.addPreset.MouseEnter += new System.EventHandler(this.addPreset_MouseEnter);
            this.addPreset.MouseLeave += new System.EventHandler(this.addPreset_MouseLeave);
            // 
            // definePreset
            // 
            this.definePreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(109)))), ((int)(((byte)(36)))));
            this.definePreset.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.definePreset.ForeColor = System.Drawing.Color.White;
            this.definePreset.Location = new System.Drawing.Point(308, 273);
            this.definePreset.Name = "definePreset";
            this.definePreset.Size = new System.Drawing.Size(171, 30);
            this.definePreset.TabIndex = 14;
            this.definePreset.Text = "Define Default Preset";
            this.definePreset.UseVisualStyleBackColor = false;
            this.definePreset.Click += new System.EventHandler(this.definePreset_Click);
            // 
            // Presets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(529, 335);
            this.Controls.Add(this.definePreset);
            this.Controls.Add(this.saveCommand);
            this.Controls.Add(this.savePreset);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.panelNewPreset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.microphone);
            this.Controls.Add(this.removeCommand);
            this.Controls.Add(this.updateCommand);
            this.Controls.Add(this.addComand);
            this.Controls.Add(this.addPreset);
            this.Controls.Add(this.presetDetails);
            this.Controls.Add(this.presetsList);
            this.Controls.Add(this.label1);
            this.Name = "Presets";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNewPreset.ResumeLayout(false);
            this.panelNewPreset.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.panelCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox presetsList;
        private System.Windows.Forms.TableLayoutPanel presetDetails;
        private System.Windows.Forms.Button addPreset;
        private System.Windows.Forms.Button addComand;
        private System.Windows.Forms.Button updateCommand;
        private System.Windows.Forms.Button removeCommand;
        private System.Windows.Forms.Button microphone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelNewPreset;
        private System.Windows.Forms.TextBox presetName;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.TextBox commandName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox specificAction;
        private System.Windows.Forms.ComboBox mainAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button savePreset;
        private System.Windows.Forms.Button saveCommand;
        private System.Windows.Forms.Button definePreset;
    }
}