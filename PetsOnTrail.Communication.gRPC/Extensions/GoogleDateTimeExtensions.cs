namespace PetsOnTrail.Communication.gRPC.Extensions;

public static class GoogleDateTimeExtensions
{
    public static DateTimeOffset? ToDateTimeOffset(this Google.Type.DateTime value)
    {
        if (value == null)
            return null;

        if (value.Year < 1900)
            return null;
        
        return new DateTime(value.Year, value.Month, value.Day, value.Hours, value.Minutes, value.Seconds);
    }
}
