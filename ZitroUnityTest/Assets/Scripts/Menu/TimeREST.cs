using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

[Serializable]
public class TimeInfo
{
    public string abbreviation;
    public string client_ip;
    public string datetime;
    public int day_of_week;
    public int day_of_year;
    public bool dst;
    public string dst_from;
    public int dst_offset;
    public string dst_until;
    public int raw_offset;
    public string timezone;
    public long unixtime;
    public string utc_datetime;
    public string utc_offset;
    public int week_number;
}

public class TimeREST : MonoBehaviour
{
    [Header("REST Parameters")]
    public string uri;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(uri));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format(uri)))
        {
            yield return req.SendWebRequest();
            while (!req.isDone)
                yield return null;
            byte[] result = req.downloadHandler.data;
            string timeJSON = System.Text.Encoding.Default.GetString(result);
            TimeInfo info = JsonUtility.FromJson<TimeInfo>(timeJSON);
            DateTime DateTimeInfo = UnixTimeToDateTime(info.unixtime);
            timeText.text = DateTimeInfo.ToString();
        }
    }

    //Convierte la hora de formato UNIX a DateTime
    private DateTime UnixTimeToDateTime(long unixTimeStamp)
    {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
    }
}
