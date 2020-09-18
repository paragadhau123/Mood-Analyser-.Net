using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserMain
    {
        public String analyseMood(String message)
        {
            if (message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
