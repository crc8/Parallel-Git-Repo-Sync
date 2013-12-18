using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parallel_Git_Repo_Sync
{
    class DisplayDataGridView
    {
        public enum SyncType
        {
            Push,
            Pull,
            Tags
        }
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
            GitRepositoriesDataGridView.Columns.Add("Push", "Push");
            GitRepositoriesDataGridView.Columns.Add("Pull", "Pull");
            GitRepositoriesDataGridView.Columns.Add("Tags", "Tags");
            GitRepositoriesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            foreach (string GitRepository in GitRepositories)
            {
                GitRepositoriesDataGridView.RowCount += 1;
                GitRepositoriesDataGridView.Rows[GitRepositoriesDataGridView.RowCount - 1].Cells[0].Value = GitRepository;
            }
        }

        public void UpdateStatus(string Repository, SyncType SyncTypeColumn, string Value)
        {
            for (int i = 0; i < GitRepositoriesDataGridView.RowCount; i++)
            {
                if (GitRepositoriesDataGridView.Rows[i].Cells[0].Value.ToString() == Repository)
                {
                    GitRepositoriesDataGridView.Rows[i].Cells[1].Value = Value;
                }
            }
        }
    }
}
