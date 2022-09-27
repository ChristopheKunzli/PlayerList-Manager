namespace ListFootball
{
    public partial class FrmList : Form
    {
        private ConnectionDB connection = new ConnectionDB();

        public FrmList()
        {
            InitializeComponent();
        }

        private void AddPlayerToList(Player player)
        {
            lstPlayerList.Items.Add(player);
            connection.AddPlayer(player);
        }

        private void RemovePlayerFromList(int index)
        {
            lstPlayerList.Items.RemoveAt(index);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd form = new FrmAdd();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Player player = new Player(form.FirstName, form.LastName, form.PhoneNum);
                AddPlayerToList(player);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lstPlayerList.SelectedItems.Count > 0)
            {

                Player selectedPlayer = (Player) lstPlayerList.SelectedItem;
                FrmAdd form = new FrmAdd(selectedPlayer);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    RemovePlayerFromList(lstPlayerList.SelectedIndex);
                    AddPlayerToList(new Player(form.FirstName, form.LastName, form.PhoneNum));
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPlayerList.SelectedItems.Count > 0)
            {
                RemovePlayerFromList(lstPlayerList.SelectedIndex);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}