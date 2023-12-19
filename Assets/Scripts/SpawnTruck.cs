using System;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{
    public float speed = 5.0f;
    public float angularX = 1.0f;
    public float angularZ = 1.0f;
    public GameObject truck;
    public Transform tr;
    public Transform truckFollow;
    private bool start = false;
    private GameObject truck1;

    public Transform GetTruck(){
        return truck1.transform;
    }
    public void Spawn(Transform origin)
    {
        if(start) return;
        tr.position = this.transform.position;
        truck1 = Instantiate(truck,tr.position + new Vector3(0.0f,0.5f,0.0f),truck.transform.rotation);
        start = true;
    }

    // Start is called before the first frame update
    void Start()
    {
       //Spawn(this.transform);
    }


    private void Update()
    {
        truckFollow.position = tr.transform.position + new Vector3(Mathf.Cos(Time.fixedTime*speed) * angularX,tr.transform.position.y,Mathf.Sin(Time.fixedTime*speed) * angularZ);
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = Vector3.ProjectOnPlane((truckFollow.position - truck1.transform.position),Vector3.up);
        truck1.transform.position = truckFollow.position;
        Quaternion target =  Quaternion.LookRotation( dir.normalized,truck1.transform.up);
        if (dir.magnitude < 0.01) return;
        truck1.transform.rotation = Quaternion.Lerp(target, truck1.transform.rotation, Time.fixedDeltaTime);
    }
}
