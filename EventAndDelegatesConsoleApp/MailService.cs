using EventAndDelegatesConsoleApp;

public class MailService()
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        Console.WriteLine("MailService: Sending an Email...." + args.Video.Title);
    }
}