using System;
using System.Threading.Tasks;

namespace TransferWiseClient
{
    internal class Program
    {
        private static readonly ApiHttpClient Client = new();
        private static readonly TransferWiseService TransferWiseService = new(Client);
        private static readonly TransferWiseSimulationService TransferWiseSimulationService = new(Client);

        static void Main(string[] args)
        {
            Console.WriteLine("TransferWise Client");

            var transferId = CreateAndFundTransfer().Result;

            SimulatePaymentProcess(transferId).GetAwaiter().GetResult();
        }
        private static async Task<string> CreateAndFundTransfer()
        {
            var profileId = await TransferWiseService.GetProfile();

            var quoteId = await TransferWiseService.CreateQuote(10, profileId);

            var recipientId = await TransferWiseService.GetRecipient();

            var transferId = await TransferWiseService.CreateTransfer(recipientId, quoteId);

            await TransferWiseService.FundTransfer(profileId, transferId);

            return transferId.ToString();
        }

        private static async Task SimulatePaymentProcess(string transferId)
        {
            var getTransferStatus = await TransferWiseService.GetTransferStatus(transferId);

            var setStatusResponse = await TransferWiseSimulationService.SetTransferStatusProcessing(transferId);

            getTransferStatus = await TransferWiseService.GetTransferStatus(transferId);

            setStatusResponse = await TransferWiseSimulationService.SetTransferStatusFundsConverted(transferId);

            getTransferStatus = await TransferWiseService.GetTransferStatus(transferId);

            setStatusResponse = await TransferWiseSimulationService.SetTransferStatusOutgoingPaymentSent(transferId);

            getTransferStatus = await TransferWiseService.GetTransferStatus(transferId);
        }
    }
}
