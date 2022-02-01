using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    private string userData;
    private Color _color;
    private void OnEnable()
    {
        
    }

    [MenuItem("MyTOOLS")]
    private static void OpenEditWindow()
    {
        GetWindow<MyEditorWindow>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("colorize"))
        {
            Debug.Log("HELLO");
            ColorizeCube();
        }
        
        GUILayout.Label("Im the Label!");
        userData = GUILayout.TextField(userData);
        _color = EditorGUILayout.ColorField(_color);

    }

    void ColorizeCube()
    {
        GameObject cubeGo = GameObject.Find("Cube");
        if(!cubeGo){return;}

        MeshRenderer cubeMr = cubeGo.GetComponent<MeshRenderer>();
        if(!cubeMr){return;}

        Material cubeMat = cubeMr.material;
        if(!cubeMat){return;}
        cubeMat.SetColor("_Color", _color);
        
    }
}

