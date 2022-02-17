using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferWiseClient.Models
{
    public class FundTransferResponse
    { 
        public string type { get; set; }
        public string status { get; set; }
        public object errorCode { get; set; }
    }

}
