using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;

namespace ExchangeRateWorkFlow
{
    public class UpdateCurrency : CodeActivity
    {
        protected override void Execute(CodeActivityContext executionContext)
        {
            var apiUrl = "http://apilayer.net/api/live?access_key=9c63c5d26713d53732db01f976b86580&currencies=CAD&source=USD&format=1";

            //Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();
            tracingService.Trace("trace", executionContext);
            //Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            Entity currency = service.Retrieve("transactioncurrency", new Guid("9e6d3598-5f8f-e911-a9c1-000d3a33afd1"), new ColumnSet(true));
            
            ExchangeRate exchangeRate = ApiCall.GetExchangeRate(apiUrl);

            
            currency.Attributes["exchangerate"] = exchangeRate.Value;
            service.Update(currency);
        }
    }
}
