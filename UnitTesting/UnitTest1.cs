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
        public void SettignsTestDuplicateKey()
        {
            Assert.Throws<Exception>(() => Settings.initializeSettings(new string[] { "[App]", "literal2=1", "[App]", "literal2=1" }));
        }
        [Test]
        public void SettignsTestDuplicateSection()
        {
            Assert.Throws<Exception>(() => Settings.initializeSettings(new string[] { "[App]", "literal2=1", "[App]", "literal2=1" }));
        }
        [Test]
        public void SettingsTestFirstKeyValue()
        {
            Settings.initializeSettings(new string[]{ "[App]","literal2=1", "[Apps]", "literal3=1" });
            Assert.AreEqual("1", Settings.getSetting().getSettings("App", "literal2", "0"));
        }

    }
}