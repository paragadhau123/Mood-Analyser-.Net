
using MoodAnalyser;
using NUnit.Framework;
using System;

namespace MoodAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
        *This Test Case Excepts
        * Sad Mood
        */
        [Test]
         public void WhenGivenSadMessage_ShouldReturnSad()
        {
            try
            {
                MoodAnalyserMain m = new MoodAnalyserMain("i am in sad mood");
                string result = m.getMood(); ;
                Assert.AreEqual("SAD", result);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "YOU HAVE ENTERED AN INVALID INPUT");
            }
        }
            /*
            *This Test Case Excepts
            * Any Other Mood
            */
        [Test]
        public void WhenGivenHappyMessage_ShouldReturnHappy()
        {
            try
            {
                MoodAnalyserMain m = new MoodAnalyserMain("i am in any mood");
                string result = m.getMood();
                Assert.AreEqual("HAPPY", result);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "YOU HAVE ENTERED AN INVALID INPUT");
            }
        }
        /*
        *This Test Case Will Check For
        * Null Pointer Exception
        */
        [Test]
        public void WhenGivenNullMessage_ShouldThrowMoodAnalyserException()
        {
            try
            {
                MoodAnalyserMain m = new MoodAnalyserMain(null);
                string result = m.getMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_NULL, e.type);
            }
        }
        /*
        *This Test Case Will Check For
        * for empty and null values
        */
        [Test]
        public void WhenGivenEmptyMessage_ShouldThrowMoodAnalyserException()
        {
            try
            {
                MoodAnalyserMain m = new MoodAnalyserMain("");
                string result = m.getMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, e.type);
            }
        }
    }
}
