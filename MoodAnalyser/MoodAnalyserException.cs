using System;

namespace MoodAnalyser
{
    public class MoodAnalysisException : Exception
    {

        public enum ExceptionType
        {
            EnteredNull, EnteredEmpty, ClassNotFound
        }

        readonly ExceptionType exceptionType;

        public MoodAnalysisException(ExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;

        }
    }
}
