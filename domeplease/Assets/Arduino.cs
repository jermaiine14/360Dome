using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Arduino : MonoBehaviour
{

    SerialPort data_stream = new SerialPort("COM3", 9600); 
    public string receivedstring;
    public string sceneName;
    public int stringToInt;
    //public GameObject test_data;
    // Start is called before the first frame update
    void Start()
    {
        data_stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        receivedstring = data_stream.ReadLine();
        int.TryParse(receivedstring, out stringToInt);
         if (stringToInt > 250){
            SceneManager.LoadScene(sceneName);
            receivedstring = null;
        }
    }
}
