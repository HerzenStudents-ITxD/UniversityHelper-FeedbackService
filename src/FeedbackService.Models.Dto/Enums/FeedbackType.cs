using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UniversityHelper.FeedbackService.Models.Dto.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum FeedbackType
{
  None,
  Wishes,
  Home,
  News,
  Routes,
  Timetable,
  Settings,
  Other
}
