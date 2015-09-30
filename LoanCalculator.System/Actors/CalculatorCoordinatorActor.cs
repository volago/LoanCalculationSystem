using Akka.Actor;
using Akka.Routing;
using LoanCalculator.Core;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class CalculatorCoordinatorActor : ReceiveActor
    {
        IActorRef _calculator;
        
        public CalculatorCoordinatorActor()
        {
            Receive<CalculateLoan>(msg =>
            {
                _calculator.Tell(msg);
            });
        }

        protected override void PreStart()
        {
            _calculator = Context.ActorOf(Props.Create(() => new CalculatorActor())
                .WithRouter(new RoundRobinPool(CalculatorConfig.NumberOfCalculatorWorkers)));

            base.PreStart();
        }
    }
}
