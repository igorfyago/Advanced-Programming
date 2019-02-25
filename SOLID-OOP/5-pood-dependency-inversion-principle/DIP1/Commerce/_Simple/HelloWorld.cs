using System;

namespace Commerce._Simple
{
    public class HelloWorldHidden
    {
        public string Hello(string name)
        {
            if (DateTime.Now.Hour < 12) return "Good morning, " + name;
            if (DateTime.Now.Hour < 18) return "Good afternoon, " + name;
            return "Good evening, " + name;
        }
    }

    public class HelloWorldExplicit
    {
        private readonly DateTime _timeOfGreeting;

        public HelloWorldExplicit(DateTime timeOfGreeting)
        {
            _timeOfGreeting = timeOfGreeting;
        }

        public string Hello(string name)
        {
            if (_timeOfGreeting.Hour < 12) return "Good morning, " + name;
            if (_timeOfGreeting.Hour < 18) return "Good afternoon, " + name;
            return "Good evening, " + name;
        }
    }
}