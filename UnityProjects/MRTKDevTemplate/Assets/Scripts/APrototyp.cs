using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GraphVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private GameObject graphContainer;
    [SerializeField] private GameObject edgePrefab;
    [SerializeField] private TextMesh labelPrefab;

    private void Start()
    {
   
        string jsonContent = File.ReadAllText("graph_data.json");//možno bude treba zmeniť 
        GraphData graphData = JsonUtility.FromJson<GraphData>(jsonContent);

        
        foreach (var node in graphData.nodes)//Vytvorenie uzlov
        {
            Vector3 position = new Vector3(node.position[0], node.position[1], node.position[2]);
            GameObject nodeObject = Instantiate(nodePrefab, position, Quaternion.identity, graphContainer.transform);
            nodeObject.name = "Node " + node.id;

            TextMesh label = Instantiate(labelPrefab, position, Quaternion.identity, nodeObject.transform);
            label.name = "Label " + node.id;
            label.text = "Label " + node.id;
        }

        
        foreach (var edge in graphData.edges)//Vytvorenie hrán
        {
            GameObject sourceNode = GameObject.Find("Node " + edge.source);
            GameObject targetNode = GameObject.Find("Node " + edge.target);
            if (sourceNode != null && targetNode != null)
            {
                GameObject edgeObject = Instantiate(edgePrefab, Vector3.zero, Quaternion.identity, graphContainer.transform);
                LineRenderer lineRenderer = edgeObject.GetComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, sourceNode.transform.localPosition);
                lineRenderer.SetPosition(1, targetNode.transform.localPosition);
            }
        }

        
        graphContainer.transform.localScale = new Vector3(1f, 1f, 1f); //Prispôsobenie mierky (nechytala by som sa toho :D)
        graphContainer.transform.localPosition = new Vector3(0f, 0f, 0f); //Prispôsobenie pozície
    }
}

[System.Serializable]
public class GraphData
{
    public List<NodeData> nodes;
    public List<EdgeData> edges;
}

[System.Serializable]
public class NodeData
{
    public int id;
    public List<float> position;
}

[System.Serializable]
public class EdgeData
{
    public int source;
    public int target;
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//public class GraphVisualizer : MonoBehaviour
//{
//    [SerializeField] private GameObject nodePrefab;
//    [SerializeField] private GameObject graphContainer;
//    [SerializeField] private GameObject edgePrefab;
//    [SerializeField] private TextMesh labelPrefab;

//    private void Start()
//    {
//        string jsonContent = File.ReadAllText("C:/Users/lerac/MixedRealityToolkit-Unity/UnityProjects/MRTKDevTemplate/graph_data.json");
//        GraphData graphData = JsonUtility.FromJson<GraphData>(jsonContent);

//        foreach (var node in graphData.nodes)
//        {
//            Vector3 position = new Vector3(node.position[0], node.position[1], node.position[2]);
//            GameObject nodeObject = Instantiate(nodePrefab, position, Quaternion.identity, graphContainer.transform);
//            nodeObject.name = "Node " + node.id.ToString();

//            TextMesh label = Instantiate(labelPrefab, position, Quaternion.identity, graphContainer.transform);
//            label.name = "Label " + node.id.ToString();
//            label.text = node.id.ToString();
//        }

//        foreach (var edge in graphData.edges)
//        {
//            GameObject sourceNode = GameObject.Find("Node " + edge.source.ToString());
//            GameObject targetNode = GameObject.Find("Node " + edge.target.ToString());
//            if (sourceNode != null && targetNode != null)
//            {
//                GameObject edgeObject = Instantiate(edgePrefab, graphContainer.transform);
//                LineRenderer lineRenderer = edgeObject.GetComponent<LineRenderer>();
//                lineRenderer.SetPosition(0, sourceNode.transform.position);
//                lineRenderer.SetPosition(1, targetNode.transform.position);
//            }
//        }
//    }
//}

//[System.Serializable]
//public class GraphData
//{
//    public List<NodeData> nodes;
//    public List<EdgeData> edges;
//}

//[System.Serializable]
//public class NodeData
//{
//    public int id;
//    public List<float> position;
//}

//[System.Serializable]
//public class EdgeData
//{
//    public int source;
//    public int target;
//}
