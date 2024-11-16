namespace Api.Controllers.V1;

using Common.Models.Vote.V1;
using Core.Votes.V1.Commands;
using Core.Votes.V1.Queries;

public class VotesController : ApiController
{
    /// <summary>
    ///     Get all Votes.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    /// <param name="query">Voting Search Model</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    [HttpPost]
    [Route("Search")]
    public async Task<ActionResult<ListResult<VoteModel>>> Search(GetAllVotesQuery query, CancellationToken cancellationToken = default)
        => ApiResponseHelper.ResponseOutcome(await this.Mediator.Send(query, cancellationToken), this);

    /// <summary>
    ///     Cast Vote.
    /// </summary>
    /// <remarks>
    ///     Vote request:
    ///     POST Vote
    ///     {
    ///         "votername" : "John Doe",
    ///         "votefor" : "Frump"
    ///     }
    /// </remarks>
    /// <param name="command">Vote Create Model.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    [HttpPost]
    public async Task<ActionResult<Result<VoteModel>>> Create(CastVoteCommand command, CancellationToken cancellationToken = default)
        => ApiResponseHelper.ResponseOutcome(await this.Mediator.Send(command, cancellationToken), this);
}
