using System;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad.Interfaces
{
    public interface IFreightByShipperRepository
    {
        void DeleteAndInsert(DateTime runDate, FreightByShipper freightByShipper);
    }
}