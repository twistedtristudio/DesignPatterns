using System.Collections.Generic;
using System.Linq;

namespace StrategyPatternFirstLook.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new();
        public IList<Payment> SelectedPayments { get; } = new List<Payment>();
        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();
        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);
        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
        public ShippingDetails ShippingDetails { get; set; }

        public decimal GetTax()
        {
            var destination = ShippingDetails.DestinationCountry.ToLowerInvariant();

            if (destination == "sweden")
            {
                if (destination == ShippingDetails.OriginCountry.ToLowerInvariant()) return TotalPrice * 0.25m;

                return 0;
            }

            if (destination == "us")
                switch (ShippingDetails.DestinationState.ToLowerInvariant())
                {
                    case "la":
                        return TotalPrice * 0.095m;
                    case "ny":
                        return TotalPrice * 0.04m;
                    case "in":
                        return TotalPrice * .07m;
                    default:
                        return 0m;
                }

            return 0m;
        }
    }
}