using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            PolicyValidation validation = new PolicyValidation();
            PrintText.FirstText();

            LoadPolicy load=new LoadPolicy();
            var policy=load.Load_Policy();

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    PrintText.SecondText("Auto");
                    if (String.IsNullOrEmpty(policy.Make))
                    {
                        PrintText.Auto_Alert();
                        return;
                    }
                    Rating=PolicyValidation.PolicyValidation_Auto(policy,Rating);

                    break;

                case PolicyType.Land:
                    PrintText.SecondText("LAND");
                    PolicyValidation.PolicyValidation_Land(policy,Rating);
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
                    PrintText.SecondText("LIFE");
                    PolicyValidation.PolicyValidation_Life(policy, Rating);
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    decimal baseRate = policy.Amount * age / 200;
                    PolicyValidation.PolicyValidation_LifeTwo(policy, Rating, age, baseRate);
                    Rating = baseRate;
                    break;

                default:
                    PrintText.DefaultSwitch();
                    break;
            }
            PrintText.LastText();
            
        }
    }
}
