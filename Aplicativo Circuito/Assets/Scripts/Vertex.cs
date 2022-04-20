using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public GameObject RightEdge;
    public GameObject UpEdge;
    public GameObject LeftEdge;
    public GameObject DownEdge;

    void Start()
    {
        if(RightEdge != null) SetVertexInEdge(RightEdge);
        if(UpEdge != null) SetVertexInEdge(UpEdge);
        if(LeftEdge != null) SetVertexInEdge(LeftEdge);
        if(DownEdge != null) SetVertexInEdge(DownEdge);
    }

    private void SetVertexInEdge(GameObject edge) {
        edge.GetComponent<Edge>().SetVertex(this.gameObject);
    }

    public void ActivateEdge(CommandType arrow) {
        if(arrow == CommandType.RightArrow && RightEdge != null) {
            RightEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.UpArrow && UpEdge != null) {
            UpEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.LeftArrow && LeftEdge != null) {
            LeftEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.DownArrow && DownEdge != null) {
            DownEdge.GetComponent<Edge>().ActivateEdge();
        }
    }

    public GameObject ChangeCurrentVertex(CommandType arrow, GameObject current) {
        if(arrow == CommandType.RightArrow && RightEdge != null) {
            return RightEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.UpArrow && UpEdge != null) {
            return UpEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.LeftArrow && LeftEdge != null) {
            return LeftEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.DownArrow && DownEdge != null) {
            return DownEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        return current;
    }
}
