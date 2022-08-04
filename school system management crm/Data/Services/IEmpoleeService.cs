﻿using school_system_management_crm.Data.Base;
using school_system_management_crm.Data.ViewModel;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.Services
{
    public interface IEmpoleeService:IRepoEntityBase<Employee>
    {
        Task<GetItemDropDownModel> GetItemDropDown();
        Task AddEmployeeAsync(EmpolyeeVM empolyee);
        Task UpdateEmployeeAsync(EmpolyeeVM empolyee);
    }
}
