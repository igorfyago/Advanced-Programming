namespace ExtractTransformLoad.Domain
{
    public class Employee
    {
        public string Name;

        protected decimal bonus;
        public decimal Bonus { get { return bonus; } }

        public virtual void CalculateAndSetBonus(decimal freightUsedForBonus)
        {
            bonus = freightUsedForBonus / 1000;
        }
        public override string ToString()
        {
            return string.Format("{0}- IsManager? {1}", Name, false);
        }
    }

    public class Manager : Employee
    {
        public override void CalculateAndSetBonus(decimal freightUsedForBonus)
        {
            bonus = freightUsedForBonus / 10;
        }
        public override string ToString()
        {
            return string.Format("{0}- IsManager? {1}", Name, true);
        }
    }

    public class EmployeeFactory
    {
        public Employee Create(int directReportCount, string name)
        {
            if(directReportCount == 0)
            {
                var myEmployee = new Employee() {Name = name};
                return myEmployee;
            }
            var myManager = new Manager() {Name = name};
            return myManager;
        }
    }
}