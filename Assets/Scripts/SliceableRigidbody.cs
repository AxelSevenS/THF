using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliceableRigidbody : Sliceable
{

    [SerializeField] protected new Rigidbody rigidbody;

    protected override void OnEnable() {
        base.OnEnable();
        Vector3 randomForce = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(-1f, 1f));
        rigidbody.AddTorque(randomForce, ForceMode.Impulse);
    }


    protected override void SliceEffectBehaviour(GameObject sliceEffectInstance)
    {
        foreach (Rigidbody rb in sliceEffectInstance.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddForce(rigidbody.velocity, ForceMode.Impulse);
            rb.AddExplosionForce(300f, transform.position, 10f);
        }
    }
    
    
}
