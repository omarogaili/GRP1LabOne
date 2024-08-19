using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbHandlerGrp1
{
    // we can use this class if we decide to improve the project and add an username so we can 
    // search for users based on their usernames.
    // otherwise this class is not needed for the Group work we have from the school. 
    public class UserName
    {
        [Key]
        public int Idname { get; set; }
        public string Name { get; set; }

    }
}
