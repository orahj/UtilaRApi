using System;
using System.Collections.Generic;
using System.Text;

namespace Tickeo.Core.DTOs
{
   public class EventCategoryResponseModel:BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class EventCategoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class EventCategoryList: BaseResponse
    {
        public List<EventCategoryItem> EventCategoryItems { get; set; }
        
    }

}
