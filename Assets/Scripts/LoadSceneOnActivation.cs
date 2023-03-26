using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LoadSceneOnActivation : MonoBehaviour
{
    public int sceneID;
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
    }
}