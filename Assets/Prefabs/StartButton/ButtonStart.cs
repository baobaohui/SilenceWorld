using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonStart : MonoBehaviour
{
    public bool IsGamePaused;

    public GameObject cubeGo;
    public GameObject capsuleGo;

    void Start()

    {

        PauseGame();
        cubeGo.SetActive(false);
        capsuleGo.SetActive(false);

    }

    void Update()

    {

        if (Input.GetKey(KeyCode.Escape))

        {

            PauseGame();

        }

        if (!IsGamePaused)
        {

            capsuleGo.transform.Rotate(Vector3.forward * 60);

        }

    }

    private void FixedUpdate()

    {

        //cubeGo.transform.Rotate(Vector3.up * 60);
    }

    void OnGUI()


    {

        if (GUI.Button(new Rect(0, 10, 100, 30), "暂停 "))
        {
            //System.Console.WriteLine("hello world");
            Time.timeScale = 0;
        }
        if (GUI.Button(new Rect(0, 40, 100, 30), "开始 "))
        {
            //System.Console.WriteLine("hello world");
            Time.timeScale = 1;
        }
        if (GUI.Button(new Rect(0, 70, 100, 30), "重新开始 "))
        {
            //System.Console.WriteLine("hello world");
            SceneManager.LoadScene(0);
        }

        if (!IsGamePaused)

            return;

        ///自动布局，按照区域

        GUILayout.BeginArea(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 100, 200));

        ///横向

        GUILayout.BeginVertical();

        if (IsGamePaused)

        {

            if (GUILayout.Button("开始游戏", GUILayout.Height(50)))

            {

                StartGame();

            }

        }

        if (GUILayout.Button("退出游戏", GUILayout.Height(50)))

        {

            Application.Quit();

        }

        GUILayout.Button("关于游戏", GUILayout.Height(50));

        GUILayout.EndVertical();

        GUILayout.EndArea();

    }

    void StartGame()

    {

        IsGamePaused = false;

        Time.timeScale = 1;

        cubeGo.SetActive(true);

        capsuleGo.SetActive(true);

    }

    void PauseGame()

    {

        IsGamePaused = true;

        Time.timeScale = 0;

    }
}
