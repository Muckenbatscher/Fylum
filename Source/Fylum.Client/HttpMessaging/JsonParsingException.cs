namespace Fylum.Client.HttpMessaging;

public class JsonParsingException<TargetType> : Exception
{
    public JsonParsingException(string json)
    {
        Json = json;
    }

    public string Json { get; }

    public new string Message => $"Could not convert to type: {typeof(TargetType)}\r\n{Json}";
}
