package DataBase;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class PreStatement {
    public static PreparedStatement getPreparedStatement(Connection cn) throws SQLException {
        return cn.prepareStatement("DELETE FROM books WHERE date > ?");
    }
}
