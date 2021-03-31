using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class UserData
    {
        public string Name { get; set; }
    }
}

@page "/counter"
@using System.Threading;

< h1 > Counter </ h1 >

< p > Current count: @currentCount </ p >
   

   < button class= "btn btn-primary" @onclick = "IncrementCount" > Click me </ button >
         < button class= "btn btn-secondary" @onclick = "AutoIncrement" > Auto Increment </ button >

               @code {
    private int currentCount = 0;

private void IncrementCount()
{
    currentCount++;
}

// UI가 갱신이 안될때.
void AutoIncrement()
{
    var timer = new Timer(x =>
    {
        InvokeAsync(() =>
        {
            IncrementCount();
            // 아래 함수를 이용해 수동으로 갱신한다
            StateHasChanged();
        });
    }, null, 1000, 1000);
}
}


@page "/user"
@using BlazorApp.Data;

< h3 > Online Users </ h3 >
   

   < p >
       Users: < b > @_users.Count() </ b >
   </ p >
   

   < br />
   

   < ul class= "list-group" >
        @foreach(UserData user in _users)
    {
        < li @key = "user" class= "list-group-item" >
   
               < button type = "button" class= "btn btn-link" @onclick = "(() => KickUser(user))" >[Kick] </ button >
       
                   < label > @user.Name </ label >
       
               </ li >
    }
</ ul >

< br />

< div class= "container" >
 
     < div class= "row" >
  
          < div class= "col" >
   
               < input class= "form-control" placeholder = "Add User" @bind - value = "_inputName" />
       
               </ div >
       
               < div class= "col" >
        
                    < !--속성(attribue)에도 binding을 할 수 있다.-->
            <!-- conditional attribute 속성 자체에도 조건을 붙일 수 있다.-->
            <button class= "@_btnClass" type = "button" @onclick = "AddUser" disabled = "@(_users.Count() >= 5)" > Add a User</button>
                 </div>
    </div>
</div>


         @code {


             List<UserData> _users = new List<UserData>();

string _inputName;
string _btnClass = "btn btn-primary";

protected override void OnInitialized()
{
    _users.Add(new UserData() { Name = "RooKiss" });
    _users.Add(new UserData() { Name = "Shung" });
    _users.Add(new UserData() { Name = "Faker" });
    RefreshButton();
}

void AddUser()
{
    _users.Add(new UserData() { Name = _inputName });
    _inputName = "";
    RefreshButton();
}

void KickUser(UserData user)
{
    _users.Remove(user);
    RefreshButton();
}

void RefreshButton()
{
    if (_users.Count() % 2 == 0)
        _btnClass = "btn btn-primary";
    else
        _btnClass = "btn btn-secondary";
}
}
