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

````cs
Compiler compiler = new Compiler();
 compiler.Code = File.ReadAllText("test.cs");
 compiler.OutputName = "bite.exe";
 compiler.OutputType = OutputType.Output.exe;
 compiler.CustomReferences.Add("System.dll");
 //compiler.CustomReferences.Add("System.IO.dll");
 CompileResult result = compiler.CompileFromCode();
 if (result.IsSuccess)
 {
                
 	Console.WriteLine("success");
  }
  else
  {
        Console.WriteLine("failed");
        Console.WriteLine(result.ErrorText);
        List<string> ErrorList = result.ErrorList;
              
  }
````

## Release History

* 0.0.1
    * First Upload Of EZCompile






