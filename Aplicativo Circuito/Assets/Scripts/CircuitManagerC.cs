using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CircuitManagerC : MonoBehaviour
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
    private bool ConditionalSelected = false;
    private Coroutine coroutine;
    [HideInInspector]
    public Conditional conditional;
    public CommandImages ConditionalCommandLine;
    public CommandImages CList;
    public GameObject conditionalEdge;
    public GameObject CompletedCondPanel;
    public TextMeshProUGUI ResultCondText;
    public GameObject CompletedCondPanel2;
    public TextMeshProUGUI ResultCondText2;
    private Sprite CondEdgeSprite;

    void Start()
    {
        currentVertex = FontePositive;
        Commands = new List<CommandType>();
        Loops = new List<Loop>();
        conditional = new Conditional();
        CondEdgeSprite = conditionalEdge.GetComponent<Image>().sprite;
        CList.gameObject.SetActive(false);
    }

    void Update()
    {
        ConditionalPuzzleCompleted();
    }

    public void AddCommand(int command) {
        if(!LoopSelected && !ConditionalSelected) {
            if(Commands.Count < CommandLimit) {
                Commands.Add((CommandType) command);
                MainCommandLine.CreateImage(Commands.Count - 1, (CommandType) command);
            }
        }
        if(LoopSelected) {
            Loops[Loops.Count - 1].AddCommand((CommandType) command);
        }
        if(ConditionalSelected) {
            conditional.AddCommand((CommandType) command);
            ConditionalCommandLine.CreateConditionalImage(conditional.Index() - 1, (CommandType) command, conditional.IfOrElse());
        }
    }

    public void OpenMenuPanel() {
        MenuPanel.SetActive(true);
    }

    public void Play() {
        if(conditional.IfOrElseRunning()) {
            conditionalEdge.GetComponent<Image>().sprite = null;
        }
        else {
            conditionalEdge.SetActive(false);
        }
        coroutine = StartCoroutine(ReadCommands());
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
        PlayIsActivePanel.SetActive(true);
    }

    public void Pause() {
        StopCoroutine(coroutine);
        Reset();
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
        PlayIsActivePanel.SetActive(false);
        conditionalEdge.GetComponent<Image>().sprite = CondEdgeSprite;
    }

    public void ClearList() {
        Commands.Clear();
        MainCommandLine.Reset();
    }

    public void EnableCList() {
        if(!conditional.IsEmpty()) {
            CList.gameObject.SetActive(true);
            CList.Reset();
            conditional.SetCommand(true);
            for(int i=0;i<conditional.Index();i++) {
                CList.CreateConditionalImage(i,conditional.GetCommandBySelected(i),conditional.IfOrElse());
            }
            conditional.SetCommand(false);
            for(int i=0;i<conditional.Index();i++) {
                CList.CreateConditionalImage(i,conditional.GetCommandBySelected(i),conditional.IfOrElse());
            }
            conditional.SetCommand(true);
        }
    }

    public void ClearCList() {
        conditional.Clear();
        ConditionalCommandLine.Reset();
    }

    public void AddLoop() {
        Loop loop = new Loop();
        Loops.Add(loop);
        LoopSelected = true;
    }

    public void SwitchConditional() {
        ConditionalSelected = !ConditionalSelected;
    }

    public void PlaySecondCond() {
        conditional.SwitchRunning();
        CompletedCondPanel.SetActive(false);
        Reset();
        Play();
    }

    public void FinishConditional() {
        CompletedCondPanel2.SetActive(false);
        PuzzleCompleted();
    }

    private IEnumerator ReadCommands() {
        for(int i=0; i < Commands.Count; i++) {
            yield return new WaitForSeconds(0.5f);
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(Commands[i]) {
                case CommandType.C:
                    if(current.CheckForConditionalEdge(conditionalEdge)) {
                        //conditional.ReadCommands(current);
                    }
                    break;
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

    private void ConditionalPuzzleCompleted() {
        if(LightbuldCompleted() && FonteNegative.GetComponent<Vertex>().RightEdge.GetComponent<Edge>().isActivated()) {
            if(!conditional.IsEmpty()) {
                if(conditional.IfOrElseRunning()) {
                    CompletedCondPanel.SetActive(true);
                }
                else {
                    CompletedCondPanel2.SetActive(true);
                }
            }
            else { 
                PuzzleCompleted();
            }
        }
    }

    private void PuzzleCompleted() {
        if(LightbuldCompleted() && FonteNegative.GetComponent<Vertex>().RightEdge.GetComponent<Edge>().isActivated()) {
            if(Commands.Count <= MelhorCaminho) {
                ResultText.text = "<color=#11FF00>Melhor Caminho Alcançado!</color>";
                Puzzles.GetInstance().SetStatus("Best", DesafioLevel-1);
            }
            else {
                ResultText.text = "<color=#FF0000>Melhor Caminho não foi Alcançado!</color>";
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
