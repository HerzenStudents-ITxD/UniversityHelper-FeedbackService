using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;

[AutoInject]
public interface ITypeResponseMapper
{
    TypeResponse Map(DbType dbType);
}