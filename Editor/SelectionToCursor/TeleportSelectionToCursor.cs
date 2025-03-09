using System.Linq;
using UnityEditor;
using UnityEngine;

public class TeleportSelectionToCursor : Editor
{
    [MenuItem("Custom Tools/Teleport Selection To Cursor %t")]
    public static void TeleportSelectionToRayHitPoint()
    {
        RaycastHit hit;

        if (Selection.transforms.Length > 0 && CameraToSceneViewRay.GetValidRaycastHit(out hit))
        {
            Vector3 offset = hit.point - Selection.transforms.Last().position;

            Undo.RecordObjects(Selection.transforms, "Teleported Objects");

            foreach (Transform selectedObjectTransfrom in Selection.transforms)
            {
                selectedObjectTransfrom.position = selectedObjectTransfrom.position + offset;
            }
        }
    }
} 