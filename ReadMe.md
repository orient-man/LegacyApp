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
    git checkout aee8744

## Notes before 1st test

 * tip: split screen
 * `Install-Package nunit -ProjectName LegacyApp.Web.Tests`
 * snippets for test class / method
 * NCrunch

## First test for shortest branch

 * Ctrl-Shift-R / Ctrl-R Ctrl-M - Extract Method "GetLoggedInUser"
 * introducing a seam into the code (to avoid HttpContext)
 