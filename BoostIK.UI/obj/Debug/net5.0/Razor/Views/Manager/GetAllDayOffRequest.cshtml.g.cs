#pragma checksum "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8cdb0987cef66d920391fa12bd296d38e11cd52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_GetAllDayOffRequest), @"mvc.1.0.view", @"/Views/Manager/GetAllDayOffRequest.cshtml")]
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
#line 1 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\_ViewImports.cshtml"
using BoostIK.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\_ViewImports.cshtml"
using BoostIK.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\_ViewImports.cshtml"
using BoostIK.BLL.Models.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
using BoostIK.BLL.Models.VMs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
using BoostIK.CORE.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8cdb0987cef66d920391fa12bd296d38e11cd52", @"/Views/Manager/GetAllDayOffRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef7b13da569f30b32891b1a2cb6bfe30cb750611", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Manager_GetAllDayOffRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DayOffRequestVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-success waves-effect waves-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-danger waves-effect waves-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
  
    Layout = "~/Views/Shared/_ManagerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- Page-Title -->
<div class=""row"">
    <div class=""col-sm-12"">
        <div class=""page-title-box"">
            <div class=""row"">
                <div class=""col"">
                    <h4 class=""page-title"">İzin Talepleri</h4>
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8cdb0987cef66d920391fa12bd296d38e11cd526043", async() => {
                WriteLiteral("Anasayfa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                        <li class=""breadcrumb-item active"">İzin Talepleri</li>
                    </ol>
                </div><!--end col-->
            </div><!--end row-->
        </div><!--end page-title-box-->
    </div><!--end col-->
</div><!--end row-->
<!-- end page title end breadcrumb -->

<div class=""row"">
    <div class=""col"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered mb-0 table-centered"">
                        <thead>
                            <tr>
                                <th>Personel</th>
                                <th>İzin Tipi</th>
                                <th>Başlangıç</th>
                                <th>Bitiş</th>
                                <th>Gün Sayısı</th>
                                <th>Açıklama</th>
                                <th class=""text-center"">Talep Tarihi</th>
                         ");
            WriteLiteral("       <th class=\"text-center\">Durum</th>\r\n                                <th class=\"text-center\">İşlemler</th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    \r\n                                    <td>");
#nullable restore
#line 51 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                   Write(item.PersonelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 52 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                   Write(item.PermissionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 53 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                     if (item.RestType == RestType.Günlük)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 55 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                       Write(item.StartDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 56 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                       Write(item.EndDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 57 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>");
#nullable restore
#line 60 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                        Write(((DateTime)item.StartHour).ToString("dd-MM-yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 61 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                        Write(((DateTime)item.EndHour).ToString("dd-MM-yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <td>");
#nullable restore
#line 64 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                   Write(item.DayCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 65 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"text-center\">");
#nullable restore
#line 66 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                                       Write(item.CreationDate.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 67 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                     switch (item.State)
                                    {
                                        case RequestState.Bekliyor:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"text-center\"><span class=\"badge badge-warning\">Bekliyor</span></td>\r\n");
#nullable restore
#line 71 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                            break;
                                        case RequestState.Onaylandı:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"text-center\"><span class=\"badge badge-success\">Onaylandı</span></td>\r\n");
#nullable restore
#line 74 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                            break;
                                        case RequestState.Reddedildi:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"text-center\"><span class=\"badge badge-danger\">Reddedildi</span></td>\r\n");
#nullable restore
#line 77 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                            break;
                                        default:
                                            break;
                                    }                                   

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td class=\"text-center\">\r\n");
#nullable restore
#line 82 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                         if (item.State == RequestState.Bekliyor)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8cdb0987cef66d920391fa12bd296d38e11cd5215109", async() => {
                WriteLiteral("Onayla");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-izinId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                                                                                                                             WriteLiteral(item.DayOffRequestID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["izinId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-izinId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["izinId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8cdb0987cef66d920391fa12bd296d38e11cd5217736", async() => {
                WriteLiteral("Reddet");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-izinId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                                                                                                                            WriteLiteral(item.DayOffRequestID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["izinId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-izinId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["izinId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 86 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <p class=\"text-muted\">İşlem Yok</p>\r\n");
#nullable restore
#line 90 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 93 "C:\Users\BUGRA\Desktop\IKProje\IKProject\BoostIK.UI\Views\Manager\GetAllDayOffRequest.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table><!--end /table-->\r\n                </div><!--end /tableresponsive-->\r\n            </div><!--end card-body-->\r\n        </div><!--end card-->\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DayOffRequestVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
