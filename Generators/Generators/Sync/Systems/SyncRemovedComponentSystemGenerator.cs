﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Generators.Sync.Systems
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class SyncRemovedComponentSystemGenerator : SyncRemovedComponentSystemGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Collections.Generic;\r\nusing Entitas;\r\nusing Sources.Networking.Serve" +
                    "r;\r\n\r\npublic class ServerCaptureRemoved");
            
            #line 9 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentName));
            
            #line default
            #line hidden
            this.Write("System : ReactiveSystem<GameEntity>\r\n{\r\n\tprivate readonly ServerNetworkSystem _se" +
                    "rver;\r\n\tpublic ServerCaptureRemoved");
            
            #line 12 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentName));
            
            #line default
            #line hidden
            this.Write("System (Contexts contexts, Services services) : base(contexts.game)\r\n\t{\r\n\t\t_serve" +
                    "r = services.ServerSystem;\r\n\t}\r\n\t\t\r\n\tprotected override ICollector<GameEntity> G" +
                    "etTrigger(IContext<GameEntity> context) {\r\n\t\treturn context.CreateCollector(Game" +
                    "Matcher.");
            
            #line 18 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentName));
            
            #line default
            #line hidden
            this.Write(".Removed());\r\n\t}\r\n\t\t\r\n\tprotected override bool Filter(GameEntity entity)\r\n\t{\r\n");
            
            #line 23 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"

    if (IsTag)
    {

            
            #line default
            #line hidden
            this.Write("\t\treturn !entity.isDestroyed && entity.isWasSynced && entity.is");
            
            #line 27 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 28 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"

    }
    else
    {

            
            #line default
            #line hidden
            this.Write("        return !entity.isDestroyed && entity.isWasSynced && !entity.has");
            
            #line 33 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 34 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"

    }

            
            #line default
            #line hidden
            this.Write(@"	}

	protected override void Execute(List<GameEntity> entities) {
		if (_server.State != ServerState.Working) return;

        foreach (var e in entities) {
		    _server.RemovedComponents.AddUShort(e.id.Value);
			_server.RemovedComponents.AddUShort(");
            
            #line 44 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ComponentId));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t    _server.RemovedComponentsCount++;\r\n\t\t}\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\UnityProjects\Entitas-Sync\Generators\Generators\Generators\Sync\Systems\SyncRemovedComponentSystemGenerator.tt"

private string _ComponentNameField;

/// <summary>
/// Access the ComponentName parameter of the template.
/// </summary>
private string ComponentName
{
    get
    {
        return this._ComponentNameField;
    }
}

private ushort _ComponentIdField;

/// <summary>
/// Access the ComponentId parameter of the template.
/// </summary>
private ushort ComponentId
{
    get
    {
        return this._ComponentIdField;
    }
}

private bool _IsTagField;

/// <summary>
/// Access the IsTag parameter of the template.
/// </summary>
private bool IsTag
{
    get
    {
        return this._IsTagField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ComponentNameValueAcquired = false;
if (this.Session.ContainsKey("ComponentName"))
{
    this._ComponentNameField = ((string)(this.Session["ComponentName"]));
    ComponentNameValueAcquired = true;
}
if ((ComponentNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ComponentName");
    if ((data != null))
    {
        this._ComponentNameField = ((string)(data));
    }
}
bool ComponentIdValueAcquired = false;
if (this.Session.ContainsKey("ComponentId"))
{
    this._ComponentIdField = ((ushort)(this.Session["ComponentId"]));
    ComponentIdValueAcquired = true;
}
if ((ComponentIdValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ComponentId");
    if ((data != null))
    {
        this._ComponentIdField = ((ushort)(data));
    }
}
bool IsTagValueAcquired = false;
if (this.Session.ContainsKey("IsTag"))
{
    this._IsTagField = ((bool)(this.Session["IsTag"]));
    IsTagValueAcquired = true;
}
if ((IsTagValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("IsTag");
    if ((data != null))
    {
        this._IsTagField = ((bool)(data));
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
    public class SyncRemovedComponentSystemGeneratorBase
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