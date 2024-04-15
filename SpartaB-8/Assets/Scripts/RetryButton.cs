using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrtyBtn : MonoBehaviour
{
    public void Retry()
    {   
        //임시로 설정 재시작시 보여줄 신 설정할 것
        SceneManager.LoadScene("MoojinScene");
    }

}
