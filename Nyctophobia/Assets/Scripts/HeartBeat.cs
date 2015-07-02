using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using System.Threading;
using System.Globalization;

public class HeartBeat : MonoBehaviour {

    SerialPort stream;
    public Text label;
    public string COM;
    private string inputData;
    private Thread updates;
    public Light spot;
    public float intensity;
    public int calibrate;
    public int cnt = 0;

    // Use this for initialization
    void Start()
    {
        try
        {
            stream = new SerialPort(COM, 115200);
            updates = new Thread(new ThreadStart(GetArduino));

        }
        catch
        {
            label.text = "ERROR";
        }
        if (stream != null)
        {
            stream.Open();
            updates.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float data = spot.intensity;
        float output = 0;
        if (cnt == 80)
        {
            if (float.TryParse(inputData, out output))
            {
                //if (data > 1 && data < 5)
                //{
                    if (output > calibrate)
                    {
                        data -= 0.18f;
                    }
                    else if (output < calibrate)
                    {
                        data += 0.18f;
                    }
                    spot.intensity = data;
                    label.text = data.ToString();
                //}
            }
            cnt = 0;
        }
        label.text = inputData;
        cnt++;
    }

    private void GetArduino()
    {
        while (updates.IsAlive)
        {
            inputData = stream.ReadLine();
            inputData = inputData.Substring(1);
        }
    }

    void OnApplicationQuit()
    {
        stream.Close();
    }
}