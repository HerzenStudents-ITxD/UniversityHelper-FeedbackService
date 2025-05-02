using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Mappers.Responses;

public class TypeResponseMapper : ITypeResponseMapper
{
    public TypeResponse Map(DbType dbType)
    {
        return new TypeResponse
        {
            Id = dbType.Id,
            Type = dbType.Type,
            Name = dbType.Name,
            IsActive = dbType.IsActive
        };
    }
}