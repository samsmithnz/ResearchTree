using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResearchTree;
using ResearchTree.Models;
using System;
using UnityEngine.UI;

public class MainLoop : MonoBehaviour
{
    public GameObject CanvasPrefab;

    // Start is called before the first frame update
    void Start()
    {
        List<ResearchItem> items = ResearchPool.BuildDemoList();
        ResearchController controller = new ResearchController(items,
            10, 10,
            5, 5);

        //Draw the nodes
        foreach (ResearchItem item in items)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = item.Name;
            cube.transform.position = new Vector3(item.Location.X, item.Location.Y, item.Location.Z);
            cube.transform.localScale = new Vector3(controller.ItemWidth, controller.ItemHeight, 1);

            GameObject cubeCanvas = GameObject.Instantiate(CanvasPrefab);
            cubeCanvas.transform.SetParent(cube.transform);
            cubeCanvas.transform.localPosition = new Vector3(0f, 0f, -1f);
            cubeCanvas.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            cubeCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
            cubeCanvas.GetComponent<CanvasScaler>().dynamicPixelsPerUnit = 1;
            Transform textTransform = cubeCanvas.transform.GetChild(0);
            textTransform.GetComponent<Text>().text = item.Name;

            int i = 0;
            foreach (Tuple<System.Numerics.Vector3, System.Numerics.Vector3> edge in item.Edges)
            {
                i++;
                //Label line = new();
                //line.Name = item.Name + "prereq_line_" + i.ToString();
                //line.BorderStyle = BorderStyle.FixedSingle;
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
                //line.Size = new Size(width, height);
                //if (edge.Item1.Y <= edge.Item2.Y)
                //{
                //    line.Location = new Point((int)edge.Item1.X, (int)edge.Item1.Y);
                //}
                //else
                //{
                //    line.Location = new Point((int)edge.Item2.X, (int)edge.Item2.Y);
                //}
                //this.Controls.Add(line);

                //create a line renderer
                GameObject lineCube = new GameObject();
                lineCube.name = item.Name + "prereq_line_" + i.ToString();
                lineCube.transform.position = Vector3.zero;
                lineCube.transform.localScale = new Vector3(controller.ItemWidth, controller.ItemHeight, 1);

                LineRenderer wayPointLine = lineCube.AddComponent<LineRenderer>();
                wayPointLine.startWidth = 1f;
                wayPointLine.endWidth = 1f;
                wayPointLine.SetPosition(0, new Vector3(edge.Item1.X, edge.Item1.Y, -1f));//edge.Item1.Z));
                wayPointLine.SetPosition(1, new Vector3(edge.Item2.X, edge.Item2.Y, -1f));//edge.Item2.Z));
                Debug.Log("Drawing line for " + item.Name + " from " + edge.Item1.ToString() + " to " + edge.Item2.ToString());
                wayPointLine.material.color = Color.white;
                //= LineMaterial;
                //if (movementCost <= 1)
                //{
                //    wayPointLine.material.color = Color.blue;
                //}
                //else
                //{
                //    wayPointLine.material.color = Colors.Names["boldorange"];
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
