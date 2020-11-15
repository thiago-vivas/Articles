using NetCoreCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCalculator.Business
{
    /// <summary>
    /// Calculates mathematics formulas
    /// </summary>
    public static class Calculation
    {
        /// <summary>
        /// Calculates the compound interest based in a given model
        /// Formula: A = P (1 + r) (n)
        /// </summary>
        /// <param name="model">Model with input data to calculate</param>
        /// <returns>The result of the operation</returns>
        public static double CalculateCompoundInterest( CompoundInterestModel model )
        {
            // P
            var initialInvestment = model.TimePeriod;

            // 1 + r
            var interestRateCalculation = 1 + GetPercentValue( model.InterestRate );

            // (1 + r) (n)
            var powerResult = Math.Pow( interestRateCalculation, model.TimePeriod );

            // P (1 + r) (n)
            return powerResult * model.Investment;
        }

        /// <summary>
        /// Converts the given percentage in a double number
        /// Result = number / 100
        /// </summary>
        /// <param name="number">Percentage to convert to number</param>
        /// <returns>The number related to the given percentage</returns>
        private static double GetPercentValue( double number )
        {
            return number / 100;
        }
    }
}