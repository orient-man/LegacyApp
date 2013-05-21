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
