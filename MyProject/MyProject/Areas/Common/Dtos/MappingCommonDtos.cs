using AutoMapper;
using MyProject.Domain.Categories;

namespace MyProject.Areas.Common.Dtos
{
    public class MappingCommonDtos : Profile
    {
        public MappingCommonDtos()
        {
            CreateMap<CategoryDomain, CategoryDto>();
        }
    }
}
