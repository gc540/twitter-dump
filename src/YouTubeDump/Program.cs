﻿using CommandLine;
using Serilog;
using Serilog.Events;

namespace YouTubeDump
{
    partial class Program
    {
        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(standardErrorFromLevel: LogEventLevel.Verbose)
                .CreateLogger();
            
            return Parser.Default.ParseArguments<IndexOptions, AuthOptions, GetCaptionsOptions>(args)
                .MapResult(
                    (IndexOptions opts) => Index(opts).GetAwaiter().GetResult(),
                    (AuthOptions opts) => Auth(opts),
                    (GetCaptionsOptions opts) => GetCaptions(opts).GetAwaiter().GetResult(),
                    errs => 1);
        }
    }
}
