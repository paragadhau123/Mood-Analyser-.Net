
using MoodAnalyser;
using NUnit.Framework;
using System.Reflection;



namespace MoodAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenSadMood_ShouldReturnSad()
        {
            string expected = "Sad";
            string message = "I am in Sad mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }
        [Test]
        public void GivenAnyMood_ShouldReturnHappy()
        {
            string expected = "Happy";
            string message = "I am in any mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual(expected, mood);
        }
        [Test]
        public void GivenNullMood_ShouldThrowException()
        {
            try
            {
                string expected = "Enetered Null, Please Enter Proper Mood";
                string message = null;
                MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
                string mood = moodAnalyser.AnalyseMood();
                //Assert.AreEqual(expected, mood);
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual(MoodAnalysisException.ExceptionType.EnteredNull, e.type);
            }
        }
        [Test]
        public void GivenEmptyMood_ShouldThrowException()
        {

            try
            {
                
                string message = "";
                MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
                string mood = moodAnalyser.AnalyseMood();
              
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual(MoodAnalysisException.ExceptionType.EnteredEmpty, e.type);
            }
        }
        [Test]
        public void GivenClassName_ShouldReturnObject()
        {
            object expected = new MoodAnalysermain();
            string className = "MoodAnalyser.MoodAnalysermain";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            Assert.IsInstanceOf(typeof(MoodAnalysermain), createdObject);
        }

        
        [Test]
        public void GivenClassName_WhenImproper_ShouldthrowException()
        {
            try
            {
              
                string className = "Hello";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            }catch(MoodAnalysisException e)
            {
                Assert.AreEqual(MoodAnalysisException.ExceptionType.ClassNotFound,e.type);

            }
        }

        [Test]
        public void GivenConstructor_WhenImproper_ShouldthrowException()
        {
            try
            {
                
                string className = "MoodAnalysermain";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(2);
                object createdObject = moodAnalyserFactory.CreateObjectUsingConstructor(className, constructor, 1);
             
            }catch(MoodAnalysisException e)
            {
                Assert.AreEqual(MoodAnalysisException.ExceptionType.EnteredEmpty, e.type);

            }
        }
        
        [Test]
        public void GivenMoodAnalyser_WhenProper_ShouldReturnObject()
        {
           
                object expected = new MoodAnalysermain("I am in happy mood");
                string className = "MoodAnalysermain";
                string parameter = "I am in happy mood";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor(className, constructor, parameter);
               
                Assert.IsInstanceOf(typeof(MoodAnalysermain), createdObject);
            }
        [Test]
        public void GivenConstructor_WhenImproper_ShouldThrowException()
        {
           
            string className = "MoodAnalyser";
            string parameter = "I am in happy mood";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(2);
            object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor(className, constructor, parameter);
           
        }
        [Test]
        public void GivenHappyMessage_WhenProper_ShouldReturnHappy()
        {
            string expected = "Happy";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            dynamic mood = moodAnalyserFactory.InvokeMoodAnalyser("I am in happy mood");
            Assert.AreEqual(expected, mood);
        }
    }
}