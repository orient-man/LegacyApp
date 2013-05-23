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
    git checkout b50ad0d

## Notes before 1st test

 * tip: split screen
 * `Install-Package nunit -ProjectName LegacyApp.Web.Tests`
 * snippets for test class / method
 * NCrunch / Resharper

## First test for shortest branch

 * Before: b50ad0d
 * ShouldThrowAnExceptionWhenNotLoggedIn
 * Ctrl-Shift-R / Ctrl-R Ctrl-M - Extract Method "GetLoggedInUser"
 * introducing a seam into the code (to avoid HttpContext)
 * code coverage shows if test covers the branch I wanted
 * refactoring test
 * After: 62af89f

## Next: "ShouldNotReturnAnyTripsWhenUsersAreNotFriends"

 * Before: 62af89f
 * After: 21b7618

## Next: "ShouldReturnFriendTripsWhenUsersAreFriends"

 * Before: 21b7618
 * PLEASE DO NOT COPY-AND-PASTE NEVER EVER
 * avoid going to database (TripDao)
 * another example of seam: escaping singleton, static calls and object creation
 * 100% coverage except seams (dependecies)
 * builders (when we need to build rich object graph)
 * After: be36f04

## Refactoring begins

Starting from the deepest branch to the shortest (different than testing)

 * Before: be36f04
 * method does too much (feature envy)
 * Single Responsibility Principle!
 * Tip for Mac keyboard: Alt+Insert == fn + alt/option + return
 * ShouldInformWhenUsersAre(Not)Friends
 * Resharper: Ctrl+Alt+F -> file structure
 * Resharper: Shift+Alt+Space -> Import symbol completion
 * stay green all the time!
 * Pit stop: 2023d49
 * bring variables together (near usage)
 * guard clause to the top
 * get rid of variables (if you can) -> they make for complexity
 * code should be read top-down
 * always baby steps - bit by bit
 * After: 9413a24

## What if desing is wrong?

 * Before: 9413a24
 * it has dependecy on web framework
 * static call (and dependency on data source)
 * Pit stop: 51b12ef
 * test for retrieving trips from in memory db
 * removing static method
 * interface segregation
 * service locator pattern and mocking dependecies
 * get rid of Testable... (ugly) - protected virtual methods only for tests
 * compare before and after - it could take 20 minutes (after some practice ;)
 * After: d4848c8

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
 * [Clean Code: A Handbook of Agile Software Craftsmanship](http://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
 * [Original talk video (Java)](http://www.youtube.com/watch?v=_NnElPO5BU0)
