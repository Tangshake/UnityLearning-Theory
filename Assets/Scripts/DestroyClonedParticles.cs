using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClonedParticles : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("KillMe", 5);
    }

    private void KillMe()
    {
        Destroy(gameObject);
    }
}
