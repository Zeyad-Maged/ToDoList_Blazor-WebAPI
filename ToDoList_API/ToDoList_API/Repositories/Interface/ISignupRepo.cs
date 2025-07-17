using ToDoList_API.DTOs;

namespace ToDoList_API.Repositories.Interface
{
    public interface ISignupRepo
    {
        public bool AddUser(SignUpAuth dto);
    }
}
