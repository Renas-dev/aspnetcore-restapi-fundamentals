## Project structure & responsibilities

### Controllers
- Must not know how data is stored  
- Handle HTTP in/out only (routes, status codes, request/response)  
- No data storage or business logic  
- Delegate work to services  

### Models
- Domain objects, such as `Product`  
- DTOs (Data Transfer Objects) define what the API accepts and returns  
- DTOs prevent accidental exposure of internal fields and restrict incoming data  

### Repositories
- Must not contain business decisions  
- Responsible for data access only  
- Stage 1: in-memory storage  
- Stage 3: real database  

### Services
- Decide system behavior  
- Contain business rules and use-cases  
- Controllers call Services  
- Services call Repositories  