namespace CommerceProject.Model.Refactored
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}