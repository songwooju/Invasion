using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet1 : MonoBehaviour
{
    private void OncollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
