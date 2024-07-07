using FinalPRN3.Models;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace FinalPRN3.Mapper
{
    public class MyMapper : AutoMapper.Profile
    {
        public MyMapper()
        {
            //CreateMap<ProductRequest, Product>().ReverseMap();
        }
    }
}
