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

    public Ammo(int maxAmmo,
                int cellSize,
                float reloadTime,
                TextMeshProUGUI playerAmmoUI,
                PlayerUI playerUI)
    {
        _maxAmmo = maxAmmo;
        _clipSize = cellSize;
        _reloadTime = reloadTime;
        Debug.Log(_reloadTime);

        _currAmmo = _maxAmmo;
        if (_currAmmo < _clipSize)
        {
            _ammoInClip = _currAmmo;
        }
        _ammoInClip = _clipSize;

        _playerAmmoTMP = playerAmmoUI;
        _playerUI = playerUI;
        long time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        _playerUI.ShowPlayerUI(_playerAmmoTMP, _ammoInClip, _middleSymbol, _currAmmo);
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
            long time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            
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
            if (_currAmmo <= _clipSize)
            {
                Debug.Log($"_currAmmo < _clipSize; doesn't wait {_reloadTime}" + _currAmmo);
                _ammoInClip = _currAmmo;

            }
            if (_currAmmo > _clipSize)
            {
                Debug.Log($"_currAmmo > _clipSize; doesn't wait {_reloadTime}" + _currAmmo);
                _ammoInClip = _clipSize;
            }
        }

        //if (_ammoInClip < _clipSize
        //    && _currAmmo < _clipSize)
        //{
        //    Reloading();
        //    Debug.Log($"_currAmmo < _clipSize; doesn't wait {_reloadTime}" + _currAmmo);
        //    _ammoInClip = _currAmmo;
        //}
        //else if (_ammoInClip < _clipSize
        //        && _currAmmo > _clipSize)
        //{
        //    Reloading();
        //    Debug.Log($"_currAmmo > _clipSize; doesn't wait {_reloadTime}" + _currAmmo);
        //    _ammoInClip = _clipSize;
        //}

        
    }

    //private void Reloading()
    //{
    //    //while (_currTime < _reloadTime)
    //    //{
    //    //    long time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    //    //    _isReloading = true;
    //    //    _currTime += Time.deltaTime;
    //    //    Debug.Log(_currTime);
    //    //}
    //    //_currTime = 0;
    //    //_isReloading = false;
    //}

    private IEnumerator Reloading()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _isReloading = false;
    }
}
