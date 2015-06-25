// c# example
// Builds an asset bundle from the selected objects in the project view,
// and changes the texture format using an AssetPostprocessor.

using UnityEngine;
using UnityEditor;

public class ExportAssetBundles
{

    // Store current texture format for the TextureProcessor.
    public static TextureImporterFormat textureFormat;

    [MenuItem("Assets/Build AssetBundle From Selection - PVRTC_RGB2")]
    static void ExportResourceRGB2()
    {
        textureFormat = TextureImporterFormat.PVRTC_RGB2;
        ExportResource();
    }

    [MenuItem("Assets/Build AssetBundle From Selection - PVRTC_RGB4")]
    static void ExportResourceRGB4()
    {
        textureFormat = TextureImporterFormat.PVRTC_RGB4;
        ExportResource();
    }

    static void ExportResource()
    {
        // Bring up save panel.
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");

        if (path.Length != 0)
        {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            foreach (object asset in selection)
            {
                string assetPath = AssetDatabase.GetAssetPath((UnityEngine.Object)asset);
                if (asset is Texture2D)
                {
                    // Force reimport thru TextureProcessor.
                    AssetDatabase.ImportAsset(assetPath);
                }
            }

            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
            Selection.objects = selection;
        }
    }
}