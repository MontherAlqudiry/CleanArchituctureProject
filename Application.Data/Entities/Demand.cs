using System.Text.Json.Serialization;

namespace Application.Data.Entities
{
    public class Demand
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public int? CompId { get; set; }


        [JsonIgnore]
        public virtual Complaint? Complaint { get; set; }
    }
}
