﻿using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto;
using System.Linq;

namespace UniversityHelper.FeedbackService.Mappers.Responses;

public class FeedbackResponseMapper : IFeedbackResponseMapper
{
  private readonly IFeedbackInfoMapper _mapper;
  private readonly IImageMapper _imageMapper;

  public FeedbackResponseMapper(
    IFeedbackInfoMapper mapper,
    IImageMapper imageMapper)
  {
    _mapper = mapper;
    _imageMapper = imageMapper;
  }

  public FeedbackResponse Map(DbFeedback dbFeedback)
  {
    return dbFeedback is null
      ? null
      : new FeedbackResponse()
      {
        Feedback = _mapper.Map(dbFeedback, dbFeedback.Images.Count),
        Images = dbFeedback.Images.Select(_imageMapper.Map).ToList()
      };
  }
}
