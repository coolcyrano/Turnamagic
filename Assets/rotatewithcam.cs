using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatewithcam : MonoBehaviour
{public Transform cam;
public Transform placeforweap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        placeforweap.rotation = cam.rotation;
    }
}
