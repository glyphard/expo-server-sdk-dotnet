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
```


## Developing

The source code is in the `src/` directory.

To build, use the .sln and msbuild


## TODO

  * Need to add unit tests

## See Also

  * https://github.com/expo/expo-server-sdk-node
  * https://github.com/expo/expo-server-sdk-ruby
  * https://github.com/expo/expo-server-sdk-python
