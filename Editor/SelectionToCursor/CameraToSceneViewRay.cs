using UnityEditor;
using UnityEngine;

public class CameraToSceneViewRay : Editor
{
    private static Ray _rayFromCameraToMousePosition = new Ray();

    [InitializeOnLoadMethod]
    private static void SubscribeToSceneGUI()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        _rayFromCameraToMousePosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    }

    public static Ray GetRay()
    {
        return _rayFromCameraToMousePosition;
    }

    public static bool GetValidRaycastHit(out RaycastHit outHit)
    {
        if (Physics.Raycast(_rayFromCameraToMousePosition, out outHit, 100f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else return false;
    }
}
