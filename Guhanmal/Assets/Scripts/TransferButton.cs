using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferButton : MonoBehaviour
{
    public void SceneTestClickListener(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
