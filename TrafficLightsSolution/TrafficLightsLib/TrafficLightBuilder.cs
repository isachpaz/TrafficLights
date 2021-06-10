using System;
using IntervalLib;

namespace TrafficLightsLib
{
    public class TrafficLightBuilder<T> where T : struct, IComparable<T>
    {
        TrafficLight<T> _trafficLight = new TrafficLight<T>();

        private TrafficLightBuilder()
        {
        }

        public static TrafficLightBuilder<T> Initialize() => new TrafficLightBuilder<T>();

        public TrafficLightBuilder<T> GreenIfValueIncludedIn(Interval<T> interval)
        {
            _trafficLight.Map(TrafficLightState.OK, interval);
            return this;
        }

        public TrafficLightBuilder<T> YellowIfValueIncludedIn(Interval<T> interval)
        {
            _trafficLight.Map(TrafficLightState.POK, interval);
            return this;
        }

        public TrafficLightBuilder<T> RedIfValueIncludedIn(Interval<T> interval)
        {
            _trafficLight.Map(TrafficLightState.NOK, interval);
            return this;
        }

        public TrafficLight<T> Build()
        {
            return _trafficLight;
        }
        
    }
}