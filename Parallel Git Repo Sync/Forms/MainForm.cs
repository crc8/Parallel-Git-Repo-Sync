using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Parallel_Git_Repo_Sync
{
    public partial class MainForm : Form
    {
        string GitBinary;
        string[] GitRepositories;
        private DisplayDataGridView GitRepositoriesDataGridView;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " - v" + Application.ProductVersion.Substring(0, 3);
            GitRepositoriesDataGridView = new DisplayDataGridView(RepositoriesDataGridView);

            RefreshDisplay();
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            foreach (string GitRepository in GitRepositories)
            {
                GitRepositoriesDataGridView.UpdateStatus(GitRepository, DisplayDataGridView.SyncType.Push, "...");
                Process p = new Process();
                p.EnableRaisingEvents = false;
                p.StartInfo.FileName = GitBinary;
                p.StartInfo.Arguments = " --git-dir=\"" + GitRepository + ".\\.git\" " + " --work-tree=\"" + GitRepository + "\" pull --all";
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                if (p.Start())
                {
                    GitRepositoriesDataGridView.UpdateStatus(GitRepository, DisplayDataGridView.SyncType.Push, "o");
                }
                else
                {
                    GitRepositoriesDataGridView.UpdateStatus(GitRepository, DisplayDataGridView.SyncType.Push, "x");
                }
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            RefreshDisplay();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshDisplay()
        {
            GitBinary = Reg.Read("Git Binary");
            GitRepositories = Reg.Read("Git Repositories").Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            GitRepositoriesDataGridView.ShowRepositories(GitRepositories);
        }
    }
}
