using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserMain
    {
        public String analyseMood(String message)
        {
            try
            {
                if (message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }catch (Exception e)
            {
                return "HAPPY";
            }
        }

        public string analyseMood()
        {
            throw new NotImplementedException();
        }
    }
}
