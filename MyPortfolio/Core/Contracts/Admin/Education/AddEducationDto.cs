using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Admin.Education
{
    public class AddEducationDto
    {
        public string Specialization { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
    }
}
