using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public float carTime;
    public float carSpeed;
    public float spawnTime;

    public GameObject redCar;
    public GameObject greenCar;
    public GameObject blueCar;

    private float time;

    

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            time = 0;
            int randomNum = Mathf.RoundToInt(Random.Range(0, 3));
            GameObject newCar;
            switch (randomNum)
            {
                case 0:
                    newCar = Instantiate(redCar);
                    break;
                case 1:
                    newCar = Instantiate(blueCar);
                    break;
                case 2:
                    newCar = Instantiate(greenCar);
                    break;
                default:
                    newCar = Instantiate(redCar);
                    break;
            }
            Car cs = newCar.GetComponent<Car>();
            cs.time = carTime;
            cs.speed = carSpeed;
            cs.sample = false;
            newCar.transform.position = transform.position;
        }
    }
}
