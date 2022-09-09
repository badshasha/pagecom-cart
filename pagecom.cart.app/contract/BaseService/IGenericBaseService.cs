namespace pagecom.cart.app.contract.BaseService;

public interface IGenericBaseService<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> Get(int id);
    Task<T> Update(T objectInformation);
    Task<T> Create(T objectInformation);
    Task Delete(T objectInformation); 
}