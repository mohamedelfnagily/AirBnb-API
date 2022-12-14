using AirBnb.BL.DTOs.CategoryDTOs;
using AirBnb.BL.DTOs.CategoryProperties;
using AirBnb.BL.DTOs.EmployeeDTOs;
using AirBnb.BL.DTOs.PropertyDTOs;
using AirBnb.BL.DTOs.PropertyPicsDTOs;
using AirBnb.BL.DTOs.ReservationDTOs;
using AirBnb.BL.DTOs.ReviewDTOs;
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
            CreateMap<UserRegisterDTO, User>().ForMember(src => src.ProfilePicture, opt => opt.Ignore()); 

            //Converting a user to urser read dto
            CreateMap<User, UserReadDTO>();

            //Converting from update user dto to user
            CreateMap<UserUpdateDTO, User>().ForMember(src => src.ProfilePicture, opt => opt.Ignore());

            //Converting from registerDto to employee
            CreateMap<EmployeeRegisterDTO, Employee>();

            //Converting a employee to employee read dto
            CreateMap<Employee, EmployeeReadDTO>();

            //Converting from update employee dto to employee
            CreateMap<EmployeeUpdateDTO, Employee>().ForMember(src => src.ProfilePicture, opt => opt.Ignore());

            //Converting from update category dto to category
            CreateMap<CategoryUpdateDTO, Category>();

            //Converting from category to category read dto
            CreateMap<Category, CategoryReadDTO>();

            //Converting from add category dto to category
            CreateMap<CategoryAddDTO, Category>();
            //convert from property to property readdto
            CreateMap<Property, PropertyReadDto>();
            //convert from property add dto to property
            CreateMap<PropertyAddDto, Property>().ForMember(src => src.Pictures, opt => opt.Ignore());
            //convert from property update dto to property
            CreateMap<PropertyUpdateDto, Property>();
            //convert from property to property categories
            CreateMap<Property, PropertyCategories>();
            //Converting from property picture to property picture read dto
            CreateMap<PropertyPicture, PropertyPictureReadDto>();
            //converting from reservation to reservation read dto
            CreateMap<Reservation, ReservationReadDto>();
            //converting from reservation add dto to reservation
            CreateMap<ReservationAddDto, Reservation>();
            ////converting from user to reservation user dto
            //CreateMap<User, ReservationUserDto>();
            //converting from review to review read dto
            CreateMap<Review, ReservationReviewReadDto>();




            // reviews mapping

            CreateMap<ReviewAddDTO, Review>();
            CreateMap<ReviewUpdateDTO, Review>();
            CreateMap<Review, ReviewReadDTO>();


        }
    }
}
