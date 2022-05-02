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
        if(arrow == CommandType.RightArrow && RightEdge != null  && RightEdge.activeSelf) {
            RightEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.UpArrow && UpEdge != null && UpEdge.activeSelf) {
            UpEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.LeftArrow && LeftEdge != null && LeftEdge.activeSelf) {
            LeftEdge.GetComponent<Edge>().ActivateEdge();
        }
        if(arrow == CommandType.DownArrow && DownEdge != null && DownEdge.activeSelf) {
            DownEdge.GetComponent<Edge>().ActivateEdge();
        }
    }

    public GameObject ChangeCurrentVertex(CommandType arrow, GameObject current) {
        if(arrow == CommandType.RightArrow && RightEdge != null && !IsEdgeActivated(RightEdge) && RightEdge.activeSelf) {
            return RightEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.UpArrow && UpEdge != null && !IsEdgeActivated(UpEdge) && UpEdge.activeSelf) {
            return UpEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.LeftArrow && LeftEdge != null && !IsEdgeActivated(LeftEdge) && LeftEdge.activeSelf) {
            return LeftEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        if(arrow == CommandType.DownArrow && DownEdge != null && !IsEdgeActivated(DownEdge) && DownEdge.activeSelf) {
            return DownEdge.GetComponent<Edge>().ChangeCurrentVertex(current);
        }
        return current;
    }

    private bool IsEdgeActivated(GameObject edge) {
        return edge.GetComponent<Edge>().isActivated();
    }
}
