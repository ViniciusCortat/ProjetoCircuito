using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Led : MonoBehaviour
{
    
    public Edge connectedEdge;

    private GameObject edge;
    private GameObject lightbuld;

    private bool IsActive = false;


    void Start()
    {
        lightbuld = transform.GetChild(0).gameObject;
        edge = transform.GetChild(2).gameObject;
    }

    
    void Update()
    {
        if(connectedEdge.isActivated()) {
            lightbuld.SetActive(true);
            edge.GetComponent<Image>().color = Color.yellow;
            IsActive = true;
        }
    }

    public void Reset() {
        lightbuld.SetActive(false);
        edge.GetComponent<Image>().color = Color.black;
        IsActive = false;
    }

    public bool LightOn() {
        return IsActive;
    }
}
