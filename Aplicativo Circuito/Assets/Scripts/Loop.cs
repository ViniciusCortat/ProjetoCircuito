using System.Collections;
using System.Collections.Generic;

public class Loop
{
    public Loop() {
        
    }
    private List<CommandType> commands;

    private int commandIndex = 0;

    public void AddCommand(CommandType command) {
        commands.Add(command);
    }

    public CommandType CurrentCommand() {
        return commands[commandIndex];
    }

    public void NextCommand() {
        commandIndex++;
    }
}
