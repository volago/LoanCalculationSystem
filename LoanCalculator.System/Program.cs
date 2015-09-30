using Akka.Actor;
using LoanCalculator.Core;
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
            var mailOutActor = system.ActorOf<MailOutActor>("mailOutActor");

            var mailInActor = system.ActorOf(Props.Create<MailInActor>(calculatorActor), "mailInActor");

            var checkMailMsg = new CheckMail();
            system.Scheduler.ScheduleTellRepeatedly(CalculatorConfig.CheckMailStartDelay, CalculatorConfig.CheckMailInterval,
                mailInActor, checkMailMsg, ActorRefs.Nobody);

            Console.ReadKey();
        }
    }
}