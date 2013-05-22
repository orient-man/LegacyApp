# Testing and Refactoring Legacy Code

## Context

Imagine a social networking website for travellers

 * You need to be logged in to see the content
 * You need to be a friend to see someone else's trips

## Legacy Code Rules

 * You cannot change production code if not covered by tests
  - Just automated ("safe") refactorings (via IDE) are allowed,
    if needed to write the test

## Working with Legacy Code Tips

Start testing from shortest do deepest branch

 * because getting to deepest requires big setup i.e. sample data, mocks, fakes etc.)
 * allows to understand better what the code does

## Demo - HOWTO obtain the code

    git clone https://github.com/orient-man/LegacyApp.git
    cd LegacyApp
    git checkout 6c63c87

## Notes before 1st test

 * tip: split screen
 * `Install-Package nunit -ProjectName LegacyApp.Web.Tests`
 * snippets for test class / method
 * NCrunch / Resharper

## First test for shortest branch

 * Before: 6c63c87
 * ShouldThrowAnExceptionWhenNotLoggedIn
 * Ctrl-Shift-R / Ctrl-R Ctrl-M - Extract Method "GetLoggedInUser"
 * introducing a seam into the code (to avoid HttpContext)
 * code coverage shows if test covers the branch I wanted
 * refactoring test
 * After: a77bee4

## Next: "ShouldNotReturnAnyTripsWhenUsersAreNotFriends"

 * Before: a77bee4
 * After: 0f45a17

## Next: "ShouldReturnFriendTripsWhenUsersAreFriends"

 * Before: 0f45a17
 * PLEASE DO NOT COPY-AND-PASTE NEVER EVER
 * avoid going to database (TripDao)
 * another example of seam: escaping singleton, static calls and object creation
 * 100% coverage except seams (dependecies)
 * builders (when we need to build rich object graph)
 * After: 55b3bb3

## Refactoring begins

Starting from the deepest branch to the shortest (different than testing)

 * Before: 55b3bb3
 * method does too much (feature envy)
 * Single Responsibility Principle!
 * Tip for Mac keyboard: Alt+Insert == fn + alt/option + return
 * ShouldInformWhenUsersAre(Not)Friends
 * Resharper: Ctrl+Alt+F -> file structure
 * Resharper: Shift+Alt+Space -> Import symbol completion
 * stay green all the time!
 * Pit stop: b358d6c
 * bring variables together (near usage)
 * guard clause to the top
 * get rid of variables (if you can) -> they make for complexity
 * code should be read top-down
 * always baby steps - bit by bit
 * After: 9de60a2

## What if desing is wrong?

 * Before: 9de60a2
 * it has dependecy on web framework
 * static call (and dependency on data source)
 * Pit stop: 4288830
 * test for retrieving trips from in memory db
 * removing static method
 * interface segregation
 * service locator pattern and mocking dependecies
 * get rid of Testable... (ugly) - protected virtual methods only for tests
 * compare before and after - it could take 20 minutes (after some practice ;)
 * After: 9ee00ec

## Craftsmen at work

 * Write readable and maintainable code
  - code must express business rules
 * Strive for simplicity
 * Know your tools well (i.e. frameworks, editor)
 * Work in small and safe increments
  - commit often
 * Embrace change, be brave
 * Boy scout rule / No broken windows

# Links

 * [Working Effectively with Legacy Code](http://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052)
 * [Refactoring: Improving the Design of Existing Code](http://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672/)
 * [Original talk video (Java)](http://www.youtube.com/watch?v=_NnElPO5BU0)