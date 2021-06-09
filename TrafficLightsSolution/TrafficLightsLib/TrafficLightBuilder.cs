using IntervalLib;

namespace TrafficLightsLib
{
    public class TrafficLightBuilder
    {
        TrafficLight _trafficLight = new TrafficLight();

        private TrafficLightBuilder()
        {
        }

        public static TrafficLightBuilder Initalize() => new TrafficLightBuilder();

        public TrafficLightBuilder GreenIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.AddRule(TrafficLightStatus.OK, interval);
            return this;
        }

        public TrafficLightBuilder YellowIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.AddRule(TrafficLightStatus.POK, interval);
            return this;
        }

        public TrafficLightBuilder RedIfValueIncludedIn(Interval<double> interval)
        {
            _trafficLight.AddRule(TrafficLightStatus.NOK, interval);
            return this;
        }

        public TrafficLight Build()
        {
            return _trafficLight;
        }
    }
}