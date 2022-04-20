using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandImages : MonoBehaviour
{
    public Vector2 InitialPosition;
    public GameObject ImagePrefab;
    public Image Arrow;
    public Image C1;
    public Image C2;
    public Image L1;
    public Image L2;
    public Image L3;
    public Image L4;

    private List<GameObject> CommandsCreated;

    void Start() 
    {
        CommandsCreated = new List<GameObject>();    
    }

    public void CreateImage(int i, CommandType type) {
        Vector2 pos = new Vector2(InitialPosition.x + i*55, InitialPosition.y);
        GameObject o = Instantiate(ImagePrefab, pos, Quaternion.identity);
        o.transform.SetParent(this.gameObject.transform, false);
        //o.transform.position = pos;
        SetImage(type,o.GetComponent<Image>());
        RotateImage(type,o);
        CommandsCreated.Add(o);
    }

    public void Reset() {
        foreach(GameObject o in CommandsCreated) {
            Destroy(o);
        }
        CommandsCreated.Clear();
    }

    private void SetImage(CommandType type, Image o) {
        switch(type) {
            case CommandType.C1:
                o.sprite = C1.sprite;
                break;
            case CommandType.C2:
                o.sprite = C2.sprite;
                break;
            case CommandType.L1:
                o.sprite = L1.sprite;
                break;
            case CommandType.L2:
                o.sprite = L2.sprite;
                break;
            case CommandType.L3:
                o.sprite = L3.sprite;
                break;
            case CommandType.L4:
                o.sprite = L4.sprite;
                break;
            default:
                o.sprite = Arrow.sprite;
                break;
            }
    }

    private void RotateImage(CommandType type, GameObject o) {
        switch(type) {
            case CommandType.UpArrow:
                o.transform.Rotate(0,0,90, Space.World);
                break;
            case CommandType.LeftArrow:
                o.transform.Rotate(0,0,180, Space.World);
                break;
            case CommandType.DownArrow:
                o.transform.Rotate(0,0,270, Space.World);
                break;
        }
    }
}
