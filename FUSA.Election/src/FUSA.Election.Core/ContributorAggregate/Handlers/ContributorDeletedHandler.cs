﻿using FUSA.Election.Core.ContributorAggregate.Events;
using FUSA.Election.Core.Interfaces;

namespace FUSA.Election.Core.ContributorAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class ContributorDeletedHandler(ILogger<ContributorDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<ContributorDeletedEvent>
{
  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ContributorId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Contributor Deleted",
                                     $"Contributor with id {domainEvent.ContributorId} was deleted.");
  }
}
