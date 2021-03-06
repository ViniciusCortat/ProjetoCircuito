using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircuitManager : MonoBehaviour
{
    public int MelhorCaminho;
    public int DesafioLevel;
    public GameObject FontePositive;
    public GameObject FonteNegative;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject PlayIsActivePanel;
    public GameObject ResultPanel;
    public GameObject MenuPanel;
    public TextMeshProUGUI ResultText;
    public int CommandLimit;
    public CommandImages MainCommandLine;
    public List<Led> Leds;
    public List<GameObject> Edges;
    private List<CommandType> Commands;
    private List<Loop> Loops;
    private GameObject currentVertex;
    private bool LoopSelected = false;
    private Coroutine coroutine;

    void Start()
    {
        currentVertex = FontePositive;
        Commands = new List<CommandType>();
        Loops = new List<Loop>();
    }

    void Update()
    {
        PuzzleCompleted();
    }

    public void AddCommand(int command) {
        if(!LoopSelected) {
            if(Commands.Count < CommandLimit) {
                Commands.Add((CommandType) command);
                MainCommandLine.CreateImage(Commands.Count - 1, (CommandType) command);
            }
        }
        if(LoopSelected) {
            Loops[Loops.Count - 1].AddCommand((CommandType) command);
        }
    }

    public void OpenMenuPanel() {
        MenuPanel.SetActive(true);
    }

    public void Play() {
        coroutine = StartCoroutine(ReadCommands());
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
        PlayIsActivePanel.SetActive(true);
    }

    public void Pause() {
        if(coroutine != null) StopCoroutine(coroutine);
        Reset();
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
        PlayIsActivePanel.SetActive(false);
    }

    public void ClearList() {
        Commands.Clear();
        MainCommandLine.Reset();
    }

    public void AddLoop() {
        Loop loop = new Loop();
        Loops.Add(loop);
        LoopSelected = true;
    }

    private IEnumerator ReadCommands() {
        for(int i=0; i < Commands.Count; i++) {
            yield return new WaitForSeconds(0.5f);
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(Commands[i]) {
                case CommandType.L1:
                    break;
                case CommandType.L2:
                    break;
                case CommandType.L3:
                    break;
                case CommandType.L4:
                    break;
                default:
                    currentVertex = current.ChangeCurrentVertex(Commands[i],currentVertex);
                    current.ActivateEdge(Commands[i]);
                    break;
            }
        }
    }

    private void Reset() {
        currentVertex = FontePositive;
        foreach(GameObject e in Edges) {
            e.GetComponent<Edge>().Reset();
        }
        foreach(Led led in Leds) {
            led.Reset();
        }
    }

    private void PuzzleCompleted() {
        if(LightbuldCompleted() && FonteNegative.GetComponent<Vertex>().RightEdge.GetComponent<Edge>().isActivated()) {
            if(Commands.Count <= MelhorCaminho) {
                ResultText.text = "<color=#11FF00>Melhor Caminho Alcan??ado!</color>";
                Puzzles.GetInstance().SetStatus("Best", DesafioLevel-1);
            }
            else {
                ResultText.text = "<color=#FF0000>Melhor Caminho n??o foi Alcan??ado!</color>";
                Puzzles.GetInstance().SetStatus("Completo", DesafioLevel-1);
            }
            ResultPanel.SetActive(true);
        }
    }

    private bool LightbuldCompleted() {
        foreach(Led led in Leds) {
            if(!led.LightOn()) {
                return false;
            }
        }
        return true;
        
    }
}
