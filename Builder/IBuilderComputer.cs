namespace Builder
{
    /// <summary>
    /// 抽象建造者
    /// </summary>
    public interface IBuilderComputer
    {
        // 1、封装各个组成部件
        void BuildCPU();
        void BuildDisk();
        void BuildMemory();
        void BuildScreen();
        void BuildSystem();

        // 2、返回创建好的对象
        Computer GetComputer();
    }

    /// <summary>
    /// 具体建造者A
    /// </summary>
    public class ComputerA : IBuilderComputer
    {
        private Computer _computer = new Computer();

        public void BuildCPU()
        {
            _computer.AddPart("i7");
        }

        public void BuildDisk()
        {
            _computer.AddPart("1T SSD");
        }

        public void BuildMemory()
        {
            _computer.AddPart("DDR4 32G");
        }

        public void BuildScreen()
        {
            _computer.AddPart("2k");
        }

        public void BuildSystem()
        {
            _computer.AddPart("win11");
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }

    public class ComputerB : IBuilderComputer
    {
        private Computer _computer = new Computer();
        public void BuildCPU()
        {
            _computer.AddPart("i3");
        }

        public void BuildDisk()
        {
            _computer.AddPart("256G SSD");
        }

        public void BuildMemory()
        {
            _computer.AddPart("8G DDR4");
        }

        public void BuildScreen()
        {
            _computer.AddPart("14寸");
        }

        public void BuildSystem()
        {
            _computer.AddPart("win7");
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
