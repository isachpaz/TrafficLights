using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntervalLib;
using NUnit.Framework;

namespace TrafficLightsLib.Tests
{
    [TestFixture]
    public class TrafficLightTests
    {
        [Test]
        public void If_Smaller_Than_20_Then_Green()
        {
            var tl = TrafficLightBuilder.Initalize()
                .GreenIfValueIncludedIn(Interval<double>.Bounded(0, Edge.Closed, 20, Edge.Open))
                .Build();
            var status = tl.CheckValue(10);
            Assert.AreEqual(TrafficLightStatus.OK, status);
        }
        
        [Test]
        public void If_Larger_Than_20_Then_Green()
        {
            //var tl = new TrafficLight(TrafficLightStatus.OK, Interval<double>.Bounded(20, Edge.Open, 2000, Edge.Open));
            var tl = TrafficLightBuilder.Initalize()
                .GreenIfValueIncludedIn(Interval<double>.Bounded(20, Edge.Open, 2000, Edge.Open))
                .Build();
            var status = tl.CheckValue(30);
            Assert.AreEqual(TrafficLightStatus.OK, status);
        }


        [Test]
        public void If_0_to_20_Green_If_20_to_40_Yellow_If_Larger_Than_40_Then_Red()
        {
            // 0..20 => Green
            // 20..40 => Yellow
            // 40..xx => Red

            var tl = TrafficLightBuilder.Initalize()
                .GreenIfValueIncludedIn(Interval<double>.Bounded(0, Edge.Closed, 20, Edge.Open))
                .YellowIfValueIncludedIn(Interval<double>.Bounded(20, Edge.Closed, 40, Edge.Open))
                .RedIfValueIncludedIn(Interval<double>.Bounded(40, Edge.Closed, Double.MaxValue, Edge.Open))
                .Build();
            
            Assert.AreEqual(TrafficLightStatus.OK, tl.CheckValue(10));
            Assert.AreEqual(TrafficLightStatus.POK, tl.CheckValue(30));
            Assert.AreEqual(TrafficLightStatus.NOK, tl.CheckValue(55));
        }


    }
}
