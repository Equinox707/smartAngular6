#pragma checksum "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "120c05417c067bf327fdb5de97a165737ccc7d84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"120c05417c067bf327fdb5de97a165737ccc7d84", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 27, true);
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n");
            EndContext();
#line 3 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(75, 18, true);
            WriteLiteral("        <h1>Hello ");
            EndContext();
            BeginContext(94, 18, false);
#line 5 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\Index.cshtml"
             Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(112, 8, true);
            WriteLiteral("!</h1>\r\n");
            EndContext();
#line 6 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(144, 31, true);
            WriteLiteral("        <h1>Hello World!</h1>\r\n");
            EndContext();
#line 10 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(182, 577, true);
            WriteLiteral(@"    <p class=""lead"">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
</div>

<div class=""row"">
    <div class=""col-lg-6"">
        <h4>Subheading</h4>
        <p>Donec id elit non mi porta gravida at eget metus. Maecenas faucibus mollis interdum.</p>
    </div>

    <div class=""col-lg-6"">
        <h4>Subheading</h4>
        <p>Donec id elit non mi porta gravida at eget metus. Maecenas faucibus mollis interdum.</p>
    </div>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
