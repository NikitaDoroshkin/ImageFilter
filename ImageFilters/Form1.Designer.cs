﻿namespace ImageFilters
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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.transformButton = new System.Windows.Forms.Button();
            this.methodMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addConstantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplyByConstantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toNegativeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerTransformMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logarithmicTransformMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearContrastMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalHistogramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalGradientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramsTextBox = new System.Windows.Forms.TextBox();
            this.openSourceDialog = new System.Windows.Forms.OpenFileDialog();
            this.adoptiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.methodMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourcePictureBox.Location = new System.Drawing.Point(8, 50);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(387, 362);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultPictureBox.Location = new System.Drawing.Point(473, 50);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(387, 362);
            this.resultPictureBox.TabIndex = 1;
            this.resultPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source image";
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(87, 27);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(64, 20);
            this.chooseButton.TabIndex = 3;
            this.chooseButton.Text = "Choose...";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transformed image";
            // 
            // transformButton
            // 
            this.transformButton.Location = new System.Drawing.Point(401, 218);
            this.transformButton.Name = "transformButton";
            this.transformButton.Size = new System.Drawing.Size(66, 23);
            this.transformButton.TabIndex = 5;
            this.transformButton.Text = "Transform";
            this.transformButton.UseVisualStyleBackColor = true;
            this.transformButton.Click += new System.EventHandler(this.transformButton_Click);
            // 
            // methodMenuStrip
            // 
            this.methodMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConstantMenuItem,
            this.multiplyByConstantMenuItem,
            this.toNegativeMenuItem,
            this.powerTransformMenuItem,
            this.logarithmicTransformMenuItem,
            this.linearContrastMenuItem,
            this.globalHistogramMenuItem,
            this.globalGradientMenuItem,
            this.adoptiveMenuItem});
            this.methodMenuStrip.Name = "methodMenuStrip";
            this.methodMenuStrip.Size = new System.Drawing.Size(221, 224);
            // 
            // addConstantMenuItem
            // 
            this.addConstantMenuItem.Name = "addConstantMenuItem";
            this.addConstantMenuItem.Size = new System.Drawing.Size(220, 22);
            this.addConstantMenuItem.Text = "Add constant";
            this.addConstantMenuItem.Click += new System.EventHandler(this.addConstantMenuItem_Click);
            // 
            // multiplyByConstantMenuItem
            // 
            this.multiplyByConstantMenuItem.Name = "multiplyByConstantMenuItem";
            this.multiplyByConstantMenuItem.Size = new System.Drawing.Size(220, 22);
            this.multiplyByConstantMenuItem.Text = "Multiply by constant";
            this.multiplyByConstantMenuItem.Click += new System.EventHandler(this.multiplyByConstantMenuItem_Click);
            // 
            // toNegativeMenuItem
            // 
            this.toNegativeMenuItem.Name = "toNegativeMenuItem";
            this.toNegativeMenuItem.Size = new System.Drawing.Size(220, 22);
            this.toNegativeMenuItem.Text = "To negative";
            this.toNegativeMenuItem.Click += new System.EventHandler(this.toNegativeMenuItem_Click);
            // 
            // powerTransformMenuItem
            // 
            this.powerTransformMenuItem.Name = "powerTransformMenuItem";
            this.powerTransformMenuItem.Size = new System.Drawing.Size(220, 22);
            this.powerTransformMenuItem.Text = "Power transform";
            this.powerTransformMenuItem.Click += new System.EventHandler(this.powerTransformMenuItem_Click);
            // 
            // logarithmicTransformMenuItem
            // 
            this.logarithmicTransformMenuItem.Name = "logarithmicTransformMenuItem";
            this.logarithmicTransformMenuItem.Size = new System.Drawing.Size(220, 22);
            this.logarithmicTransformMenuItem.Text = "Logarithmic transform";
            this.logarithmicTransformMenuItem.Click += new System.EventHandler(this.logarithmicTransformMenuItem_Click);
            // 
            // linearContrastMenuItem
            // 
            this.linearContrastMenuItem.Name = "linearContrastMenuItem";
            this.linearContrastMenuItem.Size = new System.Drawing.Size(220, 22);
            this.linearContrastMenuItem.Text = "Linear contrast";
            this.linearContrastMenuItem.Click += new System.EventHandler(this.linearContrastMenuItem_Click);
            // 
            // globalHistogramMenuItem
            // 
            this.globalHistogramMenuItem.Name = "globalHistogramMenuItem";
            this.globalHistogramMenuItem.Size = new System.Drawing.Size(220, 22);
            this.globalHistogramMenuItem.Text = "Global transform histogram";
            this.globalHistogramMenuItem.Click += new System.EventHandler(this.globalHistogramMenuItem_Click);
            // 
            // globalGradientMenuItem
            // 
            this.globalGradientMenuItem.Name = "globalGradientMenuItem";
            this.globalGradientMenuItem.Size = new System.Drawing.Size(220, 22);
            this.globalGradientMenuItem.Text = "Global transform gradient";
            this.globalGradientMenuItem.Click += new System.EventHandler(this.globalGradientMenuItem_Click);
            // 
            // paramsTextBox
            // 
            this.paramsTextBox.Location = new System.Drawing.Point(401, 192);
            this.paramsTextBox.Name = "paramsTextBox";
            this.paramsTextBox.Size = new System.Drawing.Size(66, 20);
            this.paramsTextBox.TabIndex = 7;
            this.paramsTextBox.Text = "Params here";
            // 
            // openSourceDialog
            // 
            this.openSourceDialog.FileName = "openSourceDialog";
            // 
            // adoptiveMenuItem
            // 
            this.adoptiveMenuItem.Name = "adoptiveMenuItem";
            this.adoptiveMenuItem.Size = new System.Drawing.Size(220, 22);
            this.adoptiveMenuItem.Text = "Adoptive transform";
            this.adoptiveMenuItem.Click += new System.EventHandler(this.adoptiveMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 421);
            this.Controls.Add(this.paramsTextBox);
            this.Controls.Add(this.transformButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Image Filters";
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.methodMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button transformButton;
        private System.Windows.Forms.ContextMenuStrip methodMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addConstantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplyByConstantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toNegativeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerTransformMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logarithmicTransformMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearContrastMenuItem;
        private System.Windows.Forms.TextBox paramsTextBox;
        private System.Windows.Forms.OpenFileDialog openSourceDialog;
        private System.Windows.Forms.ToolStripMenuItem globalHistogramMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalGradientMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adoptiveMenuItem;
    }
}

