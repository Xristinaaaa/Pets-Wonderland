﻿using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class DeleteHotelRequest_Should
	{
		[Test]
		public void BeInvoked_WhenHotelRegistrationRequestToDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(hotelRegistrationRequest.Object);
			hotelRegistrationRequestService.DeleteHotelRequest(hotelRegistrationRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(hotelRegistrationRequest.Object));
		}

		[Test]
		public void BeInvokedOnceForHotelRegistrationRequest_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(hotelRegistrationRequest.Object);
			hotelRegistrationRequestService.DeleteHotelRequest(hotelRegistrationRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(It.IsAny<UserHotelRegistrationRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenHotelRegistrationRequestIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(hotelRegistrationRequest.Object);
			hotelRegistrationRequestService.DeleteHotelRequest(hotelRegistrationRequest.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotCallSaveChanges_WhenHotelRegistrationRequestIsNotDeleted()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Never);
		}

		[Test]
		public void NotDeleteHotelRegistrationRequest_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(hotelRegistrationRequest.Object), Times.Never);
		}

		[Test]
		public void ThrowException_WhenHotelRegistrationRequestIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotelRegistrationRequest> hotelRegistrationRequest = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.DeleteHotelRequest(hotelRegistrationRequest.Object));
		}
	}
}