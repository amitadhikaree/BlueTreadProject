using EncoreTIX.Models;

namespace EncoreTIX.Services
{
    public interface ITicketMaster
    {
        Task<List<Attraction>> GetAttractionsByKeyword(string keyword);

        Task<Attraction> GetAttractionDetails(string keyword);

        Task<List<AttractionEvent>> GetEventsByAttractionId(string keyword);
    }
}
