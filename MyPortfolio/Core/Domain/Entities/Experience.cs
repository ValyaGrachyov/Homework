using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
    }
}
