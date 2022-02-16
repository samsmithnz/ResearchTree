using ResearchTree.Models;

namespace ResearchTree.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            List<ResearchItem> list = new()
            {
                ResearchPool.CreateA(),
                ResearchPool.CreateB(),
                ResearchPool.CreateC(),
                ResearchPool.CreateD(),
                ResearchPool.CreateE(),
                ResearchPool.CreateF(),
                ResearchPool.CreateG()
            };

    
        }
    }
}