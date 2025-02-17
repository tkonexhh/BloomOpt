using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace UnityEditor.Rendering.Universal
{
    [VolumeComponentEditor(typeof(Bloom))]
    sealed class BloomEditor : VolumeComponentEditor
    {
        SerializedDataParameter m_Threshold;
        SerializedDataParameter m_Intensity;
        SerializedDataParameter m_Scatter;
        SerializedDataParameter m_Clamp;
        SerializedDataParameter m_Tint;
        SerializedDataParameter m_HighQualityFiltering;
        SerializedDataParameter m_SkipIterations;
        SerializedDataParameter m_DirtTexture;
        SerializedDataParameter m_DirtIntensity;
        
        SerializedDataParameter m_UseOpt;
        SerializedDataParameter m_DownSample;
        SerializedDataParameter m_Sigma;

        public override void OnEnable()
        {
            var o = new PropertyFetcher<Bloom>(serializedObject);

            m_Threshold = Unpack(o.Find(x => x.threshold));
            m_Intensity = Unpack(o.Find(x => x.intensity));
            m_Scatter = Unpack(o.Find(x => x.scatter));
            m_Clamp = Unpack(o.Find(x => x.clamp));
            m_Tint = Unpack(o.Find(x => x.tint));
            m_HighQualityFiltering = Unpack(o.Find(x => x.highQualityFiltering));
            m_SkipIterations = Unpack(o.Find(x => x.skipIterations));
            m_DirtTexture = Unpack(o.Find(x => x.dirtTexture));
            m_DirtIntensity = Unpack(o.Find(x => x.dirtIntensity));
            
            m_UseOpt= Unpack(o.Find(x => x.useOpt));
            m_DownSample= Unpack(o.Find(x => x.downSample));
            m_Sigma= Unpack(o.Find(x => x.sigma));
        }

        public override void OnInspectorGUI()
        {
            PropertyField(m_Threshold);
            PropertyField(m_Intensity);
            PropertyField(m_Scatter);
            PropertyField(m_Tint);
            PropertyField(m_Clamp);
            PropertyField(m_HighQualityFiltering);

            if (m_HighQualityFiltering.overrideState.boolValue && m_HighQualityFiltering.value.boolValue && CoreEditorUtils.buildTargets.Contains(GraphicsDeviceType.OpenGLES2))
                EditorGUILayout.HelpBox("High Quality Bloom isn't supported on GLES2 platforms.", MessageType.Warning);

            PropertyField(m_SkipIterations);

            PropertyField(m_DirtTexture);
            PropertyField(m_DirtIntensity);
            
            PropertyField(m_UseOpt);
            PropertyField(m_DownSample);
            PropertyField(m_Sigma);
        }
    }
}
