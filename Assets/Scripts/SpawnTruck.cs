using System;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{
    public float speed = 5.0f;
    public float angularX = 1.0f;
    public float angularZ = 1.0f;
    public GameObject truck;
    public Transform tr;
    public Transform representationTransform;
    public Transform truckFollow;
    private bool start = false;
    public GameObject truck1;
    public bool ar = true;

    public Transform GetTruck(){
        return truck1.transform;
    }
    public void Spawn(Transform origin)
    {
        if(start) return;
        
        //truck1 = Instantiate(truck,tr.position + new Vector3(0.0f,0.5f,0.0f),truck.transform.rotation);
        truck1.transform.SetParent(tr.transform);
        start = true;
        tr.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!ar){
            Spawn(this.transform);
        }
       
    }


    private void Update()
    {
        if(!start) return;
        truckFollow.position = tr.transform.position + new Vector3(Mathf.Cos(Time.fixedTime*speed) * angularX,0.0f,Mathf.Sin(Time.fixedTime*speed) * angularZ);
     
    }

    public void SetSpeed(float i ){
        speed = i;
    }

    Vector3 oldDir;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!start) return;
        tr.position = representationTransform.position;
        Vector3 dir = Vector3.ProjectOnPlane((truckFollow.position - truck1.transform.position),Vector3.up);
        truck1.transform.position = truckFollow.position;
        if (dir.magnitude < 0.01) dir = truck1.transform.forward;
        Quaternion target =  Quaternion.LookRotation( dir.normalized,truck1.transform.up);
        truck1.transform.rotation = Quaternion.Lerp(target, truck1.transform.rotation, Time.fixedDeltaTime);
        oldDir = dir;
    }
}
