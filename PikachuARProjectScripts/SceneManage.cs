using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    
    public void Play()
    {
        SceneManager.LoadScene("ARScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
