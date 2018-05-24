namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type setType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            object[] args = new object[] { name };

            ISet set = (ISet)Activator.CreateInstance(setType, args);

            return set;
        }
	}

}
