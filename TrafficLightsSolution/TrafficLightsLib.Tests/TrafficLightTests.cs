using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TrafficLightsLib.Tests
{
    [TestFixture]
    public class TrafficLightTests
    {
        [Test]
        public void If_Smaller_Than_20_Then_Green()
        {
            var tl = new TrafficLight(cutoff: 20);
            var status = tl.CheckValue(10);
            Assert.AreEqual(TrafficLightStatus.OK, status);
        }
        
        [Test]
        public void If_Larger_Than_20_Then_Green()
        { 
            var tl = new TrafficLight(cutoff: 20);
            var status = tl.CheckValue(30);
            Assert.AreEqual(TrafficLightStatus.OK, status);
        }
    }
}
