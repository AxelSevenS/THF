using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuSliceable : Sliceable
{
    
    public static List<MenuSliceable> menuItems = new List<MenuSliceable>();



    [SerializeField] private Rigidbody rigidbody;

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

        rigidbody.AddExplosionForce(5f, transform.position, 10f);
    }



    protected override void OnEnable()
    {
        base.OnEnable();
        menuItems.Add(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        menuItems.Remove(this);
    }

}
