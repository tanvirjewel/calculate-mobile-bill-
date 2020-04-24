using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMobileBill
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDateTime;
            DateTime endDateTime;
            double totalCost = 0;
          
            TimeSpan peakstartTime = new TimeSpan(9, 0, 0);
            TimeSpan peakendTime = new TimeSpan(22, 59, 59);

            Console.WriteLine("Start time: ");
            if (DateTime.TryParse(Console.ReadLine(), out startDateTime))
            {
               
            }
            else
            {
                Console.WriteLine("You have entered an incorrect Time value.");
              
            }
            Console.WriteLine("End time: ");
            if (DateTime.TryParse(Console.ReadLine(), out endDateTime))
            {
               //  Console.WriteLine("The day of the week is: " + endDateTime.DayOfWeek);
            }
            else
            {
                Console.WriteLine("You have entered an incorrect Time value.");

            }
            DateTime currentDateTime = startDateTime; ;

            while (currentDateTime < endDateTime)
            {
                double cost = 0;
                TimeSpan now = currentDateTime.TimeOfDay;

                double secDiff = (endDateTime - currentDateTime).TotalSeconds;
                if (secDiff > 20)
                {
                    currentDateTime = currentDateTime.AddSeconds(21);
                    cost = getCost(currentDateTime.TimeOfDay, peakstartTime, peakendTime);
                    Console.WriteLine("{0} + 20 second ( {1} ) = {2} paisa", currentDateTime.AddSeconds(-21), currentDateTime.AddSeconds(-1), cost);

                } else
                {
                    currentDateTime = currentDateTime.AddSeconds(secDiff);
                    cost = getCost(currentDateTime.TimeOfDay, peakstartTime, peakendTime);
                    Console.WriteLine("{0} + 20 second ( {1} ) = {2} paisa", currentDateTime.AddSeconds(secDiff * -1), currentDateTime, cost);
                   
                }

                //TimeSpan now = currentDateTime.TimeOfDay;

                //if (now >= peakstartTime || now <= peakendTime)
                //{
                //    totalCost += 30;
                //} else
                //{
                //    totalCost += 20;
                //}
                totalCost += cost;
            }

        
            Console.WriteLine("Total Cost : {0}", totalCost/100);

           Console.ReadKey();
        }


        static double getCost(TimeSpan now, TimeSpan start, TimeSpan end)
        {
            double cost = 0;
          
            if (now >= start && now <= end)
            {
                cost = 30;
            }
            else
            {
                cost = 20;
            }

            return cost;
        }

    }
}
