using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.Lambda.Serialization.SystemTextJson;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace DynamodbFunction
{

    public class Function
    {

        private static readonly HttpClient client = new HttpClient();

        public async Task FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {
            context.Logger.LogInformation("Received event from dynamodb");
            foreach (var record in dynamoEvent.Records)
            {
                context.Logger.LogInformation(JsonSerializer.Serialize(record.Dynamodb.NewImage));
                context.Logger.LogInformation(JsonSerializer.Serialize(record.Dynamodb.OldImage));
            }
            
        }
    }
}
