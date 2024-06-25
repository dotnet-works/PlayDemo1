Feature: MultiDemo

A short summary of the feature

@nonweb
Scenario: Fail Scenario
	Given Some valid data 
	When some 'string' data
	When some '1' data
	When some another 1212323 data
	Then some another Helllllllo data
	When switch to tab having "Title1" as title
	When switch to tab having "1" as index
	When switch to tab having "1QWWEE4234" as index
	#When switch to tab having title as "Title1"
	#When switch to tab having index is 1
	Then Fail step
	

@nonweb
Scenario: Test Config Data
	When test project config data








#await Page.GotoAsync("https://demo.opensource-socialnetwork.org/");
#        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
#        await Page.GetByRole(AriaRole.Button, new() { Name = "?" }).ClickAsync();
#	//logout app
#	await Page.Locator("li.ossn-topbar-dropdown-menu").ClickAsync();
#        await Page.GetByRole(AriaRole.Link, new() { Name = "Log out" }).ClickAsync();
#	
#	//post a message
#	await Page.GetByPlaceholder("What's on your mind?").ClickAsync();
#        await Page.GetByPlaceholder("What's on your mind?").FillAsync("hello this text");
#        await Page.GetByPlaceholder("What's on your mind?").ClickAsync();
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Post" }).ClickAsync();
#	
#	//upload pic post
#	await Page.Locator("#ossn-wall-form div").Filter(new() { HasText = "Tag Friends Post Privacy" }).GetByRole(AriaRole.Listitem).Nth(2).ClickAsync();
#        await Page.Locator("input[name=\"ossn_photo\"]").ClickAsync();
#        await Page.Locator("input[name=\"ossn_photo\"]").SetInputFilesAsync(new[] { "Donald01.png" });
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Post" }).ClickAsync();
#	
#	//Invite a friend
#	await Page.Locator("li").Filter(new() { HasText = "Links" }).ClickAsync();
#        await Page.GetByRole(AriaRole.Link, new() { Name = "? Invite Friends" }).ClickAsync();
#        await Page.GetByPlaceholder("smith@example.com, john@").ClickAsync();
#        await Page.GetByPlaceholder("smith@example.com, john@").FillAsync("zumba1122@yopmail.com");
#        await Page.Locator("textarea[name=\"message\"]").ClickAsync();
#        await Page.Locator("textarea[name=\"message\"]").FillAsync("Sample invite message!!!!");
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Invite" }).ClickAsync();
	
#### Asana Test ##########

#        await Page.GotoAsync("https://app.asana.com/-/login");
#        await Page.GetByLabel("Email address").ClickAsync();
#        await Page.GetByLabel("Email address").FillAsync("herris@protonmail.com");
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true }).ClickAsync();
#        await Page.GetByLabel("Password", new() { Exact = true }).FillAsync("Test@1234");
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
#        await Page.GotoAsync("https://app.asana.com/0/home/1167266167931621");
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Projects" }).ClickAsync();
#        await Page.GetByRole(AriaRole.Button, new() { Name = "Projects" }).ClickAsync();
#        await Page.GetByLabel("User settings").ClickAsync();
#        await Page.GetByRole(AriaRole.Menuitemradio, new() { Name = "Log out" }).Locator("div").First.ClickAsync();

###### Open Source New User ###########
        # await Page.GotoAsync("https://demo.opensource-socialnetwork.org/");
        #await Page.GetByPlaceholder("First Name").ClickAsync();
        #await Page.GetByPlaceholder("First Name").FillAsync("firstname");
        #await Page.GetByPlaceholder("Last Name").ClickAsync();
        #await Page.GetByPlaceholder("Last Name").FillAsync("lastname");
        #await Page.GetByPlaceholder("Email", new() { Exact = true }).ClickAsync();
        #await Page.GetByPlaceholder("Email", new() { Exact = true }).FillAsync("wx1213@yopmail.com");
        #await Page.GetByPlaceholder("Re-enter Email").ClickAsync();
        #await Page.GetByPlaceholder("Email", new() { Exact = true }).ClickAsync();
        #await Page.GetByPlaceholder("Email", new() { Exact = true }).ClickAsync(new LocatorClickOptions
        #{
        #    ClickCount = 3,
        #});
        #await Page.GetByPlaceholder("Email", new() { Exact = true }).PressAsync("ControlOrMeta+c");
        #await Page.GetByPlaceholder("Re-enter Email").ClickAsync();
        #await Page.GetByPlaceholder("Re-enter Email").FillAsync("wx1213@yopmail.com");
        #await Page.GetByPlaceholder("Username").ClickAsync();
        #await Page.GetByPlaceholder("Username").FillAsync("wxusername");
        #await Page.GetByPlaceholder("Password").ClickAsync();
        #await Page.GetByPlaceholder("Password").FillAsync("Test@1234");
        #await Page.GetByPlaceholder("Username").ClickAsync(new LocatorClickOptions
        #{
        #    ClickCount = 8,
        #});
        #await Page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Male$") }).GetByRole(AriaRole.Radio).CheckAsync();
        #await Page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Female$") }).GetByRole(AriaRole.Radio).CheckAsync();
        #await Page.GetByRole(AriaRole.Checkbox).CheckAsync();
        #await Page.GetByRole(AriaRole.Button, new() { Name = "Create an account" }).ClickAsync();
        #await Page.GetByPlaceholder("Birthdate").ClickAsync();
        #await Page.GetByRole(AriaRole.Link, new() { Name = "1", Exact = true }).ClickAsync();
        #await Page.GetByRole(AriaRole.Button, new() { Name = "Create an account" }).ClickAsync();
        #await Page.GetByText("It's free and always will be.").ClickAsync();










