using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CustomRenderPipeline : RenderPipeline 
{
    CameraRenderer renderder = new CameraRenderer();//创建渲染器实例
    bool useDynamicBatching, useGPUInstancing;

    public CustomRenderPipeline(bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher)
    {
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher; //开启SRP Batcher
    }
    protected override void Render(ScriptableRenderContext context, Camera[] cameras) 
    {
        //循环每个相机
        foreach (Camera camera in cameras)
        {
            renderder.Render(context, camera, useDynamicBatching, useGPUInstancing);
        }
    }
}
