using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.BL.DTOs.CategoryProperties;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.UserDTOs;
using AirBnb.DAL.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.BL.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            //Converting from registerDto to user
            CreateMap<UserRegisterDTO, User>();

            //Converting a user to urser read dto
            CreateMap<User, UserReadDTO>();

            //Converting from update user dto to user
            CreateMap<UserUpdateDTO, User>();

            //Converting from registerDto to employee
            CreateMap<EmployeeRegisterDTO, Employee>();

            //Converting a employee to employee read dto
            CreateMap<Employee, EmployeeReadDTO>();

            //Converting from update employee dto to employee
            CreateMap<EmployeeUpdateDTO, Employee>();

            //Converting from update category dto to category
            CreateMap<CategoryUpdateDTO, Category>();

            //Converting from category to category read dto
            CreateMap<Category, CategoryReadDTO>();

            //Converting from add category dto to category
            CreateMap<CategoryAddDTO, Category>();
            //convert from property to property readdto
            CreateMap<Property, PropertyReadDto>();
            //convert from property add dto to property
            CreateMap<PropertyAddDto, Property>();
            //convert from property update dto to property
            CreateMap<PropertyUpdateDto, Property>();
        }
    }
}
