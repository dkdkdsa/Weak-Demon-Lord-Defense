using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;
using System.Linq;
using System.Threading.Tasks;

[System.Serializable]
public struct UserData
{

    public string email;
    public string userName;
    public int time;
    public int maxWave;

}

public class AuthManager
{
    
    public static AuthManager instance;
    public UserData userData;

    private FirebaseAuth auth;
    private DatabaseReference database;

    public AuthManager() 
    {

        auth = FirebaseAuth.DefaultInstance;
        database = FirebaseDatabase.DefaultInstance.RootReference;
        userData = new UserData();
        Login("", "");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {

        instance = new AuthManager();

    }

    public void SingUpComplete(string email, string userName)
    {

        userData = new UserData();
        userData.email = email;
        userData.userName = userName;
        database.Child(userName).SetRawJsonValueAsync(JsonUtility.ToJson(userData));


    }

    public void Setting()
    {

        database.Child(userData.userName).SetRawJsonValueAsync(JsonUtility.ToJson(userData));

    }

    public async void SingUp(string email, string password, string userName)
    {

        if (userData.userName != null) return;

        try
        {

            var res = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            SingUpComplete(email, userName);

        }
        catch(System.Exception e)
        {

            Debug.Log("이미 가입된 email");

        }

    }

    public async void Login(string email, string password)
    {

        if (userData.userName != null) return;

        try
        {

            await auth.SignInWithEmailAndPasswordAsync(email, password);

            var res = await database.GetValueAsync();

            var s = res.Children.ToList().Find((x) =>
            {

                var r = (IDictionary)x.Value;

                if (r["email"].ToString() == email)
                {

                    return true;

                }
                return false;

            });

            var obj = (IDictionary)s.Value;

            userData.userName = obj["userName"].ToString();
            userData.email = obj["email"].ToString();
            userData.time = int.Parse(obj["time"].ToString());
            userData.maxWave = int.Parse(obj["maxWave"].ToString());

        }
        catch(System.Exception e)
        {

            Debug.Log(e.ToString());

        }

        ///

    }

    public async Task<List<IDictionary>> GetAllValue()
    {

        var res = await database.GetValueAsync();

        List<IDictionary> ress = new List<IDictionary>();

        res.Children.ToList().ForEach((x) =>
        {

            var obj = (IDictionary)(x.Value);

            ress.Add(obj);

        });

        return ress;

    }

}
