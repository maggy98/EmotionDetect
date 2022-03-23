using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetect.Classes
{
    public class EmotionIBM
    {
        public double sadness { get; set; }
        public double joy { get; set; }
        public double fear { get; set; }
        public double disgust { get; set; }
        public double anger { get; set; }
    }
    public class TagsIBM
    {
        public List<EmotionIBM> EmotionIBMs { get; set; }
    }
}
