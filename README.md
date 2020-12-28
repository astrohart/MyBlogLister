# `MyBlogLister` sample app

This app is developed to test how to separate concerns.  We want to rely on a trivial, `SqlLocalDb`-hosted, `.mdf`-file based, SQL Server database of `Blog`s and `Post`s to list my blogs and their posts, but we do not want to have to drag the `EntityFramework` library, as well as matching `App.config` files, around with us all over the place.

**Problem**: So often as is the case, when developing applications that perform data access with the `EntityFramework` ORM from Microsoft, it so often seems the case that all the projects up and down the ENTIRE stack must depend on the same NuGet package and App.config files.  Well, we say No!

So we are going to design layers:

![My Blog Lister.Design](MyBlogLister.Design.png)

The Presentation Layer will be a Console App that lists Blogs and Posts.  There will be two different data sources for our blogs and posts: (1) a `configuration.json` (JSON) file that sits in the same folder as the project's executable; and (2) a `.mdf`-based SQL Server database file that is accessed with Entity Framework.

This sample application is intended to be a purile, toy-model trivilization of a stack-based, N-tier, sophisticated application.  When sophisticated projects approach the level of having 100s of projects in one Visual Studio solution, adding the `EntityFramework` NuGet package and synchronizing `App.config` or `web.config` files cross the entire stack can get daunting.