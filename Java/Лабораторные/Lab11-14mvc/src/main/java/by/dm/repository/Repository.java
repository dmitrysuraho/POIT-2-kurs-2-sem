package by.dm.repository;

        import by.dm.exception.RepositoryException;
        import by.dm.repository.paramspecification.Parameter;
        import java.util.List;
        import java.util.Optional;

public interface Repository <T> {
       List<T> query(String sqlString, Parameter parameter) throws RepositoryException;
       Optional<T> queryForSingleResult(String sqlString, Parameter parameter) throws RepositoryException;
       List<T> findAll() throws RepositoryException;
       Integer save(T object) throws RepositoryException;
}
