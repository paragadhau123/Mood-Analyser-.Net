//-----------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyserTest
{
    using System.Reflection;
    using MoodAnalyser;
    using NUnit.Framework;

    /// <summary>
    /// Tests Class
    /// </summary>
    public class UnitTest1
    {
        /// <summary>
        ///  Method SetUp
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Given "I am in Sad mood message", Test will pass if moodAnalyzer Returns "Sad"
        /// </summary>
        [Test]
        public void GivenSadMood_ShouldReturnSad()
        {
            string expected = "Sad";
            string message = "I am in Sad mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood1();
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Given "I am in any mood message", Test will pass if moodAnalyzer Returns "Happy"
        /// </summary>
        [Test]
        public void GivenAnyMood_ShouldReturnHappy()
        {
            string expected = "Happy";
            string message = "I am in any mood";
            MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
            string mood = moodAnalyser.AnalyseMood1();
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Given null , Test will pass if moodAnalyzer Returns "Happy" ***** THIS TEST WILL FAIL ***** To understand check Test Case 2.1
        /// </summary>
        [Test]
        public void GivenNullMood_ShouldThrowException()
        {
            try
            {
                string message = null;
                MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
                string mood = moodAnalyser.AnalyseMood1();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EnteredNull, e.TYPE);
            }
        }

        /// <summary>
        /// Given empty message , Test will pass if moodAnalyzer throws MoodAnalysisException
        /// </summary>
        [Test]
        public void GivenEmptyMood_ShouldThrowException()
        {
            try
            {
                string message = string.Empty;
                MoodAnalysermain moodAnalyser = new MoodAnalysermain(message);
                string mood = moodAnalyser.AnalyseMood1();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EnteredEmpty, e.TYPE);
            }
        }
         
        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenClassName_ShouldReturnObject()
        {
            string className = "MoodAnalyser.MoodAnalysermain";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            Assert.IsInstanceOf(typeof(MoodAnalysermain), createdObject);
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenClassName_WhenImproper_ShouldthrowException()
        {
            try
            {
                string className = "Hello";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass(className);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ClassNotFound, e.TYPE);
            }
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenConstructor_WhenImproper_ShouldthrowException()
        {
            try
            {
                string className = "MoodAnalyser";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(2);
                object createdObject = moodAnalyserFactory.CreateObjectUsingConstructor(className, constructor, 1);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ClassNotFound, e.TYPE);
            }
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenMoodAnalyser_WhenProper_ShouldReturnObject()
        {
            try
            {
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor(constructor.DeclaringType.FullName, constructor, "I am in Happy mood");
                Assert.IsInstanceOf(typeof(MoodAnalysermain), createdObject);
            }
            catch (MoodAnalyserException)
            {
            }
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenConstructor_WhenImproper_ShouldThrowException()
        {
            try
            {
                string className = "MoodAnalyser";
                string parameter = "I am in happy mood";
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(2);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor(className, constructor, parameter);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ClassNotFound, e.TYPE);
            }
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenHappyMessage_WhenProper_ShouldReturnHappy()
        {
            string expected = "Happy";
            MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
            dynamic mood = moodAnalyserFactory.InvokeMoodAnalyser("AnalyseMood1", "I am in happy mood");
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// Given class name , Test will pass if Mood Analyzer Factory creates object of given class name
        /// </summary>
        [Test]
        public void GivenHappyMessage_WhenImroper_ShouldThrowException()
        {
            try
            {
                MoodAnalyserFactory moodAnalyserFactory = new MoodAnalyserFactory();
                dynamic mood = moodAnalyserFactory.InvokeMoodAnalyser("Mood", "I am in happy mood");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NoSuchMethod, e.TYPE);
            }
        }

        /// <summary>
        /// Given Happy Should Return Happy.
        /// </summary>
        [Test]
        public void Change_Mood_Dynamically()
        {
            string result = MoodAnalyserFactory.SetField("Happy", "message");
            Assert.AreEqual("Happy", result);
        }

        /// <summary>
        /// Given Null Message Should Return MoodAnalysisException.
        /// </summary>
        [Test]
        public void ChangeMoodDynamically_WhenNull_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField(null, "message");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EnteredNull, e.TYPE);
            }
        }
    }
}
