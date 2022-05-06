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

    public CommandType CurrentCommand(int index) {
        if(IfRunning) {
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

    public bool IfOrElse() {
        return IfSelected;
    }
}
