using AutoMapper;
using Jwt.Core.Dtos;
using Jwt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Service
{
    internal class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
