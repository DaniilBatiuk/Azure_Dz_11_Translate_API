using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Dz_11_Translate_API
{
    public class Translation
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("to")]
        public string To { get; set; }
    }

    public class TranslationResult
    {
        [JsonPropertyName("translations")]
        public IList<Translation> Translations { get; set; }
    }
}
