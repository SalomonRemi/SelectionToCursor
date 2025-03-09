using UnityEditor;
using UnityEngine;

public class PasteSelectionToCursor : Editor
{
    private static GameObject[] _copiedGameObjects;

    [InitializeOnLoadMethod]
    private static void SubscribeToClipboardCopying()
    {
        ClipboardUtility.copyingGameObjects += OnSelectionBeingCopied;
    }

    [MenuItem("Custom Tools/Paste Selection To Cursor %#v")]
    private static void PasteToCursor()
    {
        RaycastHit hit;

        if (_copiedGameObjects != null && CameraToSceneViewRay.GetValidRaycastHit(out hit))
        {
            // DuplicateGameObjectsUsingPasteboard actually duplicates the GO that are selected.
            // This is why we need to set the Selection before duplicating.
            
            Selection.objects = _copiedGameObjects;

            Unsupported.DuplicateGameObjectsUsingPasteboard();

            TeleportSelectionToCursor.TeleportSelectionToRayHitPoint();
        }
    }

    static void OnSelectionBeingCopied(GameObject[] objects)
    {
        _copiedGameObjects = null;
        _copiedGameObjects = (GameObject[])objects.Clone();
    } 
}