namespace Builder
{
    /// <summary>
    /// 指挥类
    /// </summary>
    public class Directory
    {
        public void BuildComputer(IBuilderComputer builderComputer)
        {
            builderComputer.BuildCPU();
            builderComputer.BuildDisk();
            builderComputer.BuildMemory();
            builderComputer.BuildScreen();
            builderComputer.BuildSystem();
        }
    }
}
