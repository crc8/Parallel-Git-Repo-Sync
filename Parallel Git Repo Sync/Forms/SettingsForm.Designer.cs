namespace Parallel_Git_Repo_Sync
{
    partial class SettingsForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GitRepositoriesTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.GitBinaryTextBox = new System.Windows.Forms.TextBox();
            this.GitBinaryLabel = new System.Windows.Forms.Label();
            this.GitRepositoriesLabel = new System.Windows.Forms.Label();
            this.MaximumThreadLabel = new System.Windows.Forms.Label();
            this.MaximumThreadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumThreadNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(307, 233);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(12, 233);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GitRepositoriesTextBox
            // 
            this.GitRepositoriesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GitRepositoriesTextBox.Location = new System.Drawing.Point(112, 38);
            this.GitRepositoriesTextBox.Multiline = true;
            this.GitRepositoriesTextBox.Name = "GitRepositoriesTextBox";
            this.GitRepositoriesTextBox.Size = new System.Drawing.Size(270, 160);
            this.GitRepositoriesTextBox.TabIndex = 4;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(307, 9);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // GitBinaryTextBox
            // 
            this.GitBinaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GitBinaryTextBox.Location = new System.Drawing.Point(112, 12);
            this.GitBinaryTextBox.Name = "GitBinaryTextBox";
            this.GitBinaryTextBox.ReadOnly = true;
            this.GitBinaryTextBox.Size = new System.Drawing.Size(189, 20);
            this.GitBinaryTextBox.TabIndex = 1;
            // 
            // GitBinaryLabel
            // 
            this.GitBinaryLabel.AutoSize = true;
            this.GitBinaryLabel.Location = new System.Drawing.Point(48, 14);
            this.GitBinaryLabel.Name = "GitBinaryLabel";
            this.GitBinaryLabel.Size = new System.Drawing.Size(58, 13);
            this.GitBinaryLabel.TabIndex = 0;
            this.GitBinaryLabel.Text = "Git Binary :";
            // 
            // GitRepositoriesLabel
            // 
            this.GitRepositoriesLabel.AutoSize = true;
            this.GitRepositoriesLabel.Location = new System.Drawing.Point(19, 41);
            this.GitRepositoriesLabel.Name = "GitRepositoriesLabel";
            this.GitRepositoriesLabel.Size = new System.Drawing.Size(87, 13);
            this.GitRepositoriesLabel.TabIndex = 3;
            this.GitRepositoriesLabel.Text = "Git Repositories :";
            // 
            // MaximumThreadLabel
            // 
            this.MaximumThreadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaximumThreadLabel.AutoSize = true;
            this.MaximumThreadLabel.Location = new System.Drawing.Point(12, 206);
            this.MaximumThreadLabel.Name = "MaximumThreadLabel";
            this.MaximumThreadLabel.Size = new System.Drawing.Size(94, 13);
            this.MaximumThreadLabel.TabIndex = 5;
            this.MaximumThreadLabel.Text = "Maximum Thread :";
            // 
            // MaximumThreadNumericUpDown
            // 
            this.MaximumThreadNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaximumThreadNumericUpDown.Location = new System.Drawing.Point(112, 204);
            this.MaximumThreadNumericUpDown.Name = "MaximumThreadNumericUpDown";
            this.MaximumThreadNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.MaximumThreadNumericUpDown.TabIndex = 6;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 268);
            this.Controls.Add(this.MaximumThreadNumericUpDown);
            this.Controls.Add(this.MaximumThreadLabel);
            this.Controls.Add(this.GitRepositoriesLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.GitBinaryTextBox);
            this.Controls.Add(this.GitBinaryLabel);
            this.Controls.Add(this.GitRepositoriesTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.MaximumThreadNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox GitRepositoriesTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox GitBinaryTextBox;
        private System.Windows.Forms.Label GitBinaryLabel;
        private System.Windows.Forms.Label GitRepositoriesLabel;
        private System.Windows.Forms.Label MaximumThreadLabel;
        private System.Windows.Forms.NumericUpDown MaximumThreadNumericUpDown;
    }
}