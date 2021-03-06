﻿namespace FestivalManager.Entities.Sets
{
	using System;

    public class Long : Set
    {
        private const int maxDuration = 60;

        public Long(string name)
            : base(name, TimeSpan.FromMinutes(maxDuration))
        {
        }
    }
}
