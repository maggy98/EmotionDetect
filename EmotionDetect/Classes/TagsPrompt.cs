using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetect.Classes
{
    public class EmotionPromp
    {
        public double Happy { get; set; }
        public double Angry { get; set; }
        public double Surprise { get; set; }
        public double Sad { get; set; }
        public double Fear { get; set; }
    }
    public class TagsPrompt
    {
        public List<EmotionPromp> EmotionPromp { get; set; }
    }
}
