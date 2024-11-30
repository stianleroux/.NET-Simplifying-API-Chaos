// See https://aka.ms/new-console-template for more information

using API.Client.Template;

const string baseUrl = "https://localhost:7170/";

var client = new VotesClient(baseUrl, new HttpClient());
var result = await client.CreateAsync(new CastVoteCommand()
{
    VoterName = "John Foe",
    VoteFor = "Frump"
}, "");
if(result.IsError)
{
    Console.WriteLine($"Message: {result.Message}");
    Console.WriteLine($"Error: {result.Errors}");
    Console.WriteLine($"Validation Error: {result.ValidationErrors}");
}
else
{
    Console.WriteLine($"Name: {result.Data.VoterName}");
    Console.WriteLine($"For: {result.Data.VoteFor}");
}
Console.ReadLine();