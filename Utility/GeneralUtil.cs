
using System.Reflection;

namespace Shop.Utility;


public static class GeneralUtil
{
public static T? ApplyChanges<T>(T SourceObject, T DestObject) where T : new()
{

  if (SourceObject is not null && DestObject is not null &&
   SourceObject.GetType() == DestObject.GetType() &&
   SourceObject.GetType().GetProperties().Count() == DestObject.GetType().GetProperties().Count())
  {
    foreach (PropertyInfo item in SourceObject.GetType().GetProperties())
    {
      var value = item.GetValue(DestObject, null);

      if (value is not null && item.Name.IndexOf("id", StringComparison.CurrentCultureIgnoreCase) < 0)
        SourceObject.GetType().GetProperty(item.Name)!.SetValue(SourceObject, value);
    }


    return SourceObject;
  }

  return default;
}
}