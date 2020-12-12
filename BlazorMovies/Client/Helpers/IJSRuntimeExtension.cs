﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }

        public static async Task ConsoleLog(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("CustomLog", message);
            await js.InvokeVoidAsync("console.log", message);
        }
    }
}
