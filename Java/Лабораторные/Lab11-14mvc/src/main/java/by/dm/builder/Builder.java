package by.dm.builder;

import by.dm.exception.RepositoryException;
import java.sql.ResultSet;

public interface Builder <T> {
    T build(ResultSet resultSet) throws RepositoryException;
}
