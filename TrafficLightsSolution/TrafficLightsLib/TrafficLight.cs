using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntervalLib;

namespace TrafficLightsLib
{
    public class TrafficLight
    {
        private readonly double _cutoff;
        
        public TrafficLight(double cutoff)
        {
            _cutoff = cutoff;

            //Dictionary<TrafficLightStatus, Func<Interval<>, bool>>
        }

        public TrafficLightStatus CheckValue(double value)
        {
            if (_cutoff < value)
            {
                return TrafficLightStatus.OK;
            }

            return TrafficLightStatus.NOK;
        }
    }
}
