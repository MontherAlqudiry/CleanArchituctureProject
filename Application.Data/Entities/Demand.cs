using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Entities
{
    public class Demand
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public int? CompId { get; set; }

        [ForeignKey("CompId")]
        public virtual Complaint Complaint { get; set; }
    }
}
