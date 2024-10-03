using EncoreTIX.Models;

namespace EncoreTIX.ViewModels
{
    public class AttractionDetail
    {
        public Attraction? Attraction { get; set; }
        public List<AttractionEvent>? AttractionEvents { get; set; }   

    }
}
