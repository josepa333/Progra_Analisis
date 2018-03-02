namespace Progra_analisis
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.childsPerGeneration = new System.Windows.Forms.NumericUpDown();
            this.mutabilityPercentage = new System.Windows.Forms.NumericUpDown();
            this.pAwNa = new System.Windows.Forms.NumericUpDown();
            this.pNAwNa = new System.Windows.Forms.NumericUpDown();
            this.pAwA = new System.Windows.Forms.NumericUpDown();
            this.pAdaptableImages = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_generations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_population)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childsPerGeneration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutabilityPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwNa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNAwNa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAdaptableImages)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_selectImage
            // 
            this.BT_selectImage.Location = new System.Drawing.Point(637, 458);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Genetic Algorithms";
            // 
            // selected_picture
            // 
            this.selected_picture.Location = new System.Drawing.Point(468, 22);
            this.selected_picture.Name = "selected_picture";
            this.selected_picture.Size = new System.Drawing.Size(400, 400);
            this.selected_picture.TabIndex = 3;
            this.selected_picture.TabStop = false;
            // 
            // Q_generations
            // 
            this.Q_generations.Location = new System.Drawing.Point(39, 73);
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
            this.button1.Location = new System.Drawing.Point(793, 458);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Childs per generation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mutability percentage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Percetage of crossing A with NA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Percetage of crossing NA with NA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Percetage of crossing A with A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Percetage of adaptable images";
            // 
            // childsPerGeneration
            // 
            this.childsPerGeneration.Location = new System.Drawing.Point(39, 151);
            this.childsPerGeneration.Name = "childsPerGeneration";
            this.childsPerGeneration.Size = new System.Drawing.Size(68, 20);
            this.childsPerGeneration.TabIndex = 15;
            // 
            // mutabilityPercentage
            // 
            this.mutabilityPercentage.Location = new System.Drawing.Point(39, 191);
            this.mutabilityPercentage.Name = "mutabilityPercentage";
            this.mutabilityPercentage.Size = new System.Drawing.Size(68, 20);
            this.mutabilityPercentage.TabIndex = 16;
            // 
            // pAwNa
            // 
            this.pAwNa.Location = new System.Drawing.Point(39, 228);
            this.pAwNa.Name = "pAwNa";
            this.pAwNa.Size = new System.Drawing.Size(68, 20);
            this.pAwNa.TabIndex = 17;
            // 
            // pNAwNa
            // 
            this.pNAwNa.Location = new System.Drawing.Point(39, 268);
            this.pNAwNa.Name = "pNAwNa";
            this.pNAwNa.Size = new System.Drawing.Size(68, 20);
            this.pNAwNa.TabIndex = 18;
            // 
            // pAwA
            // 
            this.pAwA.Location = new System.Drawing.Point(39, 301);
            this.pAwA.Name = "pAwA";
            this.pAwA.Size = new System.Drawing.Size(68, 20);
            this.pAwA.TabIndex = 19;
            // 
            // pAdaptableImages
            // 
            this.pAdaptableImages.Location = new System.Drawing.Point(39, 340);
            this.pAdaptableImages.Name = "pAdaptableImages";
            this.pAdaptableImages.Size = new System.Drawing.Size(68, 20);
            this.pAdaptableImages.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 493);
            this.Controls.Add(this.pAdaptableImages);
            this.Controls.Add(this.pAwA);
            this.Controls.Add(this.pNAwNa);
            this.Controls.Add(this.pAwNa);
            this.Controls.Add(this.mutabilityPercentage);
            this.Controls.Add(this.childsPerGeneration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_generations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Q_population)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childsPerGeneration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutabilityPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwNa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pNAwNa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAwA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAdaptableImages)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown childsPerGeneration;
        private System.Windows.Forms.NumericUpDown mutabilityPercentage;
        private System.Windows.Forms.NumericUpDown pAwNa;
        private System.Windows.Forms.NumericUpDown pNAwNa;
        private System.Windows.Forms.NumericUpDown pAwA;
        private System.Windows.Forms.NumericUpDown pAdaptableImages;
    }
}

