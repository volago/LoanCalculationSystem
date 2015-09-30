﻿using Akka.Actor;
using LoanCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.System.Actors
{
    public class MailInCoordinatorActor : TypedActor
        , IHandle<CheckMail>
    {
        private IActorRef _mailInActor;
        private IActorRef _calculatorActor;

        public MailInCoordinatorActor(IActorRef calculator)
        {
            _calculatorActor = calculator;
        }

        protected override void PreStart()
        {
            _mailInActor = Context.ActorOf(Props.Create<MailInActor>(_calculatorActor), "mailInActor");
            base.PreStart();
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                maxNrOfRetries: 10,
                withinTimeRange: TimeSpan.FromSeconds(3),
                localOnlyDecider: x =>
                {
                    if (x is SocketException)
                    {
                        Console.WriteLine("[MailInCoordinator   ]: Network exception - restarting MailInActor ...");
                        return Directive.Restart;
                    }
                    else
                    {
                        Console.WriteLine("[MailInCoordinator   ]: MailInActor crashed - stopping MailInActor ... further messages won't be process.");
                        Environment.Exit(2);
                        return Directive.Stop;
                    }
                });
        }

        public void Handle(CheckMail message)
        {
            _mailInActor.Tell(message);
        }
    }
}