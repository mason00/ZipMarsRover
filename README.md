# ZipMarsRover

Demo how I understand and design the method to solve the problem. No dependencies injection yet, because I think it's not necessary to
touch the core of the problem that we want to solve. There's also plenty of projects' boilerplate with IoC.

IMO, the essence of the problem is abstracting concepts as below
1. Plateau - boundary size of Rover
2. Rover - core actor. Coordinate Mover and Runner to explore the assigned plateau
3. Rover location - position and facing
4. Mover - one of Rover's function. Use composition on Rover. Could be injected if we have other rules to move in future
5. Turner - another function of Rover. Just like Mover, think that the Rover has two equipment to move and turn
7. Input Reader - separate user input handler, focus on single responsibility to only parse user input string to application data

Added unit test to cover edge cases. No mock yet, because
1. The solution of the problem is not that complex that we need to have many different business logical path
2. No dependency on the external system, everything is running in memory

The point is that in a short time frame I'm trying to demo what's in my understanding is the most important part of solving this problem.
Doesn't mean I don't know how to use IoC, interface, mocking or some fancy design patterns. Actually, I see many Mars Rover in GitHub.
The code is extremely hard to read. Most people trying to use ICommand, IRover, command chain, factory, etc. Which in my opinion is
off topic.
