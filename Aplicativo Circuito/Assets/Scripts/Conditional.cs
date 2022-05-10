using System.Collections;
using System.Collections.Generic;

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

    // public IEnumerator ReadCommands(Vertex current) {

    // }
}
