using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (FieldOfView_Ambience))]
public class AmbientFieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView_Ambience fow = (FieldOfView_Ambience)target;
        Handles.color = Color.black;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.left, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);
        
        
    }
}