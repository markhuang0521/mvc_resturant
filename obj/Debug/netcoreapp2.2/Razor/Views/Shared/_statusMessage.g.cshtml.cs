#pragma checksum "C:\Users\mark\Documents\revature\Resturant\Views\Shared\_statusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "320427298f461bc8fa214d0d1cd6161a718dd24f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__statusMessage), @"mvc.1.0.view", @"/Views/Shared/_statusMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_statusMessage.cshtml", typeof(AspNetCore.Views_Shared__statusMessage))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\mark\Documents\revature\Resturant\Views\_ViewImports.cshtml"
using Resturant;

#line default
#line hidden
#line 2 "C:\Users\mark\Documents\revature\Resturant\Views\_ViewImports.cshtml"
using Resturant.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"320427298f461bc8fa214d0d1cd6161a718dd24f", @"/Views/Shared/_statusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"765c8df35a572ef43d98f276ec7529e0ea866496", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__statusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(17, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\mark\Documents\revature\Resturant\Views\Shared\_statusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";

#line default
#line hidden
            BeginContext(138, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 146, "\"", 203, 4);
            WriteAttributeValue("", 154, "alert", 154, 5, true);
            WriteAttributeValue(" ", 159, "alert-", 160, 7, true);
#line 7 "C:\Users\mark\Documents\revature\Resturant\Views\Shared\_statusMessage.cshtml"
WriteAttributeValue("", 166, statusMessageClass, 166, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 185, "alert-dismissible", 186, 18, true);
            EndWriteAttribute();
            BeginContext(204, 158, true);
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n        ");
            EndContext();
            BeginContext(363, 5, false);
#line 9 "C:\Users\mark\Documents\revature\Resturant\Views\Shared\_statusMessage.cshtml"
   Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(368, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 11 "C:\Users\mark\Documents\revature\Resturant\Views\Shared\_statusMessage.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
