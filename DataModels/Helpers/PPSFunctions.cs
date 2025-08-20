namespace DataModels.Helpers
{

    using System.Text.Json;
    public class PPSFunctions
    {
        public string MkPlural(string phrase)
        {
            var retval = "";
            var lastLetter = phrase.Trim().Substring(phrase.Trim().Length - 1, 1);
            var nextToLastLetter = phrase.Trim().Substring(phrase.Trim().Length - 2, 1);
            switch (lastLetter)
            {
                case "y":
                    switch (nextToLastLetter)
                    {
                        case "a":
                        case "e":
                        case "o":
                        case "u":
                            retval = phrase.Trim() + "s";
                            break;
                        default:
                            retval = phrase.Trim().Substring(0, phrase.Trim().Length - 1) + "ies";
                            break;
                    }
                    break;
                case "s":
                    retval = phrase.Trim() + "es";
                    break;
                default:
                    retval = phrase.Trim() + "s";
                    break;
            }
            return retval;
        }

        public static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();
            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name &&
                destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        if (destProperty.CanWrite)
                        {
                            destProperty.SetValue(destination, sourceProperty.GetValue(
                                  source, new object[] { }), new object[] { });
                        }
                        break;
                    }
                }
            }
        }


    }


}
