﻿using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateHotelService_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			Assert.That(hotelService, Is.InstanceOf<HotelService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arrange
			Mock<IRepository<Hotel>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new HotelService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new HotelService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
