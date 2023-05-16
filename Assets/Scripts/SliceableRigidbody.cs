using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliceableRigidbody : Sliceable
{

    [SerializeField] protected Rigidbody rb;

    protected override void OnEnable() {
        base.OnEnable();
        Vector3 randomForce = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(-1f, 1f));
        rb.AddTorque(randomForce, ForceMode.Impulse);
    }
    
    
}
