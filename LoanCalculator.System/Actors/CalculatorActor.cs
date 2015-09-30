using Akka.Actor;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class CalculatorActor : TypedActor
        , IHandle<CalculateLoan>
    {
        public void Handle(CalculateLoan message)
        {
            Console.WriteLine("[CalculatorActor    ]: Loan to calculate from = {0}, loanId = {1}"
                , message.From, message.LoanId);
        }
    }
}
