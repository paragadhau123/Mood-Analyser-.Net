using System;

namespace MoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            ENTERED_EMPTY,
            ENTERED_NULL
        }

        public ExceptionType type;
        String message;

        public MoodAnalyserException(ExceptionType type, String message)
        {
            this.type = type;
            this.message = message;

        }
    }
}
