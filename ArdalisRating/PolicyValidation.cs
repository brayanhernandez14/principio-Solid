using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    internal class PolicyValidation
    {
        public static decimal PolicyValidation_Auto(Policy policy, decimal Rating) {
            
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {

                    return 1000m;
                }
                else {
                    
                    return 900m;
                }
            }
            return 0;
        }
        public static void PolicyValidation_Land(Policy policy, decimal Rating) 
        {
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                PrintText.Land_Alert(1);
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                PrintText.Land_Alert(2);
                return;
            }
        }
        public static void PolicyValidation_Life(Policy policy, decimal Rating) {
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                PrintText.Life_Alert(1);
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                PrintText.Life_Alert(2);
                return;
            }
            if (policy.Amount == 0)
            {
                PrintText.Life_Alert(3);
                return;
            }
            

        }
        public static void PolicyValidation_LifeTwo(Policy policy, decimal Rating, int age, decimal baseRate) {
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }

            if (policy.IsSmoker)
            {
                Rating = baseRate * 2;
                return;
            }

        }
    }
}
