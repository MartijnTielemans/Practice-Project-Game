using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reading
{
    public float level;
    public float pressure;
    public float density;

    public Reading (float l, float p, float d)
    {
        level = l;
        pressure = p;
        density = d;
        LineRenderer lr;
    }
}

public class DataExercise : MonoBehaviour
{
    LineRenderer lr;
    List <string> words = new List <string>();
    Dictionary<float, Reading> powerLevels = new Dictionary<float, Reading>();

    public GameObject graphBar;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        StartCoroutine(LevelReading());
    }

    IEnumerator LevelReading()
    {
        while (powerLevels.Count < 20)
        {
            float time = Time.realtimeSinceStartup;
            powerLevels.Add(time, new Reading(Random.value, Random.value, Random.value));

            Reading latest = powerLevels[time];
            //Debug.Log("Reading: " + latest.level + " - " + latest.pressure + " - " + latest.density);

            yield return new WaitForSeconds(.2f);
        }

        GenerateGraph();
    }

    void GenerateGraph()
    {
        int count = 0;
        Vector3[] positions = new Vector3[powerLevels.Count];

        foreach (KeyValuePair<float, Reading> reading in powerLevels)
        {
            float height = reading.Value.level * 5f;
            Vector3 p = new Vector3(reading.Key * 2.8f, height, 0);
            GameObject go = Instantiate(graphBar, p, Quaternion.identity);

            positions[count] = p;

            go.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            //go.transform.localScale = new Vector3(0.8f, height, 1.0f);

            count++;
        }

        lr.positionCount = powerLevels.Count;
        lr.SetPositions(positions);
    }

    void ListExploration()
    {
        words.Add("David");
        words.Add("Bread");
        words.Add("Snorkel");
        words.Add("Broekspijp lmao");
        words.Add("Crab");
        words.Add("Pannenkoek");
        words.Add("Shoelaces");
        words.Add("Scoop");
        words.Add("Stoelpoot");

        Debug.Log("Capacity:" + words.Capacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
