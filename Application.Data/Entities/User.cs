using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Entities
{
    public class User
    {
        
        public User() {

            //We do this to avoid get into exeption (complaints is null)

            Complaints = new HashSet<Complaint>();
        }


        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? File {  get; set; }
        public string Role { get; set; }
 
        public virtual ICollection<Complaint> Complaints { get; set; }

    }
}
