namespace Test.Pizzas.V1;

using Common.Models.Vote.V1;
using Core;
using Core.Votes.V1.Commands;
using Core.Votes.V1.Queries;
using Test.Setup.TestData.Pizza.V1;

[TestFixture]
public class TestVoteV1Core : QueryTestBase
{
    private VoteModel model;

    private DatabaseContext databaseContext;

    [SetUp]
    public async Task Init()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();

        configuration.Bind("Settings", new Settings());
        this.databaseContext = this.Context;
        var sutCreate = new CastVoteCommandHandler(this.databaseContext);
        var resultCreate = await sutCreate.Handle(VoteTestData.Create, CancellationToken.None);

        if (resultCreate.IsError)
        {
            Assert.That(false, Is.False);
        }

        this.model = resultCreate.Data;
    }

    [Test]
    public async Task GetAllAsync()
    {
        var sutGetAll = new GetAllPizzaQueryHandler(this.databaseContext);
        var resultGetAll = await sutGetAll.Handle(new GetAllVotesQuery { VoterName = this.model.VoterName }, CancellationToken.None);

        Assert.That(resultGetAll?.Data.Count > 0, Is.True);
    }

    [Test]
    public void SaveAsync()
        => Assert.That(this.model, Is.Not.Null);
}