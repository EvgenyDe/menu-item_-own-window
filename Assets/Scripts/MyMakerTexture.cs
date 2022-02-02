using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MyMakerTexture : EditorWindow
{
    public GameObject cube;
    
    private  Color[,] pixels = new Color[8,8];

    private Rect[,] rects = new Rect[8, 8];

    private Texture2D outputTexture;
    
    private Color _colorForLeftClick =Color.red;
    private Color _colorForRightCkick =Color.yellow;

    
    private void OnEnable()
    {
        
        for (int i = 0; i < pixels.GetLongLength(0); i++)
        {
            for (int j = 0; j < pixels.GetLongLength(0); j++)
            {
                pixels[i, j]=RandomColor();
            }
        }
        
        outputTexture = new Texture2D(8, 8);
        
        
    }

    [MenuItem("MyTOOLS/MakerTexture")]
    public static void OpenMakerWindow()
    {
        GetWindow<MyMakerTexture>();
        //Debug.Log(pixels.GetLongLength(0));
    }

   
    
    private void OnGUI()
    {
        
        
        
        Color oldCalor = GUI.color;
        
        GUILayout.Box("name",  GUILayout.Height(500));
        for (int i = 0; i < pixels.GetLongLength(0); i++)
        {
            GUILayout.BeginHorizontal();
            for (int j = 0; j < pixels.GetLongLength(0); j++)
            {
                GUILayout.BeginVertical();
                GUI.color = GetColorForPixel(i,j); // pixels[i, j];


                rects[i, j] = new Rect(55 * i, 55 * j, 50, 50);
                GUI.DrawTexture(rects[i,j], EditorGUIUtility.whiteTexture, ScaleMode.ScaleToFit, true, 1);

                CheckLastBox(i, j);
                    
                GUI.color = oldCalor;
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }

        MakeTexture();
        // if(evnt.type == EventType.MouseDown&&)
        //
        GUILayout.BeginVertical();
        _colorForLeftClick = EditorGUILayout.ColorField(_colorForLeftClick);
        _colorForRightCkick = EditorGUILayout.ColorField(_colorForRightCkick);

        outputTexture = (Texture2D) EditorGUILayout.ObjectField("Output Texture", outputTexture, typeof(Texture2D), true);
        cube = (GameObject) EditorGUILayout.ObjectField("Target Object", cube, typeof(GameObject),true);
        
        if (GUILayout.Button("Set One Color"))
        {
            Debug.Log("Apply texture to object");
            SetOneColor();
        }
        if (GUILayout.Button("Apply texture to object"))
        {
            Debug.Log("Apply texture to object");
            SetTextureToCub();
        }
        
        
        
        
        GUILayout.EndVertical();

    }

    private void SetOneColor()
    {
       // cube.GetComponent<MeshRenderer>().material.color = _colorForLeftClick;
    }

    private void SetTextureToCub()
    {
        cube.GetComponent<MeshRenderer>().sharedMaterial.mainTexture=outputTexture;
    }

    private void MakeTexture()
    {
        outputTexture = new Texture2D(8, 8);
        
        for (int y = 0; y < outputTexture.height; y++)
        {
            for (int x = 0; x < outputTexture.width; x++)
            {
                outputTexture.SetPixel(x, y, pixels[x,y]);
            }
        }
        outputTexture.Apply();
        
        //cube.GetComponent<MeshRenderer>().material.mainTexture = outputTexture;
        
    }

    private void CheckLastBox(int i, int j)
    {
        Event evnt = Event.current;
        if (rects[i,j].Contains(evnt.mousePosition))
        {
            Debug.Log("in nets");
            if (evnt.type == EventType.MouseDown)
            {
                if(evnt.button == 0) pixels[i, j] = _colorForLeftClick;
                if(evnt.button == 1) pixels[i, j] = _colorForRightCkick;
                evnt.Use();
            }
        }
        
    }


    private Color GetColorForPixel(int i, int j)
    {
        return pixels[i, j];
    }

    private Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
