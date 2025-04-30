using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UniversityHelper.FeedbackService.Models.Dto.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum FeedbackType
{
  Bug,
  Wishes,
  Other
}
