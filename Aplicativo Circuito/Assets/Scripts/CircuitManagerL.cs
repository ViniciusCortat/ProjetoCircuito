using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CircuitManagerL : MonoBehaviour
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
    public CommandImages LoopCommandLine;
    public List<CommandImages> LCommandLine;
    public List<Led> Leds;
    public List<GameObject> Edges;
    public int LoopsLimit;
    public GameObject repetitionText;
    private List<CommandType> Commands;
    private List<CommandType> CommandsLoop;
    private List<Loop> Loops;
    private GameObject currentVertex;
    private bool LoopSelected = false;
    private Coroutine coroutine;
    private List<int> Repetitions;
    private int RepetitionsIndex;

    void Start()
    {
        currentVertex = FontePositive;
        Commands = new List<CommandType>();
        CommandsLoop = new List<CommandType>();
        Loops = new List<Loop>();
        Repetitions = new List<int>();
        RepetitionsIndex = 0;
        for(int i=0;i<4;i++) {
            Loop loop = new Loop();
            Loops.Add(loop);
        }
        StartCoroutine(DisableCommand());
    }

    private IEnumerator DisableCommand() {
        yield return new WaitForSeconds(0.01f);
        for(int i=0;i<4;i++) {
            LCommandLine[i].gameObject.SetActive(false);
        }
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
            if(CommandsLoop.Count < LoopsLimit) {
                CommandsLoop.Add((CommandType) command);
                LoopCommandLine.CreateImage(CommandsLoop.Count - 1, (CommandType) command);
            }   
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
        Repetitions.Clear();
        RepetitionsIndex = 0;
    }

    public void ClearLList(int i) {
        LCommandLine[i].Reset();
    }

    public void SwitchLoop() {
        LoopSelected = !LoopSelected;
    }

    public void CopyLoopCommands(int i) {
        Loops[i].Copy(CommandsLoop);
        for(int j=0;j<Loops[i].ListSize();j++) {
            LCommandLine[i].CreateImage(j, Loops[i].CurrentCommand(j));
        }
        ClearLoopCommandLine();
    }

    public void ClearLoopCommandLine() {
        CommandsLoop.Clear();
        LoopCommandLine.Reset();
    }

    public void AddRepetition(int n) {
        Repetitions.Add(n);
        repetitionText.GetComponent<TextMeshProUGUI>().text = $"{Repetitions[Repetitions.Count - 1]}";
        MainCommandLine.CreateRepetitionText(Commands.Count - 1, repetitionText);
    }

    private IEnumerator ReadCommands() {
        for(int i=0; i < Commands.Count; i++) {
            yield return new WaitForSeconds(0.5f);
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(Commands[i]) {
                case CommandType.L1:
                    for(int j=0;j<Repetitions[RepetitionsIndex];j++) {
                        yield return StartCoroutine(Loops[0].ReadCommands(currentVertex));
                        currentVertex = Loops[0].CurrentVertex();
                    }
                    if(Loops[0].ListSize() != 0) {
                        RepetitionsIndex++;
                    }
                    break;
                case CommandType.L2:
                   for(int j=0;j<Repetitions[RepetitionsIndex];j++) {
                        yield return StartCoroutine(Loops[1].ReadCommands(currentVertex));
                        currentVertex = Loops[1].CurrentVertex();
                    }
                    if(Loops[1].ListSize() != 0) {
                        RepetitionsIndex++;
                    }
                    break;
                case CommandType.L3:
                    for(int j=0;j<Repetitions[RepetitionsIndex];j++) {
                        yield return StartCoroutine(Loops[2].ReadCommands(currentVertex));
                        currentVertex = Loops[2].CurrentVertex();
                    }
                    if(Loops[2].ListSize() != 0) {
                        RepetitionsIndex++;
                    }
                    break;
                case CommandType.L4:
                   for(int j=0;j<Repetitions[RepetitionsIndex];j++) {
                        yield return StartCoroutine(Loops[3].ReadCommands(currentVertex));
                        currentVertex = Loops[3].CurrentVertex();
                    }
                    if(Loops[3].ListSize() != 0) {
                        RepetitionsIndex++;
                    }
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
