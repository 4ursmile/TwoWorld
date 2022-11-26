using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon: MonoBehaviour
{
    int maxBullet;
    public int currentBullet;
    public int CurrentBulletinRound;
    public WeaponBase weapon;
    public bool ReadyToShoot;
    private void Start()
    {
        maxBullet = weapon.BullperRound * weapon.MaxRound;
        currentBullet = maxBullet - weapon.BullperRound;
        CurrentBulletinRound = weapon.BullperRound;
        ReadyToShoot = true;
    }
    public void ShootBulletCount()
    {
       CurrentBulletinRound -= 1;
        if (CurrentBulletinRound <=0)
        {
            if (currentBullet > 0)
            {
                Invoke(nameof(Reload), weapon.ReloadTime);
                ReadyToShoot = false;
            }
        } else
        {
            ReadyToShoot = true;
        }
    }
    public void GrabBullet(int number)
    {
        currentBullet += number;
        Reload();
    }
    public void Reload()
    {
        CurrentBulletinRound = currentBullet > weapon.BullperRound ? weapon.BullperRound : currentBullet;
        currentBullet -= CurrentBulletinRound;
        ReadyToShoot = true;
    }
    public void OnReload()
    {
        Reload();
    }
}
