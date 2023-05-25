
using System.IO.Compression;
using UnityEditor;
using UnityEngine;


namespace aptXR
{
    public class AssetImportStandards : AssetPostprocessor
    {

        // standards for importing models
        public void OnPreprocessModel()
        {
            ModelImporter modelImporter = (ModelImporter)assetImporter;

            if (modelImporter.isReadable)
            {
                modelImporter.isReadable = false;
                modelImporter.SaveAndReimport();
            }

            if (modelImporter.meshCompression != ModelImporterMeshCompression.Medium)
            {
                modelImporter.meshCompression = ModelImporterMeshCompression.Medium;
            }

            if (modelImporter.importCameras)
            {
                modelImporter.importCameras = false;
            }

            if (modelImporter.importLights)
            {
                modelImporter.importLights = false;
            }
        }

        // presets for any imported texture. 
        public void OnPreprocessTexture()
        {

            TextureImporter textureImporter = (TextureImporter)assetImporter;

            if (textureImporter.isReadable)
            {
                textureImporter.mipmapEnabled = false;
            }

            if (textureImporter.compressionQuality > 70)
            {
                textureImporter.compressionQuality = 20;
            }

            if (textureImporter.maxTextureSize > 540)
            {
                textureImporter.maxTextureSize = 540;
            }

            if (textureImporter.textureCompression == TextureImporterCompression.Uncompressed)
            {
                textureImporter.textureCompression = TextureImporterCompression.CompressedLQ;
            }

            if (textureImporter.textureType == TextureImporterType.Default)
            {
                textureImporter.textureType = TextureImporterType.NormalMap;
            }

        }


        // Mesh renderer import settings by default for project. 
        private void OnPostprocessMeshHierarchy(UnityEngine.GameObject root)
        {

            MeshRenderer mesh = root.GetComponent<MeshRenderer>();

            if (mesh.receiveShadows)
            {
                mesh.receiveShadows = false;
            }


            if (mesh.lightProbeUsage == UnityEngine.Rendering.LightProbeUsage.BlendProbes)
            {
                mesh.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
            }

            if (mesh.shadowCastingMode == UnityEngine.Rendering.ShadowCastingMode.On)
            {
                mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
        }

        // Default import settings for audio formats.

        private void OnPreprocessAudio()
        {
            if (assetPath.Contains("mono"))
            {
                AudioImporter audioImporter = (AudioImporter)assetImporter;
                audioImporter.forceToMono = true;
                audioImporter.loadInBackground = true;
            }
        }


    }
}

