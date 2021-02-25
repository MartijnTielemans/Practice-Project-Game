using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetJSONRequest("https://pokeapi.co/api/v2/move/psychic"));
    }

    IEnumerator GetJSONRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            //webRequest.SetRequestHeader("Accept", "application/json");

            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log("Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("HTTP Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.Success:
                    var JsonObject = JSON.Parse(webRequest.downloadHandler.text);

                    Debug.Log("Move name: " + JsonObject["name"].Value);
                    Debug.Log("Type: " + JsonObject["type"]["name"].Value);
                    Debug.Log("Power: " + JsonObject["power"].AsInt);
                    Debug.Log("Pp: " + JsonObject["pp"].AsInt);
                    Debug.Log("Accuracy: " + JsonObject["accuracy"].AsInt);
                    break;

                default:
                    break;
            }
        }
    }
}
