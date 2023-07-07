using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreWinApp.Utility
{
    public interface IInputHelper<T> where T : class
    {
        string Input { get; set; }
        /// <summary>
        /// Validate Input and return result if input is valid
        /// </summary>
        /// <returns>true: input is valid</returns>
        bool ValidateInput();
    }
}
