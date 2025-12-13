namespace SoogbadMusic
{
    partial class ExitDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitDialog));
            CancelButton = new Button();
            ExitButton = new Button();
            DialogLabel = new Label();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.White;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 177);
            CancelButton.Location = new Point(181, 83);
            CancelButton.Margin = new Padding(4, 3, 4, 3);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(88, 27);
            CancelButton.TabIndex = 15;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.White;
            ExitButton.DialogResult = DialogResult.OK;
            ExitButton.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, 177);
            ExitButton.Location = new Point(12, 83);
            ExitButton.Margin = new Padding(4, 3, 4, 3);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(88, 27);
            ExitButton.TabIndex = 16;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = false;
            // 
            // DialogLabel
            // 
            DialogLabel.AutoSize = true;
            DialogLabel.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
            DialogLabel.ForeColor = Color.White;
            DialogLabel.Location = new Point(26, 17);
            DialogLabel.Margin = new Padding(4, 0, 4, 0);
            DialogLabel.Name = "DialogLabel";
            DialogLabel.Size = new Size(196, 18);
            DialogLabel.TabIndex = 17;
            DialogLabel.Text = "Are you sure you want to exit?";
            // 
            // ExitDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 80);
            ClientSize = new Size(280, 121);
            ControlBox = false;
            Controls.Add(DialogLabel);
            Controls.Add(ExitButton);
            Controls.Add(CancelButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exit Dialog";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label DialogLabel;
    }
}