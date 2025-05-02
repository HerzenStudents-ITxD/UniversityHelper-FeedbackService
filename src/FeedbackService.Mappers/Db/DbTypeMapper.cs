using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Mappers.Db;

public class DbTypeMapper : IDbTypeMapper
{
    public DbType Map(CreateTypeRequest request)
    {
        return new DbType(request.Type, request.Name);
    }
}