using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.VisualBasic;

namespace EZCompile
{
    public class Compiler
    {
        public List<string> CustomReferences = new List<string>();
        public string Code { get; set; }
        public string OutputName { get; set; }
        public OutputType.Output OutputType { get; set; }
        public Assembly CompiledAssembly { get; set; }

        /// <summary>
        /// Run the Compiled <see cref="Assembly"/> From Memory and Invoking the selected <see cref="MethodInvoke"/>
        /// <para></para>
        /// Facultative : <paramref name="obj"/> and <paramref name="parameters"/> are customs parameters needed in your <paramref name="method"/>
        /// <para></para>
        /// If you got no parameters, just put null
        /// </summary>
        /// <param name="method"></param>
        /// <param name="assembly"></param>
        /// <param name="obj"></param>
        /// <param name="parameters"></param>

        public void RunFromMemory(MethodInvoke method, Assembly assembly, object obj, object[] parameters)
        {
            Assembly asm = assembly;
            Type myType = asm.GetType(method.ClassName);

            MethodInfo myMethod = myType.GetMethod(method.MethodeName);
            myMethod.Invoke(obj, parameters);
        }
        /// <summary>
        /// Run the Compiled <see cref="Assembly"/> From Memory and Invoking the selected <see cref="MethodInvoke"/>
        /// </summary>
        /// <param name="method"></param>
        /// <param name="assembly"></param>
        public void RunFromMemory(MethodInvoke method, Assembly assembly)
        {
            Assembly asm = assembly;
            Type myType = asm.GetType(method.ClassName);

            MethodInfo myMethod = myType.GetMethod(method.MethodeName);
            myMethod.Invoke(null, null);
        }

        /// <summary>
        /// Compile and return the assembly. RunFromMemory() will run the compiled assembly
        /// </summary>
        /// <returns></returns>
        
        public CompileResult CompileAndRunCsharp()
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            foreach (var item in CustomReferences)
            {
                parameters.ReferencedAssemblies.Add(item.ToString());
            }
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.OutputAssembly = OutputName;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, Code);

            if (results.Errors.Count > 0)
            {
                //Console.WriteLine("");
                CompileResult res = new CompileResult();
                foreach (var item in results.Errors)
                {
                    res.ErrorText += Environment.NewLine + item.ToString();
                    res.ErrorList.Add(item.ToString());
                }
                res.IsSuccess = false;
                return res;
            }
            else
            {
                CompiledAssembly = results.CompiledAssembly;
                EZCompile.CompileResult res = new EZCompile.CompileResult();
                res.IsSuccess = true;
                res.ErrorText = "No Compilation Error Detected";
                return res;

            }

        }

        public CompileResult CompileFromVBCode()
        {
            VBCodeProvider codeProvider = new VBCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            foreach (var item in CustomReferences)
            {
                parameters.ReferencedAssemblies.Add(item.ToString());
            }
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = false;
            parameters.OutputAssembly = OutputName;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters,Code);
            if (results.Errors.Count > 0)
            {
                //Console.WriteLine("");
                CompileResult res = new CompileResult();
                res.IsSuccess = false;
                return res;
            }
            else
            {
                CompileResult res = new CompileResult();
                res.IsSuccess = true;
                return res;
            }

        }

        public CompileResult CompileFromCSharpCode()
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            foreach (var item in CustomReferences)
            {
                parameters.ReferencedAssemblies.Add(item.ToString());
            }
            parameters.GenerateExecutable = true;
            parameters.GenerateInMemory = false;
            parameters.OutputAssembly = OutputName;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, Code);

            if (results.Errors.Count > 0)
            {
                //Console.WriteLine("");
                CompileResult res = new CompileResult();
                res.IsSuccess = false;
                return res;
            }
            else
            {
                CompileResult res = new CompileResult();
                res.IsSuccess = true;
                return res;
            }
        }



        
    }
}
