using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cmodal : MonoBehaviour
{
    public CircuitManagerC CMC;
    public GameObject SelectedImage;
    public List<Button> allbuttons;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnEnable() {
        CMC.SwitchConditional();
        GoIfCommand();
        foreach(Button button in allbuttons) {
            button.interactable = false;
        }
    }

    void OnDisable() {
        CMC.SwitchConditional();
         foreach(Button button in allbuttons) {
            button.interactable = true;
        }
    }

    public void GoIfCommand() {
        SelectedImage.transform.localPosition = new Vector2(31,105);
        CMC.conditional.SetCommand(true);
    }

    public void GoElseCommand() {
        SelectedImage.transform.localPosition = new Vector2(31,-20);
        CMC.conditional.SetCommand(false);
    }
}
