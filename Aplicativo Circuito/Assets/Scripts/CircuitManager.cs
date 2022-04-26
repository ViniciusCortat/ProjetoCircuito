using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    public static CircuitManager Instance { get; private set; }
    private void Awake() 
    {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public GameObject FontePositive;
    public GameObject FonteNegative;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject PlayIsActivePanel;
    public int CommandLimit;
    public CommandImages MainCommandLine;
    public List<Led> Leds;
    public List<GameObject> Edges;
    private List<CommandType> Commands;
    private List<Loop> Loops;
    private List<Conditional> Conditionals;
    private GameObject currentVertex;
    private bool LoopSelected = false;
    private bool ConditionalSelected = false;

    void Start()
    {
        Reset();
        Commands = new List<CommandType>();
        Loops = new List<Loop>();
        Conditionals = new List<Conditional>();
    }

    void Update()
    {
        PuzzleCompleted();
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
            if(Conditionals[Conditionals.Count - 1].IsBaseSelected()) {
                Conditionals[Conditionals.Count - 1].AddBaseCommand((CommandType) command);
            }
            else {
                Conditionals[Conditionals.Count - 1].AddElseCommand((CommandType) command);
            }
        }
    }

    public void Play() {
        ReadCommands();
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
        PlayIsActivePanel.SetActive(true);
    }

    public void Pause() {
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

    public void AddConditional() {
        Conditional conditional = new Conditional();
        Conditionals.Add(conditional);
        ConditionalSelected = true;
    }

    private void ReadCommands() {
        for(int i=0; i < Commands.Count; i++) {
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(Commands[i]) {
                case CommandType.C1:
                    break;
                case CommandType.C2:
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

    private void PuzzleCompleted() {
        if(LightbuldCompleted() && FonteNegative.GetComponent<Vertex>().RightEdge.GetComponent<Edge>().isActivated()) {
            Debug.Log("Completo!");
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
