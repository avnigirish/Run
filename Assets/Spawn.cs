using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    float pos;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject plane4;
    public GameObject plane5;

    public GameObject iplane1;
    public GameObject iplane2;
    public GameObject iplane3;
    public GameObject iplane4;
    public GameObject iplane5;

    public GameObject wall;
    List<GameObject> normList = new List<GameObject>();
    List<GameObject> invList = new List<GameObject>();
    float timer, timer2;
    void Start()
    {
        pos = plane1.transform.position.z+45;
        normList.Add(Instantiate(plane1, plane1.transform.position, Quaternion.identity) as GameObject);
        normList.Add(Instantiate(plane2, plane2.transform.position, Quaternion.identity) as GameObject);
        normList.Add(Instantiate(plane3, plane3.transform.position, Quaternion.identity) as GameObject);
        normList.Add(Instantiate(plane4, plane4.transform.position, Quaternion.identity) as GameObject);
        normList.Add(Instantiate(plane5, plane5.transform.position, Quaternion.identity) as GameObject);

        invList.Add(Instantiate(iplane1, iplane1.transform.position, Quaternion.identity) as GameObject);
        invList.Add(Instantiate(iplane2, iplane2.transform.position, Quaternion.identity) as GameObject);
        invList.Add(Instantiate(iplane3, iplane3.transform.position, Quaternion.identity) as GameObject);
        invList.Add(Instantiate(iplane4, iplane4.transform.position, Quaternion.identity) as GameObject);
        invList.Add(Instantiate(iplane5, iplane5.transform.position, Quaternion.identity) as GameObject);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer >= 0.8f)
        {
            //Debug.Log("Plane pos: " + pos);
            //Debug.Log("timer: " + timer);
            pos+=5;
            int num1 = Random.Range(0, 5);
            int num2 = Random.Range(0, 5);
            
            for (int x=0; x<5; x++)
            {
                if (num1 != x)
                {
                    normList[x].transform.position = new Vector3(normList[x].transform.position.x, normList[x].transform.position.y, pos);
                    Instantiate(normList[x], normList[x].transform.position, Quaternion.identity);
                }
                else
                    normList[x].transform.position = new Vector3(normList[x].transform.position.x, normList[x].transform.position.y, pos);
            }

            for(int x=0; x<5; x++)
            {
                if (num2 != x)
                {
                    invList[x].transform.position = new Vector3(invList[x].transform.position.x, invList[x].transform.position.y, pos);
                    Instantiate(invList[x], invList[x].transform.position, new Quaternion(180,0,0,0));
                }
                else
                    invList[x].transform.position = new Vector3(invList[x].transform.position.x, invList[x].transform.position.y, pos);   
            }
            
            timer = 0;
        }
        if(timer2 >= 3f)
        {
            int wallNum1 = Random.Range(-9,10);
            int wallNum2 = Random.Range(-9, 10);
            Instantiate(wall, new Vector3(wallNum1, wall.transform.position.y, pos), Quaternion.identity);
            Instantiate(wall, new Vector3(wallNum2, 9, pos), Quaternion.identity);
            timer2 = 0;
        }
    }


}
