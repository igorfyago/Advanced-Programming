using System;

namespace ExtractTransformLoad.Domain
{
    public class FreightByShipper
    {
        public decimal Freight;
        public string ShipperName;

        public override string ToString()
        {
            return String.Format(Format.FreightFormatString, ShipperName,
                                 Freight);
        }
    }
}