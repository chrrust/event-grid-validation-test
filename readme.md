## Purpose

The purpose of this project is to provide a quick way to test an Azure Event Grid validation
when using either Cloud Event Schema or Event Grid Schema.

## How to use

You need to have .NET installed to run this project, and ngrok set up to 
forward the requests to your local machine.

1. Clone the repository
2. `cd` into the repository and CloudEventValidator folder
3. Run the project with `dotnet run`
4. Run ngrok with `ngrok http http://localhost:5270`

You should now have a public URL that you can use to test the validation.

## Testing

Create an event subscription in your Event Grid topic, and select either Cloud Event Schema or Event Grid Schema.
Select webhook delivery method, and for the endpoint, use the endpoint shown in the ngrok console.

When you create the subscription, you should see the validation request in the ngrok console.

To see the details of the request and response, visit the ngrok web interface at http://localhost:4040.