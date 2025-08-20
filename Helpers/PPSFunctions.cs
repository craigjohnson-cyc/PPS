namespace PPS_MVC.Helpers
{
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
    }
}
