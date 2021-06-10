using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntervalLib;

namespace TrafficLightsLib
{
    public class TrafficLight<T> where T : struct, IComparable<T>
    {
        
        private Dictionary<TrafficLightState, Interval<T>> _dict = 
            new Dictionary<TrafficLightState, Interval<T>>();

        public TrafficLight()
        {
            
        }

        public static TrafficLight<T> Empty() => new TrafficLight<T>();

        public void Map(TrafficLightState status, Interval<T> interval)
        {
            _dict.Add(status, interval);
        }

        public TrafficLightState CheckValue(T value)
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
