@using BlazorApp.Data;

<p>
    Users: <b>@Users.Count()</b>
</p>

<br />

<ul class="list-group">
    @foreach (UserData user in Users)
    {
        <li @key="user" class="list-group-item">
            <button type="button" class="btn btn-link" @onclick="(() => KickUser(user))">[Kick]</button>
            <label>@user.Name</label>
        </li>
    }
</ul>

@code {

    [Parameter]
    public List<UserData> Users { get; set; }

    [Parameter]
    public EventCallback CallbackTest { get; set; }

    protected override void OnInitialized()
    {
        Users.Add(new UserData() { Name = "RooKiss" });
        Users.Add(new UserData() { Name = "Shung" });
        Users.Add(new UserData() { Name = "Faker" });
    }

    public void AddUser(UserData user)
    {
        Users.Add(user);
    }

    public void KickUser(UserData user)
    {
        Users.Remove(user);
        CallbackTest.InvokeAsync(null);
    }
}


@page "/user"
@using BlazorApp.Data;

<h3>Online Users</h3>

<ShowUser Users="_users" CallbackTest="CallbackTestFunc" @ref="_showUser"></ShowUser>

<br />

<div class="container">
    <div class="row">
        <div class="col">
            <input class="form-control" placeholder="Add User" @bind-value="_inputName" />
        </div>
        <div class="col">
            <!-- 속성(attribue)에도 binding을 할 수 있다.-->
            <!-- conditional attribute 속성 자체에도 조건을 붙일 수 있다.-->
            <button class="btn btn-primary" type="button" @onclick="AddUser" disabled="@(_users.Count() >= 5)">Add a User</button>
        </div>
    </div>
</div>

@code {

    List<UserData> _users = new List<UserData>();
    ShowUser _showUser;

    string _inputName;

    void AddUser()
    {
        _showUser.AddUser(new UserData() { Name = _inputName });
        _inputName = "";
    }

    void KickUser(UserData user)
    {
        _users.Remove(user);
    }

    void CallbackTestFunc()
    {
        _inputName = "CallbackTest";
        StateHasChanged();
    }
}