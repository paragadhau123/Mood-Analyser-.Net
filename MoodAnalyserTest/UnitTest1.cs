
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
        public void WhenGivenSadMessageShouldReturnSad()
        {
            MoodAnalyserMain moodAnalyzer = new MoodAnalyserMain();
            String mood = moodAnalyzer.analyseMood("This is a Sad Message");
            Assert.AreEqual("SAD", mood);
            }
            
        }
    }
