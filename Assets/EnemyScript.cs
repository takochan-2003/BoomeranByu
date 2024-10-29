using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ////ƒu[ƒƒ‰ƒ“‚É“–‚½‚Á‚½‚çÁ–Å‚³‚¹‚é
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
        }
    }
}
