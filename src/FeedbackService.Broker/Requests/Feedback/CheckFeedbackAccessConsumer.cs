using UniversityHelper.Core.BrokerSupport.Broker;
using UniversityHelper.FeedbackService.Data.Interfaces;
using MassTransit;
using UniversityHelper.Models.Broker.Requests.Feedback;

namespace UniversityHelper.FeedbackService.Broker.Consumers;

public class CheckFeedbackAccessConsumer : IConsumer<ICheckFeedbackAccessRequest>
{
    private readonly IFeedbackAgentRepository _agentRepository;

    public CheckFeedbackAccessConsumer(IFeedbackAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public async Task Consume(ConsumeContext<ICheckFeedbackAccessRequest> context)
    {
        var response = OperationResultWrapper.CreateResponse(CheckAccessAsync, context.Message);

        await context.RespondAsync<IOperationResult<bool>>(response);
    }

    private async Task<object> CheckAccessAsync(ICheckFeedbackAccessRequest request)
    {
        return await _agentRepository.IsModeratorAsync(request.UserId, request.FeedbackId) ||
               await _agentRepository.IsAgentAsync(request.UserId, request.FeedbackId);
    }
}