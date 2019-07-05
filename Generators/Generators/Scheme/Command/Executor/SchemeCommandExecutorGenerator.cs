﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Generators.Scheme.Command.Executor
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class SchemeCommandExecutorGenerator : SchemeCommandExecutorGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using NetStack.Serialization;\r\nusing Sources.Tools;\r\n\r\npublic static class ");
            
            #line 9 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Type));
            
            #line default
            #line hidden
            this.Write("CommandExecutor\r\n{\r\n    public static void Execute(I");
            
            #line 11 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Type));
            
            #line default
            #line hidden
            this.Write("Handler handler, BitBuffer buffer, ushort commandCount)\r\n\t{\r\n\t\tfor (int i = 0; i " +
                    "< commandCount; i++)\r\n        {\r\n            var commandId = buffer.ReadUShort()" +
                    ";\r\n            switch (commandId)\r\n            {\r\n\t\t\t");
            
            #line 18 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"

            for (int i = 0; i < SchemeNames.Length; i++)
            {
                var id = SchemeIds[i];
                var name = SchemeNames[i];
                
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\r\n                case ");
            
            #line 25 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(id));
            
            #line default
            #line hidden
            this.Write(":\r\n                {\r\n");
            
            #line 27 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"

                if (name != "Input" && name != "InputBufferState")
                {

            
            #line default
            #line hidden
            this.Write("\t\t\t\t\tLogger.I.Log(\"");
            
            #line 31 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Type));
            
            #line default
            #line hidden
            this.Write("CommandExecutor\", \"Executing ");
            
            #line 31 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Using));
            
            #line default
            #line hidden
            
            #line 31 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("Command\");\r\n");
            
            #line 32 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"

                }

            
            #line default
            #line hidden
            this.Write("                    var c = new  ");
            
            #line 35 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Using));
            
            #line default
            #line hidden
            
            #line 35 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("Command();\r\n                    c.Deserialize(buffer);\r\n                    handl" +
                    "er.Handle");
            
            #line 37 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("Command(ref c);\r\n                    break;\r\n                }\r\n\t\t\t\t");
            
            #line 40 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"

            }
			
            
            #line default
            #line hidden
            this.Write("            }\r\n        }\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\UnityProjects\Coop-JRPG-git\Generators\Generators\Generators\Scheme\Command\Executor\SchemeCommandExecutorGenerator.tt"

private string _UsingField;

/// <summary>
/// Access the Using parameter of the template.
/// </summary>
private string Using
{
    get
    {
        return this._UsingField;
    }
}

private string _TypeField;

/// <summary>
/// Access the Type parameter of the template.
/// </summary>
private string Type
{
    get
    {
        return this._TypeField;
    }
}

private ushort[] _SchemeIdsField;

/// <summary>
/// Access the SchemeIds parameter of the template.
/// </summary>
private ushort[] SchemeIds
{
    get
    {
        return this._SchemeIdsField;
    }
}

private string[] _SchemeNamesField;

/// <summary>
/// Access the SchemeNames parameter of the template.
/// </summary>
private string[] SchemeNames
{
    get
    {
        return this._SchemeNamesField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool UsingValueAcquired = false;
if (this.Session.ContainsKey("Using"))
{
    this._UsingField = ((string)(this.Session["Using"]));
    UsingValueAcquired = true;
}
if ((UsingValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Using");
    if ((data != null))
    {
        this._UsingField = ((string)(data));
    }
}
bool TypeValueAcquired = false;
if (this.Session.ContainsKey("Type"))
{
    this._TypeField = ((string)(this.Session["Type"]));
    TypeValueAcquired = true;
}
if ((TypeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Type");
    if ((data != null))
    {
        this._TypeField = ((string)(data));
    }
}
bool SchemeIdsValueAcquired = false;
if (this.Session.ContainsKey("SchemeIds"))
{
    this._SchemeIdsField = ((ushort[])(this.Session["SchemeIds"]));
    SchemeIdsValueAcquired = true;
}
if ((SchemeIdsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("SchemeIds");
    if ((data != null))
    {
        this._SchemeIdsField = ((ushort[])(data));
    }
}
bool SchemeNamesValueAcquired = false;
if (this.Session.ContainsKey("SchemeNames"))
{
    this._SchemeNamesField = ((string[])(this.Session["SchemeNames"]));
    SchemeNamesValueAcquired = true;
}
if ((SchemeNamesValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("SchemeNames");
    if ((data != null))
    {
        this._SchemeNamesField = ((string[])(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class SchemeCommandExecutorGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
