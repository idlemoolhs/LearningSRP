using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline 
{
    CameraRenderer renderder = new CameraRenderer();//������Ⱦ��ʵ��
    bool useDynamicBatching, useGPUInstancing;

    public CustomRenderPipeline(bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher)
    {
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher; //����SRP Batcher
    }
    protected override void Render(ScriptableRenderContext context, Camera[] cameras) 
    {
        //ѭ��ÿ�����
        foreach (Camera camera in cameras)
        {
            renderder.Render(context, camera, useDynamicBatching, useGPUInstancing);
        }
    }
}
