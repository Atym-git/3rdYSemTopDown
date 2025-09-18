using UnityEngine;
using UnityEngine.UI;

public class Pause
{
    private const int PAUSED = 0;
    private const int UNPAUSED = 1;

    private Image _settingsPanel;

    public Pause(Image settingsPanel)
    {
        _settingsPanel = settingsPanel;
    }

    public void PauseUnPauseGame()
    {
        if (Time.timeScale == PAUSED)
        {
            Time.timeScale = UNPAUSED;
            _settingsPanel.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = PAUSED;
            _settingsPanel.gameObject.SetActive(true);
        }
    }
}
