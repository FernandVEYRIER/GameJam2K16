using UnityEngine;
using System.Collections;

public class DetroyObj : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            Destroy(col.gameObject);
        }
    }
}
