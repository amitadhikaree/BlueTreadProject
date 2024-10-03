
namespace EncoreTIX.Models.ResponeseDtos
{
    public class Venue
    {
        public string? Name { get; set; }
    }

    public class DateStart
    {
        public string? LocalDate { get; set; }
    }

    public class EventDates
    {
        public DateStart? Start { get; set; }
    }

    public class EmbeddedVenue
    {
        public List<Venue>? Venues { get; set; }
    }

    public class EventApiModel
    {
        public string? Name { get; set; }
        public EventDates? Dates { get; set; }
        public EmbeddedVenue? _embedded { get; set; }
    }

    public class EmbeddedEvents
    {
        public List<EventApiModel>? Events { get; set; }
    }

    public class EventApiResponse
    {
        public EmbeddedEvents? _embedded { get; set; }
    }

}
