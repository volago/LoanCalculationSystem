using Akka.Actor;
using LoanCalculator.Core.Messages;
using LoanCalculator.System.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("LoanCalculatorSystem");

            var calculatorActor = system.ActorOf<CalculatorActor>();

            var mailInActor = system.ActorOf(Props.Create<MailInActor>(calculatorActor), "mailInActor");

            var checkMailMsg = new CheckMail();
            mailInActor.Tell(checkMailMsg);           

            Console.ReadKey();
        }
    }
}
