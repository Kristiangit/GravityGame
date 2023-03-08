using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (target != null)
        {
            if (target.transform.position.x > 0)
            {
                transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);
            }
        }

    }
    public void SetNewTarget(GameObject camTarget)
    {
        target = camTarget;
    }
} 
