using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    //Throwing
    public float throwForce;
    public float throwExtraForce;
    public float rotationForce;

    //weapon col
    public Collider wepCollider;

    //Shooting
    public int maxAmmo;
    public int maxExtraAmmo;
    public int shotsPerSecond;
    public float reloadSpeed;
    public float hitForce;
    public float range;
    public bool tapable;
    public float kickbackForce;
    public float resetSmooth;
    public Vector3 scopePos;

    //Data
    public int weaponGfxLayer; //No wall clipping
    public GameObject[] weaponGfxs;
    public Collider[] gfxColliders;
    public AudioSource shootingSound;
    public AudioSource reloadingSound;
    public AudioSource ammoBoxSound;

    private float _rotationTime;
    private bool _held;
    private bool _scoping;
    private bool _reloading;
    private bool _shooting;
    private int _ammo;
    public int _extraAmmo;
    private Rigidbody _rb;
    private Transform _playerCamera;
    private TMP_Text _ammoText;
    private int numReloads;
    private AudioSource _shootingSound;
    //public SettingsMenu _trucchi = GetComponent<SettingsMenu>();


    private void Start()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.mass = 1.0f;
        _ammo = maxAmmo;
        _extraAmmo = maxExtraAmmo;

        wepCollider = GetComponent<Collider>();
        

        //shootingSound = GetComponent<AudioSource>();
        //reloadingSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if (!_held) return;

        if (SettingsMenu.statoTrucchi)
        {
            _ammoText.text = "MUNIZIONI INFINITE";
        }
        else if(!_reloading)
        {
            _ammoText.text = _ammo + " / " + _extraAmmo;
        }

        _scoping = Input.GetMouseButton(1) && !_reloading;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.Lerp(transform.localPosition, _scoping ? scopePos : Vector3.zero, resetSmooth * Time.deltaTime);

        if (_reloading)
        {
            _rotationTime += Time.deltaTime;
            var spinDelta = -(Mathf.Cos(Mathf.PI * (_rotationTime / reloadSpeed)) - 1f) / 2f;
            transform.localRotation = Quaternion.Euler(new Vector3(spinDelta * 360f, 0, 0));
        }

        if(Input.GetKeyDown(KeyCode.R) && ! _reloading && _ammo < maxAmmo && (SettingsMenu.statoTrucchi == false)) 
        {
            if(_extraAmmo <= 0)
            {
                _ammoText.text = " MUNIZIONI EXTRA ESAURITE, IMPOSSIBILE RICARICARE ";
            }
            else
            {
                StartCoroutine(ReloadCooldown());
            }
            
        }




        if ((tapable ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0)) && ! _shooting && ! _reloading) 
        {
            if (SettingsMenu.statoTrucchi)
            {
                Shoot();
                StartCoroutine(ShootingCooldown());
                _ammoText.text = "MUNIZIONI INFINITE";
            }
            else if(_ammo > 0)
            {    
                _ammo--;
                _ammoText.text = _ammo + " / " + _extraAmmo;
                Shoot();
                StartCoroutine(_ammo <= 0 ? ReloadCooldown() : ShootingCooldown());
            } else if(_ammo <= 0 && _extraAmmo <= 0)
            {
                _ammoText.text = " MUNIZIONI ESAURITE ";
            }
           
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AmmoZone"))
        {
            ammoBoxSound.Play();
            // Incrementa la variabile _extraAmmo
            _extraAmmo = 300; // Puoi cambiare il valore 10 con qualsiasi altro valore desiderato
            // Puoi anche aggiornare il testo per mostrare il nuovo valore dell'extra ammo
            _ammoText.text = _ammo + " / " + _extraAmmo;
            other.gameObject.SetActive(false);

            // Disattiva l'oggetto "AmmoZone" per evitare futuri contatti
      
        }
    }




    private void Shoot()
    {
        shootingSound.Play();
        transform.localPosition -= new Vector3(0, 0, kickbackForce);
        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out var hitInfo, range))
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                EnemyHealt enemy = hitInfo.collider.GetComponent<EnemyHealt>();
                if (enemy != null)
                {
                    enemy.TakeDamage(25);
                }
            }
        }
        else
        {
            return;
        }


    }

    private IEnumerator ShootingCooldown()
    {
        _shooting = true;
        yield return new WaitForSeconds(1f / shotsPerSecond);
        _shooting  = false;
    }

    private IEnumerator ReloadCooldown()
    {
        if(_extraAmmo > 0)
        {
            reloadingSound.Play();
            _reloading = true;
            _ammoText.text = "RICARICANDO";
            _rotationTime = 0f;
            yield return new WaitForSeconds(reloadSpeed);

            int ammoNeeded = maxAmmo - _ammo;
            int ammoToReload = Mathf.Min(ammoNeeded, _extraAmmo);

            _extraAmmo -= ammoToReload;
            _ammo += ammoToReload;

            _ammoText.text = _ammo + " / " + _extraAmmo;
            _reloading = false;
            reloadingSound.Stop();
        }
        else if(_extraAmmo <= 0)
        {
            _ammoText.text = " MUNIZIONI ESAURITE ";
        }
        
    }

    public void Pickup(Transform weaponHolder, Transform playerCamera, TMP_Text ammoText)
    {
        if (_held) return;
        _rb.isKinematic = true; 
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
        _ammoText.text = _ammo + " / " + _extraAmmo;
        _scoping = false;
    }

    public void Drop(Transform playerCamera)
    {
        if (!_held) return;
        _rb.isKinematic = false;
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

    public bool Scoping => _scoping;

}