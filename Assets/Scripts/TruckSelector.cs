using System;
using UnityEngine;

public class TruckSelector : MonoBehaviour
{
    public SpawnTruck spawnTruck;
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
      
        if (tag == "IceCream"  || tag == "Pompier" || tag == "Car" )
        {
            Transform go = spawnTruck.GetTruck();
            
            for (int i = 0; i < go.transform.childCount; i++)
            {
                go.GetChild(i).gameObject.SetActive(false);
                if(go.GetChild(i).name == tag ){
                   go.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
