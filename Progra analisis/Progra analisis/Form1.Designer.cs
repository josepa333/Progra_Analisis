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
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_selectImage
            // 
            this.BT_selectImage.Location = new System.Drawing.Point(718, 458);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 493);
            this.Controls.Add(this.selected_picture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_selectImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.selected_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_selectImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox selected_picture;
    }
}

