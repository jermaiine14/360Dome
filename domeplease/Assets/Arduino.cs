using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort data_stream = new SerialPort("COM3", 9600); 
    public string receivedstring;
    public GameObject Horse;
    public GameObject Bird;
    public int stringToInt;
    private bool onOff;
    //public GameObject test_data;
    // Start is called before the first frame update
    void Start()
    {
        onOff = true;
        data_stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        receivedstring = data_stream.ReadLine();
        int.TryParse(receivedstring, out stringToInt);
         if (stringToInt > 250){
            if (onOff == true){
            onOff = false;
            Vector3 randomSpawnPosition = new Vector3(0.67f, Random.Range(-0.005f,0.1f), Random.Range(-0.78f,0.62f));
            Quaternion randomSpawnRotation = new Quaternion(-3, Random.Range(-30,-130), 8, 90);
            Instantiate(Horse,randomSpawnPosition,randomSpawnRotation);
            //receivedstring = null;
            StartCoroutine(KillMe());
            }
        }
    }

    IEnumerator KillMe()
    {
        yield return new WaitForSeconds(1);
        onOff = true;
        //Destroy(this.gameObject);
    }
}
