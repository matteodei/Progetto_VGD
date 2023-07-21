using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    //Throwing
    public float throwForce;
    public float throwExtraForce;
    public float rotationForce;

    //Shooting
    public int maxAmmo;
    public int shotsPerSecond;
    public float reloadSpeed;
    public float hitForce;
    public float range;
    public bool tapable;

    //Data
    public int weaponGfxLayer; //No wall clipping
    public GameObject[] weaponGfxs;
    public Collider[] gfxColliders;

    private bool _held;
    private bool _reloading;
    private bool _shooting;
    private int _ammo;
    private Rigidbody _rb;
    private Transform _playerCamera;
    private TMP_Text _ammoText;

    private void Start()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.mass = 1.0f;
        _ammo = maxAmmo;
    }

    private void Update()
    {
        if (!_held) return;

        if(Input.GetKeyDown(KeyCode.R) && ! _reloading && _ammo < maxAmmo) 
        {
            StartCoroutine(ReloadCooldown());
        }

        if ((tapable ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0)) && ! _shooting && ! _reloading) 
        {
            _ammo--;
            _ammoText.text = _ammo + " / " + maxAmmo;
            Shoot();
            StartCoroutine(_ammo <= 0 ? ReloadCooldown() : ShootingCooldown());
        }
    }

    private void Shoot()
    {
        if (!Physics.Raycast(_playerCamera.position, _playerCamera.forward, out var hitInfo, range)) return;
        var rb = hitInfo.transform.GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.velocity += _playerCamera.forward * hitForce;

    }

    private IEnumerator ShootingCooldown()
    {
        _shooting = true;
        yield return new WaitForSeconds(1f / shotsPerSecond);
        _shooting  = false;
    }

    private IEnumerator ReloadCooldown()
    {
        _reloading = true;
        _ammoText.text = "RICARICANDO";
        yield return new WaitForSeconds(reloadSpeed);
        _ammo = maxAmmo;
        _ammoText.text = _ammo + " / " + maxAmmo;
        _reloading = false;
    }

    public void Pickup(Transform weaponHolder, Transform playerCamera, TMP_Text ammoText)
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
        _playerCamera = playerCamera;
        _ammoText = ammoText;
        _ammoText.text = _ammo + " / " + maxAmmo;
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

        _ammoText.text = "";
        transform.parent = null;
        _held = false;

    }

}
