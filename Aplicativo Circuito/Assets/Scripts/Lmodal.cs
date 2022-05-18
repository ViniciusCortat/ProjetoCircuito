using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lmodal : MonoBehaviour
{
    public CircuitManagerL CML;
    public List<GameObject> Loops;
    public List<Button> allbuttons;
    public GameObject ErrorPanel;
    private int LN;
    private int LoopSelected;

    void OnEnable() {
        CML.SwitchLoop();
        foreach(GameObject o in Loops) {
            o.SetActive(false);
        }
        foreach(Button button in allbuttons) {
            button.interactable = false;
        }
    }

    void OnDisable() {
        CML.SwitchLoop();
        for(int i=0;i<LN;i++) {
            Loops[i].SetActive(true);
        }
        foreach(Button button in allbuttons) {
            button.interactable = true;
        }
    }

    void Start()
    {
        LN = 0;
        LoopSelected = 0;
    }

    
    void Update()
    {
        
    }

    public void CreateOrUpdate() {
        if(LoopSelected  == 0) {
            CreateLoop();
        }
        else {
            UpdateLoop();
        }
        gameObject.SetActive(false);
    }

    public void ChooseLoopSelected(int number) {
        LoopSelected = number;
    }

    private void CreateLoop() {
        if(LN == 4) {
            ErrorPanel.SetActive(true);
            CML.ClearLoopCommandLine();
        }
        else {
            CML.CopyLoopCommands(LN);
            LN++;
        } 
    }

    private void UpdateLoop() {
        CML.CopyLoopCommands(LoopSelected - 1);
    }
}
