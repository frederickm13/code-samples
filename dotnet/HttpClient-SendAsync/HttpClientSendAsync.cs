// Code snippet demonstrating how to send an HTTP POST request 
// using the HttpClient.SendAsync() method.
// Associated article: https://www.erickmccollum.com/2021/06/16/httpclient-sendasync.html.

// ...

    // Create Uri and POST body content.
    Uri requestUri = new Uri("https://example.com/api/");
    using StringContent content = new StringContent("{ \"firstName\": \"John\", \"lastName\": \"Doe\"}");

    // Create HttpClient instance.
    using HttpClient client = new HttpClient();

    // Create HttpRequestMessage and set method, OAuth header, and content.
    using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "{OAuth token}");
    request.Content = content;

    // Send HTTP POST request.
    using HttpResponseMessage response = await client.SendAsync(request);

// ...