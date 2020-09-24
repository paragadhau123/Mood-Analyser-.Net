//-----------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyser
{
    using System;

    /// <summary>
    /// MoodAnalysisException Class
    /// </summary>
    public class MoodAnalyserException : Exception
    {
        /// <summary>
        /// Message Variable
        /// </summary>
        public readonly string MESSAGE;

        /// <summary>
        /// Type Variable
        /// </summary>
        public ExceptionType TYPE;
       
        public MoodAnalyserException(ExceptionType type, string message)
        {
            this.TYPE = type;
            this.MESSAGE = message;
        }

        /// <summary>
        /// Class Enum
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// When null
            /// </summary>
            EnteredNull,

            /// <summary>
            /// When empty
            /// </summary>
            EnteredEmpty,

            /// <summary>
            /// When Class not found
            /// </summary>
            ClassNotFound,

            /// <summary>
            /// When no such Class 
            /// </summary>
            NoSuchClass,

            /// <summary>
            ///  When no such method
            /// </summary>
            NoSuchMethod,

            /// <summary>
            ///  When no there is error
            /// </summary>
            ErrorInObjectCreation
        }
    }
}
