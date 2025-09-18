using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Ammo
{
    private int _maxAmmo;
    private int _currAmmo;
    private int _clipSize;
    private int _ammoInClip;

    private bool _isReloading;

    private float _reloadTime;
    private float _currTime;

    private const char _middleSymbol = '/';

    private TextMeshProUGUI _playerAmmoTMP;
    private PlayerUI _playerUI;
    private CoroutineRunner _coroutineRunner;

    public Ammo(int maxAmmo,
                int cellSize,
                float reloadTime,
                TextMeshProUGUI playerAmmoUI,
                PlayerUI playerUI, 
                CoroutineRunner coroutineRunner)
    {
        _maxAmmo = maxAmmo;
        _clipSize = cellSize;
        _reloadTime = reloadTime;

        _currAmmo = _maxAmmo;
        if (_currAmmo < _clipSize)
        {
            _ammoInClip = _currAmmo;
        }
        _ammoInClip = _clipSize;

        _playerAmmoTMP = playerAmmoUI;
        _playerUI = playerUI;
        _playerUI.ShowPlayerUI(_playerAmmoTMP, _ammoInClip, _middleSymbol, _currAmmo);
        _coroutineRunner = coroutineRunner;
    }

    public bool IsReadyToShoot()
    {
        if (_isReloading
            || _ammoInClip == 0)
        {
            return false;
        }
        else
        {
            _ammoInClip--;
            _currAmmo--;
            if (_ammoInClip == 0)
            {
                Reload();
            }
            
            _playerUI.ShowPlayerUI(_playerAmmoTMP, _ammoInClip, _middleSymbol, _currAmmo);
        }

        return true;
    }

    public void Reload()
    {
        //1) Full Cell
        //2) Not full cell; no bullets outside cell
        //3) Not full cell; not enough bullets for a full cell
        //4) Not full cell; enough bullets for a full cell

        if (_ammoInClip < _clipSize
            && !_isReloading)
            //&& _currAmmo < _clipSize)
        {
            _coroutineRunner.RunCoroutine(Reloading());
            if (_currAmmo <= _clipSize)
            {
                _ammoInClip = _currAmmo;

            }
            if (_currAmmo > _clipSize)
            {   
                _ammoInClip = _clipSize;
            }
        }
    }

    private IEnumerator Reloading()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _isReloading = false;
    }

    public void RestoreBullets(int bulletsAmount)
    {
        if (_currAmmo < _maxAmmo)
        {
            if ((_currAmmo + bulletsAmount) > _maxAmmo)
            {
                bulletsAmount = _maxAmmo - _currAmmo;           
            }
            _currAmmo += bulletsAmount;
            _playerUI.ShowPlayerUI(_playerAmmoTMP, _ammoInClip, _middleSymbol, _currAmmo);
        }
    }
}
