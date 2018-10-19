using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crowd
{
    public class SceneManager
    {
        public void ReloadCurrentScene()
        {
            Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
            return;
        }

        public void LoadScene(string scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            return;
        }
    }
}