using AutoMapper;
using FuDong.Common;

namespace FuDong.Data.DTO
{
    public class AutoMapperProfileRegister
    {
        public static void Register()
        {
            var assembly = typeof(IAutoMapperProfile).Assembly;
            Mapper.Initialize(cfg => cfg.AddProfiles(assembly));
        }
    }
}