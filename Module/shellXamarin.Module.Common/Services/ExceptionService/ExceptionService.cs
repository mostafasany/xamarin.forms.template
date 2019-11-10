using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Prism.Logging;
using Prism.Services;
using shellXamarin.Module.Common.Resources;

namespace shellXamarin.Module.Common.Services.ExceptionService
{
    public class ExceptionService : IExceptionService
    {
        private readonly IPageDialogService _dialogService;
        private readonly ILoggerFacade _loggerService;
        public ExceptionService(IPageDialogService dialogService,
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
            System.Diagnostics.Debug.WriteLine(ex.Message);
            _loggerService.Log(ex.Message, Category.Exception, Priority.High);
        }

        public void LogAndShowDialog(Exception ex, string error = "", [CallerMemberName] string method = "",
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string file = "")
        {
            Log(ex, method, line, file);
            _dialogService.DisplayAlertAsync("", string.IsNullOrEmpty(error) ? AppResources.dialog_exception : error, AppResources.dialog_ok);
        }
    }
}
