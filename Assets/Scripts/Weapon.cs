using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public float throwForce;
    public float throwExtraForce;
    public float rotationForce;

    public int weaponGfxLayer; //No wall clipping
    public GameObject[] weaponGfxs;
    public Collider[] gfxColliders;

    private bool _held;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.mass = 1.0f;
    }

    public void Pickup(Transform weaponHolder)
    {
        if (_held) return;
        Destroy(_rb); //Non interagisce più col mondo una volta raccolta
        transform.parent = weaponHolder;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        foreach(var col in gfxColliders) { 
            col.enabled = false;
        }
        foreach (var gfx in weaponGfxs)
        {
            gfx.layer = weaponGfxLayer;
        }
        _held = true;
    }

    public void Drop(Transform playerCamera)
    {
        if (!_held) return;
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.mass = 1.0f;
        var forward = playerCamera.forward;
        forward.y = 0f;
        _rb.velocity = forward * throwForce;
        _rb.velocity += Vector3.up * throwExtraForce;
        _rb.angularVelocity = Random.onUnitSphere * rotationForce;
        foreach (var col in gfxColliders)
        {
            col.enabled = true;
        }
        foreach (var gfx in weaponGfxs)
        {
            gfx.layer = 0;
        }
        transform.parent = null;
        _held = false;

    }

}
