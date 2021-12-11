using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public static Ball instance;
    public Rigidbody _rb;
    public SphereCollider Sc;
    public bool isdestroy = true;
  
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
     
        _rb.isKinematic = true;
        
    }

    public void Push(Vector3 force)
    {
        _rb.isKinematic = false;
        _rb.AddForce(_rb.mass * force, ForceMode.Impulse);
    }


   public  IEnumerator destroyobject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }



   

   

}