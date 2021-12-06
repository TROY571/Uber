// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace T1Driver.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using T1Driver;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\_Imports.razor"
using T1Driver.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\Pages\Login.razor"
using T1Driver.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\Pages\Login.razor"
using T1Driver.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\Pages\Login.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\Pages\Login.razor"
using T1Driver.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 28 "C:\Users\Lokkaze\Desktop\uni\SEP3\code\Tier1\T1Driver\T1Driver\Pages\Login.razor"
       
    private Driver CurrentUser;

    private string message;
    private string username;
    private string password;

    IUserServices client = new UserServices();
    
    private async Task PerformLogin()
    {
        message = "";
        try
        {
            ((UserAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
            message = "Login succeed!";
            Thread.Sleep(3000);
            NavigationManager.NavigateTo("/profile");
        }
        catch (Exception e)
        {
            message = "Username or password is incorrect!";
            Console.WriteLine(e);
        }        
    }
    
    private async Task PerformLogout()
    {
        message = "";
        username = "";
        password = "";
        try
        {
            ((UserAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            message = "Logout succeed!";
            Thread.Sleep(3000);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            message = e.Message;
        }
    }

    private async Task PerformRegister()
    {
        if (username == ""|| password == "")
        {
            message = "You should fill up username and password!";
        }
        else
        {
            client.Connect();
            Thread.Sleep(100);
            string response = client.Register(username, password);
            if(response.Equals("200"))
            {
                Console.WriteLine("Register was successful");
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
