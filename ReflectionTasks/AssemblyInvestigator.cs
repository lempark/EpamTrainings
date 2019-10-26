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
            
            foreach (Module module in Assembly.GetModules())
            {
                Printer.Write(module.Name);
            }

            foreach (Type Type in Assembly.GetTypes())
            {
                Printer.Write(Type.Name);

                foreach(CustomAttributeData attribute in Type.CustomAttributes)
                {
                    Type attributeType = attribute.AttributeType;
                    Printer.Write(attributeType.Name);
                }

                foreach(MemberInfo member in Type.GetMembers())
                {
                    Printer.Write(member.Name);
                    Printer.Write(member.MemberType.ToString());

                    foreach (CustomAttributeData attribute in Type.CustomAttributes)
                    {
                        Type attributeType = attribute.AttributeType;
                        Printer.Write(attributeType.Name);
                    }
                }
            }
        }
    }
}
