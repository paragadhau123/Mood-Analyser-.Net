
using MoodAnalyser;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;


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
        /// <summary>
        /// Test Case 4.1 : Given class name , Test will pass if Mood AnalyserFactory creates object of given class name
        /// </summary>
        [Test]
        public void GivenClassName_ShouldReturnObject()
        {
            object expected = new MoodAnalysermain();
            string className = "MoodAnalysermain";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            Assert.AreEqual(expected, createdObject);
        }

        /// <summary>
        /// Test Case 4.2 : Given class name when imporper , Test will pass if Mood AnalyserFactory throws an exception
        /// </summary>
        [Test]
        public void GivenClassName_WhenImproper_ShouldthrowException()
        {
            string expected = "No Such class exists";
            string className = "Hello";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            Assert.AreEqual(expected, createdObject);
        }

        /// <summary>
        /// Test Case 4.3 : Given constructor when imporper , Test will pass if Mood AnalyserFactory throws an exception
        /// </summary>
        [Test]
        public void GivenConstructor_WhenImproper_ShouldthrowException()
        {
            string expected = "No Such Method exists";

            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(2);
            object createdObject = moodAnalyserFactory.CreateObjectUsingConstructor(constructor, 1);
            Assert.AreEqual(expected, createdObject);
        }
        /// <summary>
        /// Test Case 5.1 : Given class name , Test will pass if Mood AnalyserFactory creates object of given class name
        /// </summary>
        [Test]
        public void GivenMoodAnalyser_WhenProper_ShouldReturnObject()
        {
            object expected = new MoodAnalysermain("I am in happy mood");
            string className = "MoodAnalyser";
            string parameter = "I am in happy mood";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
            object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor(className, constructor, parameter);
            Object.Equals(expected, createdObject);
        }
    }
}