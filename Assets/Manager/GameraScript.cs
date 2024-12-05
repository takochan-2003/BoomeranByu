using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameraScript : MonoBehaviour
{

    public Transform target; // í«îˆëŒè€

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = target.transform.position;
        var position = transform.position;

        position.x = targetPosition.x;
        position.y = targetPosition.y + 18.0f;
        position.z = targetPosition.z;

        transform.position = position;
    }
}
