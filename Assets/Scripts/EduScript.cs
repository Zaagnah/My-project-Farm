using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem graveParticle;
    

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            if (collision.CompareTag("Grave"))
            {
                
                graveParticle.Stop();
                
            }
            
            
    }
    
}
