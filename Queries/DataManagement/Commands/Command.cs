using System;
using Persistance.Consistency;

namespace Persistance.Commands
{
	public class Command<TStorage> : ICommand<TStorage>
		where TStorage : IStorage
	{
		private readonly Action<TStorage> _action;

		private Command(Action<TStorage> action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			_action = action;
		}

		public void Execute(TStorage storage)
		{
			_action(storage);
		}
	}
}
