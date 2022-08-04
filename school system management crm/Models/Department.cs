using school_system_management_crm.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Models
{
    public class Department: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Relationship 
        public List<Employee> Employees { get; set; }
    }
}
