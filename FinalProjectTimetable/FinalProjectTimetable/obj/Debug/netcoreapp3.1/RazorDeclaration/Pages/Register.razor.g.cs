// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FinalProjectTimetable.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using FinalProjectTimetable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using FinalProjectTimetable.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\_Imports.razor"
using Telerik.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\Pages\Register.razor"
using FinalProjectTimetable.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\Pages\Register.razor"
using FinalProjectTimetable.Controllers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "H:\Work\FinalProjectTimetable\FinalProjectTimetable\FinalProjectTimetable\Pages\Register.razor"
       
    private RegisterModel model = new RegisterModel();
    private bool loading;
    private async void OnValidSubmit()
    {
        loading = true;
        try
        {
            var test = controller.Register(model);
            //AlertService.Success("Registration successful", keepAfterRouteChange: true);
            //NavigationManager.NavigateTo("account/login");
        }
        catch (Exception ex)
        {
            loading = false;
            StateHasChanged();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private LoginController controller { get; set; }
    }
}
#pragma warning restore 1591
