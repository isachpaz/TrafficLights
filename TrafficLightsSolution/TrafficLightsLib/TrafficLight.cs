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
        
        private Dictionary<TrafficLightStatus, Interval<double>> _dict = 
            new Dictionary<TrafficLightStatus, Interval<double>>();

        public TrafficLight()
        {
            
        }

        public void AddRule(TrafficLightStatus status, Interval<double> interval)
        {
            _dict.Add(status, interval);
        }

        public TrafficLightStatus CheckValue(double value)
        {
            foreach (var item in _dict)
            {
                var func = item.Value;
                if (func.Includes(value))
                {
                    return item.Key;
                }
            }

            return TrafficLightStatus.NOK;
        }
    }
}
