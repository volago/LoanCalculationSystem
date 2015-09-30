using Akka.Actor;
using LoanCalculator.Core;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class MailOutActor : ReceiveActor
    {
        public MailOutActor()
        {
            Receive<SendMail>(msg =>
            {
                Thread.Sleep(CalculatorConfig.MailOutDelayMs);
                Console.WriteLine("[MailOutActor       ]: E-mail to {0} with result {1} was sent.", msg.To, msg.Result);
            });
        }
    }
}
