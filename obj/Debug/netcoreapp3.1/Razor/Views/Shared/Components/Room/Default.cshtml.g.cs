#pragma checksum "G:\Work\Almas\realtimeapp-back\Views\Shared\Components\Room\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39c6845bdf2a21d41ed5f4b2260468efc5e65aba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RealTimeApp.Shared.Components.Room.Views_Shared_Components_Room_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Room/Default.cshtml")]
namespace RealTimeApp.Shared.Components.Room
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
#line 2 "G:\Work\Almas\realtimeapp-back\Views\_ViewImports.cshtml"
using RealTimeApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39c6845bdf2a21d41ed5f4b2260468efc5e65aba", @"/Views/Shared/Components/Room/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90cb75c686d1818223ef4128a06a9dc6656796da", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Room_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Chat>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Work\Almas\realtimeapp-back\Views\Shared\Components\Room\Default.cshtml"
 foreach(var chat in Model){
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Chat>> Html { get; private set; }
    }
}
#pragma warning restore 1591