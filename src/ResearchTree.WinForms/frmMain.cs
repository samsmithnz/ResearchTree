using ResearchTree.Models;
using System.Numerics;

namespace ResearchTree.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ResearchController controller = new(ResearchPool.BuildDemoList(),
                162, 100,
                81, 50);

            foreach (ResearchItem item in controller.ResearchItems)
            {
                //Draw the nodes
                Button button = new();
                button.Text = item.Name;
                button.Location = new Point((int)item.Location.X, (int)item.Location.Y);
                button.Width = item.Width;
                button.Height = item.Height;
                this.Controls.Add(button);

                //Now draw the lines between the nodes
                int i = 0;
                foreach (Tuple<Vector3, Vector3> edge in item.Edges)
                {
                    i++;
                    Label line = new();
                    line.Name = item.Name + "prereq_line_" + i.ToString();
                    line.BorderStyle = BorderStyle.FixedSingle;
                    int width = 2;
                    int height = 2;
                    if (edge.Item1.X != edge.Item2.X)
                    {
                        width = (int)edge.Item2.X - (int)edge.Item1.X;
                    }
                    if (width < 0)
                    {
                        width *= -1;
                    }
                    if (edge.Item1.Y != edge.Item2.Y)
                    {
                        height = (int)edge.Item2.Y - (int)edge.Item1.Y;
                    }
                    if (height < 0)
                    {
                        height *= -1;
                    }
                    line.Size = new Size(width, height);
                    if (edge.Item1.Y <= edge.Item2.Y)
                    {
                        line.Location = new Point((int)edge.Item1.X, (int)edge.Item1.Y);
                    }
                    else
                    {
                        line.Location = new Point((int)edge.Item2.X, (int)edge.Item2.Y);
                    }
                    this.Controls.Add(line);
                }
            }
        }

        private void btnHideButtons_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (typeof(Button) == item.GetType())
                {
                    item.Visible = false;
                }
            }
        }
    }
}