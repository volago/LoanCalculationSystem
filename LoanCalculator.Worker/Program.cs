using Akka.Actor;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("LoanCalculatorWorker"))
            {
                var client = system.ActorOf(Props.Create<CalculatorCoordinatorActor>());
                client.Tell(new JoinToSystem());

                Console.ReadKey();
            };
        }
    }
}
