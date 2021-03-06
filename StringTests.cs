﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CommonTests
{
    /// <summary>
    /// Summary description for StringTests
    /// </summary>
    [TestClass]
    public class StringTests
    {
        public StringTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //This is just a Comment

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [TestCategory("String tests")]
        public void TestUrlExpression()
        {
            string[] data = new string[]
			{
                @"I ett långt stycke med flera länkar till bl a http://www.consid.se
bör man ändå kunna ersätta http://consid.se/se/karriaer/lediga-tjaenster/net-utvecklare-till-goeteborg/ 
eftersom allting avbryts https://intranet.industriall-union.org/Calendar/peoplethisweek/edit/ så fort
man skriver ett blanksteg. Sedan kan man läsa på www.dagensnyheter.se för att se vad som händer.
Eva Marie påstår att länkar som är speciella https://www.google.se/#q=regex+c%23+example inte funger
och då måste jag ju fixa det"
			};

            Regex re = new Regex(@"(http://|https://|www\.)([^\s])*", RegexOptions.IgnoreCase);
            foreach (string s in data)
            {

                MatchCollection matches = re.Matches(s);

                foreach (Match m in matches)
                    TestContext.WriteLine("{0} => {1} => {2}\r\n", s, m.Groups[1].Value, m.Value);


                string result = re.Replace(s, CreateBitLy);
                TestContext.WriteLine(result);


            }
        }

        private string CreateBitLy(Match m)
        {
            string prefix = m.Groups[1].Value;
            string current = m.Value;

            return "http://bit.ly/" + RandomString(6);
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Test a url pattern and removes trailing numbers. Used by client cache-prevent
        /// url rewriter written by Tibor
        /// </summary>
        [TestMethod]
        [TestCategory("String tests")]
        public void TestRegex()
        {
            string s = "http://syncron.local/assets/css/main.20140805115625.css";
            string pattern = @"^(.*)\.\d+\.(css|js)$";

            TestContext.WriteLine("Before: {0}", s);
            s = Regex.Replace(s, pattern, @"$1.$2");

            TestContext.WriteLine("After: {0}", s);

        }

        [TestMethod]
        [TestCategory("IndustriALL")]
        public void TestTimeZone()
        {
            // set value to convert
            string pageTimeZone = "Central Europe Standard Time";

            // create a time zone info object
            TimeZoneInfo ti = string.IsNullOrWhiteSpace(pageTimeZone) ? null : TimeZoneInfo.FindSystemTimeZoneById(pageTimeZone);

            // get current local time
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, ti);

            // get timezone offset for local time (including daylight saving time)
            string currentUtcOffset = string.IsNullOrEmpty(pageTimeZone) ? "" : localTime.Offset.ToString(@"\+hhmm");

            TestContext.WriteLine("Page time zone: {0}", pageTimeZone);
            TestContext.WriteLine("Current local time for time zone:{0}", localTime);
            TestContext.WriteLine("Time zone base UTC offset: {0}", ti.BaseUtcOffset.ToString(@"\+hhmm"));
            TestContext.WriteLine("Time zone current UTC offset: {0}", currentUtcOffset);
            TestContext.WriteLine("Is daylight saving time: {0}", ti.IsDaylightSavingTime(localTime));
        }

        [TestMethod]
        [TestCategory("String tests")]
        public void TestCharArray()
        {
            char[] first = new char[] { '\r', '\n' };
            char[] second = new char[] { '\x0d', '\x0a' };

            Assert.AreEqual(first[0], second[0]);
            Assert.AreEqual(first[1], second[1]);
        }
        /// <summary>
        /// Added comment #1
        /// </summary>
        public void GitTest_1()
        {

        }

        /// <summary>
        /// Added comment #2
        /// </summary>
        public void GitTest_2()
        {

        }

        [TestMethod]
        [TestCategory("Fagerhult")]
        public void StringSortTest()
        {
            string[] data = new string[]
            {
                 "2x50/54 9.4 1200 300 23238", 
                 "4x20/24 9.2 600 600 23230", 
                 "2x25/28 9.4 1200 300 23232", 
                 "3x13/14 9.1 600 600 23228", 
                 "3x25/28 14.3 1200 600 23234", 
                 "4x13/14 9.2 600 600 23229", 
                 "4x25/28 14.5 1200 600 23235"
            };

            TestContext.WriteLine("Unsorted:");
            foreach (string s in data)
                TestContext.WriteLine(s);


            Array.Sort(data);

            TestContext.WriteLine("\r\nSorted:");
            foreach (string s in data)
                TestContext.WriteLine(s);
        }


        [TestMethod]
        [TestCategory("Tibor")]
        public void LookupH2WithRegex()
        {
            string pattern = "<h2([^>]*)>([^<]+)</h2>";
            string input = "<h2 style=\"margin-top: 6px;\">Viktigt</h2>";

            Assert.IsTrue(Regex.IsMatch(input, pattern));

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match m in matches)
            {
                TestContext.WriteLine("Match: {0}", m.Value);
                foreach (var x in m.Groups.Cast<Group>().Select((g, i) => new { Index = i, Group = g }))
                {
                    TestContext.WriteLine("\tmatch.Groups[{0}]= \"{1}\"", x.Index, x.Group.Value);
                }
                string s2 = Regex.Replace(input, pattern, "<h2 id=\"{0}\"$1>$2</h2>");
                TestContext.WriteLine("\tReplaced string = \"{0}\"", s2);

            }

        }

        [TestMethod]
        [TestCategory("Bokrondellen")]
        public void ParseMedarbetare()
        {
            string intput = @"forfattare;Adam Bertilsson;;0000 0001 0856 1812
illustrator;Caesar Davidsson;http://www.consid.se/;0000 0001 0068 0715
formgivare;Erik Filipsson
efterordsforfattare;Andersson, Adam;http://www.dn.se
forordsforfattare;Bengtsson, Bertil;;1234567890123456
omslagsillustrator;Carlsson, Caesar;http://www.svt.se/;0000111122223333
huvudredaktor;Dunge, David
antologiredaktor;Eskilsson, Erik";

            string pattern = "(.+?);([^;\r\n]+);?([^;\r\n]*);?([^\r\n]*)";
            Regex re = new Regex(pattern);

            MatchCollection matches = re.Matches(intput);

            foreach (Match match in matches)
            {
                string type = match.Groups[1].Value;
                string name = match.Groups[2].Value.Trim();
                string url = match.Groups[3].Value.Trim() != string.Empty ? match.Groups[3].Value.Trim() : null;
                string isni = match.Groups[4].Value.Trim() != string.Empty ? match.Groups[4].Value.Trim() : null;

                TestContext.WriteLine("Match: {0}", match.Value);
                TestContext.WriteLine("    Type: {0}", type);
                TestContext.WriteLine("    Name: {0}", name);
                TestContext.WriteLine("    Url: {0}", url);
                TestContext.WriteLine("    ISNI: {0}", isni);
                TestContext.WriteLine("");
            }

        }

        [TestMethod]
        [TestCategory("Bokrondellen")]
        public void ParseLink()
        {
            string[] data = new[] { "http://", "http://www.dn.se", "http://dn.se/", "http://dn" };
            Regex re = new Regex(@"^http://\w+(?=\.)");

            foreach (string s in data)
            {
                TestContext.WriteLine("Regex match for {0}: {1}", s, re.IsMatch(s));
            }
        }

        [TestMethod]
        [TestCategory("Bokrondellen")]
        public void TestPasswordValidation()
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            Regex re = new Regex(pattern);

            string[] data = new[]
            {
                "abCd1234",
                "abcdefghi12340A",
                "aAbcd12a",
                "123ABcde",
                "Abc12345",
                "123456aA",
                "Abcd1234",
                "abcD1234",
                "1234a57A",
                "abcdEFGH0"
            };

            foreach(string s in data)
            {
                Assert.IsTrue(re.IsMatch(s));
            }
        }
    }
}
