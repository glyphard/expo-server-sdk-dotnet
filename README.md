# expo-server-sdk-dotnet
Server-side library for working with Expo using dot-net.

If you have problems with the code in this repository, please file an issue.

## Usage


```cs

using expo_server_sdk_dotnet.Client;
using expo_server_sdk_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

            var expoSDKClient = new PushApiClient();
            var pushTicketReq = new PushTicketRequest() {
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

            //If no errors, then wait for a few moments for the notifications to be delivered
            //Then request receipts for each push ticket

// The Expo push notification service accepts batches of notifications so
// that you don't need to send 1000 requests to send 1000 notifications. We
// recommend you batch your notifications to reduce the number of requests
// and to compress them (notifications with similar content will get
// compressed).
let chunks = expo.chunkPushNotifications(messages);
let tickets = [];
(async () => {
  // Send the chunks to the Expo push notification service. There are
  // different strategies you could use. A simple one is to send one chunk at a
  // time, which nicely spreads the load out over time:
  for (let chunk of chunks) {
    try {
      let ticketChunk = await expo.sendPushNotificationsAsync(chunk);
      console.log(ticketChunk);
      tickets.push(...ticketChunk);
      // NOTE: If a ticket contains an error code in ticket.details.error, you
      // must handle it appropriately. The error codes are listed in the Expo
      // documentation:
      // https://docs.expo.io/versions/latest/guides/push-notifications#response-format
    } catch (error) {
      console.error(error);
    }
  }
})();

...

// Later, after the Expo push notification service has delivered the
// notifications to Apple or Google (usually quickly, but allow the the service
// up to 30 minutes when under load), a "receipt" for each notification is
// created. The receipts will be available for at least a day; stale receipts
// are deleted.
//
// The ID of each receipt is sent back in the response "ticket" for each
// notification. In summary, sending a notification produces a ticket, which
// contains a receipt ID you later use to get the receipt.
//
// The receipts may contain error codes to which you must respond. In
// particular, Apple or Google may block apps that continue to send
// notifications to devices that have blocked notifications or have uninstalled
// your app. Expo does not control this policy and sends back the feedback from
// Apple and Google so you can handle it appropriately.

            var pushReceiptResult = expoSDKClient.PushGetReceiptsAsync(pushReceiptReq).GetAwaiter().GetResult();

            if (pushReceiptResult?.ErrorInformations?.Count() > 0) {
                foreach (var error in result.ErrorInformations) {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }
            foreach (var pushReceipt in pushReceiptResult.PushTicketReceipts) {
                Console.WriteLine($"TicketId & Delivery Status: {pushReceipt.Key} {pushReceipt.Value.DeliveryStatus} {pushReceipt.Value.DeliveryMessage}");
            }



## Developing

The source code is in the `src/` directory.

To build, use the .sln and msbuild


## TODO

  * Need to add unit tests

## See Also

  * https://github.com/expo/expo-server-sdk-node
  * https://github.com/expo/expo-server-sdk-ruby
  * https://github.com/expo/expo-server-sdk-python