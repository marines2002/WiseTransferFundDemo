using System.Net.Http;
using System.Threading.Tasks;
using TransferWiseClient.Models;

namespace TransferWiseClient
{
    internal class TransferWiseSimulationService
    {
        private readonly ApiHttpClient _apiHttpClient;

        public TransferWiseSimulationService(ApiHttpClient apiHttpClient)
        {
            _apiHttpClient = apiHttpClient;
        }
        
        public async Task<TransferStatusResponse> SetTransferStatusProcessing(string transferId)
        {
            return await SetTransferStatus( transferId, "processing");
        }

        public async Task<TransferStatusResponse> SetTransferStatusFundsConverted(string transferId)
        {
            return await SetTransferStatus(transferId, "funds_converted");
        }

        public async Task<TransferStatusResponse> SetTransferStatusOutgoingPaymentSent(string transferId)
        {
            return await SetTransferStatus(transferId, "outgoing_payment_sent");
        }

        public async Task<TransferStatusResponse> SetTransferStatusOutgoingBouncedBack(string transferId)
        {
            return await SetTransferStatus(transferId, "bounced_back");
        }

        public async Task<TransferStatusResponse> SetTransferStatusFundsRefunded(string transferId)
        {
            return await SetTransferStatus(transferId, "funds_refunded");
        }

        private async Task<TransferStatusResponse> SetTransferStatus(string transferId, string status)
        {
            var response = await _apiHttpClient.SendAsync($"v1/simulation/transfers/{transferId}/{status}", HttpMethod.Get);

            var statusResponse = await ApiHttpClient.GetAsAsync<TransferStatusResponse>(response.Content);

            return statusResponse;
        }
    }
}
