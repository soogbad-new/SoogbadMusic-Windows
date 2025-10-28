namespace SoogbadMusic
{
    partial class SongListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NameLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.SongContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFromQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(8, 8);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 14);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.UseMnemonic = false;
            this.NameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnSongListItemMouseDoubleClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.InfoLabel.ForeColor = System.Drawing.Color.White;
            this.InfoLabel.Location = new System.Drawing.Point(8, 23);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 13);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.UseMnemonic = false;
            this.InfoLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnSongListItemMouseDoubleClick);
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DurationLabel.ForeColor = System.Drawing.Color.White;
            this.DurationLabel.Location = new System.Drawing.Point(919, 16);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(0, 13);
            this.DurationLabel.TabIndex = 2;
            this.DurationLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnSongListItemMouseDoubleClick);
            // 
            // SongContextMenuStrip
            // 
            this.SongContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToQueueToolStripMenuItem,
            this.RemoveFromQueueToolStripMenuItem,
            this.SongInfoToolStripMenuItem});
            this.SongContextMenuStrip.Name = "ContextMenuStrip";
            this.SongContextMenuStrip.Size = new System.Drawing.Size(187, 70);
            // 
            // AddToQueueToolStripMenuItem
            // 
            this.AddToQueueToolStripMenuItem.Image = global::SoogbadMusic.Properties.Resources.QueueAdd;
            this.AddToQueueToolStripMenuItem.Name = "AddToQueueToolStripMenuItem";
            this.AddToQueueToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.AddToQueueToolStripMenuItem.Text = "Add To Queue";
            this.AddToQueueToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnAddToQueueToolStripMenuItemMouseDown);
            // 
            // RemoveFromQueueToolStripMenuItem
            // 
            this.RemoveFromQueueToolStripMenuItem.Image = global::SoogbadMusic.Properties.Resources.QueueRemove;
            this.RemoveFromQueueToolStripMenuItem.Name = "RemoveFromQueueToolStripMenuItem";
            this.RemoveFromQueueToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.RemoveFromQueueToolStripMenuItem.Text = "Remove From Queue";
            this.RemoveFromQueueToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnRemoveFromQueueToolStripMenuItemMouseDown);
            // 
            // SongInfoToolStripMenuItem
            // 
            this.SongInfoToolStripMenuItem.Image = global::SoogbadMusic.Properties.Resources.Info;
            this.SongInfoToolStripMenuItem.Name = "SongInfoToolStripMenuItem";
            this.SongInfoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SongInfoToolStripMenuItem.Text = "Song Info";
            this.SongInfoToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnSongInfoToolStripMenuItemMouseDown);
            // 
            // SongListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(96)))));
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "SongListItem";
            this.Size = new System.Drawing.Size(927, 45);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnSongListItemMouseDoubleClick);
            this.SongContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.ContextMenuStrip SongContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SongInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFromQueueToolStripMenuItem;
    }
}
