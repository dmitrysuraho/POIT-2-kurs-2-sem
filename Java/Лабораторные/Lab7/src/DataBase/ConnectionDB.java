package DataBase;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ResourceBundle;

public class ConnectionDB {
    public static Connection getConnection() throws SQLException {
        ResourceBundle resource = ResourceBundle.getBundle("db");
        String url = resource.getString("db.url");
        String user = resource.getString("db.user");
        String pass = resource.getString("db.pass");

        return DriverManager.getConnection(url, user, pass);
    }
    public static void closeConnection(Connection cn, Statement st) throws SQLException {
        st.close();
        cn.close();
    }
}
