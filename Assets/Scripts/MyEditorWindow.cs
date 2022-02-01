using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditorWindow : EditorWindow
{
    private Color[] _pixels= new Color[8*8];
    
    private GameObject cube;
    private string _userData;
    private Color _color;
    private Texture te;
    private void OnEnable()
    {
        cube = GameObject.Find("Cube");
        //GameObject[] boxes = GUILayout.Box()
    }

    [MenuItem("MyTOOLS/My Editor")]
    private static void OpenEditWindow()
    {
        GetWindow<MyEditorWindow>();
    }

    private void OnGUI()
    {
        // cube = (GameObject)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 60), 
        //     "Find Dependency", cube, typeof(GameObject),true);

        cube = (GameObject) EditorGUILayout.ObjectField("Target Object", cube, typeof(GameObject),true);
        
       // EditorGUILayout.ObjectField(GameObject);
        if (GUILayout.Button("Do COLORIZE"))
        {
            Debug.Log("Do COLORIZE");
            ColorizeCube();
        }
        
        // if (GUILayout.Box(_color,))
        // {
        //     Debug.Log("Do COLORIZE");
        //     ColorizeCube();
        // }
        
        
        
        //GUILayout.Label("Im the Label!");
        //_userData = GUILayout.TextField(_userData);
        _color = EditorGUILayout.ColorField(_color);

    }

    void ColorizeCube()
    {
        
        // if(!cubeGo){return;}
        //
        // MeshRenderer cubeMr = cubeGo.GetComponent<MeshRenderer>();
        // if(!cubeMr){return;}
        //
        // Material cubeMat = cubeMr.material;
        // if(!cubeMat){return;}
        // cubeMat.SetColor("_Color", _color);
        //
    }
}

