namespace RestApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private async void FrmMain_LoadAsync(object sender, EventArgs e)
        {
            var users = await CoreApp.LoadUsers();
            if (users != null)
            {
                foreach (var user in users)
                    this.listView1.Items.Add(new ListViewItem(new String[] { user.Username, user.Email }) { Tag = user });
            }

        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var selectedUser = (User)this.listView1.SelectedItems[0].Tag;
            if (selectedUser != null)
            {
                this.listView2.Items.Clear();

                var todos = await CoreApp.LoadTodo(selectedUser.Id);
                if (todos != null)
                {
                    foreach (var todo in todos)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = todo.Title;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = todo.Completed ? "Completed" : "" });
                        item.Tag = todo;
                        this.listView2.Items.Add(item);
                    }
                }
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {

            }
        }

        private void btnGoogle_Click(object sender, EventArgs e)
        {
            string searchText = "";
            if (this.listView2.SelectedItems.Count != 0)
            {
                var todo = (Todo)this.listView2.SelectedItems[0].Tag;
                searchText = todo.Title;
            }
            else if (this.listView1.SelectedItems.Count != 0)
            {
                var user = (User)this.listView1.SelectedItems[0].Tag;
                searchText = user.Username;
            }


            string text = Clipboard.GetText();
            FrmBrowser frmBrowser = new FrmBrowser();
            frmBrowser.Url = "https://google.com/?q=" + searchText;
            frmBrowser.ShowDialog();
        }
    }
}