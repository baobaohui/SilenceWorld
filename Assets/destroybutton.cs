using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //点击销毁该button按钮，加载主场景
    public void OnMouseDown()
    {
        Destroy(this.gameObject);
        //SceneManager.LoadScene(sceneName);
    }
}
