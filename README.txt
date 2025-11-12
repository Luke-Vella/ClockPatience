Thank you for finding the time to review my submission for the Clock Patience technical test. I hope you enjoy scouring through my code as much as I enjoyed implementing the solution.

To start with, I researched a bit about clock patience and played a few games online (https://cardgames.io/clocksolitaire/) to really get a feel of the domain in which I would be working.

After I felt that I understood how it was played, I started trying to sketch how the architecture of the app could look like. The app itself is simple, but that doesn't mean it doesn't need to be scalable. 

I opted for a DDD approach, as it is universally adopted and works well for most busines scenarios where a technical solution should mimic a real world scenario, in this case being a card game. 

I wanted to make sure that if in the future we wanted to add more features, or even change the way the game is played, it would be easy to do so without having to refactor the entire codebase. This meant having a testing strategy in place, as well as a modular architecture.

The infrastructure layer is just there for demonstration purposes, as I didn't want to spend too much time on it. The focus of this exercise was the domain and application layers, which is where the business logic resides.

I also added a few unit tests to make sure that the core logic of the game is working as expected, and to give you an idea of how I approach testing in general.

Thanks for reading! If you have any queries about my implementation, be sure to reach me at luke.vella.0697@gmail.com, and I'd be happy to answer any questions you may have.

Clock Patience Layered Architecture Diagram: https://app.diagrams.net/#G1Oo4mtTV8gRppAqO22_MOV6mERipOClzG#%7B%22pageId%22%3A%222g4z5qk63yYmMoGZ1e9L%22%7D