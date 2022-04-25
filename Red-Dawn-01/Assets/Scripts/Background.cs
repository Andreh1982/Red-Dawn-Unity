using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speedMove;

    void Update()
    {
        transform.position -= new Vector3(speedMove * Time.deltaTime, transform.position.y);
        
    }
}
