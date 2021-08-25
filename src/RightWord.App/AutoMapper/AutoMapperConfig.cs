using AutoMapper;
using RightWord.App.ViewModels;
using RightWord.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RightWord.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Agency, AgencyViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Document, DocumentViewModel>().ReverseMap();
        }
    }
}
