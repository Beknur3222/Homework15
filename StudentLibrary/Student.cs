using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class Student
    {
        public void MethodName()
        {
            Console.WriteLine("Вызов метода студента");
        }

        public string PropertyName { get; set; } = "ГУК";
    }
    public interface IPlugin
    {
        void Execute();
    }
    public class SamplePlugin : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Выполнено!");
        }
    }
}
