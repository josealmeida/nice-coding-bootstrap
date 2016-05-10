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
        public async static Task<long?> GetPageLength(){

            HttpClient client = new HttpClient();
            var httpMessage = 
                await client.GetAsync(
                    String.Concat(
                        "https://raw.githubusercontent.com",
                        "/josealmeida/diveintohtml5/master/index.html"));
            // we could do other things here while we are waiting
            // for the HTTP request to complete
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}