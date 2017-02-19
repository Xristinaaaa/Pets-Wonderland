﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin
{
	[PresenterBinding(typeof(AddHotelPresenter))]
	public partial class ApproveHotelRequest : MvpPage<AddHotelModel>, IAddHotelView
	{
		public event EventHandler<AddHotelArgs> AddHotel;

		protected void Page_Load(object sender, EventArgs e)
		{
			Approve();
		}

		protected void Approve()
		{
			var requestId = int.Parse(Request.QueryString["id"]);
			var hotelName = Request.QueryString["name"];
			var hotelDescription = Request.QueryString["description"];
			var hotelImage = Request.QueryString["image"];
			var hotelLocation = Request.QueryString["location"];

			var hotelArgs = new AddHotelArgs
			{
				HotelName = hotelName,
				HotelDescription = hotelDescription,
				ImageUrl = hotelImage,
				Location = hotelLocation,
				RequestId = requestId
			};

			this.AddHotel?.Invoke(this, hotelArgs);
		}
	}
}