
var func = (function() {

    window.testFunction = {
        helloWorld: function() {
    return alert('Hello World');
},
        inputName: function(text) {
    return prompt(text, 'Input Name');
}
    };

});

func();

@page "/"
@namespace BlazorApp.Pages
@addTagHelper*, Microsoft.AspNetCore.Mvc.TagHelpers
@{
    Layout = null;
}

< !DOCTYPE html >
 < html lang = "en" >
  < head >
  
      < meta charset = "utf-8" />
   
       < meta name = "viewport" content = "width=device-width, initial-scale=1.0" />
      
          < title > BlazorApp </ title >
      
          < base href = "~/" />
       
           < link rel = "stylesheet" href = "css/bootstrap/bootstrap.min.css" />
          
              < link href = "css/site.css" rel = "stylesheet" />
             </ head >
             < body >
             
                 < app >
             
                     < component type = "typeof(App)" render - mode = "ServerPrerendered" />
                
                    </ app >
                

                    < div id = "blazor-error-ui" >
                 
                         < environment include = "Staging,Production" >
                              An error has occurred. This application may no longer respond until reloaded.
        </environment>
        <environment include="Development">
            An unhandled exception has occurred. See browser dev tools for details.
        </environment>
        <a href="" class= "reload" > Reload </ a >
        < a class= "dismiss" >🗙</ a >
   
       </ div >
   

       < script src = "_framework/blazor.server.js" ></ script >
    
        < script src = "test.js" ></ script >
     </ body >
     </ html >




     @inject BlazorApp.Data.CounterState CounterState
@implements IDisposable

<div class= "top-row pl-4 navbar navbar-dark" >
    < a class= "navbar-brand" href = "" > BlazorApp </ a >
  
      < button class= "navbar-toggler" @onclick = "ToggleNavMenu" >
    
            < span class= "navbar-toggler-icon" ></ span >
     
         </ button >
     </ div >
     

     < div class= "@NavMenuCssClass" @onclick = "ToggleNavMenu" >
       
           < ul class= "nav flex-column" >
        
                < li class= "nav-item px-3" >
         
                     < NavLink class= "nav-link" href = "" Match = "NavLinkMatch.All" >
             
                             < span class= "oi oi-home" aria - hidden = "true" ></ span > Home
                           </ NavLink >
               
                       </ li >
               
                       < li class= "nav-item px-3" >
                
                            < NavLink class= "nav-link" href = "counter" >
                  
                                  < span class= "oi oi-plus" aria - hidden = "true" ></ span > Counter
                                </ NavLink >
                    
                            </ li >
                    
                            < li class= "nav-item px-3" >
                     
                                 < NavLink class= "nav-link" href = "fetchdata" >
                       
                                       < span class= "oi oi-list-rich" aria - hidden = "true" ></ span > Fetch data
                                            </ NavLink >
                                
                                        </ li >
                                
                                        < li class= "nav-item px-3" >
                                 
                                             < NavLink class= "nav-link" href = "JSInterop" >
                                   
                                                   < span class= "oi oi-list-rich" aria - hidden = "true" ></ span > JSInterop
                                                 </ NavLink >
                                     
                                             </ li >
                                     
                                         </ ul >
                                     </ div >
                                     

                                     < div >
                                     
                                         < p style = "color:white" > Counter : @CounterState.Count </ p >
                                          </ div >

                                          @code {
    private bool collapseNavMenu = true;

private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

private void ToggleNavMenu()
{
    collapseNavMenu = !collapseNavMenu;
}

protected override void OnInitialized()
{
    CounterState.OnStateChanged += onStateChanged;
}

void onStateChanged()
{
    this.StateHasChanged();
}

void IDisposable.Dispose()
{
    CounterState.OnStateChanged -= onStateChanged;
}
}


@page "/JSInterop"
@inject IJSRuntime JSRuntime

<h3>JSInterop</h3>

<div>
    <button type="button" class= "btn btn-primary" @onclick = "HelloWorld" >
         Hello World
     </ button >
 </ div >
 

 < br />
 

 < div >
 
     < button type = "button" class= "btn btn-primary" @onclick = "InputName" >
             Input Name
         </ button >
     
         < p > @_name </ p >
     </ div >

     @code {
    string _name = "";

    public async void HelloWorld()
    {
        await JSRuntime.InvokeVoidAsync("testFunction.helloWorld", null);
    }

    public async void InputName()
    {
        _name = await JSRuntime.InvokeAsync<string>("testFunction.inputName", "Input Name");
        StateHasChanged();
    }
}
