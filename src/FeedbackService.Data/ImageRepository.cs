using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;
using Microsoft.EntityFrameworkCore;
using UniversityHelper.FeedbackService.Data.Provider;

namespace UniversityHelper.FeedbackService.Data;


public class ImageRepository : IImageRepository
{
private readonly IImageInfoMapper _imageInfoMapper;
private readonly IDataProvider _provider;

public ImageRepository(IImageInfoMapper imageInfoMapper, IDataProvider provider)
{
  _imageInfoMapper = imageInfoMapper;
  _provider = provider;
}

public async Task CreateAsync(List<DbImage> images)
{
  if (images == null || !images.Any())
  {
    return;
  }

  await _provider.Images.AddRangeAsync(images);
  await _provider.SaveAsync();
}

public async Task<List<DbImage>> GetByFeedbackIdAsync(Guid feedbackId)
{
  return await _provider.Images
      .Where(img => img.FeedbackId == feedbackId)
      .ToListAsync();

  
}
}