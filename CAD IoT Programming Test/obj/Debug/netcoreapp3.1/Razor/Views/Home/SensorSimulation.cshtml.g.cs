#pragma checksum "C:\Users\erick\source\repos\CAD IoT Programming Test\CAD IoT Programming Test\Views\Home\SensorSimulation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d138c2afc60f82c542c1e0fff413f1002a4572d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SensorSimulation), @"mvc.1.0.view", @"/Views/Home/SensorSimulation.cshtml")]
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
#line 1 "C:\Users\erick\source\repos\CAD IoT Programming Test\CAD IoT Programming Test\Views\_ViewImports.cshtml"
using CAD_IoT_Programming_Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\erick\source\repos\CAD IoT Programming Test\CAD IoT Programming Test\Views\_ViewImports.cshtml"
using CAD_IoT_Programming_Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d138c2afc60f82c542c1e0fff413f1002a4572d", @"/Views/Home/SensorSimulation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"258d66312cb5fe67101252364cb0a7b37f5d8302", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SensorSimulation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/site.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12 text-right"">
            <button type=""button"" id=""buttonToggle"" class=""btn btn-success"" onclick=""changeColor('buttonToggle')"">Start</button>
        </div>
    </div>
</div>

<div class=""container"">
    <h2>Room Area 1</h2>
</div>
<div class=""container"">
    <div class=""row"">
        <div class=""col col-5"">
            <h2>Temperature</h2>
            <canvas id=""Room1T"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxT1"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minT1"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medT1"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgT1"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""c");
            WriteLiteral(@"ol-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Median</div>
                <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </div>
        <span class=""border""></span>
        <div class=""col col-5"">
            <h2>Humidity</h2>
            <canvas id=""Room1H"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxH1"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minH1"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medH1"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgH1"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""col-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Medi");
            WriteLiteral(@"an</div>
                <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </div>
    </div>
</div>

<div class=""container"">
    <h2>Room Area 2</h2>
</div>
<div class=""container"">
    <div class=""row"">
        <div class=""col col-5"">
            <h2>Temperature</h2>
            <canvas id=""Room2T"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxT2"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minT2"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medT2"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgT2"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""col-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Median</div>
 ");
            WriteLiteral(@"               <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </div>
        <span class=""border""></span>
        <div class=""col col-5"">
            <h2>Humidity</h2>
            <canvas id=""Room2H"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxH2"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minH2"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medH2"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgH2"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""col-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Median</div>
                <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </");
            WriteLiteral(@"div>
    </div>
</div>
<div class=""container"">
    <h2>Room Area 3</h2>
</div>
<div class=""container"">
    <div class=""row"">
        <div class=""col col-5"">
            <h2>Temperature</h2>
            <canvas id=""Room3T"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxT3"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minT3"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medT3"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgT3"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""col-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Median</div>
                <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </div>
       ");
            WriteLiteral(@" <span class=""border""></span>
        <div class=""col col-5"">
            <h2>Humidity</h2>
            <canvas id=""Room3H"" width=""200"" height=""200""></canvas>
            <div class=""row"">
                <div class=""col-3 h2 bg-danger"" align=""center"" id=""maxH3"">N/A</div>
                <div class=""col-3 h2 bg-info"" align=""center"" id=""minH3"">N/A</div>
                <div class=""col-3 h2 bg-warning"" align=""center"" id=""medH3"">N/A</div>
                <div class=""col-3 h2 bg-success"" align=""center"" id=""avgH3"">N/A</div>
            </div>
            <div class=""row"">
                <div class=""col-3 bg-danger"" align=""center"">Max</div>
                <div class=""col-3 bg-info"" align=""center"">Min</div>
                <div class=""col-3 bg-warning"" align=""center"">Median</div>
                <div class=""col-3 bg-success"" align=""center"">Average</div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d138c2afc60f82c542c1e0fff413f1002a4572d10235", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 136 "C:\Users\erick\source\repos\CAD IoT Programming Test\CAD IoT Programming Test\Views\Home\SensorSimulation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
