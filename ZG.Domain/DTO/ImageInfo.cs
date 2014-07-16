using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ImageInfo
    {
        public string Name { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string ThumbUrl { get; set; }
        public string Caption { get; set; }
    }
}
