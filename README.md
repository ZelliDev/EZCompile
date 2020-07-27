# EZCompile Library
> Usefull Library With Simplified compilation methods

[![Open Source](https://badges.frapsoft.com/os/v1/open-source.svg?v=103)](https://opensource.org/)
[![Active](http://img.shields.io/badge/Status-Active-green.svg)](https://tterb.github.io)


Easily compile your C# code 

## Installation
```

Download the current release and add it to your project

```

## Usage example
Compile CSharp Code (C#)
````cs
Compiler compiler = new Compiler();
compiler.Code = File.ReadAllText("test.cs");
compiler.OutputName = "bite.exe";
compiler.OutputType = OutputType.Output.exe;
compiler.CustomReferences.Add("System.dll");
CompileResult result = compiler.CompileFromCSharpCode();
if (result.IsSuccess)
{    
     Console.WriteLine("success");
               
}
else
{
     Console.WriteLine("failed");
     Console.WriteLine(result.ErrorText);
     List<string> ErrorList = result.ErrorList;
     foreach (var error in ErrorList)
     {
         Console.WriteLine(error.ToString());
     }
              
}
````

Compile VisualBasic Code (VB)

````cs
Compiler compiler = new Compiler();
compiler.Code = File.ReadAllText("test.vb");
compiler.OutputName = "bite.exe";
compiler.OutputType = OutputType.Output.exe;
compiler.CustomReferences.Add("System.dll");
CompileResult result = compiler.CompileFromVBCode();
if (result.IsSuccess)
{
                
     Console.WriteLine("success");
               
}
else
{
     Console.WriteLine("failed");
     Console.WriteLine(result.ErrorText);
     List<string> ErrorList = result.ErrorList;
     foreach (var error in ErrorList)
     {
           Console.WriteLine(error.ToString());
     }
              
}
````

## Release History

* 0.0.1
    * First Upload Of EZCompile






