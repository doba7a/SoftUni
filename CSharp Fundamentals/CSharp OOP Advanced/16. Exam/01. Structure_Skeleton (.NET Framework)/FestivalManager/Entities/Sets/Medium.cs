namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int maxDuration = 40;

        public Medium(string name)
            : base(name, TimeSpan.FromMinutes(maxDuration))
        {
        }
    }
}