using System;
using System.Net.Http;
using TransferWiseClient.Models;

namespace TransferWiseClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TransferWise Client");

            var client = new ApiHttpClient();

            var transferWiseService = new TransferWiseService(client);
            var transferWiseSimulationService = new TransferWiseSimulationService(client);

            //var profileId = transferWiseService.GetProfile().Result;

            //var quoteId = transferWiseService.CreateQuote(10, profileId).Result;

            //var recipientId = transferWiseService.GetRecipient().Result;

            //var transferId = transferWiseService.CreateTransfer(recipientId, quoteId).Result;

            //var transferStatus = transferWiseService.FundTransfer(profileId, transferId.ToString()).Result;

            //Console.WriteLine($"Transfer Status: {transferStatus}");

            //var getTransferStatus = transferWiseService.GetTransferStatus(transferId.ToString()).Result;

            //Happy Path
            
            var transferId = "";

            var getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;

            var setStatusResponse = transferWiseSimulationService.SetTransferStatusProcessing(transferId);

            getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;

            setStatusResponse = transferWiseSimulationService.SetTransferStatusFundsConverted(transferId);

            getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;

            setStatusResponse = transferWiseSimulationService.SetTransferStatusOutgoingPaymentSent(transferId);
            
            getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;

            // Unhappy Paths

            setStatusResponse = transferWiseSimulationService.SetTransferStatusFundsRefunded(transferId);

            getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;

            setStatusResponse = transferWiseSimulationService.SetTransferStatusOutgoingBouncedBack(transferId);

            getTransferStatus = transferWiseService.GetTransferStatus(transferId).Result;
        }
    }
}
