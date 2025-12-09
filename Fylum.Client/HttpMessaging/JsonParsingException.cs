namespace Fylum.Client.HttpMessaging;

public class JsonParsingException : Exception
{
    public JsonParsingException(Type targetType, string json)
    {
        TargetType = targetType;
        Json = json;
    }

    public Type TargetType { get; }
    public string Json { get; }

    public new string Message => $"Could not convert to type: {TargetType}\r\n{Json}";
}
