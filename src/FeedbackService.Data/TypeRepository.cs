using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Data.Provider;
using UniversityHelper.FeedbackService.Models.Db;

namespace UniversityHelper.FeedbackService.Data;

public class TypeRepository : ITypeRepository
{
    private readonly IDataProvider _provider;

    public TypeRepository(IDataProvider provider)
    {
        _provider = provider;
    }

    public async Task<List<DbType>> GetAllAsync()
    {
        return await _provider.Types.ToListAsync();
    }

    public async Task<DbType?> GetByIdAsync(Guid typeId)
    {
        return await _provider.Types.FirstOrDefaultAsync(t => t.Id == typeId);
    }

    public async Task CreateAsync(DbType dbType)
    {
        await _provider.Types.AddAsync(dbType);
        await _provider.SaveAsync();
    }

    public async Task UpdateAsync(DbType dbType)
    {
        _provider.Types.Update(dbType);
        await _provider.SaveAsync();
    }
}