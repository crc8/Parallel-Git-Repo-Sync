using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parallel_Git_Repo_Sync
{
    class DisplayDataGridView
    {
        private DataGridView GitRepositoriesDataGridView;

        public DisplayDataGridView(DataGridView InputDataGridView)
        {
            GitRepositoriesDataGridView = InputDataGridView;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            GitRepositoriesDataGridView.Columns.Clear();
            GitRepositoriesDataGridView.Columns.Add("Repository", "Repository");
            GitRepositoriesDataGridView.Columns.Add("Pull", "Pull");
            GitRepositoriesDataGridView.Columns.Add("Push", "Push");
            GitRepositoriesDataGridView.Columns.Add("Tags", "Tags");
            GitRepositoriesDataGridView.Columns[0].FillWeight = 55;
            GitRepositoriesDataGridView.Columns[1].FillWeight = 15;
            GitRepositoriesDataGridView.Columns[2].FillWeight = 15;
            GitRepositoriesDataGridView.Columns[3].FillWeight = 15;
            GitRepositoriesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GitRepositoriesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            GitRepositoriesDataGridView.AllowUserToResizeColumns = true;
            GitRepositoriesDataGridView.AllowUserToResizeRows = true;
            GitRepositoriesDataGridView.AllowUserToAddRows = false;
            GitRepositoriesDataGridView.AllowUserToDeleteRows = false;
            GitRepositoriesDataGridView.MultiSelect = true;
            GitRepositoriesDataGridView.ReadOnly = true;
            GitRepositoriesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GitRepositoriesDataGridView.RowHeadersVisible = false;
            GitRepositoriesDataGridView.Refresh();
        }

        public void ShowRepositories(string[] GitRepositories)
        {
            GitRepositoriesDataGridView.Rows.Clear();
            foreach (string GitRepository in GitRepositories)
            {
                GitRepositoriesDataGridView.RowCount += 1;
                GitRepositoriesDataGridView.Rows[GitRepositoriesDataGridView.RowCount - 1].Cells[0].Value = GitRepository;
            }
        }

        public void UpdateStatus(string Repository, SyncActionType InputSyncActionType, SyncResultType InputSyncResultType)
        {
            GitRepositoriesDataGridView.Invoke(new EventHandler(delegate
            {
                int RowIndex, ColumnIndex;
                string DisplayOutput;
                for (RowIndex = 0; RowIndex < GitRepositoriesDataGridView.RowCount; RowIndex++)
                {
                    if (GitRepositoriesDataGridView.Rows[RowIndex].Cells[0].Value.ToString() == Repository)
                    {
                        switch (InputSyncActionType)
                        {
                            default:
                            case SyncActionType.Pull: ColumnIndex = 1; break;
                            case SyncActionType.Push: ColumnIndex = 2; break;
                            case SyncActionType.Tags: ColumnIndex = 3; break;
                        }
                        switch (InputSyncResultType)
                        {
                            case SyncResultType.Pending: DisplayOutput = "-"; break;
                            case SyncResultType.Success: DisplayOutput = "o"; break;
                            case SyncResultType.Failed: DisplayOutput = "x"; break;
                            default: DisplayOutput = ""; break;
                        }
                        GitRepositoriesDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value = DisplayOutput;
                    }
                }
            }));
        }
    }
}
