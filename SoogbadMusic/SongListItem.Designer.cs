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
            components = new System.ComponentModel.Container();
            NameLabel = new Label();
            InfoLabel = new Label();
            DurationLabel = new Label();
            SongContextMenuStrip = new ContextMenuStrip(components);
            AddToQueueToolStripMenuItem = new ToolStripMenuItem();
            RemoveFromQueueToolStripMenuItem = new ToolStripMenuItem();
            SongInfoToolStripMenuItem = new ToolStripMenuItem();
            SongContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(9, 9);
            NameLabel.Margin = new Padding(4, 0, 4, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(0, 14);
            NameLabel.TabIndex = 0;
            NameLabel.UseMnemonic = false;
            NameLabel.MouseDoubleClick += OnSongListItemMouseDoubleClick;
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            InfoLabel.ForeColor = Color.White;
            InfoLabel.Location = new Point(9, 27);
            InfoLabel.Margin = new Padding(4, 0, 4, 0);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(0, 13);
            InfoLabel.TabIndex = 1;
            InfoLabel.UseMnemonic = false;
            InfoLabel.MouseDoubleClick += OnSongListItemMouseDoubleClick;
            // 
            // DurationLabel
            // 
            DurationLabel.AutoSize = true;
            DurationLabel.Font = new Font("Calibri", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            DurationLabel.ForeColor = Color.White;
            DurationLabel.Location = new Point(1072, 18);
            DurationLabel.Margin = new Padding(4, 0, 4, 0);
            DurationLabel.Name = "DurationLabel";
            DurationLabel.Size = new Size(0, 13);
            DurationLabel.TabIndex = 2;
            DurationLabel.MouseDoubleClick += OnSongListItemMouseDoubleClick;
            // 
            // SongContextMenuStrip
            // 
            SongContextMenuStrip.Items.AddRange(new ToolStripItem[] { AddToQueueToolStripMenuItem, RemoveFromQueueToolStripMenuItem, SongInfoToolStripMenuItem });
            SongContextMenuStrip.Name = "ContextMenuStrip";
            SongContextMenuStrip.Size = new Size(187, 70);
            // 
            // AddToQueueToolStripMenuItem
            // 
            AddToQueueToolStripMenuItem.Image = Properties.Resources.QueueAdd;
            AddToQueueToolStripMenuItem.Name = "AddToQueueToolStripMenuItem";
            AddToQueueToolStripMenuItem.Size = new Size(186, 22);
            AddToQueueToolStripMenuItem.Text = "Add To Queue";
            AddToQueueToolStripMenuItem.MouseDown += OnAddToQueueToolStripMenuItemMouseDown;
            // 
            // RemoveFromQueueToolStripMenuItem
            // 
            RemoveFromQueueToolStripMenuItem.Image = Properties.Resources.QueueRemove;
            RemoveFromQueueToolStripMenuItem.Name = "RemoveFromQueueToolStripMenuItem";
            RemoveFromQueueToolStripMenuItem.Size = new Size(186, 22);
            RemoveFromQueueToolStripMenuItem.Text = "Remove From Queue";
            RemoveFromQueueToolStripMenuItem.MouseDown += OnRemoveFromQueueToolStripMenuItemMouseDown;
            // 
            // SongInfoToolStripMenuItem
            // 
            SongInfoToolStripMenuItem.Image = Properties.Resources.Info;
            SongInfoToolStripMenuItem.Name = "SongInfoToolStripMenuItem";
            SongInfoToolStripMenuItem.Size = new Size(186, 22);
            SongInfoToolStripMenuItem.Text = "Song Info";
            SongInfoToolStripMenuItem.MouseDown += OnSongInfoToolStripMenuItemMouseDown;
            // 
            // SongListItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 96);
            Controls.Add(DurationLabel);
            Controls.Add(InfoLabel);
            Controls.Add(NameLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SongListItem";
            Size = new Size(1082, 52);
            MouseDoubleClick += OnSongListItemMouseDoubleClick;
            SongContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
