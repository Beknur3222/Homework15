using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15
{
    class MyClass
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
    }
    class Program
    {
        static void Exemple01()
        {
            Type consoleType = typeof(Console);

            MethodInfo[] methods = consoleType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
        static void Exemple02()
        {
            MyClass myObject = new MyClass
            {
                MyProperty1 = 20,
                MyProperty2 = "Hello, World!"
            };

            Type myType = myObject.GetType();

            PropertyInfo[] properties = myType.GetProperties();
            foreach (var property in properties)
            {
                object value = property.GetValue(myObject);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }
        static void Exemple03()
        {
            string myString = "Hello, World!";
            Type stringType = typeof(string);

            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            object[] parameters = { 7, 5 };
            object result = substringMethod.Invoke(myString, parameters);

            Console.WriteLine(result);
        }
        static void Exemple04()
        {
            Type listType = typeof(List<>);

            ConstructorInfo[] constructors = listType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
        }
        static void Main(string[] args)
        {
            Exemple01();
            Exemple02();
            Exemple03();
            Exemple04();
            Console.ReadKey();
        }
    }
}
