# aspnetcore-routing-experiment
This started as an experiment to see if/how ASP.NET Core could route a request to a specific controller method based on whether or not a URI query parameter was used.

Turns out, you _can_ do this; it's just a little messy.  The trick is to use `IActionConstraint`.  See `Stuff/RequiredFromQueryAttribute.cs`.
