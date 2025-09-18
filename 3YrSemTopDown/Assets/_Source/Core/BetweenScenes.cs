using UnityEngine;
using UnityEngine.SceneManagement;

public class BetweenScenes : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
