using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;
using System.Linq;
using System.Threading.Tasks;
using System;

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

    public async void SingUp(string email, string password, string userName, Action<bool> comp)
    {

        if (userData.userName != null) return;

        try
        {

            var res = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            SingUpComplete(email, userName);
            comp?.Invoke(true);

        }
        catch(System.Exception e)
        {

            Debug.Log("이미 가입된 email");
            Debug.Log(e);
            comp?.Invoke(false);

        }

    }

    public async void Login(string email, string password, Action<bool> comp)
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

            comp?.Invoke(true);

        }
        catch(System.Exception e)
        {

            Debug.Log(e.ToString());
            comp?.Invoke(false);

        }

    }

    public async Task<List<IDictionary>> GetAllValue()
    {

        var res = await database.GetValueAsync();

        List<IDictionary> ress = new List<IDictionary>();

        Debug.Log(res.ChildrenCount);

        res.Children.ToList().ForEach((x) =>
        {

            var obj = (IDictionary)(x.Value);

            if(obj != null)
            {

                ress.Add(obj);

            }


        });

        return ress;

    }

}
