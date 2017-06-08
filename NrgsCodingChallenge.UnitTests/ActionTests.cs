using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace NrgsCodingChallenge.UnitTests
{
    public class ActionTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEnumerable<string> _controllersToSkip = new[] { "ActionLog", "Account" };

        public ActionTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CheckForCancellationTokens()
        {
            var apiAssembly = typeof(Startup).GetTypeInfo().Assembly;

            var testSucceeded = true;
            foreach (var controller in apiAssembly.GetTypes()
                .Where(type => typeof(Controller)
                                   .IsAssignableFrom(type)
                               && type.Name != "Controller"
                               && type.Name != "ControllerBase"))
            {
                var controllerName = controller.Name.Replace("Controller", "");
                if (_controllersToSkip.Contains(controllerName))
                {
                    continue;
                }


                foreach (var action in controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {

                    if (action.GetParameters().All(p => p.ParameterType != typeof(CancellationToken)))
                    {
                        _output.WriteLine("Cancellation Token missing on {0}.{1}", controller.Name, action.Name);
                        testSucceeded = false;
                    }
                }
            }

            Assert.True(testSucceeded);
        }
    }
}
