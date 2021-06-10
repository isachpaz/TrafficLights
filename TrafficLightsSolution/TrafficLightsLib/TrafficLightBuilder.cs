using IntervalLib;

namespace TrafficLightsLib
{
    public class TrafficLightBuilder
    {
        TrafficLight _trafficLight = new TrafficLight();

        private TrafficLightBuilder()
        {
        }

        public static TrafficLightBuilder Initialize() => new TrafficLightBuilder();

        public TrafficLightBuilder GreenIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.Map(TrafficLightState.OK, interval);
            return this;
        }

        public TrafficLightBuilder YellowIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.Map(TrafficLightState.POK, interval);
            return this;
        }

        public TrafficLightBuilder RedIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.Map(TrafficLightState.NOK, interval);
            return this;
        }

        public TrafficLight Build()
        {
            return _trafficLight;
        }
    }
}