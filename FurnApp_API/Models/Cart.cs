using System;
using System.Collections.Generic;

namespace FurnApp_API.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? UsersId { get; set; }
        public int? ProductsId { get; set; }

        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
