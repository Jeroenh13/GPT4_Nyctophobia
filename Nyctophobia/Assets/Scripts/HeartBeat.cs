using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using System.Threading;

public class HeartBeat : MonoBehaviour {

    SerialPort stream;
    public Text label;
    public string COM;
    private string data;
    private Thread updates;

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
        
        label.text = data;
    }

    private void GetArduino()
    {
        while (updates.IsAlive)
        {
            data = stream.ReadLine();
        }
    }

}