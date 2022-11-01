using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.BL.Emails.Services;
using AirBnb.DAL.Data.Models;
using AutoMapper;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IEmailService _emailService;
        public EmployeeManager(UserManager<Employee> employeemanager, IMapper mapper,IEmailService emailService)
        {
            _employeemanager = employeemanager;
            _mapper = mapper;
            _emailService = emailService;
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
            var errors = string.Empty;

            Employee myEmp = _mapper.Map<Employee>(model);
            if (myEmp == null)
            {
                return null;
            }
            var  result= await _employeemanager.CreateAsync(myEmp, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new EmployeeReadDTO { Errors = errors };
                    
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,myEmp.Id),
                new Claim(ClaimTypes.Role,model.Role)
            };
            await _employeemanager.AddClaimsAsync(myEmp, claims);
            EmployeeReadDTO AddedEmployee = _mapper.Map<EmployeeReadDTO>(myEmp);
            // Setting Html Welcome Email Body
            // C:\Users\Dell\source\repos\AirBnb-API\AirBnb.Api\Template\EmailTemplate.html'
            var currentDirector = Directory.GetCurrentDirectory().Replace($"AirBnb.Api", "AirBnb.BL");
            var filePath = $"{currentDirector}\\Emails\\Template\\EmailTemplate.html";
            var str = new StreamReader(filePath);
            var MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[name]", model.FirstName+" "+model.LastName).Replace("[email]", model.Email).Replace("[password]",model.Password);
            await _emailService.SendEmailAsync(model.Email, "Welcome On Board", MailText);
            return AddedEmployee;
        }
        //Deleting Section
        public async Task<EmployeeReadDTO> DeleteEmployee(string id)
        {
            var errors = string.Empty;
            Employee emp = await _employeemanager.FindByIdAsync(id);
            if (emp == null)
            {
                return null;
            }
            var result = await _employeemanager.DeleteAsync(emp);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new EmployeeReadDTO { Errors = errors };
            }
            EmployeeReadDTO deletedEmp = _mapper.Map<EmployeeReadDTO>(emp);
            return deletedEmp;
        }
        //Updating section:
        public async Task<EmployeeReadDTO> UpdateEmployee(EmployeeUpdateDTO model, string id)
        {
            var errors = string.Empty;
            Employee emp = await _employeemanager.FindByIdAsync(id);
            if (emp == null)
            {
                return null;
            }
            _mapper.Map(model, emp);
            var result = await _employeemanager.UpdateAsync(emp);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                return new EmployeeReadDTO { Errors = errors };
            }
            EmployeeReadDTO updatedEmployee = _mapper.Map<EmployeeReadDTO>(emp);
            return updatedEmployee;
        }

    }
}
