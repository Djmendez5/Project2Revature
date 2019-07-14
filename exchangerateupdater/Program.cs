using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Xrm.Tooling.Connector;

namespace exchangerateupdater
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {

            using (var httpClient = new HttpClient())
            {
                var apiUrl = "http://apilayer.net/api/live?access_key=9c63c5d26713d53732db01f976b86580&currencies=CAD&source=USD&format=1";

                //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                //var response = httpClient.GetStringAsync(new Uri(url)).Result;
                string CrmConnectionString = "AuthType=Office365;Url=https://dynamictraining.crm.dynamics.com;UserName=EricBooker@dynamictraining.onmicrosoft.com;Password=teddy1500!@#$";

                CrmServiceClient service = new CrmServiceClient(CrmConnectionString);

                //var serializer = new JavaScriptSerializer();
                //dynamic jsonObject = serializer.Deserialize<dynamic>(response);
                //var value = jsonObject["quotes"]["USDCAD"];
                //Console.WriteLine(value);
                //Console.ReadKey();

                //Create the tracing service

                //Create the context

                Entity currency = service.Retrieve("transactioncurrency", new Guid("9e6d3598-5f8f-e911-a9c1-000d3a33afd1"), new ColumnSet(true));

                ExchangeRate exchangeRate = ApiCall.GetExchangeRate(apiUrl);

                currency.Attributes["exchangerate"] = exchangeRate.Value;
                service.Update(currency);
            }
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
