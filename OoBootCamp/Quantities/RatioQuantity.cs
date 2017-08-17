/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */
 
namespace OoBootCamp.Quantities
{
    // Understands a specific zero-based measurement
    public class RatioQuantity : IntervalQuantity
    {
        internal RatioQuantity(double amount, Unit unit) : base (amount, unit) { }
        
        public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right) 
            => new RatioQuantity(left.Amount + left.ConvertedAmount(right), left.Unit);

        public static RatioQuantity operator -(RatioQuantity q) => new RatioQuantity(-q.Amount, q.Unit);

        public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right) => left + -right;
    }
}