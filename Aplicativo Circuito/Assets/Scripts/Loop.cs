using System.Collections;
using System.Collections.Generic;

public class Loop
{
    public Loop() {
        commands = new List<CommandType>();
    }
    private List<CommandType> commands;

    public void AddCommand(CommandType command) {
        commands.Add(command);
    }

    public CommandType CurrentCommand(int index) {
        return commands[index];
    }
}
