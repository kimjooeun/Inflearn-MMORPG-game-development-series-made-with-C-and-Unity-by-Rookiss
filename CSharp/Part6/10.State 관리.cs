using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class CounterState
    {
        int _count = 0;

        public Action OnStateChanged;

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
                Refresh();
            }
        }

        void Refresh()
        {
            OnStateChanged?.Invoke();
        }
    }
}


@page "/counter"
@inject BlazorApp.Data.CounterState CounterState
<h1> Counter</h1>

<p>Current count: @CounterState.Count</p>

<button class= "btn btn-primary" @onclick = "IncrementCount" > Click me </ button >

     @code {

    private void IncrementCount()
    {
        CounterState.Count = CounterState.Count + 1;
    }
}


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
