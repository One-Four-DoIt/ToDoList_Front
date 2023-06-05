using UnityEngine.SceneManagement;

namespace Manager
{
    public class ScenesManager : Singleton<ScenesManager>
    {  
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
