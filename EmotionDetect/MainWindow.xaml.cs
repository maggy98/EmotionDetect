using System.Windows;
using EmotionDetect.Classes;
using ParallelDots;
using RestSharp;
using System.Text.Json;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.NaturalLanguageUnderstanding.v1;
using IBM.Watson.NaturalLanguageUnderstanding.v1.Model;


namespace EmotionDetect
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonToDetect_Click(object sender, RoutedEventArgs e)
        {
            var textToDetect = TextToDetect.Text;
            

            ToDetectIBM(textToDetect);
            ToDetectParallel(textToDetect);
            ToDetectPromptapi(textToDetect);
        }

        public void ToDetectParallel(string textToDetect)
        {
            var api_key = "---api key---";
            paralleldots pd = new paralleldots(api_key);

            string responseString = pd.emotion(textToDetect);
            responseString = responseString.Substring(11);
            responseString = responseString.Remove(responseString.Length-1);

            Emotion response = JsonSerializer.Deserialize<Emotion>(responseString);

            TextSad.Text = response.Sad.ToString("P3");
            TextExcited.Text = response.Excited.ToString("P3");
            TextAngry.Text = response.Angry.ToString("P3");
            TextHappy.Text = response.Happy.ToString("P3");
            TextBored.Text = response.Bored.ToString("P3");
            TextFear.Text = response.Fear.ToString("P3");
        }

        public void ToDetectPromptapi(string textToDetect)
        {
            var client = new RestClient("https://api.promptapi.com/text_to_emotion");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("apikey", "---api key---");
            request.AddParameter("text/plain", textToDetect, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string responseString = response.Content;

            EmotionPromp response2 = JsonSerializer.Deserialize<EmotionPromp>(responseString);

            TextSadPromp.Text = response2.Sad.ToString("P3");
            TextSurprisePromp.Text = response2.Surprise.ToString("P3");
            TextAngryPrompt.Text = response2.Angry.ToString("P3");
            TextHappyPrompt.Text = response2.Happy.ToString("P3");
            TextFearPromp.Text = response2.Fear.ToString("P3");

        }

        public void ToDetectIBM(string textToDetect)
        {
            IamAuthenticator authenticator = new IamAuthenticator(apikey: "---api key---");
            NaturalLanguageUnderstandingService naturalLanguageUnderstanding = new NaturalLanguageUnderstandingService("2020-08-01", authenticator);
            naturalLanguageUnderstanding.SetServiceUrl("https://api.eu-gb.natural-language-understanding.watson.cloud.ibm.com/instances/3777d0c9-6aad-4112-adc9-20fbc116ffaf");

            var result = naturalLanguageUnderstanding.Analyze(
                text: textToDetect,
                features: new Features()
                {
                    Emotion = new EmotionOptions()

                }
                );

            string responseString = result.Response;
            responseString = responseString.Substring(165);
            responseString = responseString.Remove(responseString.Length - 15);
            responseString = responseString.Replace("\r", "");
            responseString = responseString.Replace("\n        ", "");
            responseString = responseString.Remove(90, 7);

            EmotionIBM response = JsonSerializer.Deserialize<EmotionIBM>(responseString);
            TextSadIBM.Text = response.sadness.ToString("P3");
            TextHappyIBM.Text = response.joy.ToString("P3");
            TextFearIBM.Text = response.fear.ToString("P3");
            TextDisgustIBM.Text = response.disgust.ToString("P3");
            TextAngryIBM.Text = response.anger.ToString("P3");

        }

        private void TextToDetect_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}


