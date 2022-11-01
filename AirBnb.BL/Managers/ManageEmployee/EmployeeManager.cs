using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.DAL.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageEmployee
{
    public class EmployeeManager:IEmployeeManager
    {
        private readonly UserManager<Employee> _employeemanager;
        private readonly IMapper _mapper;
        public EmployeeManager(UserManager<Employee> employeemanager, IMapper mapper)
        {
            _employeemanager = employeemanager;
            _mapper = mapper;
        }
        //Getting section implementation
        public async Task<EmployeeReadDTO> GetEmployeeByEmail(string email)
        {
            Employee emp = await _employeemanager.FindByEmailAsync(email);
            if (emp == null)
            {
                return null;
            }
            EmployeeReadDTO neededEmployee = _mapper.Map<EmployeeReadDTO>(emp);
            return neededEmployee;
        }

        public async Task<EmployeeReadDTO> GetEmployeeById(string id)
        {
            Employee emp = await _employeemanager.FindByIdAsync(id);
            if (emp == null)
            {
                return null;
            }
            EmployeeReadDTO neededEmployee = _mapper.Map<EmployeeReadDTO>(emp);
            return neededEmployee;
        }

        public async Task<EmployeeReadDTO> GetEmployeeByUsername(string username)
        {
            Employee emp = await _employeemanager.FindByNameAsync(username);
            if (emp == null)
            {
                return null;
            }
            EmployeeReadDTO neededUser = _mapper.Map<EmployeeReadDTO>(emp);
            return neededUser;
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetAllEmployees()
        {
            IEnumerable<Employee> myEmps = await _employeemanager.Users.ToListAsync();
            if (myEmps == null)
            {
                return null;
            }
            IEnumerable<EmployeeReadDTO> employees = _mapper.Map<IEnumerable<EmployeeReadDTO>>(myEmps);

            return employees;
        }
        //Adding Section:
        public async Task<EmployeeReadDTO> AddNewEmployee(EmployeeRegisterDTO model)
        {
            Employee myEmp = _mapper.Map<Employee>(model);
            if (myEmp == null)
            {
                return null;
            }
            var AddedEmp = await _employeemanager.CreateAsync(myEmp, model.Password);
            if (!AddedEmp.Succeeded)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,myEmp.Id),
                new Claim(ClaimTypes.Role,"Customer")
            };
            var result = await _employeemanager.AddClaimsAsync(myEmp, claims);
            EmployeeReadDTO AddedEmployee = _mapper.Map<EmployeeReadDTO>(myEmp);
            return AddedEmployee;
        }
        //Deleting Section
        public async Task<EmployeeReadDTO> DeleteEmployee(string id)
        {
            Employee emp = await _employeemanager.FindByIdAsync(id);
            if (emp == null)
            {
                return null;
            }
            var result = await _employeemanager.DeleteAsync(emp);
            if (!result.Succeeded)
            {
                return null;
            }
            EmployeeReadDTO deletedEmp = _mapper.Map<EmployeeReadDTO>(emp);
            return deletedEmp;
        }
        //Updating section:
        public async Task<EmployeeReadDTO> UpdateEmployee(EmployeeUpdateDTO model, string id)
        {
            Employee emp = await _employeemanager.FindByIdAsync(id);
            if (emp == null)
            {
                return null;
            }
            _mapper.Map(model, emp);
            var result = await _employeemanager.UpdateAsync(emp);
            if (!result.Succeeded)
            {
                return null;
            }
            EmployeeReadDTO updatedEmployee = _mapper.Map<EmployeeReadDTO>(emp);
            return updatedEmployee;
        }

    }
}
