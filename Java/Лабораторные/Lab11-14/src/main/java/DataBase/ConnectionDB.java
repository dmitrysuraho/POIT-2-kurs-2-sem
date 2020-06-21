package DataBase;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ResourceBundle;

public class ConnectionDB {
    public static Connection getConnection() throws SQLException {
        String url = "jdbc:mysql://localhost:3306/java?allowPublicKeyRetrieval=true&useSSL=false&verifyServerCertificate=false&useSSL=false&requireSSL=false&useLegacyDatetimeCode=false&amp&serverTimezone=UTC";
        String user = "root";
        String pass = "12345";

        return DriverManager.getConnection(url, user, pass);
    }

    public static Statement statement(Connection cn) throws SQLException {
        return cn.createStatement();
    }

    public static void closeConnection(Connection cn, Statement st) throws SQLException {
        st.close();
        cn.close();
    }
}
