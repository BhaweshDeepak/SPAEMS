using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Implementation.Comman
{
    public class FeeAmountBasedOnPaymentType
    {
        public decimal CalcullateFeeAmount(int paymentType,decimal amount)
        {
            switch(paymentType)
            {
                case -1:
                    return amount;
                case 12:
                    return amount *12;
                case 1:
                    return amount ;
                case 4:
                    return amount * 3;
                case 6:
                    return amount * 2;
                default:
                    return amount;
            }

        }
    }
}
