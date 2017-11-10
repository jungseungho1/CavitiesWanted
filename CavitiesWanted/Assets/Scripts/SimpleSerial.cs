using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO.Ports;
using System.Threading;

public class SimpleSerial : MonoBehaviour
{

    private SerialPort serialPort = null;
    private String portName = "COM3";
    private int baudRate = 115200;
    private int readTimeOut = 100;

    private string serialInput;

    bool programActive = true;
    Thread thread;

    public bool chomp = false;

    float readingSmoothed;
    float potA;
    float readings;
    float lockPos = 0f;

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void Start()
    {
        try
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        thread = new Thread(new ThreadStart(ProcessData));
        thread.Start();
    }

    void ProcessData()
    {
        Debug.Log("Thread: Start");
        while (programActive)
        {
            try
            {
                serialInput = serialPort.ReadLine();
            }
            catch (TimeoutException)
            {

            }
        }
        Debug.Log("Thread: Stop");
    }

    void FixedUpdate()
    {
        if (serialInput != null)
        {
            string[] strEul = serialInput.Split(',');
            if (strEul.Length > 0)
            {
                float potA = float.Parse(strEul[0]);
                //readingSmoothed = Mathf.Lerp(readingSmoothed, potA, Time.deltaTime * 0.01F);
                float readings = map(potA, 0, 20, 0, 35);
                //Debug.Log("potA " + potA);
                //Debug.Log("readings " + readings);


                this.transform.localRotation = Quaternion.Euler(new Vector3(readings, 0f, 0f));

                if (readings > 25f)
                {
                    chomp = true;
                    //Debug.Log("chomp is true");
                }
                else
                {
                    chomp = false;
                    //Debug.Log("chomp is false");
                }
            }
        }

        //readingSmoothed = Mathf.Lerp(readingSmoothed, potA, Time.deltaTime * 0.1F);
        

    }

    public void OnDisable()
    {
        programActive = false;
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }


}
