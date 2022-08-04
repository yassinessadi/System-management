using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.ViewModel
{
    public class EmpolyeeVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary Is Required")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Start Date Is Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date Is Required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Department Is Required")]
        public int DepartmentId { get; set; }
    }
}
