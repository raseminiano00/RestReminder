using NUnit.Framework;
using RestReminder.Controller;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void SettingsTest1()
        {
            Settings.initializeSettings(@"C:/Users/Administrator/Documents/PERSONAL/REPOSITORY/RestReminder/RestReminder/settings.ini");

            Assert.AreEqual(Settings.getSetting().getPath(), @"C:/Users/Administrator/Documents/PERSONAL/REPOSITORY/RestReminder/RestReminder/settings.ini");
        }
        [Test]
        public void SettignsTestNull()
        {
            Assert.Throws<NullReferenceException>(() => Settings.getSetting().getPath());
        }
    }
}