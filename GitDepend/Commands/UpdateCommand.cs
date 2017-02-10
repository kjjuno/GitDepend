﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitDepend.CommandLine;
using GitDepend.Visitors;

namespace GitDepend.Commands
{
	class UpdateCommand : ICommand
	{
		private readonly UpdateSubOptions _options;
		public const string Name = "update";

		public UpdateCommand(UpdateSubOptions options)
		{
			_options = options;
		}

		#region Implementation of ICommand

		public int Execute()
		{
			var alg = new DependencyVisitorAlgorithm();
			var visitor = new RunBuildScriptVisitor();
			alg.TraverseDependencies(visitor, _options.Directory);

			if (visitor.ReturnCode == ReturnCodes.Success)
			{
				Console.WriteLine("Update complete!");
			}

			return visitor.ReturnCode;
		}

		#endregion
	}
}