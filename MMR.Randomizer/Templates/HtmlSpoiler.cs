﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace MMR.Randomizer.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using MMR.Randomizer.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class HtmlSpoiler : HtmlSpoilerBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"<html>
<head>
<style>
    body.dark-mode {
      background-color: #111;
      color: #ccc;
    }
    body.dark-mode a {
      color: #111;
    }
    body.dark-mode button {
      background-color: #ddd;
      color: #111;
    }

    body.light-mode {
      background-color: #eee;
      color: #111;
    }
    body.light-mode a {
      color: #111;
    }
    body.light-mode button {
      background-color: #111;
      color: #ccc;
    }

    th{ text-align:left }
    .region { text-align: center; font-weight: bold; }
    [data-content]:before { content: attr(data-content); }

	.dark-mode .spoiler{ background-color:#ccc }
	.dark-mode .spoiler:hover { background-color: #111;  }
	.dark-mode .show-highlight .unavailable .newlocation { background-color: #500705; }
	.dark-mode .show-highlight .acquired .newlocation { background-color: #69591f; }
	.dark-mode .show-highlight .available .newlocation { background-color: #313776; }

	.light-mode .spoiler{ background-color:#111 }
	.light-mode .spoiler:hover { background-color: #ccc;  }
	.light-mode .show-highlight .unavailable .newlocation { background-color: #FF9999; }
	.light-mode .show-highlight .acquired .newlocation { background-color: #99FF99; }
	.light-mode .show-highlight .available .newlocation { background-color: #9999FF; }


    #spoilerLogState { width: 560px; }
</style>
</head>
<body class=""light-mode"">
<label><b>Version: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.Version));
            this.Write("</span><br/>\r\n<label><b>Settings String: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.SettingsString));
            this.Write("</span><br/>\r\n<label><b>Seed: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.Seed));
            this.Write("</span><br/>\r\n");
 if (spoiler.CustomItemListString != null) { 
            this.Write("<label><b>Custom Item List: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.CustomItemListString));
            this.Write("</span><br/>\r\n");
 } 
 if (spoiler.CustomStartingItemListString != null) { 
            this.Write("<label><b>Custom Starting Item List: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.CustomStartingItemListString));
            this.Write("</span><br/>\r\n");
 } 
 if (spoiler.CustomJunkLocationsString != null) { 
            this.Write("<label><b>Enforce Junk Locations List: </b></label><span>");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.CustomJunkLocationsString));
            this.Write("</span><br/>\r\n");
 } 
            this.Write("<br/>\r\n<button type=\"button\" onclick=\"toggleDarkLight()\" title=\"Toggle dark/light" +
                    " mode\">Toggle Dark Theme</button>\r\n<br/>\r\n<br/>\r\n<label><b>Spoiler Log State: </" +
                    "b></label><input id=\"spoilerLogState\" type=\"text\"/><br/>\r\n");
 if (spoiler.RandomizeDungeonEntrances) { 

            this.Write("<h2>Dungeon Entrance Replacements</h2>\r\n<table border=\"1\" class=\"item-replacement" +
                    "s\">\r\n\t<tr>\r\n\t\t<th>Entrance</th>\r\n\t    <th></th>\r\n\t\t<th>New Destination</th>\r\n\t</" +
                    "tr>\r\n");
		 for (int i = 0; i < 4; i++) {
            var entrance = spoiler.Entrances[i];
            var destination = spoiler.Entrances[spoiler.NewDestinationIndices[i]];
            this.Write("\t<tr data-id=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture((int)destination));
            this.Write("\" data-newlocationid=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture((int)destination));
            this.Write("\" class=\"unavailable\">\r\n\t\t<td class=\"newlocation\">");
            this.Write(this.ToStringHelper.ToStringWithCulture(entrance.Entrance()));
            this.Write("</td>\r\n\t    <td><input type=\"checkbox\"/></td>\r\n\t\t<td class=\"spoiler itemname\"><sp" +
                    "an data-content=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(destination.Entrance()));
            this.Write("\"></span></td>\r\n\t</tr>\r\n");
 } 
            this.Write("</table>\r\n");
 } 
            this.Write("<h2>Item Replacements</h2>\r\n<input type=\"checkbox\" id=\"highlight-checks\"/> Highli" +
                    "ght available checks\r\n<table border=\"1\" class=\"item-replacements\">\r\n <tr>\r\n     " +
                    "<th>Location</th>\r\n\t <th></th>\r\n     <th></th>\r\n </tr>\r\n");
 foreach (var region in spoiler.ItemList.GroupBy(item => item.Region).OrderBy(g => g.Key)) {

            this.Write(" <tr class=\"region\"><td colspan=\"3\">");
            this.Write(this.ToStringHelper.ToStringWithCulture(region.Key.Name()));
            this.Write("</td></tr>\r\n ");
 foreach (var item in region.OrderBy(item => item.NewLocationName)) { 
            this.Write(" <tr data-id=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Id));
            this.Write("\" data-newlocationid=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.NewLocationId));
            this.Write("\" class=\"unavailable\">\r\n\t<td class=\"newlocation\">");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.NewLocationName));
            this.Write("</td>\r\n\t<td><input type=\"checkbox\"/></td>\r\n\t<td class=\"spoiler itemname\"> <span d" +
                    "ata-content=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Name));
            this.Write("\"></span></td>\r\n </tr>\r\n ");
 } 
 } 
            this.Write("</table>\r\n<h2>Item Locations</h2>\r\n<table border=\"1\" id=\"item-locations\">\r\n <tr>\r" +
                    "\n     <th>Item</th>\r\n\t <th></th>\r\n     <th>Location</th>\r\n </tr>\r\n");
 foreach (var item in spoiler.ItemList.Where(item => !item.IsJunk)) {

            this.Write(" <tr data-id=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Id));
            this.Write("\" data-newlocationid=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.NewLocationId));
            this.Write("\">\r\n\t<td>");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Name));
            this.Write("</td>\r\n\t<td><input type=\"checkbox\"/></td>\r\n\t<td class=\"spoiler newlocation\"> <spa" +
                    "n data-content=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(item.NewLocationName));
            this.Write("\"></span></td>\r\n </tr>\r\n");
 } 
            this.Write("</table>\r\n");
 if (spoiler.GossipHints != null && spoiler.GossipHints.Any()) { 

            this.Write("<h2>Gossip Stone Hints</h2>\r\n<table border=\"1\">\r\n\t<tr>\r\n\t\t<th>Gossip Stone</th>\r\n" +
                    "\t\t<th>Message</th>\r\n\t</tr>\r\n");
	foreach (var hint in spoiler.GossipHints.OrderBy(h => h.Key.ToString())) { 

            this.Write("\t<tr>\r\n\t\t<td>");
            this.Write(this.ToStringHelper.ToStringWithCulture(hint.Key));
            this.Write("</td>\r\n\t\t<td class=\"spoiler\"><span data-content=\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(hint.Value));
            this.Write("\"></span></td>\r\n\t</tr>\r\n");
 } 
            this.Write("</table>\r\n");
 } 
            this.Write("<script>\r\n\tfunction all(list, predicate) {\r\n\t\tfor (var i = 0; i < list.length; i+" +
                    "+) {\r\n\t\t\tif (!predicate(list[i])) {\r\n\t\t\t\treturn false;\r\n\t\t\t}\r\n\t\t}\r\n\t\treturn true" +
                    ";\r\n\t}\r\n\r\n\tfunction any(list, predicate) {\r\n\t\tfor (var i = 0; i < list.length; i+" +
                    "+) {\r\n\t\t\tif (predicate(list[i])) {\r\n\t\t\t\treturn true;\r\n\t\t\t}\r\n\t\t}\r\n\t\treturn false;" +
                    "\r\n\t}\r\n    \r\n    var segmentSize = 16;\r\n    function saveItems() {\r\n        var s" +
                    "egments = [];\r\n        for (var i = 0; i < logic.length; i++) {\r\n            var" +
                    " segmentIndex = parseInt(i / segmentSize);\r\n            segments[segmentIndex] =" +
                    " segments[segmentIndex] || 0;\r\n            if (logic[i].Checked) {\r\n            " +
                    "    segments[parseInt(i / segmentSize)] += (1 << (i%segmentSize));\r\n            " +
                    "}\r\n        }\r\n        var saveString = segments.map(function(s) {\r\n            r" +
                    "eturn s.toString(16);\r\n        }).join(\"-\");\r\n        var saveInput = document.q" +
                    "uerySelector(\"#spoilerLogState\");\r\n        saveInput.value = saveString;\r\n    }\r" +
                    "\n\r\n    function loadItems() {\r\n        var saveInput = document.querySelector(\"#" +
                    "spoilerLogState\");\r\n        var segments = saveInput.value.split(\"-\");\r\n        " +
                    "if (Math.ceil((logic.length - 1) / segmentSize) !== segments.length) {\r\n        " +
                    "    alert(\"Invalid Spoiler Log state\");\r\n            return;\r\n        }\r\n       " +
                    " segments = segments.map(function(segment) {\r\n            return parseInt(segmen" +
                    "t, 16);\r\n        });\r\n        for (var i = 0; i < segments.length; i++) {\r\n     " +
                    "       var segment = segments[i];\r\n            for (var j = 0; j < segmentSize; " +
                    "j++) {\r\n                var itemIndex = segmentSize * i + j;\r\n                if" +
                    " (itemIndex < logic.length) {\r\n                    var mark = ((segment >> j) % " +
                    "2 == 1);\r\n                    logic[itemIndex].Checked = mark;\r\n                " +
                    "    var itemRow = document.querySelector(\"tr[data-newlocationid=\'\" + itemIndex +" +
                    " \"\']\");\r\n                    if (itemRow) {\r\n\t                    logic[itemRow." +
                    "dataset.id].Acquired = mark;\r\n                    } else {\r\n\t                   " +
                    " logic[itemIndex].Acquired = mark;\r\n                    }\r\n                }\r\n  " +
                    "          }\r\n        }\r\n\t\trecalculateItems();\r\n    }\r\n\r\n    document.querySelect" +
                    "or(\"#spoilerLogState\").addEventListener(\"keypress\", function(event) {\r\n        i" +
                    "f (event.keyCode === 13) {\r\n            loadItems();\r\n        }\r\n    });\r\n\r\n\tfun" +
                    "ction recalculateItems() {\r\n\t\tvar recalculate = false;\r\n\t\tfor (var i = 0; i < lo" +
                    "gic.length; i++) {\r\n\t\t\tvar item = logic[i];\r\n\t\t\titem.IsAvailable = \r\n\t\t\t\t(item.R" +
                    "equiredItemIds === null || all(item.RequiredItemIds, function(id) { return logic" +
                    "[id].Acquired; }))\r\n\t\t\t\t&& \r\n\t\t\t\t(item.ConditionalItemIds === null || any(item.C" +
                    "onditionalItemIds, function(conditionals) { return all(conditionals, function(id" +
                    ") { return logic[id].Acquired; }); }));\r\n            \r\n\t\t\tif (!item.Acquired && " +
                    "item.IsFakeItem && item.IsAvailable) {\r\n\t\t\t\titem.Acquired = true;\r\n\t\t\t\trecalcula" +
                    "te = true;\r\n\t\t\t}\r\n\t\t\tif (item.Acquired && item.IsFakeItem && !item.IsAvailable) " +
                    "{\r\n\t\t\t\titem.Acquired = false;\r\n\t\t\t\trecalculate = true;\r\n\t\t\t}\r\n        \r\n\t\t\tvar l" +
                    "ocationRow = document.querySelector(\".item-replacements tr[data-newlocationid=\'\"" +
                    " + i + \"\']\");\r\n\t\t\tif (locationRow) {\r\n\t\t\t\tlocationRow.className = \"\";\r\n\t\t\t\tlocat" +
                    "ionRow.classList.add(item.IsAvailable ? \"available\" : \"unavailable\");\r\n\t\t\t\tvar i" +
                    "temName = locationRow.querySelector(\".itemname\");\r\n                var checkbox " +
                    "= locationRow.querySelector(\"input\");\r\n                checkbox.checked = item.C" +
                    "hecked;\r\n\t\t\t\tif (item.Checked) {\r\n\t\t\t\t\titemName.classList.remove(\"spoiler\");\r\n\t\t" +
                    "\t\t} else {\r\n\t\t\t\t\titemName.classList.add(\"spoiler\");\r\n\t\t\t\t}\r\n\t\t\t}\r\n        \r\n\t\t\tv" +
                    "ar itemRow = document.querySelector(\"#item-locations tr[data-id=\'\" + i + \"\']\");\r" +
                    "\n\t\t\tif (itemRow) {\r\n\t\t\t\tvar itemName = itemRow.querySelector(\".newlocation\");\r\n " +
                    "               var checkbox = itemRow.querySelector(\"input\");\r\n                c" +
                    "heckbox.checked = item.Acquired;\r\n\t\t\t\tif (item.Acquired) {\r\n\t\t\t\t\titemName.classL" +
                    "ist.remove(\"spoiler\");\r\n\t\t\t\t} else {\r\n\t\t\t\t\titemName.classList.add(\"spoiler\");\r\n\t" +
                    "\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t\tif (recalculate) {\r\n\t\t\trecalculateItems();\r\n\t\t} else {\r\n     " +
                    "       saveItems();\r\n        }\r\n\t}\r\n\r\n    var logic = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(spoiler.LogicJson));
            this.Write(";\r\n\r\n    for (var i = 0; i < logic.length; i++) {\r\n        var item = logic[i];\r\n" +
                    "        if (item.Acquired) {\r\n            item.Checked = true;\r\n\t        documen" +
                    "t.querySelector(\"tr[data-newlocationid=\'\" + i + \"\'] input\").checked = true;\r\n   " +
                    "     }\r\n    }\r\n\r\n    var startingLocations = [0, 94, 274, 275, 276, 277];\r\n    f" +
                    "or (var id of startingLocations) {\r\n\t    logic[id].Checked = true;\r\n\t    logic[d" +
                    "ocument.querySelector(\"tr[data-newlocationid=\'\" + id + \"\']\").dataset.id].Acquire" +
                    "d = true;\r\n\t    document.querySelector(\"tr[data-newlocationid=\'\" + id + \"\'] inpu" +
                    "t\").checked = true;\r\n    }\r\n\r\n\trecalculateItems();\r\n\r\n\tvar rows = document.query" +
                    "SelectorAll(\"tr\");\r\n\tfor (var i = 1; i < rows.length; i++) {\r\n\t\tvar row = rows[i" +
                    "];\r\n\t\tvar checkbox = row.querySelector(\"input\");\r\n\t\tif (checkbox) {\r\n\t\t\tcheckbox" +
                    ".addEventListener(\"click\", function(e) {\r\n\t\t\t\tvar row = e.target.closest(\"tr\");\r" +
                    "\n                var rowId = parseInt(row.dataset.id);\r\n\t\t\t\tvar newLocationId = " +
                    "parseInt(row.dataset.newlocationid);\r\n\t\t\t\tlogic[newLocationId].Checked = e.targe" +
                    "t.checked;\r\n                logic[rowId].Acquired = e.target.checked;\r\n\t\t\t\trecal" +
                    "culateItems();\r\n\t\t\t});\r\n\t\t}\r\n\t}\r\n\r\n\tdocument.querySelector(\"#highlight-checks\")." +
                    "addEventListener(\"click\", function(e) {\r\n        var tables = document.querySele" +
                    "ctorAll(\"table.item-replacements\");\r\n        for (var i = 0; i < tables.length; " +
                    "i++) {\r\n            if (e.target.checked) {\r\n                tables[i].classList" +
                    ".add(\"show-highlight\");\r\n            } else {\r\n                tables[i].classLi" +
                    "st.remove(\"show-highlight\");\r\n            }\r\n        }\r\n\t});\r\n\r\n    function tog" +
                    "gleDarkLight() {\r\n\t    var body = document.getElementsByTagName(\'body\')[0];\r\n\t  " +
                    "  var currentClassBody = body.className;\r\n\t    body.className = currentClassBody" +
                    " === \"dark-mode\" ? \"light-mode\" : \"dark-mode\";\r\n    }\r\n</script>\r\n</body>\r\n</htm" +
                    "l>");
            return this.GenerationEnvironment.ToString();
        }
    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class HtmlSpoilerBase
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
