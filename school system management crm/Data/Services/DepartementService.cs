using school_system_management_crm.Data.Base;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.Services
{
    public class DepartementService:RepoEntityBase<Department>,IDepartementService
    {
        public DepartementService(ApplicationDbContext Context) :base(Context)
        {

        }
    }
}
