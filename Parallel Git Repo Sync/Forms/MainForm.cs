using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

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

        private void RepositoriesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LogTextBox.Clear();
            SyncBackgroundWorker = new BackgroundWorker[1];
            SyncBackgroundWorker[0] = new BackgroundWorker();
            SyncBackgroundWorker[0].DoWork += (sender2, e2) =>
            {
                int j;
                string GitRepository = GitRepositories[(int)e2.Argument];
                SyncActionType TargetSyncActionType;
                string TargetSyncAction;
                Process SyncProcess;

                for (j = 0; j < 3; j++)
                {
                    SyncProcess = new Process();
                    SyncProcess.EnableRaisingEvents = false;
                    SyncProcess.StartInfo.FileName = GitBinary;
                    SyncProcess.StartInfo.CreateNoWindow = true;
                    SyncProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    SyncProcess.StartInfo.UseShellExecute = false;
                    SyncProcess.StartInfo.RedirectStandardOutput = true;
                    SyncProcess.StartInfo.RedirectStandardError = true;
                    switch (j)
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
                    SyncProcess.StartInfo.Arguments = " --git-dir=\"" + GitRepository.Trim() + ".\\.git\" " + " --work-tree=\"" + GitRepository.Trim() + "\" " + TargetSyncAction;
                    SyncProcess.Start();
                    while (!SyncProcess.StandardOutput.EndOfStream)
                    {
                        LogTextBox.Invoke(new EventHandler(delegate
                        {
                            LogTextBox.AppendText(GitRepository + ": (" + TargetSyncAction + ") " + SyncProcess.StandardOutput.ReadLine() + "\r\n");
                        }));
                    }
                    while (!SyncProcess.StandardError.EndOfStream)
                    {
                        LogTextBox.Invoke(new EventHandler(delegate
                        {
                            LogTextBox.AppendText(GitRepository + ": (" + TargetSyncAction + ") " + SyncProcess.StandardError.ReadLine() + "\r\n");
                        }));
                    }
                    SyncProcess.WaitForExit(15 * 1000);
                    if (SyncProcess.HasExited && SyncProcess.ExitCode == 0)
                    {
                        GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Success);
                    }
                    else
                    {
                        GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Failed);
                    }
                    SyncProcess.Close();
                }
            };
            SyncBackgroundWorker[0].RunWorkerAsync(e.RowIndex);
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            RefreshDisplay();
            SyncBackgroundWorker = new BackgroundWorker[GitRepositories.Length];
            for (int i = 0; i < GitRepositories.Length; i++)
            {
                SyncBackgroundWorker[i] = new BackgroundWorker();
                SyncBackgroundWorker[i].DoWork += (sender2, e2) =>
                    {
                        int j;
                        string GitRepository = GitRepositories[(int)e2.Argument];
                        SyncActionType TargetSyncActionType;
                        string TargetSyncAction;
                        Process SyncProcess;

                        for (j = 0; j < 3; j++)
                        {
                            SyncProcess = new Process();
                            SyncProcess.EnableRaisingEvents = false;
                            SyncProcess.StartInfo.FileName = GitBinary;
                            SyncProcess.StartInfo.CreateNoWindow = true;
                            SyncProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            SyncProcess.StartInfo.UseShellExecute = false;
                            SyncProcess.StartInfo.RedirectStandardOutput = true;
                            SyncProcess.StartInfo.RedirectStandardError = true;
                            switch (j)
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
                            SyncProcess.StartInfo.Arguments = " --git-dir=\"" + GitRepository.Trim() + ".\\.git\" " + " --work-tree=\"" + GitRepository.Trim() + "\" " + TargetSyncAction;
                            SyncProcess.Start();
                            while (!SyncProcess.StandardOutput.EndOfStream)
                            {
                                LogTextBox.Invoke(new EventHandler(delegate
                                {
                                    LogTextBox.AppendText(GitRepository + ": (" + TargetSyncAction + ") " + SyncProcess.StandardOutput.ReadLine() + "\r\n");
                                }));
                            }
                            while (!SyncProcess.StandardError.EndOfStream)
                            {
                                LogTextBox.Invoke(new EventHandler(delegate
                                {
                                    LogTextBox.AppendText(GitRepository + ": (" + TargetSyncAction + ") " + SyncProcess.StandardError.ReadLine() + "\r\n");
                                }));
                            }
                            SyncProcess.WaitForExit(15 * 1000);
                            if (SyncProcess.HasExited && SyncProcess.ExitCode == 0)
                            {
                                GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Success);
                            }
                            else
                            {
                                GitRepositoriesDataGridView.UpdateStatus(GitRepository, TargetSyncActionType, SyncResultType.Failed);
                            }
                            SyncProcess.Close();
                        }
                    };
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
            string Temp;

            GitBinary = Reg.Read("Git Binary");
            
            Temp = Reg.Read("Git Repositories");
            if(!String.IsNullOrEmpty(Temp))
            {
                GitRepositories = Temp.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                GitRepositories = new string[0];
            }

            Temp = Reg.Read("Maximum Thread");
            if (!String.IsNullOrEmpty(Temp))
            {
                MaximumThread = Int32.Parse(Temp);
            }

            GitRepositoriesDataGridView.ShowRepositories(GitRepositories);
            LogTextBox.Clear();
        }
    }
}
