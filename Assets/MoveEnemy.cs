using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Vector3 m;
    public Animator enemyanime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
              enemyanime.Play("Die");
            Destroy(this.gameObject, 2f);

        }
        if (collision.gameObject.tag == "Can1")
        {
            enemyanime.Play("Die");
            Destroy(this.gameObject, 2f);

        }

    }
}
