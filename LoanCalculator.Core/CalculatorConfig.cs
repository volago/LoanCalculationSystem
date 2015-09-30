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

        public static int NetworkExceptionChance = 10000;
        public static int FatalExceptionChance = 40000;

        // MailOut
        public static int MailOutDelayMs = 500;

        // Calculation
        public static int MaxResult = 400;
        public static int MessageProcessingTimeMinMs = 1000;
        public static int MessageProcessingTimeMaxMs = 10000;

        // Calculation coordinator
        public static int NumberOfCalculatorWorkers = 10;

        // Calculation commander
        public static string CalculatorCommanderActorPath = "akka.tcp://LoanCalculatorSystem@172.18.56.77:8081/user/calculatorCommanderActor";
        public static string MailOutActorPath = "akka.tcp://LoanCalculatorSystem@172.18.56.77:8081/user/mailOutActor";

    }
}



