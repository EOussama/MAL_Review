using System.Collections.Generic;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models.ListEntryModel;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class EntryList : UserControl
    {
        private const short
            fixedHeight = 1500,
            fixedBottom = 23;

        private int listHeight = 0;        

        public int ListHeight { get => listHeight; }

        public EntryList(string label, EntryType type)
        {
            InitializeComponent();
          
            // Affecting values for the lables.
            lType.Text = label;
            lCount.Text = "0";

            if (type == EntryType.Manga)
            {
                dgvList.Columns["cProgress"].HeaderText = "Chapters";
                dgvList.Columns["cVolumes"].Visible = true;
            }
        }

        /// <summary>
        /// Populates the list with anime data.
        /// </summary>
        /// <param name="animeList"></param>
        public void UpdateList(List<AnimelistEntryModel> animeList)
        {
            short _index = 0;

            dgvList.Rows.Clear();
            lCount.Text = animeList.Count.ToString();

            // Populating the DataDridView.
            animeList.ForEach(a => {
                dgvList.Rows.Add(_index + 1, a.title, $"{ a.watched_episodes }/ { (a.total_episodes == 0 ? "?" : a.total_episodes.ToString()) }", "", a.score, a.type);
                dgvList.Rows[_index++].Tag = a.url;
            });

            ResizeList();
        }

        /// <summary>
        /// Populates the list with manga data.
        /// </summary>
        /// <param name="animeList"></param>
        public void UpdateList(List<MangalistEntryModel> mangaList)
        {
            short _index = 0;

            dgvList.Rows.Clear();
            lCount.Text = mangaList.Count.ToString();

            // Populating the DataDridView.
            mangaList.ForEach(a => {
                dgvList.Rows.Add(_index + 1, a.title, $"{ a.read_chapters }/ { (a.total_chapters == 0 ? "?" : a.total_chapters.ToString()) }", $"{ a.read_volumes }/ { (a.total_volumes == 0 ? "?" : a.total_volumes.ToString()) }", a.score, a.type);
                dgvList.Rows[_index++].Tag = a.url;
            });

            ResizeList();
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void ClearList()
        {
            lCount.Text = "0";
            dgvList.Rows.Clear();
            ResizeList();
        }

        /// <summary>
        /// Resizes the control to fit the displayed data.
        /// </summary>
        private void ResizeList()
        {
            Height = 198;

            if (dgvList.Rows.Count == 0)
                listHeight = dgvList.Top + lType.Top;
            else if (dgvList.Rows.Count < 50)
                listHeight = dgvList.Top + dgvList.ColumnHeadersHeight * 2 + dgvList.Rows.GetRowsHeight(DataGridViewElementStates.None) + fixedBottom;
            else
                listHeight = dgvList.Top + dgvList.ColumnHeadersHeight * 2 + fixedHeight + fixedBottom;

            Height = ListHeight;
        }

        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvList.Rows[e.RowIndex].Selected = true;
                System.Diagnostics.Process.Start(dgvList.Rows[e.RowIndex].Tag.ToString());
            }
        }
    }
}
