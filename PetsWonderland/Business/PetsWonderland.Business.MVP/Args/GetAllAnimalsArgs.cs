﻿using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.MVP.Args
{
	public class GetAllAnimalsArgs : EventArgs
	{
		public GetAllAnimalsArgs()
		{
		}

		public GetAllAnimalsArgs(IList<Animal> allAnimals)
		{
			Guard.WhenArgument(allAnimals, "All animals list is null!").IsNullOrEmpty();

			this.AllAnimals = allAnimals;
		}

		public IList<Animal> AllAnimals { get; set; }
	}
}
