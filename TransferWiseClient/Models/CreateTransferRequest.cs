using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferWiseClient.Models
{
    public class TransferRequestDetails
    {
        public string reference { get; set; }
        public string transferPurpose { get; set; }
    }

    public class CreateTransferRequest
    {
        public int targetAccount { get; set; }
        public string quoteUuid { get; set; }
        public string customerTransactionId { get; set; }
        public TransferRequestDetails details { get; set; }
    }
}
