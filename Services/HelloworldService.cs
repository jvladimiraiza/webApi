public class HelloworldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello Wordl!!";
    }
}
public interface IHelloWorldService
{
    string GetHelloWorld();
}