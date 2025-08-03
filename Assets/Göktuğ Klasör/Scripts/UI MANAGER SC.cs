using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMANAGERSC : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; // For Unity Editor
        Application.Quit();
    }
}
