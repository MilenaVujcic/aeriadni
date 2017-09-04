using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class  Common
    {
        public static readonly int sequenceLength = 6;
        public static readonly int upperBound = 49;
    }
    public class Participant
    {
        public int Id { get; set; }
        private static int  generator { get; set; }
        public int[] NumberCombination { get; set; }
        public string FormatedNumberCombination { get; set; }


        public Participant()
        {
            Id = ++generator;
            NumberCombination = GenerateLotteryNumbers();
            FormatedNumberCombination = FormatLotteryNumbers(NumberCombination);
        }
       
        public static int[] GenerateLotteryNumbers()
        {
            Random rnd = new Random();
         
            int[] combination = new int[Common.sequenceLength];
            int i = 0;
          
            while (i < Common.sequenceLength)
            {
                int num = rnd.Next(1, Common.upperBound + 1);
                if (!combination.Contains(num))
                {
                    combination[i] = num;
                    ++i;
                }
            }

          
            return combination.ToArray().OrderBy(e => e).ToArray();
        }

        public string FormatLotteryNumbers(int[] lotteryNumbers)
        {
            string stringCombination = "";
            foreach (var item in lotteryNumbers)
            {
                stringCombination += item.ToString() + " ";
            }
            return stringCombination.Substring(0, stringCombination.Length - 1); ;
        }
    }

    public class ParticipantDBContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
    }
}