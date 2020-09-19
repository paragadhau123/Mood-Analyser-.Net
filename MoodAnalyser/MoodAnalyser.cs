using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalysermain : Exception
    {
        /// <summary>
        /// private field message
        /// </summary>
        private string _message;

        /// <summary>
        /// getter and setter property for _message
        /// </summary>
        private string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        /// <summary>
        /// default constuctor
        /// </summary>
        public MoodAnalysermain() { }

        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="message"> string type message </param>
        public MoodAnalysermain(string message)
        {
            this.Message = message;
        }


        public string AnalyseMood()
        {
            try
            {
                if (this.Message == null)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EnteredNull, "Enetered Null, Please Enter Proper Mood");

                if (this.Message.Length == 0)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EnteredEmpty, "Empty message, Please enter Proper Mood");

                if (this.Message.Contains("sad", StringComparison.OrdinalIgnoreCase))
                    return "Sad";
                else
                    return "Happy";
            }
            catch (MoodAnalysisException exception)
            {
                return exception.Message;
            }
        }

        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"> no parameters </param>
       
    }
}
