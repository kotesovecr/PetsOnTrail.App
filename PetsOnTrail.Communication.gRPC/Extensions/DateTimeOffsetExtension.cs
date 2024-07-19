namespace PetsOnTrail.Communication.gRPC.Extensions;

public static class DateTimeOffsetExtension
{
    public static Google.Type.DateTime? ToGoogleDateTime(this DateTimeOffset? value)
    {
        if (value == null)
            return null;
        
        return new Google.Type.DateTime
        {
            Year = value.Value.Year,
            Month = value.Value.Month,
            Day = value.Value.Day,
            Hours = value.Value.Hour,
            Minutes = value.Value.Minute,
            Seconds = value.Value.Second
        };
    }
    
    public static Google.Type.DateTime ToGoogleDateTime(this DateTimeOffset value)
    {
        return new Google.Type.DateTime
        {
            Year = value.Year,
            Month = value.Month,
            Day = value.Day,
            Hours = value.Hour,
            Minutes = value.Minute,
            Seconds = value.Second
        };
    }

    public static Google.Protobuf.WellKnownTypes.Timestamp ToGoogleTimestamp(this DateTimeOffset value)
    {
        return new Google.Protobuf.WellKnownTypes.Timestamp
        {
            Seconds = value.ToUnixTimeSeconds()
        };
    }
}
