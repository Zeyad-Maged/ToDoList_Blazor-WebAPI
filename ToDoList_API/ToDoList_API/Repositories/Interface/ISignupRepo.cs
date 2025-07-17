using ToDoList_API.DTOs;

namespace ToDoList_API.Repositories.Interface
{
    public interface ISignupRepo
    {
        bool RegisterUser(SignUpAuth dto);
    }
}
