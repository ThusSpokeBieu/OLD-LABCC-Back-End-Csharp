
namespace LABCC.BackEnd.Utils;

public static class StringEnumConverter
{
  public static Enum StringToEnum(string source, Type target) 
  {
    return (Enum)Enum.Parse(target, source, true);
  }

  public static string EnumToString(Enum source)
  {
    return source.ToString();
  }

  public static byte StringToEnumByteIndex(string source, Type enumType)
  {
    if (!enumType.IsEnum)
    {
      throw new ArgumentException("O tipo fornecido não é um Enum válido.");
    }

    object enumValue = Enum.Parse(enumType, source, ignoreCase: true);

    if (!Enum.IsDefined(enumType, enumValue))
    {
      throw new ArgumentException("A string fornecida não corresponde a nenhum valor válido do Enum.");
    }

    byte enumIndex = (byte)enumValue;

    return enumIndex;
  }
}
