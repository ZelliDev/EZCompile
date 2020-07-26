using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZCompile
{
    public class CompileResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorText { get; set; }

        public List<string> ErrorList { get; set; }
    }
}
