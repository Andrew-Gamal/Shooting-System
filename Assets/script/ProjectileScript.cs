using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    internal float range;

    Rigidbody rb;

    Vector3 startPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(  Vector3.Distance(transform.position, startPosition) > range)
        {
            Destroy(this.gameObject);
        }

        if (rb = GetComponent<Rigidbody>())
        {

            if (rb.velocity.magnitude < .1)
            {
                Destroy(this.gameObject);
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(this);
            Destroy(collision.gameObject);
            ScoreCounter.Instance.score();
        }

    }
}
