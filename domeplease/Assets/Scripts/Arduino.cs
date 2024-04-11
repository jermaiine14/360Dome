using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{

    SerialPort data_stream = new SerialPort("COM4", 9600); 
    public string receivedstring;
    public GameObject Horse;
    public GameObject Panda;
    public GameObject Bird;
    public int stringToInt1;
    public int stringToInt2;
    public int stringToInt3;
    private bool onOff;
    private bool onOff1;
    private bool onOff2;
    //public GameObject test_data;
    // Start is called before the first frame update
    void Start()
    {
        onOff = true;
        onOff1 = true;
        onOff2 = true;
        data_stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        receivedstring = data_stream.ReadLine();
        //data_stream.BaseStream.Flush();
        string[] datas = receivedstring.Split(",");
        int.TryParse(datas[0], out stringToInt1);
        int.TryParse(datas[1], out stringToInt2);
        int.TryParse(datas[2], out stringToInt3);
         if (stringToInt1 > 50){
            if (onOff == true){
            //Bird.SetActive
            onOff = false;
            Vector3 randomSpawnPosition = new Vector3(0.67f, Random.Range(-0.005f,0.1f), Random.Range(-0.78f,0.62f));
            Quaternion randomSpawnRotation = new Quaternion(-3, Random.Range(-30,-130), 8, 90);
            Instantiate(Horse,randomSpawnPosition,randomSpawnRotation);
            //receivedstring = null;
            StartCoroutine(KillHorse());
            }
        }
        if (stringToInt2 > 50){
            if (onOff1 == true){
            //Bird.SetActive
            onOff1 = false;
            Vector3 SpawnPanda = new Vector3(-0.028f, 0.19685f, 0.511f);
            Instantiate(Panda,SpawnPanda,Quaternion.identity);
            //receivedstring = null;
            StartCoroutine(KillPanda());
            }
        }
        if (stringToInt3 > 20){
            if (onOff2 == true){
            //Bird.SetActive
            onOff2 = false;
             //Quaternion BirdSpawn = new Quaternion(0,0,0, 0);
            Vector3 SpawnBird = new Vector3(-0.0198f, 1.16659f, 1.07854f);
            Instantiate(Bird,SpawnBird,Quaternion.identity);
            //receivedstring = null;
            StartCoroutine(KillBird());
            }
        }
    }

    IEnumerator KillHorse()
    {
        yield return new WaitForSeconds(1);
        onOff = true;
        //Destroy(this.gameObject);
    }

    IEnumerator KillPanda()
    {
        yield return new WaitForSeconds(10);
        onOff1 = true;
    }
     IEnumerator KillBird()
    {
        yield return new WaitForSeconds(4);
        onOff2 = true;
    }

    
}
