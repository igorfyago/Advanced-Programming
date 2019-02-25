namespace ExtractTransformLoad
{
    public class Employee
    {
        public string Name;
        public bool IsManager;

        protected decimal bonus;
        public decimal Bonus { get{ return bonus;}}

        public virtual void SetBonus(decimal freightUsedForBonus)
        {
            bonus = freightUsedForBonus/1000;
        }
    }

    public class Manager : Employee
    {
        public override void SetBonus(decimal freightUsedForBonus)
        {
            bonus = freightUsedForBonus/10;
        }
    }
}