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


        }
    }
}