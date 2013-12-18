using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parallel_Git_Repo_Sync
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            MaximumThreadNumericUpDown.Minimum = 1;
            MaximumThreadNumericUpDown.Maximum = 99;

            GitBinaryTextBox.Text = Reg.Read("Git Binary");
            GitRepositoriesTextBox.Text = Reg.Read("Git Repositories");
            MaximumThreadNumericUpDown.Value = Int32.Parse(Reg.Read("Maximum Thread"));

            MaximumThreadLabel.Visible = false;
            MaximumThreadNumericUpDown.Visible = false;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseOpenFileDialog = new OpenFileDialog();
            BrowseOpenFileDialog.Title = "Select git.exe";
            if (!String.IsNullOrEmpty(Reg.Read("Git Binary")))
            {
                BrowseOpenFileDialog.InitialDirectory = Reg.Read("Git Binary");
            }
            BrowseOpenFileDialog.FileName = "git.exe";
            BrowseOpenFileDialog.Filter = "Git Application (git.exe)|git.exe";
            if (BrowseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Reg.Write("Git Binary", BrowseOpenFileDialog.FileName);
                GitBinaryTextBox.Text = Reg.Read("Git Binary");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Reg.Write("Git Binary", GitBinaryTextBox.Text);
            Reg.Write("Git Repositories", GitRepositoriesTextBox.Text);
            Reg.Write("Maximum Thread", MaximumThreadNumericUpDown.Value.ToString());

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
