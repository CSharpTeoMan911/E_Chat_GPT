using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace E_Chat_GPT
{
    internal class Tools_Variables
    {
        protected static bool C_Sharp_Tools_Window_Opened;
        protected static bool Python_Tools_Window_Opened;
        protected static bool PowerShell_Tools_Window_Opened;
        protected static bool Command_Prompt_Window_Tools_Opened;

        protected static bool Activate_C_Sharp_Tools_Window;
        protected static bool Activate_Python_Tools_Window;
        protected static bool Activate_PowerShell_Tools_Window;
        protected static bool Activate_Command_Prompt_Window_Tools_Window;

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

                        Compilation_Errors.Add("Error Message: " + error.ErrorText);
                        Compilation_Errors.Add("Error HResult: " + error.ErrorNumber);
                    }


                    MessageBox msg = new MessageBox(Compilation_Errors);
                    msg.ShowDialog();
                }
                compiler.Dispose();

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }


        protected static async Task<bool> Python_Interpreter(string Code)
        {
            try
            {
                using (System.Diagnostics.Process main_process = new System.Diagnostics.Process())
                {
                    using (System.IO.StreamWriter file_writter = System.IO.File.CreateText(System.IO.Directory.GetCurrentDirectory() + "\\Test.py"))
                    {
                        await file_writter.WriteAsync(Code);
                        await file_writter.FlushAsync();
                        file_writter.Close();
                        file_writter.Dispose();
                    }

                    main_process.StartInfo.UseShellExecute = false;
                    main_process.StartInfo.CreateNoWindow = false;
                    main_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    main_process.StartInfo.FileName = "cmd.exe";
                    main_process.StartInfo.Arguments = "cmd.exe cmd /k \"\""+ Environment.CurrentDirectory + "\"\"\\python.exe -m Test";

                    main_process.Start();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        protected static Task<bool> Python_Interpreter_Pip_Install(string Package_Name)
        {
            try
            {
                using (System.Diagnostics.Process main_process = new System.Diagnostics.Process())
                {
                    main_process.StartInfo.UseShellExecute = false;
                    main_process.StartInfo.CreateNoWindow = false;
                    main_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    main_process.StartInfo.FileName = "cmd.exe";
                    main_process.StartInfo.Arguments = "cmd.exe cmd /k \"\"" + Environment.CurrentDirectory + "\"\"\\python.exe -m pip install " + Package_Name;

                    main_process.Start();
                }
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }



        protected static Task<bool> Python_Interpreter_Pip_Uninstall(string Package_Name)
        {
            try
            {
                using (System.Diagnostics.Process main_process = new System.Diagnostics.Process())
                {
                    main_process.StartInfo.UseShellExecute = false;
                    main_process.StartInfo.CreateNoWindow = false;
                    main_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    main_process.StartInfo.FileName = "cmd.exe";
                    main_process.StartInfo.Arguments = "cmd.exe cmd /k \"\"" + Environment.CurrentDirectory + "\"\"\\python.exe -m pip uninstall " + Package_Name;

                    main_process.Start();
                }
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }



        protected async static Task<bool> PowerShell_Interpreter(string Code)
        {
            try
            {
                using (System.Diagnostics.Process main_process = new System.Diagnostics.Process())
                {
                    using (System.IO.StreamWriter file_writter = System.IO.File.CreateText(Environment.CurrentDirectory + "\\Test.ps1"))
                    {
                        await file_writter.WriteAsync(Code);
                        await file_writter.FlushAsync();
                        file_writter.Close();
                        file_writter.Dispose();
                    }

                    main_process.StartInfo.UseShellExecute = true;
                    main_process.StartInfo.CreateNoWindow = true;
                    main_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    main_process.StartInfo.FileName = "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe";
                    main_process.StartInfo.Arguments = "PowerShell -NoExit -File \"'" + Environment.CurrentDirectory + "\\Test.ps1'\"";

                    main_process.Start();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }



        protected async static Task<bool> Command_Prompt_Interpreter(string Code)
        {
            try
            {
                using (System.Diagnostics.Process main_process = new System.Diagnostics.Process())
                {
                    using (System.IO.StreamWriter file_writter = System.IO.File.CreateText(Environment.CurrentDirectory + "\\Test.bat"))
                    {
                        await file_writter.WriteAsync(Code);
                        await file_writter.FlushAsync();
                        file_writter.Close();
                        file_writter.Dispose();
                    }

                    main_process.StartInfo.UseShellExecute = true;
                    main_process.StartInfo.CreateNoWindow = true;
                    main_process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    main_process.StartInfo.FileName = "cmd.exe";
                    main_process.StartInfo.Arguments = "cmd.exe cmd /k \"\"" + Environment.CurrentDirectory + "\"\"\\Test.bat";

                    main_process.Start();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
