using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.ViewModel
{
    public class GetItemDropDownModel
    {
        public GetItemDropDownModel()
        {
            Departments = new List<Department>();
        }
        public List<Department> Departments { get; set; }
    }
}
