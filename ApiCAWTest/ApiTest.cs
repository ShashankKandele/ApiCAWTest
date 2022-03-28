using ApiCAWTest.DTO;
using ApiCAWTest.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace ApiCAWTest
{
	[TestClass]

	public class ApiTest
	{
		private string authUrl = "https://restful-booker.herokuapp.com/auth";

		ApiHelper helper = new ApiHelper();

		[TestMethod]
		[Ignore]
		public void TestToken()
		{
			string token = helper.AuthToken();
			Assert.IsNotNull(token);
		}

		[TestMethod]
		[Ignore]
		public void CreateBooking()
		{
			var client = helper.setClient();
			var request = helper.CreatePostRequest();
			var response = helper.GetResponse(client, request);
			ListBookingDTO content = helper.GetContentBookingPost<ListBookingDTO>(response);
			Assert.AreEqual((int)response.StatusCode, 200);
			long bookingid = content.Bookingid;
			Assert.IsNotNull(bookingid);

		}

		[TestMethod]
		[Ignore]
		public void GetBooking()
		{
			var client = helper.setClient();
			var request = helper.CreateGetRequest(12);
			var response = helper.GetResponse(client, request);
			BooKingIDDTO content = helper.GetContentBookingId<BooKingIDDTO>(response);
			Assert.AreEqual((int)response.StatusCode, 200);
			Assert.AreEqual("Sally", content.Firstname);
			Assert.AreEqual("Brown", content.Lastname);
			Assert.AreEqual("Breakfast", content.Additionalneeds);

		}

		[TestMethod]

		public void UpdateBooking()
		{
			string token = helper.AuthToken();
			var client = helper.setClient();
			var request = helper.PutRequest(token, 28);
			var response = helper.GetResponse(client, request);
			BooKingIDDTO content = helper.GetContentBookingId<BooKingIDDTO>(response);
			Assert.AreEqual((int)response.StatusCode, 200);
			Assert.AreEqual("555", content.Totalprice);
			Assert.AreEqual("Dinner", content.Additionalneeds);
			Assert.AreEqual("2021-03-05", content.Bookingdates.Checkout);
		}

		[TestMethod]
		public void UpdatewithPatchBooking()
		{
			string token = helper.AuthToken();
			var client = helper.setClient();
			var request = helper.PatchRequest(token, 28);
			var response = helper.GetResponse(client, request);
			BooKingIDDTO content = helper.GetContentBookingId<BooKingIDDTO>(response);
			Assert.AreEqual((int)response.StatusCode, 200);
			Assert.AreEqual("555", content.Totalprice);
			Assert.AreEqual("sha", content.Firstname);
			Assert.AreEqual("kan", content.Lastname);
		}
	}
}