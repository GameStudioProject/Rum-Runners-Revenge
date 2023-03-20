using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartActivation : MonoBehaviour
{

    public DartShoot dartShoot;

    // Start is called before the first frame update
    void Start()
    {
        dartShoot = GameObject.Find("Dart").GetComponent<DartShoot>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dartShoot.isShooting == false)
                    {
                        Debug.Log("Check 1");
                        dartShoot.shootDart();
                    }
        }
        

    }
}
