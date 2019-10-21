#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public static class ComponentTools
{
    [MenuItem("CONTEXT/Component/Collapse All")]
    private static void CollapseAll(MenuCommand command)
    {
        SetAllInspectorsExpanded((command.context as Component).gameObject, false);
    }

    [MenuItem("CONTEXT/Component/Expand All")]
    private static void ExpandAll(MenuCommand command)
    {
        SetAllInspectorsExpanded((command.context as Component).gameObject, true);
    }

    [MenuItem("CONTEXT/Component/Remove All MonoBehaviours")]
    private static void RemoveAllMonoBehaviours(MenuCommand command)
    {
        var go = (command.context as Component).gameObject;
        Component[] components = go.GetComponents<Component>();

        foreach (Component component in components)
            if (component is MonoBehaviour)
                Object.DestroyImmediate(component);

        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

    public static void SetAllInspectorsExpanded(GameObject go, bool expanded)
    {
        Component[] components = go.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (component is Transform) continue;
            if (component is Renderer)
            {
                var mats = ((Renderer)component).sharedMaterials;
                for (int i = 0; i < mats.Length; ++i)
                {
                    InternalEditorUtility.SetIsInspectorExpanded(mats[i], expanded);
                }
            }
            InternalEditorUtility.SetIsInspectorExpanded(component, expanded);
        }
        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

}
#endif