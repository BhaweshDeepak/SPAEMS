
namespace SMS.Implementation.Comman
{
    public class CalcullateNetAmount
    {

        public decimal GetCalcaullatedAmount(decimal discountAmnt,decimal discountPer,decimal amount)
        {
            var discountAmount = amount - ((amount * discountPer) / 100);
            return discountAmount - discountAmnt;
        }
    }
}
