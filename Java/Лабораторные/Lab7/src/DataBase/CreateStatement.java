package DataBase;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

public class CreateStatement {
    public static Statement statement(Connection cn) throws SQLException {
        return cn.createStatement();
    }
}
