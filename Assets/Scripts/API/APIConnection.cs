using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using System.Text.RegularExpressions;

public class APIConnection : MonoBehaviour
{
    public TextMeshProUGUI idText;
    public TextMeshProUGUI jokeText;

    public List<GameObject> keyCardList = new List<GameObject>();
    GameObject keyCard;
    public GameObject door;
    
    public string jokeID;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetJSONRequest("https://icanhazdadjoke.com/"));
    }

    IEnumerator GetJSONRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            webRequest.SetRequestHeader("Accept", "application/json");

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

                    //Debug.Log("This Dad joke's ID is: " + JsonObject["id"].Value);

                    // Store the id and the actual joke in the text
                    jokeText.text = JsonObject["joke"].Value;

                    jokeID = JsonObject["id"].Value;

                    idText.text = jokeID;

                    // Grab one random keycard from the list and randomize their ids
                    foreach (GameObject i in keyCardList)
                    {
                        string cardName = "";

                        for (int j = 0; j < Random.Range(6, 12); j++)
                        {
                            char k = (char)Random.Range('1', 'z');
                            cardName = cardName + k;
                        }

                        Access a = i.GetComponent<Access>();
                        a.doorID = Random.Range(100, 50000);
                        a.itemName = "Keycard " + cardName;
                    }

                    keyCard = keyCardList[Random.Range(0, keyCardList.Count)];
                    Access key = keyCard.GetComponent<Access>();

                    // Remove all letters from the jokeID
                    int ID = int.Parse (Regex.Replace(jokeID, "[^0-9.]", "") + Random.Range(20, 2000));

                    // Make the doorID the same as the id and change the name
                    key.doorID = ID;
                    key.itemName = "Keycard " + jokeID;
                    door.GetComponent<DoorScript>().doorID = ID;

                    break;

                default:
                    break;
            }
        }
    }
}
