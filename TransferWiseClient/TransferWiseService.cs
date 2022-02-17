using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TransferWiseClient.Models;

namespace TransferWiseClient
{
    internal class TransferWiseService
    {
        private readonly ApiHttpClient _apiHttpClient;

        public TransferWiseService(ApiHttpClient apiHttpClient)
        {
            _apiHttpClient = apiHttpClient;
        }

        public async Task<int> GetProfile()
        {
            var response = await _apiHttpClient.SendAsync("v1/profiles", HttpMethod.Get);

            var profiles = await ApiHttpClient.GetAsAsync<List<Detail>>(response.Content);

            Console.WriteLine($"Profile: {profiles[0].type} {profiles[0].id}");
            Console.WriteLine($"Profile: {profiles[1].type} {profiles[1].id}");

            return profiles[1].id;
        }

        public async Task<string> CreateQuote(int amount, int profileId)
        {
            var qoute = new QuoteRequest { sourceCurrency = "EUR", targetCurrency = "EUR", sourceAmount = amount, profile = profileId };

            var quoteResponse = await _apiHttpClient.SendAsync(qoute, "v2/quotes", HttpMethod.Post);

            var quote = await ApiHttpClient.GetAsAsync<QuoteResponse>(quoteResponse.Content);

            return quote.id;
        }

        public async Task<int> GetRecipient()
        {
            var recipientResponse = await _apiHttpClient.SendAsync("/v2/accounts/?currency=EUR", HttpMethod.Get);

            var recipient = await ApiHttpClient.GetAsAsync<RecipientsResponse>(recipientResponse.Content);

            return recipient.content.First().id;
        }

        public async Task<int> CreateTransfer(int recipientId, string quoteId)
        {
            var e2eId = Guid.NewGuid().ToString();

            Console.WriteLine("Transfer E2EID " + e2eId);

            var transferRequestDetails = new TransferRequestDetails
                { reference = "ClearBank Test", transferPurpose = "verification.transfers.purpose.pay.bills" };

            var transferRequest = new CreateTransferRequest { targetAccount = recipientId, quoteUuid = quoteId,  customerTransactionId = e2eId, details = transferRequestDetails };

            var transferResponse = await _apiHttpClient.SendAsync(transferRequest, "v1/transfers", HttpMethod.Post);

            var transfer = await ApiHttpClient.GetAsAsync<CreateTransferResponse>(transferResponse.Content);

            return transfer.id;
        }

        public async Task<string> FundTransfer(int profileId, string transferId)
        {
            var fundTransferRequests = new FundTransferRequest { type = "BALANCE" };

            var fundTransferResponse = await _apiHttpClient.SendAsync(fundTransferRequests, $"v3/profiles/{profileId}/transfers/{transferId}/payments", HttpMethod.Post);

            var transfer = await ApiHttpClient.GetAsAsync<FundTransferResponse>(fundTransferResponse.Content);

            return transfer.status;
        }

        public async Task<string> FundTransfer(string transferId)
        {
            var fundTransferRequests = new FundTransferRequest { type = "BALANCE" };

            var fundTransferResponse = await _apiHttpClient.SendAsync(fundTransferRequests, $"/v1/transfers/{transferId}", HttpMethod.Get);

            var transfer = await ApiHttpClient.GetAsAsync<FundTransferResponse>(fundTransferResponse.Content);

            return transfer.status;
        }

        public async Task<TransferStatusResponse> GetTransferStatus(string transferId)
        {
            var fundTransferResponse = await _apiHttpClient.SendAsync($"/v1/transfers/{transferId}", HttpMethod.Get);

            var transfer = await ApiHttpClient.GetAsAsync<TransferStatusResponse>(fundTransferResponse.Content);

            return transfer;
        }
    }
}
