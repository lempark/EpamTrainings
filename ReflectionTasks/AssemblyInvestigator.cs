using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UserInterface;

namespace ReflectionTasks
{
    public class AssemblyInvestigator : IInvestigator
    {
        public Assembly Assembly { get; set; }
        public IPrinter Printer { get; set; }

        public void Investigate()
        {
            Printer.Write(Assembly.GetName().Name);
            

            try
            {
                foreach (Module module in Assembly.GetModules())
                {
                    Printer.Write("\t" + module.Name);     
                }

                foreach (Type Type in Assembly.GetTypes())
                {
                    TypeAttributes tAttributes = Type.Attributes; 
                    Printer.Write($"\n\t\t{tAttributes.ToString()} {Type.Name}");

                    Printer.Write("\n\t\t\tFields: \n");

                    foreach (FieldInfo field in Type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    {
                        FieldAttributes fAttributes = field.Attributes;
                        Printer.Write($"\t\t\t{fAttributes.ToString()} {field.FieldType} {field.Name}");
                    }

                    Printer.Write("\n\t\t\tProperties: \n");

                    foreach (PropertyInfo prop in Type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    {
                        PropertyAttributes pAttributes = prop.Attributes;
                        Printer.Write($"\t\t\t{pAttributes.ToString()} {prop.PropertyType} {prop.Name}");
                    }

                    Printer.Write("\n\t\t\tConstructors: \n");

                    foreach (ConstructorInfo ctor in Type.GetConstructors())
                    {
                        string parametrs = "";

                        foreach (ParameterInfo param in ctor.GetParameters())
                        {
                            parametrs += $"{param.ParameterType} {param.Name} ";
                        }
                        
                        Printer.Write($"\t\t\t{Type.Name} ({parametrs})");      
                    }

                    Printer.Write("\n\t\t\tMethods: \n");

                    foreach (MethodInfo method in Type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Static | BindingFlags.Instance  | BindingFlags.DeclaredOnly))
                    {
                        string parametrs = "";

                        foreach (ParameterInfo param in method.GetParameters())
                        {
                            parametrs += $" {param.ParameterType} {param.Name} ";
                        }

                        MethodAttributes mAttributes = method.Attributes;
                        Printer.Write($"\t\t\t{mAttributes.ToString()} {method.ReturnType} {method.Name} ({parametrs})");
                    }
                }
            }
            catch(System.IO.FileNotFoundException)
            {
                throw;
            }
            catch(ReflectionTypeLoadException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
