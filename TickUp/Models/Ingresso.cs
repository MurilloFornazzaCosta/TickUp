using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TickUp.Models
{

    public class Ingresso
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8bk6pzt4StGLmyg1h2ckiaODULn273DLyUeDeB7I",
            BasePath = "https://tickup-251a6-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Ingresso()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);

            }
            catch (Exception)
            {

            }

        }
        Evento evento = new Evento();

        
       

    }
}
