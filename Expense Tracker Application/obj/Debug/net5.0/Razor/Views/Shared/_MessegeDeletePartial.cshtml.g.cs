#pragma checksum "D:\Document Data\Github\Expense-Tracker-Application\Expense Tracker Application\Views\Shared\_MessegeDeletePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccc5c8009474a7dea721f4c3d01c8f6429ce9391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MessegeDeletePartial), @"mvc.1.0.view", @"/Views/Shared/_MessegeDeletePartial.cshtml")]
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
#nullable restore
#line 2 "D:\Document Data\Github\Expense-Tracker-Application\Expense Tracker Application\Views\_ViewImports.cshtml"
using Expense_Tracker_Application.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc5c8009474a7dea721f4c3d01c8f6429ce9391", @"/Views/Shared/_MessegeDeletePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a7040f5134a43859970b0c92eb9ea68585907b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MessegeDeletePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<bool?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Document Data\Github\Expense-Tracker-Application\Expense Tracker Application\Views\Shared\_MessegeDeletePartial.cshtml"
 if (Model.Value)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""alert alert-success alert-dismissible fade show"" role=""alert"">
    <strong>Expense Category Deleted Successfully !!</strong> To Check Expense Category you have deleted, Click the button below ""back to the Index"".
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>
");
#nullable restore
#line 8 "D:\Document Data\Github\Expense-Tracker-Application\Expense Tracker Application\Views\Shared\_MessegeDeletePartial.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
    <strong>Failed!</strong> You Cann't Delete the Branch because it relatated to Employees.
    <button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>
</div>
");
#nullable restore
#line 15 "D:\Document Data\Github\Expense-Tracker-Application\Expense Tracker Application\Views\Shared\_MessegeDeletePartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<bool?> Html { get; private set; }
    }
}
#pragma warning restore 1591
