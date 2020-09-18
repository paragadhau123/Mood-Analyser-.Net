using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
             String analyseMood(String message)
            {
                if (message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
        }
    }
}
