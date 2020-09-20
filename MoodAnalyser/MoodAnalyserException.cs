using System;

namespace MoodAnalyser
{
    public class MoodAnalysisException : Exception
    {

        public enum ExceptionType
        {
            EnteredNull, EnteredEmpty, ClassNotFound, NoSuchClass, NoSuchMethod, ErrorInObjectCreation
        }

        public ExceptionType type;
        string message;

        public MoodAnalysisException(ExceptionType type, string message) 
        {
            this.type = type;
            this.message = message;
        }
    }
}
