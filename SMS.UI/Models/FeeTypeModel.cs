using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Models
{
    public class FeeTypeModel
    {
        public int FeeTypeId { get; set; }
        public string FeeTypeName { get; set; }

        public List<FeeTypeModel> GetFeeTypeModelList()
        {
            List<FeeTypeModel> feeTypeModels = new List<FeeTypeModel>()
        {
            new FeeTypeModel(){
                FeeTypeId= -1,
                FeeTypeName=" On time Payment"
            },

              new FeeTypeModel(){
                FeeTypeId= 12,
                FeeTypeName="Monthly Payment"
            },
                new FeeTypeModel(){
                FeeTypeId= 1,
                FeeTypeName="Year Payment"
            },
                new FeeTypeModel(){
                FeeTypeId= 4,
                FeeTypeName="Quaterly Payment"
            },
               new FeeTypeModel(){
                FeeTypeId= 6,
                FeeTypeName="Half Yearly Payment"
            }
        };

            return feeTypeModels;
        }
    }
}