using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCaller : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
    }
}