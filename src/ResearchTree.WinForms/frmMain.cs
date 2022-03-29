using ResearchTree.Models;
using System.Numerics;

namespace ResearchTree.WinForms
{
    public partial class frmMain : Form
    {
        private readonly ResearchController _controller;

        public frmMain()
        {
            InitializeComponent();

            _controller = new(ResearchPool.BuildDemoList(),
                100, 100,//162, 100,
                50, 50);// 81, 50);

            foreach (ResearchItem item in _controller.ResearchItems)
            {
                //Draw the nodes
                Button button = new();
                button.Text = item.Name;
                button.Location = new Point((int)item.Location.X - (item.Width / 2), (int)item.Location.Y - (item.Height / 2));
                button.Width = item.Width;
                button.Height = item.Height;
                button.Click += (s, e) => { MessageBox.Show(button.Location.ToString()); };
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
                    line.Location = new Point((int)edge.Item1.X, (int)edge.Item1.Y);
                    //if (edge.Item1.Y == edge.Item2.Y)
                    //{
                    //    line.Location = new Point((int)edge.Item1.X, (int)edge.Item1.Y + (item.Height / 2));
                    //}
                    //else if(edge.Item1.Y > edge.Item2.Y)
                    //{
                    //    line.Location = new Point((int)edge.Item2.X , (int)edge.Item2.Y - (item.Height / 1));
                    //}
                    //else if (edge.Item1.Y < edge.Item2.Y)
                    //{
                    //    line.Location = new Point((int)edge.Item2.X , (int)edge.Item2.Y - (item.Height / 1));
                    //}
                    this.Controls.Add(line);
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BringToFront();
                }
                else
                {
                    control.SendToBack();
                }
            }

            //Add workers to combo
            AddWorkersToCombo();
            UpdateForm();
        }

        private void btnAddTick_Click(object sender, EventArgs e)
        {
            _controller.AddTick();
            UpdateForm();
        }

        private void AddWorkersToCombo()
        {
            cboWorkers.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cboWorkers.Items.Add(i.ToString() + " workers");
            }
            cboWorkers.SelectedIndex = 0;
        }

        private void UpdateForm()
        {
            //Get available research
            List<ResearchItem> availableItems = _controller.GetUnstartedResearchItems();
            lstAvailableItems.Items.Clear();
            if (availableItems != null)
            {
                foreach (ResearchItem? item in availableItems)
                {
                    lstAvailableItems.Items.Add(new ListViewItem(new string[] { item.Name }));
                }
            }

            //Get research in progress
            List<ResearchItem> currentItems = _controller.GetUnstartedResearchItems();
            lstCurrentItems.Items.Clear();
            if (currentItems != null)
            {
                foreach (ResearchItem? item in currentItems)
                {
                    lstCurrentItems.Items.Add(new ListViewItem(new string[] { item.Name, item.WorkCompleted.ToString() }));
                }
            }

        }

        private void btnStartResearch_Click(object sender, EventArgs e)
        {
            if (lstAvailableItems.SelectedItems.Count > 0)
            {
                ResearchItem item = _controller.FindItem(_controller.ResearchItems, lstAvailableItems.SelectedItems[0].Text);
                item.WorkersAssigned += 1;// _controller.WorkersAvailable;
                UpdateForm();
            }
        }
    }
}