using Akka.Actor;
using LoanCalculator.Core;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class MailInActor : ReceiveActor
    {
        private IActorRef _calculatorCommanderActor;

        public MailInActor(IActorRef calculatorCommanderActor)
        {
            _calculatorCommanderActor = calculatorCommanderActor;

            Receive<CheckMail>(m =>
            {
                Console.Write("[MailInActor        ]: Checking e-mail inbox ...");

                var ex = Helpers.GetRandomInt(CalculatorConfig.NetworkExceptionChance);
                if (ex == 2)
                {
                    throw new SocketException();
                }

                ex = Helpers.GetRandomInt(CalculatorConfig.FatalExceptionChance);
                if (ex == 5)
                {
                    throw new ArgumentNullException();
                }

                // emulate receiving n e-mails
                int n = Helpers.GetRandomInt(CalculatorConfig.MaxNumberEmailsReceived);
                Console.WriteLine(" {0} e-mails found.", n);

                for (int i = 0; i < n; i++)
                {
                    var from = Helpers.GetRandomEmail();
                    var loanId = Helpers.GetRandomLoadId();
                    var calculationOrder = new CalculateLoan(from, loanId);
                    _calculatorCommanderActor.Tell(calculationOrder);
                }
            });
        }
    }
}
