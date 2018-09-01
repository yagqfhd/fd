using FuDong.Common;
using System.ComponentModel.DataAnnotations;

namespace FuDong.Data.DTO
{
    /// <summary>
    /// 实体DTO基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DefaultEntityDTO<TKey>: IDefaultEntityDTO<TKey>
    {
        /// <summary>
        /// 对象ID主键值
        /// </summary>
        [Required(AllowEmptyStrings = false,ErrorMessageResourceName = "Required",ErrorMessageResourceType =typeof(Resources))]
        [Display(ResourceType =typeof(Resources) , Name ="Id")]
        public TKey Id { get; set; }
        /// <summary>
        /// 对象名称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(maximumLength: 20, ErrorMessageResourceName = "MaxMin" , ErrorMessageResourceType =typeof(Resources), MinimumLength = 1)]
        [Display(ResourceType = typeof(Resources), Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 对象说明
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "Description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// 实体DTO基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DefaultEntityDTO : DefaultEntityDTO<string>, IDefaultEntityDTO<string> { }
}