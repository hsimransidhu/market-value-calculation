using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Program
    {
           /// <summary>
        /// Calculate the market value for the investment based on user-input interest rate, 
        /// growth rate, dividend and number of shares. 
        /// </summary>
        static void Main(string[] args)
        {

            Console.Write("Enter interest rate : (high, medium, low): ");
            string interestRate = Console.ReadLine();

            Console.Write("Enter growth rate : (high, medium, low): ");
            string growthRate = Console.ReadLine();

            Console.Write("Enter most recent dividend : (between 1 and 99): ");
            uint recentDividend = uint.Parse(Console.ReadLine());

            // Check whether dividend is between 1 and 99 or not (positive integer greater than 0)
            if (recentDividend < 1 || recentDividend > 99)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.Write("Enter the number of shares: ");
            uint numShares = uint.Parse(Console.ReadLine());

            // Calculate the market value
            CalculateMarketValue(interestRate, growthRate, recentDividend, numShares);

            Console.ReadLine();
        }

        static  void CalculateMarketValue(string interestRate, string growthRate, uint recentDividend, uint numShares)
            {
            // Get interest and growth levels
            double interestLevel = GetInterestRate(interestRate);
            double growthLevel = GetGrowthRate(growthRate);


            // Check for division by zero
            if (interestLevel - growthLevel == 0)
            {
                Console.WriteLine("Invalid Input.");
                return;
            }

            // Calculate the price  
            double price = recentDividend / (interestLevel - growthLevel);

            // Calculate the market value  
            double marketValue = price * numShares;

            // Display the market value  
            Console.WriteLine("The  market value for the investment is: ${0}", Math.Round(marketValue, 2));

        }

        // Get the interest rate based on the input level
        static double GetInterestRate(string level)
            {
                switch (level.ToLower())
                {
                    case "high": return 0.20;
                    case "medium": return 0.10;
                    case "low": return 0.08;
                    default: return 0;
                }
            }

        // Get the growth rate based on the input level
        static double GetGrowthRate(string level)
            {
                switch (level.ToLower())
                {
                    case "high": return 0.075;
                    case "medium": return 0.05;
                    case "low": return 0.025;
                    default: return 0;
                }
            }
        }

    }
 
