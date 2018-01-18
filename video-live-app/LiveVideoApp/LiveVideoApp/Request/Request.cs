using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace LiveVideoApp
{
	public enum RequestTyp
	{
		Loggin,
		Registrierung,
		SendDemand,
		ConfirmDemand,
		DeniedDemand,
		DeleteFriend,
		ChangeSetting,
        InfoUser,
		Live
	}
	/// <summary>
	/// Create Http Request, using json, and read Http Response.
	/// </summary>
	public class Request
	{
		public String URL { get; set; }

		public String Verb { get; set; }

		public String Content
		{
			get { return "application/json"; }
		}

		public HttpWebRequest HttpRequest { get; internal set; }
		public HttpWebResponse HttpResponse { get; internal set; }
		public Responce Responce { get; internal set; }

		public Request(string url, string verb)
		{
			this.URL = url;
			this.Verb = verb;
		}

		public string CreateJsonObject(RequestTyp typ, object obj1, object obj2 = null)
		{
            string ObjectToSend = "";
			if (typ == RequestTyp.Loggin)
			{
				User user = (User)obj1;
				ObjectToSend = "{" + $"\"Email\":\"{user.Email}\",\"Passwort\" : \"{user.Passwort}\"" + "}";
			}

			else if (typ == RequestTyp.Registrierung)
			{
				User user = (User)obj1;
				ObjectToSend = "{" + $"\"Id\": {user.Id},\"Username\": \"{user.Benutzername}\",\"Email\": \"{user.Email}\",\"Passwort\" : \"{user.Passwort}\", \"Action\" : 5" + "}";
			}

			else if (typ == RequestTyp.SendDemand)
			{
				User user = (User)obj1;
				string To = (string)obj2;
				ObjectToSend = "{" + $"\"Id\": {user.Id},\"Friends\": [ {To}],\"Action\": 1" + "}";
			}
            else if (typ == RequestTyp.InfoUser)
			{
				User user = (User)obj1;
				string To = (string)obj2;
				ObjectToSend = "{" + $"\"Id\": {user.Id},\"Action\": 7" + "}";
			}
			else if (typ == RequestTyp.ConfirmDemand)
			{
				User user1 = (User)obj1;
				string To = (string)obj2;
				ObjectToSend = "{" + $"\"Id\": {user1.Id},\"Friends\": [ {To}],\"Action\": 2" + "}";
			}
			else if (typ == RequestTyp.DeniedDemand)
			{
				User user1 = (User)obj1;
				string To = (string)obj2;
				ObjectToSend = "{" + $"\"Id\": {user1.Id},\"Friends\": [ {To}],\"Action\": 3" + "}";
			}
			else if (typ == RequestTyp.DeleteFriend)
			{
				User user1 = (User)obj1;
				string To = (string)obj2;
				ObjectToSend = "{" + $"\"Id\": {user1.Id},\"Friends\": [ {To}],\"Action\": 4" + "}";
			}
			else if (typ == RequestTyp.ChangeSetting)
			{
				User user = (User)obj1;
				ObjectToSend = "{" + $"\"All\": {user.All.ToString()}" + "}";
			}
			else if (typ == RequestTyp.Live)
			{
				User user = (User)obj1;
				ObjectToSend = "{" + $"\"Id\": {user.Id}" + "}";
			}
			else
			{
				ObjectToSend = "";
			}

			return ObjectToSend;
		}

		public object Execute(string ObjectToSend)
		{
			HttpRequest = CreateRequest();

			WriteStream(ObjectToSend);

			try
			{
				HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
			}
			catch (WebException error)
			{
				HttpResponse = (HttpWebResponse)error.Response;
				return ReadResponseFromError(error);
			}

			return ReadResponse();
		}

		internal HttpWebRequest CreateRequest()
		{
			var basicRequest = (HttpWebRequest)WebRequest.Create(this.URL);
			basicRequest.ContentType = this.Content;
			basicRequest.Method = this.Verb;

			return basicRequest;
		}

		internal void WriteStream(object obj)
		{
			if (obj != null)
			{
				using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
				{
					if (obj is string)
						streamWriter.Write(obj);
					else
						streamWriter.Write(JsonConvert.SerializeObject(obj));
				}
			}
		}

		internal Responce ReadResponse()
		{
			if (HttpResponse != null)
			{
				using (var streamReader = new StreamReader(HttpResponse.GetResponseStream()))
				{
					string json = streamReader.ReadToEnd();
					Console.WriteLine(json);

					Responce deserializedResponce = JsonConvert.DeserializeObject<Responce>(json);

					return deserializedResponce;
				}
			}
			else
			{
				return Responce.ResponeNull();
			}
		}

        internal object GetResponceObject(Responce responce)
        {
            if (responce.Result.ToString().StartsWith("{", StringComparison.Ordinal) & responce.Result.ToString().EndsWith("}", StringComparison.Ordinal))
            {
                Result result = JsonConvert.DeserializeObject<Result>(responce.Result.ToString());
                return result;
            }
            else
            {
                return responce.Result.ToString();
            }
		}
		internal String ReadResponseFromError(WebException error)
		{
			using (var streamReader = new StreamReader(error.Response.GetResponseStream()))
				return streamReader.ReadToEnd();
		}
	}
}
