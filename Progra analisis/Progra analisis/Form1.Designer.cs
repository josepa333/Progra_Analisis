﻿namespace Progra_analisis
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
            this.BT_selectImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selected_picture = new System.Windows.Forms.PictureBox();
            this.Q_generations = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Q_population = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pAwNa = new System.Windows.Forms.NumericUpDown();
            this.pNAwNa = new System.Windows.Forms.NumericUpDown();
            this.pAwA = new System.Windows.Forms.NumericUpDown();
            this.pAdaptableImagesPercentage = new System.Windows.Forms.NumericUpDown();
            this.output1 = new System.Windows.Forms.PictureBox();
            this.output2 = new System.Windows.Forms.PictureBox();
            this.output3 = new System.Windows.Forms.PictureBox();
            this.output4 = new System.Windows.Forms.PictureBox();
            this.output5 = new System.Windows.Forms.PictureBox();
            this.output6 = new System.Windows.Forms.PictureBox();
            this.output7 = new System.Windows.Forms.PictureBox();
            this.output8 = new System.Windows.Forms.PictureBox();
            this.output9 = new System.Windows.Forms.PictureBox();
            this.output10 = new System.Windows.Forms.PictureBox();
            this.sectionsPerImage = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.childsPerGenerations = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.adapatblesPercentageToCopy = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.mutationsPerGeneration = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RGBSelected = new System.Windows.Forms.RadioButton();
            this.darknessSelected = new System.Windows.Forms.RadioButton();
            this.manhattan = new System.Windows.Forms.RadioButton();
            this.Surprise = new System.Windows.Forms.RadioButton();
            this.saveResults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_generations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_population)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwNa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNAwNa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAdaptableImagesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsPerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childsPerGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapatblesPercentageToCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationsPerGeneration)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_selectImage
            // 
            this.BT_selectImage.Location = new System.Drawing.Point(821, 560);
            this.BT_selectImage.Name = "BT_selectImage";
            this.BT_selectImage.Size = new System.Drawing.Size(150, 23);
            this.BT_selectImage.TabIndex = 0;
            this.BT_selectImage.Text = "Select image";
            this.BT_selectImage.UseVisualStyleBackColor = true;
            this.BT_selectImage.Click += new System.EventHandler(this.BT_selectImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Genetic Algorithms";
            // 
            // selected_picture
            // 
            this.selected_picture.Location = new System.Drawing.Point(622, 12);
            this.selected_picture.Name = "selected_picture";
            this.selected_picture.Size = new System.Drawing.Size(400, 400);
            this.selected_picture.TabIndex = 3;
            this.selected_picture.TabStop = false;
            this.selected_picture.Click += new System.EventHandler(this.selected_picture_Click);
            // 
            // Q_generations
            // 
            this.Q_generations.Location = new System.Drawing.Point(39, 73);
            this.Q_generations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Q_generations.Name = "Q_generations";
            this.Q_generations.Size = new System.Drawing.Size(68, 20);
            this.Q_generations.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantity of generations";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(977, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Q_population
            // 
            this.Q_population.Location = new System.Drawing.Point(39, 108);
            this.Q_population.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Q_population.Name = "Q_population";
            this.Q_population.Size = new System.Drawing.Size(68, 20);
            this.Q_population.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity of population";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Percetage of crossing A with NA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Percetage of crossing NA with NA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Percetage of crossing A with A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(111, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Percetage of adaptable images";
            // 
            // pAwNa
            // 
            this.pAwNa.Location = new System.Drawing.Point(37, 262);
            this.pAwNa.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pAwNa.Name = "pAwNa";
            this.pAwNa.Size = new System.Drawing.Size(68, 20);
            this.pAwNa.TabIndex = 17;
            // 
            // pNAwNa
            // 
            this.pNAwNa.Location = new System.Drawing.Point(37, 302);
            this.pNAwNa.Name = "pNAwNa";
            this.pNAwNa.Size = new System.Drawing.Size(68, 20);
            this.pNAwNa.TabIndex = 18;
            // 
            // pAwA
            // 
            this.pAwA.Location = new System.Drawing.Point(37, 335);
            this.pAwA.Name = "pAwA";
            this.pAwA.Size = new System.Drawing.Size(68, 20);
            this.pAwA.TabIndex = 19;
            // 
            // pAdaptableImagesPercentage
            // 
            this.pAdaptableImagesPercentage.Location = new System.Drawing.Point(37, 365);
            this.pAdaptableImagesPercentage.Name = "pAdaptableImagesPercentage";
            this.pAdaptableImagesPercentage.Size = new System.Drawing.Size(68, 20);
            this.pAdaptableImagesPercentage.TabIndex = 20;
            // 
            // output1
            // 
            this.output1.Location = new System.Drawing.Point(29, 75);
            this.output1.Name = "output1";
            this.output1.Size = new System.Drawing.Size(200, 120);
            this.output1.TabIndex = 21;
            this.output1.TabStop = false;
            // 
            // output2
            // 
            this.output2.Location = new System.Drawing.Point(270, 73);
            this.output2.Name = "output2";
            this.output2.Size = new System.Drawing.Size(200, 120);
            this.output2.TabIndex = 22;
            this.output2.TabStop = false;
            // 
            // output3
            // 
            this.output3.Location = new System.Drawing.Point(520, 73);
            this.output3.Name = "output3";
            this.output3.Size = new System.Drawing.Size(200, 120);
            this.output3.TabIndex = 23;
            this.output3.TabStop = false;
            // 
            // output4
            // 
            this.output4.Location = new System.Drawing.Point(771, 73);
            this.output4.Name = "output4";
            this.output4.Size = new System.Drawing.Size(200, 120);
            this.output4.TabIndex = 24;
            this.output4.TabStop = false;
            // 
            // output5
            // 
            this.output5.Location = new System.Drawing.Point(29, 215);
            this.output5.Name = "output5";
            this.output5.Size = new System.Drawing.Size(200, 120);
            this.output5.TabIndex = 25;
            this.output5.TabStop = false;
            // 
            // output6
            // 
            this.output6.Location = new System.Drawing.Point(270, 214);
            this.output6.Name = "output6";
            this.output6.Size = new System.Drawing.Size(200, 120);
            this.output6.TabIndex = 26;
            this.output6.TabStop = false;
            // 
            // output7
            // 
            this.output7.Location = new System.Drawing.Point(520, 225);
            this.output7.Name = "output7";
            this.output7.Size = new System.Drawing.Size(200, 120);
            this.output7.TabIndex = 27;
            this.output7.TabStop = false;
            // 
            // output8
            // 
            this.output8.Location = new System.Drawing.Point(771, 225);
            this.output8.Name = "output8";
            this.output8.Size = new System.Drawing.Size(200, 120);
            this.output8.TabIndex = 28;
            this.output8.TabStop = false;
            // 
            // output9
            // 
            this.output9.Location = new System.Drawing.Point(270, 359);
            this.output9.Name = "output9";
            this.output9.Size = new System.Drawing.Size(200, 120);
            this.output9.TabIndex = 29;
            this.output9.TabStop = false;
            // 
            // output10
            // 
            this.output10.Location = new System.Drawing.Point(520, 365);
            this.output10.Name = "output10";
            this.output10.Size = new System.Drawing.Size(200, 120);
            this.output10.TabIndex = 30;
            this.output10.TabStop = false;
            // 
            // sectionsPerImage
            // 
            this.sectionsPerImage.Location = new System.Drawing.Point(37, 417);
            this.sectionsPerImage.Name = "sectionsPerImage";
            this.sectionsPerImage.Size = new System.Drawing.Size(68, 20);
            this.sectionsPerImage.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(111, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Percentaje of adaptables to copy";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // childsPerGenerations
            // 
            this.childsPerGenerations.Location = new System.Drawing.Point(39, 151);
            this.childsPerGenerations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.childsPerGenerations.Name = "childsPerGenerations";
            this.childsPerGenerations.Size = new System.Drawing.Size(68, 20);
            this.childsPerGenerations.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(113, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Childs per generations";
            // 
            // adapatblesPercentageToCopy
            // 
            this.adapatblesPercentageToCopy.Location = new System.Drawing.Point(37, 391);
            this.adapatblesPercentageToCopy.Name = "adapatblesPercentageToCopy";
            this.adapatblesPercentageToCopy.Size = new System.Drawing.Size(68, 20);
            this.adapatblesPercentageToCopy.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(111, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Sections per image";
            // 
            // mutationsPerGeneration
            // 
            this.mutationsPerGeneration.Location = new System.Drawing.Point(39, 189);
            this.mutationsPerGeneration.Name = "mutationsPerGeneration";
            this.mutationsPerGeneration.Size = new System.Drawing.Size(68, 20);
            this.mutationsPerGeneration.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Mutations per generation";
            // 
            // RGBSelected
            // 
            this.RGBSelected.AutoSize = true;
            this.RGBSelected.Location = new System.Drawing.Point(37, 444);
            this.RGBSelected.Name = "RGBSelected";
            this.RGBSelected.Size = new System.Drawing.Size(48, 17);
            this.RGBSelected.TabIndex = 39;
            this.RGBSelected.TabStop = true;
            this.RGBSelected.Text = "RGB";
            this.RGBSelected.UseVisualStyleBackColor = true;
            this.RGBSelected.CheckedChanged += new System.EventHandler(this.RGBSelected_CheckedChanged);
            // 
            // darknessSelected
            // 
            this.darknessSelected.AutoSize = true;
            this.darknessSelected.Location = new System.Drawing.Point(37, 467);
            this.darknessSelected.Name = "darknessSelected";
            this.darknessSelected.Size = new System.Drawing.Size(70, 17);
            this.darknessSelected.TabIndex = 40;
            this.darknessSelected.TabStop = true;
            this.darknessSelected.Text = "Darkness";
            this.darknessSelected.UseVisualStyleBackColor = true;
            this.darknessSelected.CheckedChanged += new System.EventHandler(this.darknessSelected_CheckedChanged);
            // 
            // manhattan
            // 
            this.manhattan.AutoSize = true;
            this.manhattan.Location = new System.Drawing.Point(37, 527);
            this.manhattan.Name = "manhattan";
            this.manhattan.Size = new System.Drawing.Size(76, 17);
            this.manhattan.TabIndex = 41;
            this.manhattan.TabStop = true;
            this.manhattan.Text = "Manhattan";
            this.manhattan.UseVisualStyleBackColor = true;
            this.manhattan.CheckedChanged += new System.EventHandler(this.manhattan_CheckedChanged);
            // 
            // Surprise
            // 
            this.Surprise.AutoSize = true;
            this.Surprise.Location = new System.Drawing.Point(37, 550);
            this.Surprise.Name = "Surprise";
            this.Surprise.Size = new System.Drawing.Size(63, 17);
            this.Surprise.TabIndex = 42;
            this.Surprise.TabStop = true;
            this.Surprise.Text = "Surprise";
            this.Surprise.UseVisualStyleBackColor = true;
            this.Surprise.CheckedChanged += new System.EventHandler(this.Surprise_CheckedChanged);
            // 
            // saveResults
            // 
            this.saveResults.Location = new System.Drawing.Point(671, 560);
            this.saveResults.Name = "saveResults";
            this.saveResults.Size = new System.Drawing.Size(137, 23);
            this.saveResults.TabIndex = 43;
            this.saveResults.Text = "Save results";
            this.saveResults.UseVisualStyleBackColor = true;
            this.saveResults.Click += new System.EventHandler(this.saveResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 595);
            this.Controls.Add(this.saveResults);
            this.Controls.Add(this.Surprise);
            this.Controls.Add(this.manhattan);
            this.Controls.Add(this.darknessSelected);
            this.Controls.Add(this.RGBSelected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mutationsPerGeneration);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.adapatblesPercentageToCopy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.childsPerGenerations);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sectionsPerImage);
            this.Controls.Add(this.output10);
            this.Controls.Add(this.output9);
            this.Controls.Add(this.output8);
            this.Controls.Add(this.output7);
            this.Controls.Add(this.output6);
            this.Controls.Add(this.output5);
            this.Controls.Add(this.output4);
            this.Controls.Add(this.output3);
            this.Controls.Add(this.output2);
            this.Controls.Add(this.output1);
            this.Controls.Add(this.pAdaptableImagesPercentage);
            this.Controls.Add(this.pAwA);
            this.Controls.Add(this.pNAwNa);
            this.Controls.Add(this.pAwNa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Q_population);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Q_generations);
            this.Controls.Add(this.selected_picture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_selectImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_generations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_population)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwNa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNAwNa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAdaptableImagesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsPerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childsPerGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adapatblesPercentageToCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationsPerGeneration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_selectImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox selected_picture;
        private System.Windows.Forms.NumericUpDown Q_generations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Q_population;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown pAwNa;
        private System.Windows.Forms.NumericUpDown pNAwNa;
        private System.Windows.Forms.NumericUpDown pAwA;
        private System.Windows.Forms.NumericUpDown pAdaptableImagesPercentage;
        private System.Windows.Forms.PictureBox output1;
        private System.Windows.Forms.PictureBox output2;
        private System.Windows.Forms.PictureBox output3;
        private System.Windows.Forms.PictureBox output4;
        private System.Windows.Forms.PictureBox output5;
        private System.Windows.Forms.PictureBox output6;
        private System.Windows.Forms.PictureBox output7;
        private System.Windows.Forms.PictureBox output8;
        private System.Windows.Forms.PictureBox output9;
        private System.Windows.Forms.PictureBox output10;
        private System.Windows.Forms.NumericUpDown sectionsPerImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown childsPerGenerations;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown adapatblesPercentageToCopy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown mutationsPerGeneration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RGBSelected;
        private System.Windows.Forms.RadioButton darknessSelected;
        private System.Windows.Forms.RadioButton manhattan;
        private System.Windows.Forms.RadioButton Surprise;
        private System.Windows.Forms.Button saveResults;
    }
}

