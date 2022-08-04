using Microsoft.EntityFrameworkCore;
using school_system_management_crm.Data.Base;
using school_system_management_crm.Data.ViewModel;
using school_system_management_crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.Services
{
    public class EmpoleeService : RepoEntityBase<Employee>, IEmpoleeService
    {
        private readonly ApplicationDbContext __Context;

        public EmpoleeService(ApplicationDbContext Context) : base(Context)
        {
            __Context = Context;
        }

        public async Task AddEmployeeAsync(EmpolyeeVM empolyee)
        {
            var data = new Employee()
            {
                Name = empolyee.Name,
                Address = empolyee.Address,
                Salary = empolyee.Salary,
                StartDate = empolyee.StartDate,
                EndDate = empolyee.EndDate,
                DepartmentId = empolyee.DepartmentId
            };
            await __Context.AddAsync(data);
            await __Context.SaveChangesAsync();
        }

        public  async Task<GetItemDropDownModel> GetItemDropDown()
        {
            var responce = new GetItemDropDownModel();
            responce.Departments = await __Context.Departments.OrderBy(c=>c.Name).ToListAsync();
            return responce;
        }

        public async Task UpdateEmployeeAsync(EmpolyeeVM empolyee)
        {
            var result = await __Context.Employees.FirstOrDefaultAsync(E=>E.Id == empolyee.Id);
            if (result !=null)
            {
                result.Name = empolyee.Name;
                result.Address = empolyee.Address;
                result.Salary = empolyee.Salary;
                result.StartDate = empolyee.StartDate;
                result.EndDate = empolyee.EndDate;
                result.DepartmentId = empolyee.DepartmentId;
                await __Context.SaveChangesAsync();
            }
        }
    }
}
