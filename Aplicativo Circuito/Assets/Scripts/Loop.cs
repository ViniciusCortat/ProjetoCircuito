using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop
{
    public Loop() {
        commands = new List<CommandType>();
    }
    private List<CommandType> commands;
    private GameObject CurrentVertexL;

    public void AddCommand(CommandType command) {
        commands.Add(command);
    }

    public CommandType CurrentCommand(int index) {
        return commands[index];
    }

    public void Copy(List<CommandType> list) {
        commands = new List<CommandType>(list);
    }

    public int ListSize() {
        return commands.Count;
    }

    public IEnumerator ReadCommands(GameObject currentVertex) {
        for(int i=0; i < commands.Count; i++) {
            yield return new WaitForSeconds(0.5f);
            Vertex current = currentVertex.GetComponent<Vertex>();
            switch(commands[i]) {
                case CommandType.L1:
                    break;
                case CommandType.L2:
                    break;
                case CommandType.L3:
                    break;
                case CommandType.L4:
                    break;
                default:
                    currentVertex = current.ChangeCurrentVertex(commands[i],currentVertex);
                    current.ActivateEdge(commands[i]);
                    break;
            }
        }
        CurrentVertexL = currentVertex;
    }

    public GameObject CurrentVertex() {
        return CurrentVertexL;
    }
}
