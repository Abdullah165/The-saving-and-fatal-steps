using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartGamePLay()
    {
        SceneManager.LoadScene(0);
    }
}
