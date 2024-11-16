namespace Benchmark.Testing.Votes.V1;

using Core.Votes.V1.Commands;
using Core.Votes.V1.Queries;
using Test.Setup;
using Test.Setup.TestData.Vote.V1;
using Utilities;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[HtmlExporter]
[RPlotExporter]
public class VoteV1MemoryBenchmarker : QueryTestBase
{
    [GlobalSetup]
    public void Setup()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        configuration.Bind("Settings", new Settings());
    }

    [Benchmark]
    public async Task TestCast()
    {
        var sutCast = new CastVoteCommandHandler(this.Context);
        var resultCast = await sutCast.Handle(new CastVoteCommand()
        {
            VoteFor = VoteTestData.Create.VoteFor,
            VoterName = VoteTestData.Create.VoterName
        }, CancellationToken.None);

        if (!resultCast.IsError)
        {
            var sutGet = new GetAllVotesQueryHandler(this.Context);
        }
    }
}
