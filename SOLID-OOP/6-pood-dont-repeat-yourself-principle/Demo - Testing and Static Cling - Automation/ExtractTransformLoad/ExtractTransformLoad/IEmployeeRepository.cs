using System.Data;

namespace ExtractTransformLoad
{
    public interface IEmployeeRepository
    {
        DataTable ListEmployees();
    }
}