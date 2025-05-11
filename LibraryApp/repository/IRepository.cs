using LibraryApp.domain;

namespace LibraryApp.repository;

public interface IRepository<ID, E> where E : Entity<ID>
{
    void Add(E entity);
    void Remove(ID id);
    void Update(E entity);
    E GetById(ID id);
    List<E> GetAll();
    
}