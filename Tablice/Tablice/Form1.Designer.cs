namespace Tablice
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.status = new System.Windows.Forms.Label();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.pictureBoxCutPlate = new System.Windows.Forms.PictureBox();
            this.pictureboxEditPicture = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.findPlate = new System.Windows.Forms.Button();
            this.pictureboxCatched = new System.Windows.Forms.PictureBox();
            this.statusVideo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCutPlate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxEditPicture)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxCatched)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 466);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(217, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Get Devices";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(439, 178);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 666);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.status);
            this.tabPage2.Controls.Add(this.LoadFileButton);
            this.tabPage2.Controls.Add(this.pictureBoxCutPlate);
            this.tabPage2.Controls.Add(this.pictureboxEditPicture);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "From file";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.status.ForeColor = System.Drawing.Color.Blue;
            this.status.Location = new System.Drawing.Point(130, 15);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(152, 20);
            this.status.TabIndex = 9;
            this.status.Text = "Load file to continue";
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(9, 12);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFileButton.TabIndex = 8;
            this.LoadFileButton.Text = "Load file";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // pictureBoxCutPlate
            // 
            this.pictureBoxCutPlate.Location = new System.Drawing.Point(23, 365);
            this.pictureBoxCutPlate.Name = "pictureBoxCutPlate";
            this.pictureBoxCutPlate.Size = new System.Drawing.Size(321, 77);
            this.pictureBoxCutPlate.TabIndex = 5;
            this.pictureBoxCutPlate.TabStop = false;
            this.pictureBoxCutPlate.Click += new System.EventHandler(this.pictureBoxCutPlate_Click);
            // 
            // pictureboxEditPicture
            // 
            this.pictureboxEditPicture.Location = new System.Drawing.Point(6, 52);
            this.pictureboxEditPicture.Name = "pictureboxEditPicture";
            this.pictureboxEditPicture.Size = new System.Drawing.Size(536, 307);
            this.pictureboxEditPicture.TabIndex = 0;
            this.pictureboxEditPicture.TabStop = false;
            this.pictureboxEditPicture.Click += new System.EventHandler(this.pictureboxEditPicture_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.findPlate);
            this.tabPage1.Controls.Add(this.pictureboxCatched);
            this.tabPage1.Controls.Add(this.statusVideo);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "From video";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // findPlate
            // 
            this.findPlate.Location = new System.Drawing.Point(451, 233);
            this.findPlate.Name = "findPlate";
            this.findPlate.Size = new System.Drawing.Size(75, 23);
            this.findPlate.TabIndex = 12;
            this.findPlate.Text = "Find plate";
            this.findPlate.UseVisualStyleBackColor = true;
            this.findPlate.Click += new System.EventHandler(this.findPlate_Click);
            // 
            // pictureboxCatched
            // 
            this.pictureboxCatched.Location = new System.Drawing.Point(8, 291);
            this.pictureboxCatched.Name = "pictureboxCatched";
            this.pictureboxCatched.Size = new System.Drawing.Size(437, 150);
            this.pictureboxCatched.TabIndex = 11;
            this.pictureboxCatched.TabStop = false;
            // 
            // statusVideo
            // 
            this.statusVideo.AutoSize = true;
            this.statusVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusVideo.ForeColor = System.Drawing.Color.Blue;
            this.statusVideo.Location = new System.Drawing.Point(7, 55);
            this.statusVideo.Name = "statusVideo";
            this.statusVideo.Size = new System.Drawing.Size(198, 20);
            this.statusVideo.TabIndex = 10;
            this.statusVideo.Text = "Find video cam to continue";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Open image";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 666);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCutPlate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxEditPicture)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxCatched)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureboxEditPicture;
        private System.Windows.Forms.PictureBox pictureBoxCutPlate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label statusVideo;
        private System.Windows.Forms.PictureBox pictureboxCatched;
        private System.Windows.Forms.Button findPlate;
    }
}

