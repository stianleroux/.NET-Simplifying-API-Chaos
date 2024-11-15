namespace Benchmark.Testing.Votes.V1;

using Core.Votes.V1.Commands;
using Test.Setup;
using Test.Setup.TestData.Pizza.V1;
using Test.Setup.TestData.Vote.V1;

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
            var sutGet = new GetVoteQueryHandler(this.Context);
            var resultGet = await sutGet.Handle(new GetVoteQuery { Id = resultCast.Data.Id }, CancellationToken.None);
        }
    }

    [Benchmark]
    public async Task TestGet()
    {
        var sutCast = new CastVoteCommandHandler(this.Context);
        var resultCast = await sutCast.Handle(VoteTestData.Cast, CancellationToken.None);

        if (!resultCast.IsError)
        {
            var sutGet = new GetVoteQueryHandler(this.Context);
            var resultGet = await sutGet.Handle(new GetVoteQuery { Id = resultCast.Data.Id }, CancellationToken.None);
        }
    }

    [Benchmark]
    public async Task TestUpdate()
    {
        var sutCast = new CastVoteCommandHandler(this.Context);
        var resultCast = await sutCast.Handle(VoteTestData.Cast, CancellationToken.None);

        if (!resultCast.IsError)
        {
            var sutUpdate = new UpdateVoteCommandHandler(this.Context);
            var resultUpdate = await sutUpdate.Handle(
                new UpdateVoteCommand
                {
                    Id = resultCast.Data.Id,
                    Model = new UpdateVoteModel
                    {
                        Name = "Test"
                    }
                }, CancellationToken.None);
        }
    }

    [Benchmark]
    public async Task TestDelete()
    {
        var sutCast = new CastVoteCommandHandler(this.Context);
        var resultCast = await sutCast.Handle(VoteTestData.Cast, CancellationToken.None);

        if (!resultCast.IsError)
        {

            var sutDelete = new DeleteVoteCommandHandler(this.Context);
            var outcomeDelete = await sutDelete.Handle(
                new DeleteVoteCommand
                {
                    Id = resultCast.Data.Id
                }, CancellationToken.None);
        }
    }
}
