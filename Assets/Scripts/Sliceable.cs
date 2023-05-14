using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sliceable : MonoBehaviour
{
    
    [SerializeField] private AudioClip sliceSound;
    [SerializeField] private GameObject sliceEffect;
    [SerializeField] private float sliceEffectDuration = 5f;

    public void Slice() {
        SliceBehaviour();

        if (sliceSound != null)
            AudioSource.PlayClipAtPoint(sliceSound, transform.position);

        if (sliceEffect != null)
        {
            GameObject sliceEffectInstance = Instantiate(sliceEffect, transform.position, Quaternion.identity);
            Destroy(sliceEffectInstance, sliceEffectDuration);
        }

        Destroy(gameObject);
    }

    
    public abstract void SliceBehaviour();

}
