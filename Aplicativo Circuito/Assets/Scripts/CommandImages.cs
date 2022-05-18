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
        SetImage(type,o.GetComponent<Image>());
        RotateImage(type,o);
        CommandsCreated.Add(o);
    }

    public void CreateConditionalImage(int i, CommandType type, bool ifOrelse) {
        Vector2 position;
        if(ifOrelse) {
            position = new Vector2(InitialPosition.x + i*55, InitialPosition.y);
        }
        else {
            position = new Vector2(InitialPosition.x + i*55, InitialPosition.y - 125);
        }
        GameObject o = Instantiate(ImagePrefab, position, Quaternion.identity);
        o.transform.SetParent(this.gameObject.transform, false);
        SetImage(type,o.GetComponent<Image>());
        RotateImage(type,o);
        CommandsCreated.Add(o);
    }

    public void CreateRepetitionText(int i, GameObject text) {
        GameObject p = Instantiate(text, new Vector2(14,-4), Quaternion.identity);
        p.transform.SetParent(CommandsCreated[i].transform,false);
    }

    public void Reset() {
        for(int i=0;i<CommandsCreated.Count;i++) {
            Destroy(CommandsCreated[i]);
        }
        CommandsCreated.Clear();
    }

    private void SetImage(CommandType type, Image o) {
        switch(type) {
            case CommandType.C:
                o.sprite = C1.sprite;
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
