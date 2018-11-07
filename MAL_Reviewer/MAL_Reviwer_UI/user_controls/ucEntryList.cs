using System.Collections.Generic;
using System.Windows.Forms;
using MAL_Reviewer_API.models.ListEntryModel;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class UcEntryList : UserControl
    {
        private const short
            fixedHeight = 1500,
            fixedBottom = 23;

        private int listHeight = 0;        

        public int ListHeight { get => listHeight; }

        public UcEntryList(string type)
        {
            InitializeComponent();
          
            // Affecting values for the lables.
            lType.Text = type;
            lCount.Text = "0";            
        }

        /// <summary>
        /// Populates the list with data.
        /// </summary>
        /// <param name="animeList"></param>
        public void UpdateList(List<AnimelistEntryModel> animeList)
        {
            short _index = 0;

            dgvList.Rows.Clear();
            lCount.Text = animeList.Count.ToString();

            // Populating the DataDridView.
            animeList.ForEach(a => {
                dgvList.Rows.Add(_index + 1, a.title, $"{ a.watched_episodes }/ { (a.total_episodes == 0 ? "?" : a.total_episodes.ToString()) }", a.score, a.type);
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

            System.Console.WriteLine(lType.Text);
            System.Console.WriteLine($"dgvList.Top: {dgvList.Top}");
            System.Console.WriteLine($"dgvList.Rows.GetRowsHeight(DataGridViewElementStates.None): {dgvList.Rows.GetRowsHeight(DataGridViewElementStates.None)}");
            System.Console.WriteLine($"dgvList.ColumnHeadersHeight: {dgvList.ColumnHeadersHeight}");
            System.Console.WriteLine($"lType.Top: {lType.Top}");
            System.Console.WriteLine("-------------");

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
