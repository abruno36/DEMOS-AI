using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;

namespace Translate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Falai garota(o)!");

            var speechConfig = SpeechTranslationConfig.FromSubscription("84fecb59abe04eb590f6429ce7e19d29", "southcentralus");
            speechConfig.SpeechRecognitionLanguage = "pt-BR";

            //speechConfig.AddTargetLanguage("en-US");

            var lang = new List<string>() { "en-US", "fr-FR", "es-AR" };
            lang.ForEach(speechConfig.AddTargetLanguage);

            var recognizer = new TranslationRecognizer(speechConfig);
            
            while (true)
            {
                var result = await recognizer.RecognizeOnceAsync();
                if (result.Reason == ResultReason.TranslatedSpeech)
                {
                    foreach (var item in result.Translations)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                        if (item.Value == "Go out.")
                        {
                            break;
                        }
                    }
                }
            }
         
            Console.ReadLine();

        }
    }
}
