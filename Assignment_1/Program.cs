using Newtonsoft.Json.Linq;
using RestSharp;

string baseUrl = "https://jsonplaceholder.typicode.com/";
RestClient client = new RestClient(baseUrl);

GetAllUsers(client);
CreateUser(client);
UpdateUser(client);
DeleteUser(client);
GetSingleUser(client);

static void GetAllUsers(RestClient client)
{
    var getUserRequest = new RestRequest("todos", Method.Get); 
    var getUserResponse = client.Execute(getUserRequest);

    Console.WriteLine("GET Reponse:\n" + getUserResponse.Content);
}
static void CreateUser(RestClient client)
{
    //create/post
    var createUserRequest = new RestRequest("todos", Method.Post);
    createUserRequest.AddHeader("Content-Type", "application/json");
    createUserRequest.AddJsonBody(new { userId = "2", title = "How are you", completed="true" });

    var createUserResponse = client.Execute(createUserRequest);
    Console.WriteLine("POST Create User Response:");
    Console.WriteLine(createUserResponse.Content);
}
static void UpdateUser(RestClient client)
{

    //PUT /PATCH
    var updateUserRequest = new RestRequest("todos/2", Method.Put);

    updateUserRequest.AddHeader("Content-Type", "application/json");
    updateUserRequest.AddJsonBody(new { userId = 3,title="update a user",completed="true" });
    var updateUserReponse = client.Execute(updateUserRequest);
    Console.WriteLine("PUT Update User Reponse");
    Console.WriteLine(updateUserReponse.Content);
}
static void DeleteUser(RestClient client)
{

    //DELETE
    var deleteUserRequest = new RestRequest("todos/3", Method.Delete);

    var deleteUserReponse = client.Execute(deleteUserRequest);
    Console.WriteLine("Delete User Response:");
    Console.WriteLine(deleteUserReponse.Content);

}
static void GetSingleUser(RestClient client)
{
    //GET
    var getUserRequest = new RestRequest("todos/5", Method.Get);
    var getUserResponse = client.Execute(getUserRequest);

    Console.WriteLine("GET Single Reponse:\n" + getUserResponse.Content);

}