using ResearchTree.Models;

namespace ResearchTree.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ResearchController controller = new ResearchController();
            List<ResearchItem> items = controller.BuildDemoList();

            foreach (ResearchItem item in items)
            {
                Button button = new();
                button.Text = item.Name;
                button.Location = new Point((int)item.Position.X, (int)item.Position.Y);
                button.Width = item.Width;
                button.Height = item.Height;
            }

        }
    }
}