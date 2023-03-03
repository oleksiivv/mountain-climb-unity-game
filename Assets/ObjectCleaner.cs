using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    void Start(){
        Invoke(nameof(CleanUp), 6f);
    }
    
    void CleanUp(){
        Destroy(gameObject);
    }
}
