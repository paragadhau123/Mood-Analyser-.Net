//-----------------------------------------------------------------------
// <copyright file="MoodAnalysermain.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyser
{
    using System;

    /// <summary>
    /// MoodAnalyzer main Class
    /// </summary>
    public class MoodAnalysermain
    {        
        /// <summary>
        /// Message variable
        /// </summary>
        private string message;
                              
        public MoodAnalysermain(string message)
            {
                this.Message = message;
            }

        public MoodAnalysermain()
        {
        }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        private string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args">String argument</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>       
        /// <returns>mood happy or sad</returns>
        public string AnalyseMood1()
        {
            return this.AnalyseMood(this.Message);
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="m">first name to validate</param>
        /// <returns>mood happy or sad</returns>
        public string AnalyseMood(string m)
            {
                try
                {
                if (this.Message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredNull, "Enetered Null, Please Enter Proper Mood");
                }

                if (this.Message.Length == 0)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredEmpty, "Empty message, Please enter Proper Mood");
                }

                if (this.Message.Contains("sad", StringComparison.OrdinalIgnoreCase))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (Exception e)
                {
                    return e.Message;
                }
              }
            }
         }  