#pragma checksum "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a830488d2a88a5da617d350eec753ea7c908202b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserInformation), @"mvc.1.0.view", @"/Views/Home/UserInformation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/UserInformation.cshtml", typeof(AspNetCore.Views_Home_UserInformation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a830488d2a88a5da617d350eec753ea7c908202b", @"/Views/Home/UserInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 48, true);
            WriteLiteral("<div class=\"starter-template\">\r\n    <h1>Welcome ");
            EndContext();
            BeginContext(49, 18, false);
#line 2 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml"
           Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(67, 63, true);
            WriteLiteral("</h1>\r\n    <p class=\"lead\">Here are your claims</p>\r\n    <ul>\r\n");
            EndContext();
#line 5 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml"
         foreach (var claim in User.Claims)
        {

#line default
#line hidden
            BeginContext(186, 38, true);
            WriteLiteral("            <li>\r\n                <em>");
            EndContext();
            BeginContext(225, 10, false);
#line 8 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml"
               Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(235, 7, true);
            WriteLiteral("</em>: ");
            EndContext();
            BeginContext(243, 11, false);
#line 8 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml"
                                 Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(254, 21, true);
            WriteLiteral("\r\n            </li>\r\n");
            EndContext();
#line 10 "D:\smartAngular6\LabSolution\VouchersAPI\VouchersAPI\Views\Home\UserInformation.cshtml"
        }

#line default
#line hidden
            BeginContext(286, 17, true);
            WriteLiteral("    </ul>\r\n</div>");
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
