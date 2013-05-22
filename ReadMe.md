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
 * allows to understand better the code

## Demo - HOWTO obtain the code

    git clone https://github.com/orient-man/LegacyApp.git
    cd LegacyApp
    git checkout 6c63c87

## Notes before 1st test

 * tip: split screen
 * `Install-Package nunit -ProjectName LegacyApp.Web.Tests`
 * snippets for test class / method
 * NCrunch

## First test for shortest branch

 * ShouldThrowAnExceptionWhenNotLoggedIn
 * Ctrl-Shift-R / Ctrl-R Ctrl-M - Extract Method "GetLoggedInUser"
 * introducing a seam into the code (to avoid HttpContext)
 * code coverage shows if test covers the branch I wanted
 * refactoring test

## Next: "ShouldNotReturnAnyTripsWhenUsersAreNotFriends"

 * Before: a77bee4
 * After: 0f45a17

## Next: "ShouldReturnFriendTripsWhenUsersAreFriends"

 * PLEASE DONT COPY-AND-PASTE NEVER EVER
 * avoid going to database (TripDao)
 * another example of seam: escaping singleton, static calls and object creation
 * 100% coverage except seams (dependecies)
 * builders (when we need to build rich object graph)

## Refactoring begins

 * Starting from the deepest branch to the shortest (different than testing)
 * method does too much (feature envy)
 * Single Responsibility Principle!
 * Tip for Mac keyboard: Alt+Insert == fn + alt/option + return
 * ShouldInformWhenUsersAre(Not)Friends
 * Resharper: Ctrl+Alt+F -> file structure
 * Resharper: Shift+Alt+Space -> Import symbol completion
 * stay green all the time!
 * bring variables together (near usage)
 * guard clause to the top
 * get rid of variables (if you can) -> they make for complexity
 * code should be read top-down
 * always baby steps - bit by bit

## What if desing is wrong?

 * it has dependecy on web framework
 * static call (and dependency on data source)
 * test for retrieving trips from in memory db
 * removing static method

