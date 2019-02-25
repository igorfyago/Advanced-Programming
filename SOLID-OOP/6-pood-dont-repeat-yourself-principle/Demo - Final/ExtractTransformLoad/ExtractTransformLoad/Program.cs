using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Services;

namespace ExtractTransformLoad
{
    internal class Program
    {
        private static ExtractionResult _extractionResult;
        private static TransformResult _transformResult;

        private static void Main(string[] args)
        {
            foreach (var step in GetSteps())
            {
                ExecuteStep(step);
            }

            Console.ReadLine();
        }

        private static IEnumerable<Action> GetSteps()
        {
            yield return Extract;
            yield return Transform;
            yield return Load;
        }

        private static void ExecuteStep(Action action)
        {
            Console.WriteLine("Beginning {0} at " + DateTime.Now, action.Method.Name);
            action();
            Console.WriteLine("Finished {0} at " + DateTime.Now, action.Method.Name);
        }

        private static void Extract()
        {
            var myService = new ExtractionService();
            _extractionResult = myService.Extract();
        }

        private static void Transform()
        {
            var myService = new TransformService();
            _transformResult = myService.Transform(_extractionResult);
        }

        private static void Load()
        {
            var myService = new LoadService();
            myService.Load(_transformResult);
        }
    }
}