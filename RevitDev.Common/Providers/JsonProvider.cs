using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace RevitDev.Common.Providers;

public class JsonProvider
{
    public Dictionary<TK, TV> GetDictionaryFromResourceJson<TK, TV>(Assembly assembly, string resourceName)
    {
        var resourceNames = assembly.GetManifestResourceNames();

        var fullResourceName = resourceNames.First(n => n.Contains(resourceName));

        using (var stream = assembly.GetManifestResourceStream(fullResourceName))
        {
            if (stream == null)
            {
                throw new NullReferenceException($"Check {resourceName}");
            }

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var dict = JsonConvert.DeserializeObject<Dictionary<TK, TV>>(json);

                if (dict == null)
                {
                    throw new NullReferenceException("Can't deserialize a resource");
                }

                return dict;
            }
        }
    }
}