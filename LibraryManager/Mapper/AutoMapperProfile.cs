using AutoMapper;
using LibraryManager.DTOs;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<BorrowingRequestDto, BorrowingRequest>().ReverseMap();
            CreateMap<BorrowingRequestDetailDto, BorrowingRequestDetail>().ReverseMap();
        }
    }
}
