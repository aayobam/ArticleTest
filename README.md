# ArticleTest
# Bonus Challenge: Resilience, Scalability, and Performance

# Resilience Against Abuse/Exploitation:
- Use IP rate limiting to prevent abuse on the api.
- Implement user authentication to allow only logged-in users to like articles.
- Keep track of which users have liked an article to prevent multiple likes from the same user.

# Scalability to Millions of Users:
- since article Id(primary key) are already indexed, we do not need indexing on this feature.
- Use a distributed cache (e.g., Redis or memory cache) to store the like count and reduce database load.
- Use a message queue (e.g., RabbitMQ) to handle like requests asynchronously.
- use cqrs pattern to seperate read(get and get all) and write(create, update and delete) operations and also duplicate databases seperately for read and write.
- Deploy the API using a load balancer and multiply app instances to handle high traffic.

# Handling Million Concurrent Users Clicking the Button:
- Implement optimistic concurrency control to handle simultaneous updates.
- Use caching strategies to manage high-frequency read/write operations.
# Handling Million Concurrent Users Requesting Like Count:
- Use caching to store the like count and serve it quickly.
- Update the cache periodically or invalidate it upon changes.
