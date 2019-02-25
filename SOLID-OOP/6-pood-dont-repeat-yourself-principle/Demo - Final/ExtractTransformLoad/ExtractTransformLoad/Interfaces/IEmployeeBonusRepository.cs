using System;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad.Interfaces
{
    public interface IEmployeeBonusRepository
    {
        void DeleteAndInsert(DateTime runDate, Employee employee);
    }
}