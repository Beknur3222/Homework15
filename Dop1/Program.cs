using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using StudentLibrary;
namespace Dop1
{
    class Program
    {
        static void Main()
        {
            // 1. 
            Assembly assembly = Assembly.LoadFrom("StudentLibrary.dll");
            Type[] types = assembly.GetTypes();

            Type studentType = types.First(t => t.Name == "Student");
            dynamic student = Activator.CreateInstance(studentType);

            MethodInfo method = studentType.GetMethod("MethodName");
            method.Invoke(student, null);

            PropertyInfo property = studentType.GetProperty("PropertyName");
            var propertyValue = property.GetValue(student);
            Console.WriteLine($"Название имущества: {propertyValue}");

            // 2.
            Console.WriteLine("\nИерархия типов и интерфейсы:");
            PrintTypeHierarchyAndInterfaces(studentType);

            // 3. 
            Type dictionaryType = typeof(Dictionary<string, int>);
            dynamic dictionary = Activator.CreateInstance(dictionaryType);
            dictionary.Add("Key1", 20);
            dictionary.Add("Key2", 123);

            int value = dictionary["Key1"];
            Console.WriteLine($"Значение ключа 1: {value}");

            // 4.
            LoadAndExecutePlugins();

            Console.ReadKey();
        }

        static void PrintTypeHierarchyAndInterfaces(Type type)
        {
            
            Console.WriteLine("Иерархия:");
            Type currentType = type;
            while (currentType != null)
            {
                Console.WriteLine(currentType.Name);
                currentType = currentType.BaseType;
            }

            Console.WriteLine("\nИнтерфейсы:");
            foreach (Type interfaceType in type.GetInterfaces())
            {
                Console.WriteLine(interfaceType.Name);
            }
        }

        static void LoadAndExecutePlugins()
        {
            string[] dllFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "StudentLibrary.dll");

            foreach (string dllFile in dllFiles)
            {
                Assembly assembly = Assembly.LoadFrom(dllFile);

                Type[] pluginTypes = assembly.GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IPlugin)))
                    .ToArray();

                foreach (Type pluginType in pluginTypes)
                {
                    dynamic plugin = Activator.CreateInstance(pluginType);
                    plugin.Execute();
                }
            }
        }
    }
}
