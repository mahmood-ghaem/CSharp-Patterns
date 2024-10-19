# CSharp-Patterns


1. Data Mapper Pattern
The Data Mapper pattern separates the in-memory objects from the database. It maps each field in a database record to a property in a domain object. This pattern is useful for complex mappings and helps keep the domain model clean.

2. Active Record Pattern
In the Active Record pattern, an object wraps a row in a database table or view, encapsulating the database access. This pattern is simpler to implement but can lead to a less clean separation between the domain logic and data access logic.

3. CQRS (Command Query Responsibility Segregation)
CQRS is a pattern that separates read and write operations into different models. This allows for optimized read and write operations and can be particularly useful in systems with high performance and scalability requirements.

4. Event Sourcing
Event Sourcing involves storing the state of a system as a sequence of events. Instead of storing the current state, you store a series of events that represent state changes. This pattern can be used in conjunction with CQRS and is useful for audit trails and complex business logic.

5. Factory Pattern
The Factory pattern is used to create objects without specifying the exact class of object that will be created. This pattern is useful for managing and encapsulating the creation process of complex objects.

6. Decorator Pattern
The Decorator pattern allows behavior to be added to individual objects, dynamically, without affecting the behavior of other objects from the same class. This pattern is useful for extending functionalities in a flexible and reusable way.
