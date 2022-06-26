using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUIManager : MonoBehaviour
{
    public void OnClickToTitle()
    {
        LoadingSceneManager.LoadScene("Title");
    }
}
