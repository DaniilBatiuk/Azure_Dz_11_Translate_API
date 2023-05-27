using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Azure_Dz_11_Translate_API;

string endpoint = "https://api.cognitive.microsofttranslator.com/";
string bearerToken = "bearerToken";
string url = "translate?api-version=3.0&to=en&to=de&from=uk&to=pl";
string requestUrl = endpoint + url;
using (HttpClient client = new HttpClient())
using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl))
{
    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

    object[] textForTranslate = new[] {
        new {Text = "Мене цікавить вивчення і використання хмарних сервісів для розробки програмного забезпечення" },
        new {Text = "Доброго вечора, ми з України"}
    };

    string body = JsonSerializer.Serialize(textForTranslate);

    requestMessage.Content = new StringContent(body, encoding: Encoding.UTF8, "application/json");
    HttpResponseMessage message = await client.SendAsync(requestMessage);

    string translation = await message.Content.ReadAsStringAsync();

    List<TranslationResult>? translationResults = JsonSerializer.Deserialize<List<TranslationResult>>(translation);

    foreach (TranslationResult result in translationResults!)
    {
        Console.WriteLine("=>");
        foreach (Translation transl in result.Translations)
        {
            Console.WriteLine($"To {transl.To}: {transl.Text}");
        }
    }
    Console.WriteLine("====================================\n");
}
