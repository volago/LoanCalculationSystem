using Akka.Actor;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class CalculatorCommanderActor : TypedActor
        , IHandle<JoinToSystem>
        , IHandle<CalculateLoan>
    {
        private List<IActorRef> _coordinators = new List<IActorRef>();
        private int _button = 0;

        public void Handle(CalculateLoan message)
        {
            if (_coordinators.Any())
            {
                _coordinators[_button].Tell(message);
                _button = _button + 1;
                _button = _button % _coordinators.Count;
            }

        }

        public void Handle(JoinToSystem message)
        {
            _coordinators.Add(Sender);
        }
    }
}
