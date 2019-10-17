﻿using System;
using System.Runtime.CompilerServices;

namespace shellXamarin.Module.Common.Services.ExceptionService
{
    public interface IExceptionService
    {
        void Handle(Exception ex, [CallerMemberName] string method = "",
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string file = "");

        void HandleAndShowDialog(Exception ex, string error = "", [CallerMemberName] string method = "",
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string file = "");
    }
}
