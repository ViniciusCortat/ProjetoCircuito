using System.Collections;
using System.Collections.Generic;

public class Conditional
{
    public Conditional() {

    }
    private List<CommandType> BaseCommands;

    private List<CommandType> ElseCommands;

    private int CommandIndex = 0;

    private bool BaseSelected = true;

    public void AddBaseCommand(CommandType command) {
        BaseCommands.Add(command);
    }

    public void AddElseCommand(CommandType command) {
        ElseCommands.Add(command);
    }

    public CommandType CurrentCommand() {
        if(BaseSelected) {
            return BaseCommands[CommandIndex];
        }
        return ElseCommands[CommandIndex];
    }

    public void NextCommand() {
        CommandIndex++;
    }

    public void SwapCommandLine() {
        BaseSelected = !BaseSelected;
    }

    public bool IsBaseSelected() {
        return BaseSelected;
    }
}
