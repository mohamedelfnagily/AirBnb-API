using AirBnb.BL.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.Managers.ManageEmployee
{
    public interface IEmployeeManager
    {
        //This interface is responsible for all the user operations like getting , adding, removing user
        //Getting section:
        Task<EmployeeReadDTO> GetEmployeeById(string id);
        Task<EmployeeReadDTO> GetEmployeeByEmail(string email);
        Task<EmployeeReadDTO> GetEmployeeByUsername(string username);
        Task<IEnumerable<EmployeeReadDTO>> GetAllEmployees();
        //Adding new user
        Task<EmployeeReadDTO> AddNewEmployee(EmployeeRegisterDTO model);
        //Deleting user
        Task<EmployeeReadDTO> DeleteEmployee(string id);
        //update existing user
        Task<EmployeeReadDTO> UpdateEmployee(EmployeeUpdateDTO model, string id);
    }
}
