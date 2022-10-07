using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;

namespace Utility
{
    public  class SendToFireBase: MonoBehaviour
    {
        private static readonly String URL = "https://dsci551-b6052-default-rtdb.firebaseio.com/.json";
        public static void Send(String jsonString)
        {
            RestClient.Patch(URL,  jsonString).Then(res => {
                Debug.Log(res.StatusCode);
            }).Catch(err =>
            {
                Debug.Log(err.StackTrace);
            });
        }
    }
}