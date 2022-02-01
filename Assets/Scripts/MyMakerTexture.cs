using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MyMakerTexture : EditorWindow
{
    private  Color[,] pixels = new Color[8,8];

    private Rect[,] rects = new Rect[8, 8];

    private Texture[] _textures = new Texture[8 * 8];
    
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
        
        // if(evnt.type == EventType.MouseDown&&)
        //
        GUILayout.BeginVertical();
        _colorForLeftClick = EditorGUILayout.ColorField(_colorForLeftClick);
        _colorForRightCkick = EditorGUILayout.ColorField(_colorForRightCkick);
        GUILayout.EndVertical();

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
