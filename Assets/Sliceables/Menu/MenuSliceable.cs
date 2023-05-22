using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuSliceable : SliceableRigidbody
{
    
    public static List<MenuSliceable> menuItems = new List<MenuSliceable>();

    private bool menuDisabled = false;



    public override void SliceBehaviour()
    {
        if (menuDisabled) return;

        foreach (MenuSliceable menuItem in menuItems)
        {
            menuItem?.Disable();
        }
        
    }

    public void Disable()
    {
        rigidbody.useGravity = true;
        menuDisabled = true;
        Destroy(gameObject, 10f);
        
        rigidbody.AddForceAtPosition(Random.insideUnitSphere * 10f, transform.position, ForceMode.Impulse);
        rigidbody.AddTorque(Random.insideUnitSphere * 10f, ForceMode.Impulse);
    }



    protected override void OnEnable()
    {
        menuItems.Add(this);
    }

    protected override void OnDisable()
    {
        menuItems.Remove(this);
    }

}
