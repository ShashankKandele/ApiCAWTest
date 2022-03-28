using ApiCAWTest.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCAWTest.Helper
{
	public class ApiHelper
	{
		public RestClient client;
		public RestRequest request;
		public string baseurl = "https://restful-booker.herokuapp.com";


		public RestClient setClient()
		{
			var client = new RestClient(baseurl);
			return client;
		}


		public RestRequest CreatePostRequest()
		{
			var payload = new
			{
				firstname = "shashank",
				lastname = "kandele",
				totalprice = 444,
				depositpaid = false,
				bookingdates = new
				{
					checkin = @"2020-03-04",
					checkout = @"2021-03-04"
				},
				additionalneeds = "Breakfast"
			};
			var request = new RestRequest("/booking")
			{
				Method = Method.Post
			};
			request.AddHeader("Accept", "application/json");
			request.AddHeader("Content-Type", "application/json");
			request.RequestFormat = DataFormat.Json;
			request.AddBody(payload);
			//request.AddHeader("Accept", "application/json");
			//request.AddHeader("Content-Type", "application/json");
			//request.RequestFormat = DataFormat.Json;
			//request.AddParameter("application/json", payload, ParameterType.RequestBody);
			return request;
		}

		public RestRequest CreateGetRequest(int id)
		{
			var request = new RestRequest("/booking/" + id)
			{
				Method = Method.Get
			};
			request.AddHeader("Accept", "application/json");
			return request;
		}

		public RestResponse GetResponse(RestClient client, RestRequest request)
		{
			return client.ExecuteAsync(request).Result;
		}

		public string AuthToken()
		{
			var payload = new
			{
				username = "admin",
				password = "password123"
			};

			var restClient = new RestClient(baseurl);
			RestRequest restRequest = new RestRequest("/auth")
			{
				Method = Method.Post
			};

			restRequest.AddHeader("Content-Type", "application/json");
			restRequest.RequestFormat = DataFormat.Json;
			restRequest.AddBody(payload);
			RestResponse response = restClient.ExecuteAsync(restRequest).Result;
			var content = response.Content;
			ListAuthDTO dtoObject = JsonConvert.DeserializeObject<ListAuthDTO>(content);
			string token = dtoObject.Token;
			return token;

		}

		public RestRequest PutRequest(string token, int id)
		{
			var payload = new
			{
				firstname = "shashank",
				lastname = "kandele",
				totalprice = 555,
				depositpaid = false,
				bookingdates = new
				{
					checkin = @"2020-03-04",
					checkout = @"2021-03-05"
				},
				additionalneeds = "Dinner"
			};
			var request = new RestRequest("/booking/" + id)
			{
				Method = Method.Put
			};
			request.AddHeader("Accept", "application/json");
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Cookie", "token="+token);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(payload);
			return request;

		}
		public RestRequest PatchRequest(string token, int id)
		{
			var payload = new
			{
				firstname = "sha",
				lastname = "kan",
				totalprice = 555	
			};
			var request = new RestRequest("/booking/" + id)
			{
				Method = Method.Patch
			};
			request.AddHeader("Accept", "application/json");
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Cookie", "token=" + token);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(payload);
			return request;

		}
		public ListBookingDTO GetContentBookingPost<ListBookingDTO>(RestResponse restResponse)
		{
			var content = restResponse.Content;
			ListBookingDTO response = JsonConvert.DeserializeObject<ListBookingDTO>(content);
			return response;
		}
		public BooKingIDDTO GetContentBookingId<BooKingIDDTO>(RestResponse restResponse)
		{
			var content = restResponse.Content;
			BooKingIDDTO response = JsonConvert.DeserializeObject<BooKingIDDTO>(content);
			return response;
		}
	}
}
