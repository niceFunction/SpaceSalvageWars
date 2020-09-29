﻿using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isHaveBullets = false;
    public int maxAmountOfBullets = 6;
    public int currentAmountOfBullets = 6;

    public bool isWeaponAim = false;
    public float aimRotationSpeed = 5f;
    public float roundsPerMinute = 60f;

    public string weaponSocketName = "WeaponSocket";

    public bool isBulletAimAt = false;
    public bool isBulletEnemyAim = false;
    public GameObject bulletToSpawn;
    public float bulletVelocity;
    public Transform spawnPoint;

    public AudioClip shootSFX;
    public AudioSource weaponAudioSource;

    [System.NonSerialized] public Vector2 aimAtPosition;


    public ParticleSystem weaponParticleSystem;
    public Transform weaponSocket;

    private float _timeBetweenShots;
    private float _timeSinceLastShot;
    private Transform _transform;
    private Coroutine _shootingCoroutine;
    private Camera _Camera;

    public bool IsShooting { get; private set; } = false;

    public bool IsAimable
    {
        get
        {
            return !Mathf.Approximately(aimRotationSpeed, 0f);
        }
    }


    private void Awake()
    {
        _transform = transform;
        weaponSocket = _transform.Find(weaponSocketName);
        weaponParticleSystem = GetComponentInChildren<ParticleSystem>();

        _timeBetweenShots = 60f / roundsPerMinute;
        _Camera = Camera.main;
    }

    private void LateUpdate()
    {
        if (isWeaponAim)
        {
            if (IsAimable)
            {
                AimWeapon();
            }
        }
    }

    public void AimWeapon()
    {
        Vector2 direction = aimAtPosition - (Vector2)weaponSocket.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponSocket.rotation = Quaternion.Slerp(weaponSocket.rotation, rotation, aimRotationSpeed * Time.deltaTime);
    }

    public virtual void AimBullet(GameObject bullet)
    {
        Vector2 direction = aimAtPosition - (Vector2)weaponSocket.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.transform.rotation = Quaternion.Slerp(weaponSocket.rotation, rotation, aimRotationSpeed * Time.deltaTime);
    }

    public void StartShooting()
    {
        //Early return statement
        if (IsShooting)
        {
            return;
        }

        IsShooting = true;
        _shootingCoroutine = StartCoroutine(Shooting(Mathf.Max(0f, _timeSinceLastShot + _timeBetweenShots - Time.time)));
    }
    public void StopShooting()
    {
        if (!IsShooting)
        {
            return;
        }

        IsShooting = false;
        StopCoroutine(_shootingCoroutine);
    }

    private IEnumerator Shooting(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            FireShot();
            _timeSinceLastShot = Time.time;
            yield return new WaitForSeconds(_timeBetweenShots);
        }
    }

    public virtual void FireShot()
    {
        var _bulletSpawned = Instantiate(bulletToSpawn, spawnPoint.position, weaponSocket.rotation);
        var _bulletRB = _bulletSpawned.GetComponent<Rigidbody2D>();
        if (isBulletAimAt)
        {
            AimBullet(_bulletSpawned);
        }
        PlayShootSFX();
        weaponParticleSystem.Play();
        if (isHaveBullets)
        {
            currentAmountOfBullets -= 1;
            if(currentAmountOfBullets < 0)
            {
                currentAmountOfBullets = 0;
            }
        }
    }

    public void PlayShootSFX()
    {
        weaponAudioSource.PlayOneShot(shootSFX);
    }
}

