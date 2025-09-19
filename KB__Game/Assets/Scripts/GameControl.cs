using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameControl
{
    public static void FREEZE()
    {
        Time.timeScale = 0;
    }
    public static void UNFREEZE()
    {
        Time.timeScale = 1;
    }
    public static void LOAD_COMBAT()
    {
        SceneManager.LoadScene("CombatScene", LoadSceneMode.Single);
    }
}
