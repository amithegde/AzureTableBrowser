using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AzureTableBrowser.Helpers
{
    /// <summary>
    /// Helper class to compile, execute and capture result of a linq query entered as string
    /// TODO: Refactor this class, apply DRY
    /// </summary>
    public static class TextToLinq
    {
        /// <summary>
        /// Checks if a query is valid.
        /// </summary>
        public static bool IsValidQuery<T>(List<T> sourceData, string linqQueryAsString)
        {
            //cast objects to dynamic so that it can be passed on to another assembly.
            var data = sourceData.Cast<dynamic>().ToList();

            #region template Code

            //add required namespaces
            var defaultNamespaces = new[]
                {
                    "System", " System.Dynamic", "System.Collections.Generic", "System.Linq", "System.Text",
                    "System.Windows.Forms"
                };

            //complete class as string which will be compiled to an in memory assembly
            string executeCode =
                defaultNamespaces.Aggregate("",
                                            (current, defaultNamespace) =>
                                            current + string.Format("using {0};\n", defaultNamespace)) +
                @"namespace MyNamespace {
                    public class MyClass {
                        public List<dynamic> FilterData(List<dynamic> data,  string linqQueryAsString) {
                            try{
                                    var result = ((IEnumerable<dynamic>)(" + linqQueryAsString + @")).ToList();
                                    return result ;
                               }catch(Exception ex)
                               {
                                    return new List<dynamic>{new{Cause = ""LINQ Query Failed"", Message = ex.Message, Stacktrace = ex.StackTrace}};
                               }
                        }   
                     }    
                }";

            #endregion template Code

            //add required assembly references
            var defaultAssemblies = new[]
                {
                    "System.dll", "System.Core.dll", "Microsoft.CSharp.dll", "System.Data.dll", "System.Xml.dll",
                    "System.Xml.Linq.dll", "System.Windows.Forms.dll"
                };

            var compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize",
            };
            compilerParams.ReferencedAssemblies.AddRange(defaultAssemblies);

            //compile assembly
            var compiledAssembly = new CSharpCodeProvider().CompileAssemblyFromSource(compilerParams, executeCode);

            return !compiledAssembly.Errors.HasErrors;
        }

        /// <summary>
        /// This method accepts List<T> and linqQueryAsString. Data that is filtered is refered as "data" on linqQueryAsString.
        /// It compiles the user query as a in memory assembly by filling it in a simple class. Once compiled,
        /// source data is passed in to the assembly instance and excution result is collected.
        /// </summary>
        public static List<dynamic> Filter<T>(List<T> sourceData, string linqQueryAsString)
        {
            //cast objects to dynamic so that it can be passed on to another assembly.
            var data = sourceData.Cast<dynamic>().ToList();

            #region template Code

            //add required namespaces
            var defaultNamespaces = new[]
                {
                    "System", " System.Dynamic", "System.Collections.Generic", "System.Linq", "System.Text",
                    "System.Windows.Forms"
                };

            //complete class as string which will be compiled to an in memory assembly
            string executeCode =
                defaultNamespaces.Aggregate("",
                                            (current, defaultNamespace) =>
                                            current + string.Format("using {0};\n", defaultNamespace)) +
                @"namespace MyNamespace {
                    public class MyClass {
                        public List<dynamic> FilterData(List<dynamic> data,  string linqQueryAsString) {
                            try{
                                    var result = ((IEnumerable<dynamic>)(" + linqQueryAsString + @")).ToList();
                                    return result ;
                               }catch(Exception ex)
                               {
                                    return new List<dynamic>{new{Cause = ""LINQ Query Failed"", Message = ex.Message, Stacktrace = ex.StackTrace}};
                               }
                        }   
                     }    
                }";

            #endregion template Code

            //add required assembly references
            var defaultAssemblies = new[]
                {
                    "System.dll", "System.Core.dll", "Microsoft.CSharp.dll", "System.Data.dll", "System.Xml.dll",
                    "System.Xml.Linq.dll", "System.Windows.Forms.dll"
                };

            var compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize",
            };
            compilerParams.ReferencedAssemblies.AddRange(defaultAssemblies);

            //compile assembly
            var compiledAssembly = new CSharpCodeProvider().CompileAssemblyFromSource(compilerParams, executeCode);

            if (compiledAssembly.Errors.HasErrors)
            {
                var exceptionMessage = compiledAssembly.Errors.Cast<CompilerError>()
                                           .Aggregate("Compilation error on the query:\n",
                                                      (x, y) => x + ("rn" + y.ToString()));

                MessageBox.Show("Exception while compiling LINQ Query: \n "+ exceptionMessage);

                return data;
            }
            
            // create instance of the assembly
            dynamic instance =
                Activator.CreateInstance(compiledAssembly.CompiledAssembly.GetType("MyNamespace.MyClass"));

            //execute the method and collect result. since "instance" is of type dynamic, FilterData() method will be resolved at run time
            dynamic result = instance.FilterData(data, linqQueryAsString);

            return result;
        }
    }
}