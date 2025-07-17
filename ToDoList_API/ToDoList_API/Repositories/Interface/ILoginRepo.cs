using ToDoList_API.DTOs;

namespace ToDoList_API.Repositories.Interface
{
    public interface ILoginRepo
    {
        LoginJWT ValidateUser(LoginAuth dto);
    }
}
