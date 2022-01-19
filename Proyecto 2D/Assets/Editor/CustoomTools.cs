using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[ExecuteInEditMode()]
public class CustomTools : MonoBehaviour
{
    private static Vector3 copiedLocalPosition;
    private static int distribuitionDistance = 1;

    [MenuItem("Proyecto2D/Rotate Z 90º &#r", false, 2)]
    public static void RotateZ90All()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selected.Length > 0)
        {
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].Rotate(0, 0, 90);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Proyecto2D/Create parent for selection", false, 4)]
    public static void CreateNewParentForSelection()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        if (selected.Length > 0)
        {
            GameObject parent = new GameObject("Parent from selection");

            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].parent = parent.transform;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Proyecto2D/Copy local position for selection", false, 5)]
    public static void CopyLocalPosition()
    {
        Transform selected = Selection.activeTransform;
        if (selected != null)
        {
            copiedLocalPosition = selected.localPosition;
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Proyecto2D/Paste local position for selection", false, 6)]
    public static void PastePosition()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        if (selected.Length > 0)
        {
            for (int a = 0; a < selected.Length; a++)
            {
                selected[a].localPosition = copiedLocalPosition;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Proyecto2D/X axis distribuition for selection", false, 8)]
    public static void DistributeXSelection()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        int x = distribuitionDistance;

        if (selected.Length > 0)
        {
            for (int a = 0; a < selected.Length; a++)
            {
                selected[a].transform.localPosition = new Vector3(x, 0, 0);

                x -= distribuitionDistance;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }

    [MenuItem("Proyecto2D/Y axis distribuition for selection", false, 9)]
    public static void DistributeYSelection()
    {
        Transform[] selected = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        int y = distribuitionDistance;

        if (selected.Length > 0)
        {
            for (int a = 0; a < selected.Length; a++)
            {
                selected[a].transform.localPosition = new Vector3(0, y, 0);

                y -= distribuitionDistance;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto", "Ok");
        }
    }
}