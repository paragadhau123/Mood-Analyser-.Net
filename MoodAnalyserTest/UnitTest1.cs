
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

        [Test]
        public void givenMessgae_WhenSad_ShouldReturn_Sad()
        {
            MoodAnalyserMain moodAnalyzer = new MoodAnalyserMain();
            String mood = moodAnalyzer.analyseMood("This is a Sad Message");
            Assert.AreEqual("SAD", mood);
        }

        [Test]
        public void givenMessage_WhenNotSad_ShouldReturn_Happy()
        {
            MoodAnalyserMain moodAnalyzer = new MoodAnalyserMain();
            String mood = moodAnalyzer.analyseMood("This is a Happy Message");
            Assert.AreEqual("HAPPY", mood);
        }
        [Test]
        public void givenNullMood_ShouldReturn_Happy()
        {
            MoodAnalyserMain moodAnalyzer = new MoodAnalyserMain();
            String mood = moodAnalyzer.analyseMood();
            Assert.AreEqual("HAPPY", mood);
        }
    }
}
