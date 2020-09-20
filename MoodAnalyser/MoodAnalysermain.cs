using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyser
{

    public class MoodAnalysermain
    {
       
        public static void Main(string[] args)
        {
           
        }
    
       
            public int name = 19;
           
            private string _message;

            
            private string Message
            {
                get { return this._message; }
                set { this._message = value; }
            }

           
            public MoodAnalysermain() { }

           
            public MoodAnalysermain(string message)
            {
                this.Message = message;
            }

        public String AnalyseMood1()
        {
            return this.AnalyseMood(Message);
        }
            public string AnalyseMood(String m)
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
                catch (Exception e)
                {
                    return e.Message;
                }
            }
       
    }
       
    }

