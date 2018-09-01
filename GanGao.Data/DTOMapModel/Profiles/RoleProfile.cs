using AutoMapper;
using GanGao.Data.DTO;
using GanGao.Data.Models;

namespace GanGao.Data.DTOMapModel.Profiles
{
    /// <summary>
    /// 角色转化配置
    /// </summary>
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDTO, RoleEntity>();
            CreateMap<RoleEntity, RoleDTO>();
        }
    }
}