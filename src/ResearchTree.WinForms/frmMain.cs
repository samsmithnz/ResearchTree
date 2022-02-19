using ResearchTree.Models;

namespace ResearchTree.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            ResearchController controller = new ResearchController();
            List<ResearchItem> items = controller.BuildDemoList(162, 100);

            int horizontalBuffer = items[0].Width / 2;
            int verticalBuffer = items[0].Height / 2;

            //Draw the nodes
            foreach (ResearchItem item in items)
            {
                Button button = new();
                button.Text = item.Name;
                button.Location = new Point((int)item.Location.X, (int)item.Location.Y);
                button.Width = item.Width;
                button.Height = item.Height;
                this.Controls.Add(button);
            }

            //Now draw the lines between the nodes
            foreach (ResearchItem item in items)
            {
                if (item.PreReqs.Count > 0) //item.Name == "H" &&
                {
                    foreach (string prereq in item.PreReqs)
                    {
                        ResearchItem prereqItem = controller.FindItem(prereq);
                        int horizontalGap = (int)(item.Location.X - prereqItem.Location.X);
                        if (horizontalGap < 0)
                        {
                            horizontalGap *= -1;
                        }

                        //If the item is at the same Y position, draw a single straight line
                        if (prereqItem.Location.Y == item.Location.Y)
                        {
                            Label horizontalLine1 = new();
                            horizontalLine1.Name = prereqItem.Name + "_Label1";
                            horizontalLine1.BorderStyle = BorderStyle.FixedSingle;
                            horizontalLine1.Size = new Size(horizontalBuffer, 2);
                            int x1 = (int)prereqItem.Location.X + prereqItem.Width;
                            int y1 = (int)prereqItem.Location.Y + verticalBuffer;
                            horizontalLine1.Location = new Point(x1, y1);
                            this.Controls.Add(horizontalLine1);
                        }
                        else //if (prereqItem.Name == "D")
                        {
                            //We need to add two half horizontal lines, and a vertical line
                            Label horizontalLine1 = new();
                            horizontalLine1.Name = prereqItem.Name + "_Label1";
                            horizontalLine1.BorderStyle = BorderStyle.FixedSingle;
                            horizontalLine1.Size = new Size(horizontalGap - prereqItem.Width - (horizontalBuffer / 2), 2);
                            int x1 = (int)prereqItem.Location.X + prereqItem.Width;
                            int y1 = (int)prereqItem.Location.Y + verticalBuffer;
                            horizontalLine1.Location = new Point(x1, y1);
                            this.Controls.Add(horizontalLine1);

                            Label horizontalLine2 = new();
                            horizontalLine2.Name = prereqItem.Name + "_Label2";
                            horizontalLine2.BorderStyle = BorderStyle.FixedSingle;
                            horizontalLine2.Size = new Size(horizontalBuffer / 2, 2);
                            int x2 = (int)item.Location.X - (horizontalBuffer / 2);
                            int y2 = (int)item.Location.Y + verticalBuffer;
                            horizontalLine2.Location = new Point(x2, y2);
                            this.Controls.Add(horizontalLine2);

                            Label vecticalLine3 = new();
                            vecticalLine3.Name = prereqItem.Name + "_Label3";
                            vecticalLine3.BorderStyle = BorderStyle.FixedSingle;
                            int verticalLineHeight = (int)item.Location.Y - (int)prereqItem.Location.Y;
                            if (prereqItem.Location.Y > item.Location.Y)
                            {
                                verticalLineHeight = (int)prereqItem.Location.Y - (int)item.Location.Y;
                            }
                            vecticalLine3.Size = new Size(2, verticalLineHeight);
                            int x3 = (int)item.Location.X - (horizontalBuffer / 2);
                            int y3 = (int)prereqItem.Location.Y + verticalBuffer;
                            if (prereqItem.Location.Y > item.Location.Y)
                            {
                                y3 -= ((int)prereqItem.Location.Y - item.Height) + verticalBuffer;
                            }
                            vecticalLine3.Location = new Point(x3, y3);
                            this.Controls.Add(vecticalLine3);
                        }
                    }


                }
            }

            foreach (Control item in this.Controls)
            {
                comboBox1.Items.Add(item.Name);
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