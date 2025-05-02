using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbTypeMapper
{
    DbType Map(CreateTypeRequest request);
}