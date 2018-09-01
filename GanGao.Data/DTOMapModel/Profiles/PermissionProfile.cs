using AutoMapper;
using GanGao.Data.DTO;
using GanGao.Data.Models;

namespace GanGao.Data.DTOMapModel.Profiles
{
    /// <summary>
    /// 权限转化配置
    /// </summary>
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDTO, PermissionEntity>()
                .ForMember(d => d.Departments, m => m.Ignore());

            CreateMap<PermissionEntity, PermissionDTO>();
            
            CreateMap<PermissionDepartmentRelation, RelationDepartmentDTO>()
               .ForMember(d => d.Name, mo => mo.MapFrom(dto => dto.Department.Name));

            CreateMap<PermissionDepartmentRoleRelation, RelationDepartmentRoleDTO>()
                .ForMember(d => d.Name, mo => mo.MapFrom(dto => dto.Role.Name));
        }
    }
}