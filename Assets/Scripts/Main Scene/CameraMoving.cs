using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public GameObject player;
    public int xRange, yRange, zRange;
    // Start is called before the first frame update
    void Start()
    {
        xRange = 0;
        yRange = 0;
        zRange = -30;
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(xRange, yRange, zRange); 
    }
}
