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
        }
    }
}
