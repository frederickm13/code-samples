// Code snippet demonstrating how to send an HTTP POST request 
// using the HttpClient.PostAsync() method.
// Associated article: https://www.erickmccollum.com/2021/06/16/httpclient-sendasync.html.

// ...

    // Create Uri and POST body content.
    Uri requestUri = new Uri("https://example.com/api/");
    using StringContent content = new StringContent("{ \"firstName\": \"John\", \"lastName\": \"Doe\"}");

    // Create HttpClient instance and set OAuth header.
    using HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "{OAuth token}");

    // Send HTTP POST request.
    using HttpResponseMessage response = await client.PostAsync(requestUri, content);

// ...