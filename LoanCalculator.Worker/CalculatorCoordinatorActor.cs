using Akka.Actor;
using Akka.Routing;
using LoanCalculator.Core;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Worker
{
    public class CalculatorCoordinatorActor : ReceiveActor
    {
        IActorRef _calculator;
        private readonly ActorSelection _server = Context.ActorSelection(CalculatorConfig.CalculatorCommanderActorPath);

        public CalculatorCoordinatorActor()
        {
            Receive<CalculateLoan>(msg =>
            {
                _calculator.Tell(msg);
            });

            Receive<JoinToSystem>(msg =>
            {
                _server.Tell(new JoinToSystem());
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
