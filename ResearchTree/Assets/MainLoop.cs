using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResearchTree;
using ResearchTree.Models;

public class MainLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<ResearchItem> items = ResearchPool.BuildDemoList();
        ResearchController controller = new ResearchController(items,
            16, 10,
            8, 5);

        //Draw the nodes
        foreach (ResearchItem item in items)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = item.Name;
            cube.transform.position = new Vector3(item.Location.X, item.Location.Y, item.Location.Z);
            cube.transform.localScale = new Vector3(controller.ItemWidth, controller.ItemHeight, 1);

            //Button button = new();
            //button.Text = item.Name;
            //button.Location = new Point((int)item.Location.X, (int)item.Location.Y);
            //button.Width = item.Width;
            //button.Height = item.Height;
            //this.Controls.Add(button);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
