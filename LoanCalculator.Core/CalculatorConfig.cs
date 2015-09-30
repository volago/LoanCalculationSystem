using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Core
{
    public static class CalculatorConfig
    {
        // MailIn
        public static int MaxNumberEmailsReceived = 10;
        public static TimeSpan CheckMailStartDelay = TimeSpan.FromSeconds(0);
        public static TimeSpan CheckMailInterval = TimeSpan.FromMilliseconds(2000);

        public static int NetworkExceptionChance = 10;
        public static int FatalExceptionChance = 4000;

        // MailOut
        public static int MailOutDelayMs = 500;

        // Calculation
        public static int MaxResult = 400;
        public static int MessageProcessingTimeMinMs = 1000;
        public static int MessageProcessingTimeMaxMs = 10000;
    }
}
