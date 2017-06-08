﻿using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder = new Engine(
            new ConsoleReader(),
            new ConsoleWriter(new AuthProvider()),
            new CommandParser(),
            new CommandFactory(Academy.Container.Container.Kernel));

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly ICommandFactory commandFactory;

        private Engine(IReader reader, IWriter writer, IParser parser, ICommandFactory commandFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
            this.commandFactory = commandFactory;
        }

        public static IEngine Instance
        {
            get
            {
                return instanceHolder;
            }
        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.commandFactory.GetCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);
            var executionResult = command.Execute(parameters);

            this.builder.AppendLine(executionResult);
        }
    }
}
