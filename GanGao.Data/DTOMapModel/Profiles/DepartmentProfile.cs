using AutoMapper;
using GanGao.Data.DTO;
using GanGao.Data.Models;

namespace GanGao.Data.DTOMapModel.Profiles
{
    /// <summary>
    /// 部门转化配置
    /// </summary>
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentDTO, DepartmentEntity>()
                .ForMember(d => d.Childs, mo => mo.Ignore())
                .ForMember(d => d.Parent, mo => mo.Ignore());
                
            CreateMap<DepartmentEntity, DepartmentDTO>()
               .ForMember(d => d.Parent, mo => mo.MapFrom(dto => dto.Parent.Name));
        }
    }
}