using Expo.Server.Client;
using Expo.Server.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Category("Harness")]
        [Test]
        public void TestPushTicketRequest()
        {
            var expoSDKClient = new Expo.Server.Client.PushApiClient();
            var pushTicketReq = new Expo.Server.Models.PushTicketRequest() {
                PushTo = new List<string>() { "..." },
                PushBadgeCount = 7,
                PushBody = "Test Push - Msg"
            };
            var result = expoSDKClient.PushSendAsync(pushTicketReq).GetAwaiter().GetResult();

            if (result?.PushTicketErrors?.Count() > 0) {
                foreach (var error in result.PushTicketErrors) {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }

            ///If no errors, then wait for a the notifications to be delivered
            

            foreach (var ticketStatus in result.PushTicketStatuses) {
                Console.WriteLine($"TicketId & Status: {ticketStatus.TicketId} = {ticketStatus.TicketStatus}, {ticketStatus.TicketMessage}");
                var pushReceiptReq = new Expo.Server.Models.PushReceiptRequest()
                {
                    PushTicketIds = new List<string>() { "..." }
                };

            }



            Assert.Pass();
        }

        [Category("Harness")]
        [Test]
        public void TestPushReceiptRequest()
        {
            var expoSDKClient = new PushApiClient();
            var pushReceiptReq = new PushReceiptRequest()
            {
                PushTicketIds = new List<string>() { "..." }
            };


            var result = expoSDKClient.PushGetReceiptsAsync(pushReceiptReq).GetAwaiter().GetResult();

            if (result?.ErrorInformations?.Count() > 0) {
                foreach (var error in result.ErrorInformations) {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }
            foreach (var pushReceipt in result.PushTicketReceipts) {
                Console.WriteLine($"TicketId & Delivery Status: {pushReceipt.Key} {pushReceipt.Value.DeliveryStatus} {pushReceipt.Value.DeliveryMessage}");
            }


            Assert.Pass();
        }

    }
}