// Base URL of the Petstore API
using System.Text.Json.Nodes;
using RestSharp;

const string baseUrl = "https://localhost:7170/";

// Create RestSharp client
var client = new RestClient(baseUrl);

// Create request for "Get Pet by ID" endpoint
var request = new RestRequest($"/votes/", Method.Post);
request.AddJsonBody(new
{
    VoterName = "John Foe",
    VoteFor = "Frump"
});
try
{
    // Execute request
    var response = await client.ExecuteAsync(request);
    var jsonObject = JsonNode.Parse(response.Content);

    if (response.IsSuccessful)
    {
        var voterName = jsonObject?["Data"]?["VoterName"]?.GetValue<string>();
        var voteFor = jsonObject?["Data"]?["VoteFor"]?.GetValue<string>();

        Console.WriteLine($"Name: {voterName}");
        Console.WriteLine($"For: {voteFor}");
    }
    else
    {
        var isError = jsonObject?["IsError"]?.GetValue<bool>() ?? false;
        var isValidationError = jsonObject?["IsValidationError"]?.GetValue<bool>() ?? false;
        var voterName = jsonObject?["Data"]?["VoterName"]?.GetValue<string>();
        var errors = jsonObject?["Errors"]?.AsArray()?.Select(x => x.ToString()).ToList();
        var validationErrors = jsonObject?["ValidationErrors"]?.AsObject()
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.AsArray().Select(v => v.ToString()).ToList());

        Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
    }
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}
