using Newtonsoft.Json;

namespace oop_beta3;

public class Login
{
    public static string FileName = @"D:\oop beta3\Login.json";

    public int PersonId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public Login(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    //validate the login form the user
    public static bool ValidateLogin(Login login)
    {
        var jsonString = File.ReadAllText(Credential.FileName);
        var credentials = JsonConvert.DeserializeObject<List<Credential>>(jsonString);

        var credentialCheck = credentials.FirstOrDefault(c => c.UserName == login.UserName && c.Password == login.Password);

        return credentialCheck != null;
    }

    //check if there is a person already logged in
    public static bool IsLoggedIn()
    {
        var loginString = File.ReadAllText(FileName);
        List<Login> logins = string.IsNullOrEmpty(loginString) ? new List<Login>() : JsonConvert.DeserializeObject<List<Login>>(loginString);
        //var logins = JsonConvert.DeserializeObject<List<Login>>(loginString);

        return logins.Count != 0;
        //return !string.IsNullOrEmpty(loginString);
    }

    //Save the login to the file after validate the userName and password from the method above
    public static void SaveLogin(Login login)
    {
            
        if (IsLoggedIn())
        {
            Console.WriteLine("there is another Login Please log out of that user first");
            return;
        }

        if (!ValidateLogin(login))
        {
            Console.WriteLine("Invalid User name or Password");
            return;
        }

        var loginString = File.ReadAllText(FileName);
        List<Login> logins = string.IsNullOrEmpty(loginString) ? new List<Login>() : JsonConvert.DeserializeObject<List<Login>>(loginString);
        var jsonString = File.ReadAllText(Credential.FileName);
        var credentials = JsonConvert.DeserializeObject<List<Credential>>(jsonString);
        var credentialCheck = credentials.FirstOrDefault(c => c.UserName == login.UserName && c.Password == login.Password);
        login.PersonId = credentialCheck.PersonId;

        logins.Add(login);

        var updatedJsonString = JsonConvert.SerializeObject(logins, Formatting.Indented);

        File.WriteAllText(FileName, updatedJsonString);
    }

    //Check the logged in user is student
    public static bool IsStudent()
    {
        if (IsLoggedIn())
        {
            var loginString = File.ReadAllText(FileName);
            List<Login> logins = string.IsNullOrEmpty(loginString) ? new List<Login>() : JsonConvert.DeserializeObject<List<Login>>(loginString);
            if (logins[0].PersonId >= 100 && logins[0].PersonId < 500)
            {
                return true;
            }
        }
        return false;

    }

    //Check the logged in user is admin
    public static bool IsAdmin()
    {
        if (IsLoggedIn())
        {
            var loginString = File.ReadAllText(FileName);
            List<Login> logins = string.IsNullOrEmpty(loginString) ? new List<Login>() : JsonConvert.DeserializeObject<List<Login>>(loginString);
            if (logins[0].PersonId >= 1 && logins[0].PersonId < 20)
            {
                return true;
            }
        }
        return false;
    }

    //public static bool is instructor
    public static bool IsInstructor()
    {
        if (IsLoggedIn())
        {
            var loginString = File.ReadAllText(FileName);
            List<Login> logins = string.IsNullOrEmpty(loginString) ? new List<Login>() : JsonConvert.DeserializeObject<List<Login>>(loginString);
            if (logins[0].PersonId >= 20 && logins[0].PersonId < 100)
            {
                return true;
            }
        }
        return false;
    }

    //log out the user
    public static void LogOut()
    {
        File.WriteAllText(FileName, "[]");
    }


}