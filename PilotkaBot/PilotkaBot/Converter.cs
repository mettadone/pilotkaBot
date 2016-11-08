using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;


namespace PilotkaBot
{
    public static class Converter
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }
}
