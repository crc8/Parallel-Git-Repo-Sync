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
        private string GitBinary;
        private string[] GitRepositories;
        private int MaximumThread;
        private DisplayDataGridView GitRepositoriesDataGridView;
        private BackgroundWorker[] SyncBackgroundWorker;

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
            RefreshDisplay();
            SyncBackgroundWorker = new BackgroundWorker[GitRepositories.Length];
            for (int i = 0; i < GitRepositories.Length; i++)
            {
                SyncBackgroundWorker[i] = new BackgroundWorker();
                SyncBackgroundWorker[i].DoWork += new DoWorkEventHandler(SyncBackgroundWorker_DoWork);
                SyncBackgroundWorker[i].RunWorkerAsync(i);
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
            MaximumThread = Int32.Parse(Reg.Read("Maximum Thread"));
            GitRepositoriesDataGridView.ShowRepositories(GitRepositories);
        }

        private void SyncBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string GitRepository = GitRepositories[(int)e.Argument];
            string Output;
            int i;
            SyncActionType TargetSyncActionType;
            string TargetSyncAction;

            Process SyncProcess = new Process();
            SyncProcess.EnableRaisingEvents = false;
            SyncProcess.StartInfo.FileName = GitBinary;
            SyncProcess.StartInfo.CreateNoWindow = true;
            SyncProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            SyncProcess.StartInfo.RedirectStandardOutput = true;
            SyncProcess.StartInfo.RedirectStandardError = true;
            SyncProcess.StartInfo.UseShellExecute = false;

            for (i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        TargetSyncActionType = SyncActionType.Pull;
                        TargetSyncAction = "pull --all";
                        break;
                    case 1:
                        TargetSyncActionType = SyncActionType.Push;
                        TargetSyncAction = "push --all";
                        break;
                    case 2:
                        TargetSyncActionType = SyncActionType.Tags;
                        TargetSyncAction = "push --tags -f";
                        break;
                    default:
                        return;
                }
                GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Pending);
                SyncProcess.StartInfo.Arguments = " --git-dir=\"" + GitRepository + ".\\.git\" " + " --work-tree=\"" + GitRepository + "\" " + TargetSyncAction;
                SyncProcess.Start();
                Output = "";
                while (!SyncProcess.StandardOutput.EndOfStream)
                {
                    Output += SyncProcess.StandardOutput.ReadLine();
                }
                SyncProcess.WaitForExit();
                if (SyncProcess.ExitCode == 0)
                {
                    GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Success);
                }
                else
                {
                    GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Failed);
                }
            }
        }
    }
}
