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
        
        private Dictionary<TrafficLightState, Interval<double>> _dict = 
            new Dictionary<TrafficLightState, Interval<double>>();

        public TrafficLight()
        {
            
        }

        public void Map(TrafficLightState status, Interval<double> interval)
        {
            _dict.Add(status, interval);
        }

        public TrafficLightState CheckValue(double value)
        {
            foreach (var item in _dict)
            {
                var func = item.Value;
                if (func.Includes(value))
                {
                    return item.Key;
                }
            }

            return TrafficLightState.Undefined;
        }
    }
}
