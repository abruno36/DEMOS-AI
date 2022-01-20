using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace AI_Mic
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Falai garota(o)!");
            var config = SpeechConfig.FromSubscription("84fecb59abe04eb590f6429ce7e19d29", "southcentralus");
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();

            var recognizer = new SpeechRecognizer(config, "pt-Br", audioConfig);

            Console.WriteLine("Falei agora - pronto falei");

            while (true)
            {
                var result = await recognizer.RecognizeOnceAsync();
                var text = result.Text;
                Console.WriteLine($"Rec: {text}");
                if (text.ToLower().Contains("sair."))
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
