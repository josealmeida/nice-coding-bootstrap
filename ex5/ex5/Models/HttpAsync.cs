using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace ex5.Models
{
    public class HttpAsync
    {
        public static Task<long?> GetPageLength(){

            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://google.com");

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }
    }
}