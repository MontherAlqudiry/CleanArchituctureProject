using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Data.Entities
{
    public class Complaint
    {

        public Complaint()
        {

            Demands = new HashSet<Demand>();

        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        public virtual ICollection<Demand>? Demands { get; set; }



    }
}
