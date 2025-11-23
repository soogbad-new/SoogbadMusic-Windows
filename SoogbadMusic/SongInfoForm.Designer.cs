namespace SoogbadMusic
{
    partial class SongInfoForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongInfoForm));
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.ArtistTextBox = new System.Windows.Forms.TextBox();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.AlbumTextBox = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.AlbumCoverLabel = new System.Windows.Forms.Label();
            this.OpenAlbumCoverDialog = new System.Windows.Forms.OpenFileDialog();
            this.LyricsTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AlbumCoverPictureButton = new PictureButton();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCoverPictureButton)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(112)))));
            this.TitleTextBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TitleTextBox.ForeColor = System.Drawing.Color.White;
            this.TitleTextBox.Location = new System.Drawing.Point(87, 15);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(132, 24);
            this.TitleTextBox.TabIndex = 0;
            this.TitleTextBox.WordWrap = false;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(20, 18);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(45, 21);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title:";
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ArtistLabel.ForeColor = System.Drawing.Color.White;
            this.ArtistLabel.Location = new System.Drawing.Point(20, 78);
            this.ArtistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(53, 21);
            this.ArtistLabel.TabIndex = 3;
            this.ArtistLabel.Text = "Artist:";
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(112)))));
            this.ArtistTextBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ArtistTextBox.ForeColor = System.Drawing.Color.White;
            this.ArtistTextBox.Location = new System.Drawing.Point(87, 74);
            this.ArtistTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(132, 24);
            this.ArtistTextBox.TabIndex = 2;
            this.ArtistTextBox.WordWrap = false;
            this.ArtistTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            // 
            // AlbumLabel
            // 
            this.AlbumLabel.AutoSize = true;
            this.AlbumLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AlbumLabel.ForeColor = System.Drawing.Color.White;
            this.AlbumLabel.Location = new System.Drawing.Point(20, 137);
            this.AlbumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlbumLabel.Name = "AlbumLabel";
            this.AlbumLabel.Size = new System.Drawing.Size(61, 21);
            this.AlbumLabel.TabIndex = 5;
            this.AlbumLabel.Text = "Album:";
            // 
            // AlbumTextBox
            // 
            this.AlbumTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(112)))));
            this.AlbumTextBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AlbumTextBox.ForeColor = System.Drawing.Color.White;
            this.AlbumTextBox.Location = new System.Drawing.Point(87, 133);
            this.AlbumTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AlbumTextBox.Name = "AlbumTextBox";
            this.AlbumTextBox.Size = new System.Drawing.Size(132, 24);
            this.AlbumTextBox.TabIndex = 4;
            this.AlbumTextBox.WordWrap = false;
            this.AlbumTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YearLabel.ForeColor = System.Drawing.Color.White;
            this.YearLabel.Location = new System.Drawing.Point(20, 196);
            this.YearLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(44, 21);
            this.YearLabel.TabIndex = 7;
            this.YearLabel.Text = "Year:";
            // 
            // YearTextBox
            // 
            this.YearTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(112)))));
            this.YearTextBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YearTextBox.ForeColor = System.Drawing.Color.White;
            this.YearTextBox.Location = new System.Drawing.Point(87, 192);
            this.YearTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.YearTextBox.MaxLength = 4;
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.ShortcutsEnabled = false;
            this.YearTextBox.Size = new System.Drawing.Size(132, 24);
            this.YearTextBox.TabIndex = 6;
            this.YearTextBox.WordWrap = false;
            this.YearTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            this.YearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnYearTextBoxKeyPress);
            // 
            // AlbumCoverLabel
            // 
            this.AlbumCoverLabel.AutoSize = true;
            this.AlbumCoverLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AlbumCoverLabel.ForeColor = System.Drawing.Color.White;
            this.AlbumCoverLabel.Location = new System.Drawing.Point(100, 310);
            this.AlbumCoverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlbumCoverLabel.Name = "AlbumCoverLabel";
            this.AlbumCoverLabel.Size = new System.Drawing.Size(105, 21);
            this.AlbumCoverLabel.TabIndex = 11;
            this.AlbumCoverLabel.Text = "Album Cover:";
            // 
            // OpenAlbumCoverDialog
            // 
            this.OpenAlbumCoverDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";
            this.OpenAlbumCoverDialog.SupportMultiDottedExtensions = true;
            // 
            // LyricsTextBox
            // 
            this.LyricsTextBox.AcceptsReturn = true;
            this.LyricsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(112)))));
            this.LyricsTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LyricsTextBox.ForeColor = System.Drawing.Color.White;
            this.LyricsTextBox.HideSelection = false;
            this.LyricsTextBox.Location = new System.Drawing.Point(385, 18);
            this.LyricsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.LyricsTextBox.Multiline = true;
            this.LyricsTextBox.Name = "LyricsTextBox";
            this.LyricsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LyricsTextBox.Size = new System.Drawing.Size(852, 442);
            this.LyricsTextBox.TabIndex = 12;
            this.LyricsTextBox.WordWrap = false;
            this.LyricsTextBox.TextChanged += new System.EventHandler(this.OnTextBoxTextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CancelButton.Location = new System.Drawing.Point(1139, 570);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 28);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnCancelButtonMouseDown);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SaveButton.Location = new System.Drawing.Point(20, 570);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 28);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnSaveButtonMouseDown);
            // 
            // AlbumCoverPictureButton
            // 
            this.AlbumCoverPictureButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlbumCoverPictureButton.Location = new System.Drawing.Point(87, 338);
            this.AlbumCoverPictureButton.Margin = new System.Windows.Forms.Padding(4);
            this.AlbumCoverPictureButton.Name = "AlbumCoverPictureButton";
            this.AlbumCoverPictureButton.Size = new System.Drawing.Size(133, 123);
            this.AlbumCoverPictureButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AlbumCoverPictureButton.TabIndex = 10;
            this.AlbumCoverPictureButton.TabStop = false;
            this.AlbumCoverPictureButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnAlbumCoverPictureButtonMouseDown);
            // 
            // SongInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1259, 617);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.LyricsTextBox);
            this.Controls.Add(this.AlbumCoverLabel);
            this.Controls.Add(this.AlbumCoverPictureButton);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.AlbumLabel);
            this.Controls.Add(this.AlbumTextBox);
            this.Controls.Add(this.ArtistLabel);
            this.Controls.Add(this.ArtistTextBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SongInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Song Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumCoverPictureButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.Label AlbumLabel;
        private System.Windows.Forms.TextBox AlbumTextBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private PictureButton AlbumCoverPictureButton;
        private System.Windows.Forms.Label AlbumCoverLabel;
        private System.Windows.Forms.OpenFileDialog OpenAlbumCoverDialog;
        private System.Windows.Forms.TextBox LyricsTextBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}