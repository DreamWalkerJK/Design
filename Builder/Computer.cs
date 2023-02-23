using System;
using System.Collections.Generic;

namespace Builder
{
    /// <summary>
    /// 具体产品类
    /// </summary>
    public class Computer
    {
        private List<string> _servers = new List<string>();

        public void AddPart(string part)
        {
            _servers.Add(part);
        }

        public void ShowComputer()
        {
            Console.WriteLine("======================");
            foreach(var item in _servers)
            {
                Console.WriteLine($"installing {item}");
            }
        }
    }
}
