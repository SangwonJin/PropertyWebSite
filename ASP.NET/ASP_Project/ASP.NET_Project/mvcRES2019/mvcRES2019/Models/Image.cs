using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace mvcRES2019.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        [DisplayName("Upload File")]
        public byte[] ImagePath { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}