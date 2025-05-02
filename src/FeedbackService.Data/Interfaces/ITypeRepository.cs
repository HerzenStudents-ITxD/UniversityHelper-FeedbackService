using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface ITypeRepository
{
    Task<List<DbType>> GetAllAsync();
    Task<DbType?> GetByIdAsync(Guid typeId);
    Task CreateAsync(DbType dbType);
    Task UpdateAsync(DbType dbType);
}