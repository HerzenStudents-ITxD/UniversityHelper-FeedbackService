using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback;

public class GetAllFeedbacksCommand : IGetAllFeedbacksCommand
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IFeedbackResponseMapper _responseMapper;
    private readonly IAccessValidator _accessValidator;
    private readonly IResponseCreator _responseCreator;

    public GetAllFeedbacksCommand(
        IFeedbackRepository feedbackRepository,
        IFeedbackResponseMapper responseMapper,
        IAccessValidator accessValidator,
        IResponseCreator responseCreator)
    {
        _feedbackRepository = feedbackRepository;
        _responseMapper = responseMapper;
        _accessValidator = accessValidator;
        _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<FeedbackResponse[]>> ExecuteAsync()
    {
        if (!await _accessValidator.IsAdminAsync())
        {
            return _responseCreator.CreateFailureResponse<FeedbackResponse[]>(HttpStatusCode.Forbidden);
        }

        var feedbacks = await _feedbackRepository.GetAllAsync();
        var response = feedbacks.Select(_responseMapper.Map).Where(x => x != null).ToArray();

        return new OperationResultResponse<FeedbackResponse[]>(body: response);
    }
}