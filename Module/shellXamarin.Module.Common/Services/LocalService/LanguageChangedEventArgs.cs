using System;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Common.Services
{
    public class LanguageChangedEventArgs : EventArgs
    {
        public Language Langauge { get; set; }
    }
}