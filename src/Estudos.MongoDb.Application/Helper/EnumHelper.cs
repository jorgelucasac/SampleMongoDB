using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Application.Helper;

internal static class EnumHelper
{
    public static bool IsInCountryEnum(int country)
    {
        return Enum.IsDefined(typeof(Country), country);
    }
}