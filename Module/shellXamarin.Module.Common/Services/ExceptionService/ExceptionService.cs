using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Prism.Logging;
using Prism.Services.Dialogs;

namespace shellXamarin.Module.Common.Services.ExceptionService
{
    public class ExceptionService : IExceptionService
    {
        private readonly IDialogService _dialogService;
        private readonly ILoggerFacade _loggerService;
        public ExceptionService(IDialogService dialogService,
            ILoggerFacade loggerService)
        {
            _dialogService = dialogService;
            _loggerService = loggerService;
        }

        public void Log(Exception ex, [CallerMemberName] string method = "",
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string file = "")
        {
            var paramDictionary =
                new Dictionary<string, string>
                {
                    {nameof(CallerMemberNameAttribute), method},
                    {nameof(CallerLineNumberAttribute), line.ToString()},
                    {nameof(CallerFilePathAttribute), file}
                };
            Console.WriteLine(ex.Message);
            _loggerService.Log(ex.Message, Category.Exception, Priority.High);
        }

        public void LogAndShowDialog(Exception ex, string error = "", [CallerMemberName] string method = "",
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string file = "")
        {
            var paramDictionary =
                new Dictionary<string, string>
                {
                    {nameof(CallerMemberNameAttribute), method},
                    {nameof(CallerLineNumberAttribute), line.ToString()},
                    {nameof(CallerFilePathAttribute), file}
                };

            Console.WriteLine(ex.Message);
            _loggerService.Log(ex.Message, Category.Exception, Priority.High);

            _dialogService.ShowDialog(string.IsNullOrEmpty(error) ? ex.Message : error);
        }
    }
}
