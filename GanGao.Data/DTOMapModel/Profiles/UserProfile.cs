using AutoMapper;
using GanGao.Data.DTO;
using GanGao.Data.Models;

namespace GanGao.Data.DTOMapModel.Profiles
{
    /// <summary>
    /// 用户DTO转化配置
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserEntity>()
                .ForMember(d => d.Departments, m => m.Ignore())                
                .ForMember(d => d.PasswordHash, m => m.Ignore()); // 不转化密码

            CreateMap<UserEntity, UserDTO>()
                .ForMember(d => d.Departments, m => m.Ignore())
                .ForMember(d => d.Password, m => m.Ignore()); // 不转化密码

            CreateMap<UserDepartmentRelation, RelationDepartmentDTO>()
                .ForMember(d => d.Name, mo => mo.MapFrom(dto => dto.Department.Name));

            CreateMap<UserDepartmentRoleRelation, RelationDepartmentRoleDTO>()
                .ForMember(d => d.Name, mo => mo.MapFrom(dto => dto.Role.Name));
        }

    }
}