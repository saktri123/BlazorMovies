using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static BlazorMovies.Client.Shared.MainLayout;
using MathNet.Numerics.Statistics;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {

        private int currentCount = 0;
        public void IncrementCount()
        {
            var arry = new double[] { 1, 2, 3, 4, 6 };
            var max = arry.Maximum();
            var min = arry.Minimum();
            Console.WriteLine($"Maximum: {max}, Minimum: {min}");
            currentCount++;
        }

      
    }
}
