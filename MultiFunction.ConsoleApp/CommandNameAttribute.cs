namespace MultiFunction.ConsoleApp;

[AttributeUsage(AttributeTargets.Class)]
public class CommandNameAttribute: Attribute
{
    public string CommandName { get; set; }
    
    public CommandNameAttribute(string commandName)
    {
        CommandName = commandName;
    }
}