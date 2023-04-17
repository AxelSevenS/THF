using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sliceable : MonoBehaviour
{
    
    [SerializeField] private AudioClip sliceSound;
    [SerializeField] private GameObject sliceEffect;

    public void Slice() {
        SliceBehaviour();

        if (sliceSound != null)
            AudioSource.PlayClipAtPoint(sliceSound, transform.position);

        if (sliceEffect != null)
            Instantiate(sliceEffect, transform.position, Quaternion.identity);
    }

    
    public abstract void SliceBehaviour();

}
