using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbHandlerGrp1
{
    public class Password
    {
        public int Id { get; set; }
        public string EncryptedText { get; set; } 
        public string Salt { get; set; } 
        public string IV { get; set; } 
    }
    /*
     * user name id is needed here to search 
     */
}
