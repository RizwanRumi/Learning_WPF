using EventAndDelegatesConsoleApp;

public class MessageService()
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        Console.WriteLine("MessageService: Sending a message...." + args.Video.Title);
    }
}