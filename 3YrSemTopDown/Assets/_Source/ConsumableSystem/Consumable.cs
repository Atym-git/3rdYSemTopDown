using TMPro;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private int bulletsAmount = 10;

    //[SerializeField] private TextMeshProUGUI consumableTMP;

    private Ammo _playerAmmo;

    public bool PlayerInsideTrigger { get; private set; }

    public void Construct(Ammo playerAmmo)
    {
        _playerAmmo = playerAmmo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, collision.gameObject))
        {
            _playerAmmo.RestoreBullets(bulletsAmount);
            PlayerInsideTrigger = true;
            gameObject.SetActive(false);
            //consumableTMP.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(playerLayerMask, collision.gameObject))
        {
            PlayerInsideTrigger = false;
            //consumableTMP.gameObject.SetActive(false);
        }
    }
}
