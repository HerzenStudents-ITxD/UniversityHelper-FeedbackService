using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;

namespace UniversityHelper.FeedbackService.Data
{

  public class ImageRepository : IImageRepository
  {
    private readonly IImageInfoMapper _imageInfoMapper;
    private readonly FeedbackServiceDbContext _context;

    public ImageRepository(IImageInfoMapper imageInfoMapper, FeedbackServiceDbContext context)
    {
      _imageInfoMapper = imageInfoMapper;
      _context = context;
    }

    public async Task CreateAsync(List<DbImage> images)
    {
      if (images == null || !images.Any())
      {
        return;
      }

      await _context.Images.AddRangeAsync(images);
      await _context.SaveChangesAsync();
    }

    public async Task<List<ImageInfo>?> GetByFeedbackIdAsync(Guid feedbackId)
    {
      var images = await _context.Images
          .Where(img => img.FeedbackId == feedbackId)
          .ToListAsync();

      return images?
          .Select(img => _imageInfoMapper.Map(img))
          .Where(img => img != null)
          .ToList();
    }
  }
}