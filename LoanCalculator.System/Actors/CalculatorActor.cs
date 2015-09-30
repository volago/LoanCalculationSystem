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
    public class CalculatorActor : TypedActor
        , IHandle<CalculateLoan>
    {
        public void Handle(CalculateLoan msg)
        {
            var actorName = Context.Self.Path.Name;
            Console.WriteLine("[CalculatorActor  {2}]: Start processing: from = {0}, loanId = {1}"
                , msg.From, msg.LoanId, actorName);

            var sleep = Helpers.GetRandomInt(CalculatorConfig.MessageProcessingTimeMinMs
                , CalculatorConfig.MessageProcessingTimeMaxMs);
            Thread.Sleep(sleep);

            var result = Helpers.GetRandomInt(CalculatorConfig.MaxResult);

            var mailBoxSize = ((ActorCell)Context).NumberOfMessages;


            Console.WriteLine("[CalculatorActor  {2}]: Stop processing: from = {0}, loanId = {1}, result = {3} "
                , msg.From, msg.LoanId, actorName, result);
            Console.WriteLine("[CalculatorActor  {1}]: Inbox size: {0}", mailBoxSize, actorName);

            var mailOutActor = Context.ActorSelection(CalculatorConfig.MailOutActorPath);
            mailOutActor.Tell(new SendMail(msg.From, result));
        }
    }
}