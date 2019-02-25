using System;

namespace ExtractTransformLoad.Domain
{
    public class Invoice
    {
        public string ShipperName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal Freight { get; set; }
    }
}