using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAirWall : MonoBehaviour
{
    public GameObject airWall;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SavePoint.isSave)
        {
            airWall.SetActive(true);
        }
    }
}
