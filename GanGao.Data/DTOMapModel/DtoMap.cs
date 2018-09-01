using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace GanGao.Data.DTOMapModel
{
    /// <summary>
    /// 模型 DTO 相互转化服务
    /// </summary>
    [Export(typeof(IDTOMapService))]
    public class DtoMap : DefaultDTOMapService, IDTOMapService
    {

    }
}