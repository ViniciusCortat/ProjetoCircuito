using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour
{
    private bool Activated = false;
    private GameObject Vertex1;
    private GameObject Vertex2;

    public void ActivateEdge() {
        Activated = true;
        GetComponent<Image>().color = Color.yellow;
    }

    public void SetVertex(GameObject vertex) {
        if(Vertex1 == null) {
            Vertex1 = vertex;
        }
        else {
            if(Vertex2 == null) {
                Vertex2 = vertex;
            }  
        }
    }

    public bool isActivated() {
        return Activated;
    }

    public GameObject ChangeCurrentVertex(GameObject current) {
        if(GameObject.ReferenceEquals(Vertex1,current)) {
            return Vertex2;
        }
        return Vertex1;
    }

    public void Reset() {
        GetComponent<Image>().color = Color.black;
        Activated = false;
    }
}
