using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrtyBtn : MonoBehaviour
{
    public void Retry()
    {   
        //�ӽ÷� ���� ����۽� ������ �� ������ ��
        SceneManager.LoadScene("MoojinScene");
    }

}
