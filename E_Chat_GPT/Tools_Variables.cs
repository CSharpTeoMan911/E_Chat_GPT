using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Chat_GPT
{
    internal class Tools_Variables
    {
        protected static bool C_Sharp_Tools_Window_Opened;


        protected static Task<bool> C_Sharp_Code_Compilation(string code)
        {
            try
            {
                string compilation_output = "Test_Compilation.exe";

                CSharpCodeProvider compiler = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();

#pragma warning disable CS0618 // Type or member is obsolete
                ICodeCompiler compiler_interface = compiler.CreateCompiler();
#pragma warning restore CS0618 // Type or member is obsolete


                parameters.ReferencedAssemblies.AddRange(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(a =>
                {
                    if (a.Name == "PresentationCore")
                        return "WPF\\" + a.Name + ".dll";

                    else if (a.Name == "PresentationFramework")
                        return "WPF\\" + a.Name + ".dll";

                    else if (a.Name == "WindowsBase")
                        return "WPF\\" + a.Name + ".dll";

                    else
                        return a.Name + ".dll";
                }).ToArray());



                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = compilation_output;

                CompilerResults compilation_results = compiler_interface.CompileAssemblyFromSource(parameters, code);

                if (compilation_results.Errors.Count > 0)
                {
                    List<string> Compilation_Errors = new List<string>();

                    for (int count = 0; count < compilation_results.Errors.Count; count++)
                    {
                        CompilerError error = compilation_results.Errors[count];

                        Compilation_Errors.Add("\tError: " + error.ErrorText);
                        Compilation_Errors.Add("\tError HResult: " + error.ErrorNumber);
                    }


                    Compiler_Or_Interpreter_Errors compiler_Or_Interpreter_Errors = new Compiler_Or_Interpreter_Errors(Compilation_Errors);
                    compiler_Or_Interpreter_Errors.ShowDialog();
                }

                System.IO.File.Delete(compilation_output);
                compiler.Dispose();

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
