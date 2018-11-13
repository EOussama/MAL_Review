using System.Collections.Generic;
using System.Windows.Forms;
using MAL_Reviewer_API.models.ListEntryModel;
using MAL_Reviewer_Review.enumerations;

namespace MAL_Reviewer_UI.user_controls
{
    public partial class EntryListControl : UserControl
    {
        private const short
            fixedHeight = 1500,
            fixedBottom = 23;

        private int listHeight = 0;        

        /// <summary>
        /// Gets the list's height.
        /// </summary>
        public int ListHeight { get => listHeight; }

        public EntryListControl(string label, EntryType type)
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
                dgvList.Rows.Add(_index + 1, a.Title, $"{ a.Watched_episodes }/ { (a.Total_episodes == 0 ? "?" : a.Total_episodes.ToString()) }", "", a.Score, a.Type);
                dgvList.Rows[_index++].Tag = a.Url;
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
                dgvList.Rows.Add(_index + 1, a.Title, $"{ a.Read_chapters }/ { (a.Total_chapters == 0 ? "?" : a.Total_chapters.ToString()) }", $"{ a.Read_volumes }/ { (a.Total_volumes == 0 ? "?" : a.Total_volumes.ToString()) }", a.Score, a.Type);
                dgvList.Rows[_index++].Tag = a.Url;
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
