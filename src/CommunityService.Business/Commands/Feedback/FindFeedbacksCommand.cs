using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.FluentValidationExtensions;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.Core.Validators.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback;

public class FindFeedbacksCommand : IFindFeedbacksCommand
{
  private readonly IBaseFindFilterValidator _validator;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IFeedbackRepository _repository;
  private readonly IFeedbackInfoMapper _mapper;

  public FindFeedbacksCommand(
    IBaseFindFilterValidator validator,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IHttpContextAccessor httpContextAccessor,
    IFeedbackRepository repository,
    IFeedbackInfoMapper mapper)
  {
    _validator = validator;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _httpContextAccessor = httpContextAccessor;
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<FindResultResponse<FeedbackInfo>> ExecuteAsync(FindFeedbacksFilter filter)
  {
    if (!await _accessValidator.IsAdminAsync(_httpContextAccessor.HttpContext.GetUserId()))
    {
      return _responseCreator.CreateFailureFindResponse<FeedbackInfo>(HttpStatusCode.Forbidden);
    }

    if (!_validator.ValidateCustom(filter, out List<string> errors))
    {
      return _responseCreator.CreateFailureFindResponse<FeedbackInfo>(HttpStatusCode.BadRequest, errors);
    }

    (List<(DbFeedback dbFeedback, int imagesCount)> dbFeedbacks, int totalCount) = await _repository.FindAsync(filter);

    return new FindResultResponse<FeedbackInfo>(
      dbFeedbacks.Select(f => _mapper.Map(f.dbFeedback, f.imagesCount)).ToList(),
      totalCount);
  }
}
