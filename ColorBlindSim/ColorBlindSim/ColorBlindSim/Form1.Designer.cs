namespace ColorBlindSim
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox_Align_D = new System.Windows.Forms.PictureBox();
            this.pictureBox_Align_U = new System.Windows.Forms.PictureBox();
            this.pictureBox_Align_L = new System.Windows.Forms.PictureBox();
            this.pictureBox_Align_R = new System.Windows.Forms.PictureBox();
            this.pictureBox_maximise = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_unchecked = new System.Windows.Forms.PictureBox();
            this.pictureBox_checked = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_camera = new System.Windows.Forms.PictureBox();
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            this.pictureBox_reduce = new System.Windows.Forms.PictureBox();
            this.pictureBox_background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_U)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_maximise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_unchecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_camera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_reduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_background)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox_Align_D
            // 
            resources.ApplyResources(this.pictureBox_Align_D, "pictureBox_Align_D");
            this.pictureBox_Align_D.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Align_D.BackgroundImage = global::ColorBlindSim.Properties.Resources.btn_D;
            this.pictureBox_Align_D.Name = "pictureBox_Align_D";
            this.pictureBox_Align_D.TabStop = false;
            this.pictureBox_Align_D.Click += new System.EventHandler(this.pictureBox_Align_D_Click);
            // 
            // pictureBox_Align_U
            // 
            resources.ApplyResources(this.pictureBox_Align_U, "pictureBox_Align_U");
            this.pictureBox_Align_U.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Align_U.BackgroundImage = global::ColorBlindSim.Properties.Resources.btn_U;
            this.pictureBox_Align_U.Name = "pictureBox_Align_U";
            this.pictureBox_Align_U.TabStop = false;
            this.pictureBox_Align_U.Click += new System.EventHandler(this.pictureBox_Align_U_Click);
            // 
            // pictureBox_Align_L
            // 
            resources.ApplyResources(this.pictureBox_Align_L, "pictureBox_Align_L");
            this.pictureBox_Align_L.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Align_L.BackgroundImage = global::ColorBlindSim.Properties.Resources.btn_L;
            this.pictureBox_Align_L.Name = "pictureBox_Align_L";
            this.pictureBox_Align_L.TabStop = false;
            this.pictureBox_Align_L.Click += new System.EventHandler(this.pictureBox_Align_L_Click);
            // 
            // pictureBox_Align_R
            // 
            resources.ApplyResources(this.pictureBox_Align_R, "pictureBox_Align_R");
            this.pictureBox_Align_R.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Align_R.BackgroundImage = global::ColorBlindSim.Properties.Resources.btn_R;
            this.pictureBox_Align_R.Name = "pictureBox_Align_R";
            this.pictureBox_Align_R.TabStop = false;
            this.pictureBox_Align_R.Click += new System.EventHandler(this.pictureBox_Align_R_Click);
            // 
            // pictureBox_maximise
            // 
            resources.ApplyResources(this.pictureBox_maximise, "pictureBox_maximise");
            this.pictureBox_maximise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pictureBox_maximise.BackgroundImage = global::ColorBlindSim.Properties.Resources.agrandir;
            this.pictureBox_maximise.Name = "pictureBox_maximise";
            this.pictureBox_maximise.TabStop = false;
            this.pictureBox_maximise.Click += new System.EventHandler(this.pictureBox_maximise_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackgroundImage = global::ColorBlindSim.Properties.Resources.Center;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox_unchecked
            // 
            resources.ApplyResources(this.pictureBox_unchecked, "pictureBox_unchecked");
            this.pictureBox_unchecked.BackgroundImage = global::ColorBlindSim.Properties.Resources._unchecked;
            this.pictureBox_unchecked.Name = "pictureBox_unchecked";
            this.pictureBox_unchecked.TabStop = false;
            this.pictureBox_unchecked.Click += new System.EventHandler(this.pictureBox_unchecked_Click);
            // 
            // pictureBox_checked
            // 
            resources.ApplyResources(this.pictureBox_checked, "pictureBox_checked");
            this.pictureBox_checked.BackgroundImage = global::ColorBlindSim.Properties.Resources._checked;
            this.pictureBox_checked.Name = "pictureBox_checked";
            this.pictureBox_checked.TabStop = false;
            this.pictureBox_checked.Click += new System.EventHandler(this.pictureBox_checked_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = global::ColorBlindSim.Properties.Resources.info;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox_camera
            // 
            resources.ApplyResources(this.pictureBox_camera, "pictureBox_camera");
            this.pictureBox_camera.BackgroundImage = global::ColorBlindSim.Properties.Resources.camera2;
            this.pictureBox_camera.Name = "pictureBox_camera";
            this.pictureBox_camera.TabStop = false;
            this.pictureBox_camera.Click += new System.EventHandler(this.pictureBox_camera_Click);
            // 
            // pictureBox_Close
            // 
            resources.ApplyResources(this.pictureBox_Close, "pictureBox_Close");
            this.pictureBox_Close.BackgroundImage = global::ColorBlindSim.Properties.Resources.close;
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            // 
            // pictureBox_reduce
            // 
            resources.ApplyResources(this.pictureBox_reduce, "pictureBox_reduce");
            this.pictureBox_reduce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pictureBox_reduce.BackgroundImage = global::ColorBlindSim.Properties.Resources.reduce;
            this.pictureBox_reduce.Name = "pictureBox_reduce";
            this.pictureBox_reduce.TabStop = false;
            this.pictureBox_reduce.Click += new System.EventHandler(this.pictureBox_reduce_Click);
            // 
            // pictureBox_background
            // 
            resources.ApplyResources(this.pictureBox_background, "pictureBox_background");
            this.pictureBox_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pictureBox_background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_background.Name = "pictureBox_background";
            this.pictureBox_background.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox_Align_D);
            this.Controls.Add(this.pictureBox_Align_U);
            this.Controls.Add(this.pictureBox_Align_L);
            this.Controls.Add(this.pictureBox_Align_R);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox_checked);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_camera);
            this.Controls.Add(this.pictureBox_Close);
            this.Controls.Add(this.pictureBox_reduce);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox_maximise);
            this.Controls.Add(this.pictureBox_unchecked);
            this.Controls.Add(this.pictureBox_background);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_U)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Align_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_maximise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_unchecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_camera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_reduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox_reduce;
        private System.Windows.Forms.PictureBox pictureBox_Close;
        private System.Windows.Forms.PictureBox pictureBox_camera;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_background;
        private System.Windows.Forms.PictureBox pictureBox_checked;
        private System.Windows.Forms.PictureBox pictureBox_unchecked;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox_maximise;
        private System.Windows.Forms.PictureBox pictureBox_Align_R;
        private System.Windows.Forms.PictureBox pictureBox_Align_L;
        private System.Windows.Forms.PictureBox pictureBox_Align_U;
        private System.Windows.Forms.PictureBox pictureBox_Align_D;
    }
}

