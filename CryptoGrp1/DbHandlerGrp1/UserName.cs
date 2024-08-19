using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandlerGrp1
{
    public class UserName
    {
        [Key]
        public int Idname { get; set; }
        public string Name { get; set; }

    }
}
