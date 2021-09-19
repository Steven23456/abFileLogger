# abFileLogger
Simple extension to .NET logging that adds the ability to output to a file without the overhead of full featured logging extensions. 

Credit:

ge333 on Stackoverflow.com for : https://stackoverflow.com/questions/40073743/how-to-log-to-a-file-without-using-third-party-logger-in-net-core

and IEvangelist fpr the MS example: https://docs.microsoft.com/en-us/dotnet/core/extensions/custom-logging-provider

Usage:

simply add it to your project and in ConfigureLogging section include .AddFile()
by default it will create a file named yyyy-MM-dd_{AppDomain.CurrentDomain.FriendlyName}_log.txt

you can override this in ConfigureLogging by setting values for filePath & filePrefix
