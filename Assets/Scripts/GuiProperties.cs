using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiProperties : MonoBehaviour
{
    public Slider speed;
    public Slider pitch;
    public SpawnTruck spawn;
    public Toggle tooggle;
    public Toggle tunnel;
    public GameObject tunnelObject;
    public AudioSource[] audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawn.SetSpeed(speed.value);
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].pitch = pitch.value;
            audioSource[i].mute = tooggle.isOn;
        }


        tunnelObject.SetActive(tunnel.isOn);

    }
}
