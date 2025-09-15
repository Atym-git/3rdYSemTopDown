using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputListener inputListener;

    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Invoker _invoker;

    private void Awake()
    {
        _playerMovement = new PlayerMovement();
        _playerCombat = new PlayerCombat();

        _invoker = new Invoker(_playerMovement, playerData, _playerCombat);

        inputListener.Construct(_invoker);
    }
}
