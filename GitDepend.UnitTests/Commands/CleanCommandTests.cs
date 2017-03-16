﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitDepend.Busi;
using GitDepend.CommandLine;
using GitDepend.Commands;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace GitDepend.UnitTests.Commands
{
    [TestFixture]
    public class CleanCommandTests : TestFixtureBase
    {
        [Test]
        public void CleanShouldSucceedWithDefaultOptions()
        {
            var options = new CleanSubOptions();
            var instance = new CleanCommand(options);
            var code = instance.Execute();

            Assert.AreEqual(ReturnCode.Success, code);
        }

        [Test]
        public void CleanCommand()
        {
            //setup IGit
            DependencyInjection.Resolve<IGit>();
            var options = new CleanSubOptions()
            {
                DryRun = false,
                Dependencies = new List<string>()
                {
                    "dep1"
                },
                
            };
            var instance = new CleanCommand(options);

            var code = instance.Execute();
        }

    }
}
