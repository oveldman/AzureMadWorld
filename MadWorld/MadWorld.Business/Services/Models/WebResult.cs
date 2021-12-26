using System;
using System.Net;

namespace MadWorld.Business.Services.Models
{
	public class WebResult<T>
	{
		public T Body { get; set; }
		public HttpStatusCode HttpStatus { get; set; }
	}
}

