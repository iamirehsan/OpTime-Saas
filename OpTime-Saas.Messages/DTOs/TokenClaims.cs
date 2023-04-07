using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Messages.DTOs
{
    public class TokenClaims
    {
        public string userId{ get; set; }
        public string userName  { get; set; }
    }
}
