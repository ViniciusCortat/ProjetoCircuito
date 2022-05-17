using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditional 
{
    public Conditional() {
        ifCommands = new List<CommandType>();
        elseCommands = new List<CommandType>();
    }

    private List<CommandType> ifCommands;
    private List<CommandType> elseCommands;
    private bool IfSelected = true;
    private bool IfRunning = true;

    private GameObject CurrentVertexC;

    public void AddCommand(CommandType command) {
        if(IfSelected) {
            ifCommands.Add(command);
        }
        else {
            elseCommands.Add(command);
        }
    }

    public List<CommandType> GetCommandByRunning() {
        if(IfRunning) {
            return ifCommands;
        }
        else {
            return elseCommands;
        }
    }

    public CommandType GetCommandBySelected(int index) {
        if(IfSelected) {
            return ifCommands[index];
        }
        else {
            return elseCommands[index];
        }
    }

    public List<CommandType> GetCommandListBySelected() {
        if(IfSelected) {
            return ifCommands;
        }
        else {
            return elseCommands;
        }
    }

    public void SwitchRunning() {
        IfRunning = !IfRunning;
    }

    public void SetCommand(bool ifOrelse) {
        IfSelected = ifOrelse;
    }

    public int Index() {
        if(IfSelected) {
            return ifCommands.Count;
        }
        else {
            return elseCommands.Count;
        }
    }

    public bool IsEmpty() {
        if(ifCommands.Count == 0 && elseCommands.Count == 0) {
            return true;
        }
        return false;
    }

    public bool WasUsed() {
        if(ifCommands.Count == 0 || elseCommands.Count == 0) {
            return false;
        }
        return true;
    }

    public void Clear() {
        ifCommands.Clear();
        elseCommands.Clear();
    }

    public bool IfOrElse() {
        return IfSelected;
    }

    public bool IfOrElseRunning() {
        return IfRunning;
    }

    public IEnumerator ReadCommands(GameObject currentVertex) {
        for(int i=0; i < GetCommandByRunning().Count; i++) {
            yield return new WaitForSeconds(0.5f);
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(GetCommandByRunning()[i]) {
                case CommandType.L1:
                    break;
                case CommandType.L2:
                    break;
                case CommandType.L3:
                    break;
                case CommandType.L4:
                    break;
                default:
                    currentVertex = current.ChangeCurrentVertex(GetCommandByRunning()[i],currentVertex);
                    current.ActivateEdge(GetCommandByRunning()[i]);
                    break;
            }
        }
        CurrentVertexC = currentVertex;
    }

    public GameObject CurrentVertex() {
        return CurrentVertexC;
    }
}
