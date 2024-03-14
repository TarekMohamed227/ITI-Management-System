using Newtonsoft.Json;

namespace oop_beta3;

public class Credential
{
    public static string FileName = @"D:\oop beta3\credentials.json";
    public int PersonId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public Credential(int personId, string userName, string password)
    {
        PersonId = personId;
        UserName = userName;
        Password = password ;

    }

    //Save the credentials to the file
    public static void UpdateCredential(Credential credential)
    {
        var jsonString = File.ReadAllText(FileName);


        List<Credential> credentials = string.IsNullOrEmpty(jsonString) ? new List<Credential>() : JsonConvert.DeserializeObject<List<Credential>>(jsonString);


        credentials.Add(credential);

        var updatedJsonString = JsonConvert.SerializeObject(credentials, Formatting.Indented);

        File.WriteAllText(FileName, updatedJsonString);
    }


    public static void PrintCredentials(Credential credential)
    {
        Console.WriteLine($"PersonId: {credential.PersonId}");
        Console.WriteLine($"UserName: {credential.UserName}");
        Console.WriteLine($"Password: {credential.Password}");
    }
}