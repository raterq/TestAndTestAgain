using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vova.TestAndTestAgain
{
    public class GameOverPanel : MonoBehaviour
    {
        public TMP_Text Label;
        
        public void Initialize(int stepCount) => 
            Label.text = stepCount.ToString();

        public void Restart() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}