using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform playerTransform;
    
    public Transform backgound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = playerTransform.position.x;
        var y = playerTransform.position.y+15;
        transform.position = new Vector3(x, y, transform.position.z);
        backgound.position = new Vector3(transform.position.x, transform.position.y);
    }
}
