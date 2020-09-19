
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

        /// <summary>
        /// Test Case 1.1 : Given "I am in Sad mood message", Test will pass if moodAnalyser Returns "Sad"
        /// </summary>
        [Test]
        public void GivenSadMood_ShouldReturnSad()
        {
            string expected = "Sad";
            string message = "I am in Sad mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Test Case 1.2 : Given "I am in any mood message", Test will pass if moodAnalyser Returns "Happy"
        /// </summary>
        [Test]
        public void GivenAnyMood_ShouldReturnHappy()
        {
            string expected = "Happy";
            string message = "I am in any mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Test Case 3.1 : Given null , Test will pass if moodAnalyser throws MoodAnalysisException
        /// </summary>
        [Test]
        public void GivenNullMood_ShouldThrowException()
        {
            string expected = "Enetered Null, Please Enter Proper Mood";
            string message = null;
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Test Case 3.2 : Given empty message , Test will pass if moodAnalyser throws MoodAnalysisException
        /// </summary>
        [Test]
        public void GivenEmptyMood_ShouldThrowException()
        {
            string expected = "Empty message, Please enter Proper Mood";
            string message = "";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }
    }
}
