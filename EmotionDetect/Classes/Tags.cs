using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmotionDetect.Classes
{
    public class Emotion
    {
        public double Sad { get; set; }
        public double Excited { get; set; }
        public double Angry { get; set; }
        public double Happy { get; set; }
        public double Bored { get; set; }
        public double Fear { get; set; }
    }

    public class Tags
    {
        public List<Emotion> Emotions { get; set; }
    }
}
